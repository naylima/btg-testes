using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using src.Web.Api.Core.Dto;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Infrastructure.EntityFramework;
using src.Web.Api.Infrastructure.EntityFramework.Entity;

namespace src.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        
        private readonly ResistenceDbContext _modelContext;

        public InventoryRepository(ResistenceDbContext modelContext)
        {
            _modelContext = modelContext;
        }

        public Inventory FindInventory(long idRebel, string resource){
            return _modelContext.Inventories.FirstOrDefault(x => x.Resource == resource && x.IdRebel == idRebel);
        }

        public bool AddInventory(Inventory inventory){
            _modelContext.Add(inventory);
            return _modelContext.SaveChanges() > 0;
        }

        public bool UpdateQuantity(Inventory inventory, long quantity){

            _modelContext.Inventories.Attach(inventory);
            inventory.Quantity = quantity;
            
            return _modelContext.SaveChanges() > 0;
        }

        public bool RemoveResource(Inventory inventory){

            _modelContext.Inventories.Attach(inventory);
            _modelContext.Remove(inventory);

            return _modelContext.SaveChanges() > 0;
        }

        public List<Inventory> FindTraitorInventory(){
            return _modelContext.Inventories.Include(x => x.Rebel).Where(x => x.Rebel.Traitor).ToList();
        }

        public List<ResourceAverageDto> AverageInventory(long qtdRebels){
            return _modelContext.Inventories.GroupBy(x => x.Resource)
                                .Select(r => new ResourceAverageDto() { Resource = r.Key, Average = r.Sum(x => x.Quantity) / qtdRebels }).ToList();
        }
        
    }
}