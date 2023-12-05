using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using src.Web.Api.Core.Dto;
using src.Web.Api.Core.Interface.Repository;
using src.Web.Api.Infrastructure.EntityFramework;
using src.Web.Api.Infrastructure.EntityFramework.Entity;

namespace src.Repository
{
    public class RebelRepository : IRebelRepository
    {
        
        private readonly ResistenceDbContext _modelContext;

        public RebelRepository(ResistenceDbContext modelContext)
        {
            _modelContext = modelContext;
        }
        public bool InsertRebel(Rebel rebel){
            _modelContext.Add(rebel);
            return _modelContext.SaveChanges() > 0;
        }

        public Rebel SelectRebel(long id){
            return _modelContext.Rebels.Find(id);
        }

        public List<RebelCountDto> SelectCountRebel(){
            return _modelContext.Rebels.GroupBy(x => x.Traitor).Select(r => new RebelCountDto(){ Traitor = r.Key, Count = r.Count() }).ToList();
        }

        public Rebel SelectRebelLocation(long id){
            return _modelContext.Rebels.Include(x => x.Location).FirstOrDefault(x => x.IdRebel == id);
        }

        public Rebel SelectRebelInventory(long id){
            return _modelContext.Rebels.Include(x => x.Inventories).FirstOrDefault(x => x.IdRebel == id);
        }

        public bool ReportRebelTraitor(Rebel rebel){
            _modelContext.Rebels.Attach(rebel);
            return _modelContext.SaveChanges() > 0;
        }

        public bool UpdateRebelLocation(Rebel rebel, Location location){
            _modelContext.Rebels.Attach(rebel);
            
            rebel.Location.GalaxyName = location.GalaxyName;
            rebel.Location.Latitude = location.Latitude;
            rebel.Location.Longitude = location.Longitude;

            _modelContext.Entry(rebel).Reference(x => x.Location).IsModified = true;

            return _modelContext.SaveChanges() > 0;
        }
    }
}