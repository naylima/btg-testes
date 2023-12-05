using System.Collections.Generic;
using System.Linq;
using src.Web.Api.Core.Dto;
using src.Web.Api.Core.Interface.Repository;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Infrastructure.EntityFramework;

namespace src.Web.Api.Core.UseCase
{
    public class ReportUseCase : IReportUseCase
    {
        private readonly IRebelRepository _rebelRepository;
        private readonly IInventoryRepository _inventoryRepository;
        public ReportUseCase(IRebelRepository rebelRepository, IInventoryRepository inventoryRepository){
            _rebelRepository = rebelRepository;
            _inventoryRepository = inventoryRepository;
        }

        // Aplicar testes
        public string TraitorsPercentage()
        {
            var registers = _rebelRepository.SelectCountRebel();
            var traitors = registers.FirstOrDefault(x => x.Traitor);
            var total = registers.Sum(x => x.Count);

            return $"Percentage of traitors is {traitors.Count * 100 / total}%";
        }

        // Aplicar testes
        public string RebelsPercentage()
        {
            var registers = _rebelRepository.SelectCountRebel();
            var rebels = registers.FirstOrDefault(x => !x.Traitor);
            var total = registers.Sum(x => x.Count);

            return $"Percentage of rebels is {rebels.Count * 100 / total}%";
        }

        // Aplicar testes
        public string LostPoints()
        {
            decimal totalPoints = 0;
            var registers = _inventoryRepository.FindTraitorInventory();
            foreach(var register in registers){
                totalPoints += ResourceTypeMethod.GetTotalPoints(register.Resource, register.Quantity);
            }
            
            return $"Total lost points is {totalPoints}";
        }

        // Aplicar testes
        public List<ResourceAverageDto> Average()
        {
            RebelCountDto rebels = _rebelRepository.SelectCountRebel().FirstOrDefault(x => !x.Traitor);            
            return _inventoryRepository.AverageInventory(rebels.Count);
        }
    }
}