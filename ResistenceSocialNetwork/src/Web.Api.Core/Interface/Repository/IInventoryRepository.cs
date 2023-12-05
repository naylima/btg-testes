using System.Collections.Generic;
using src.Web.Api.Core.Dto;
using src.Web.Api.Infrastructure.EntityFramework.Entity;

namespace src.Web.Api.Core.Interface.UseCase
{
    public interface IInventoryRepository
    {
        Inventory FindInventory(long idRebel, string resource);
        bool AddInventory(Inventory inventory);
        bool RemoveResource(Inventory inventory);
        bool UpdateQuantity(Inventory inventory, long quantity);
        List<Inventory> FindTraitorInventory();
        List<ResourceAverageDto> AverageInventory(long qtdRebels);
    }
}