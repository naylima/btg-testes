using System.Linq;
using src.Web.Api.Core.Interface.Repository;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Infrastructure.EntityFramework.Entity;
using src.Web.Api.Model;

namespace src.Web.Api.Core.UseCase
{
    public class RebelUseCase : IRebelUseCase
    {
        private readonly IRebelRepository _rebelRepository;
        public RebelUseCase(IRebelRepository rebelRepository){
            _rebelRepository = rebelRepository;
        }

        public bool InsertRebel(RebelRequest request){
            var rebel = new Rebel(){
                Name = request.Name,
                Age = request.Age,
                Location = new Location(){
                    Latitude = request.Location.Latitude,
                    Longitude = request.Location.Longitude,
                    GalaxyName = request.Location.GalaxyName
                },
                Inventories = request.Inventories.Select(inv => new Inventory(){
                    Resource = inv.Resource,
                    Quantity = inv.Quantity
                }).ToList()
            };
            
            return _rebelRepository.InsertRebel(rebel);
        }

        public bool ReportRebelTraitor(long id, out string message){
            message = "";
            Rebel rebelTraitor = _rebelRepository.SelectRebel(id);

            if (rebelTraitor.Traitor){
                message = "Already a traitor";
                return false;
            }

            rebelTraitor.ReportTraitor++;
            if (rebelTraitor.ReportTraitor == 3)
            {
                rebelTraitor.Traitor = true;
            }
             
            return _rebelRepository.ReportRebelTraitor(rebelTraitor);
        }

        public bool UpdateLocation(long id, LocationRequest location){
            Rebel rebel = _rebelRepository.SelectRebelLocation(id);

            if (rebel == null)
                return false;
            
            var newLocaltion = new Location(){
                GalaxyName = location.GalaxyName,
                Latitude = location.Latitude,
                Longitude = location.Longitude
            };
                         
            return _rebelRepository.UpdateRebelLocation(rebel, newLocaltion);
        }

    }
}