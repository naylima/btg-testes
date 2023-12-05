using System.Collections.Generic;
using System.Linq;
using src.Web.Api.Core.Interface.Repository;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Infrastructure.EntityFramework;
using src.Web.Api.Infrastructure.EntityFramework.Entity;
using src.Web.Api.Model;
using static src.Web.Api.Model.TradeResourcesRequest;

namespace src.Web.Api.Core.UseCase
{
    public class TradeResoursesUseCase : ITradeResourcesUseCase
    {
        private readonly IRebelRepository _rebelRepository;
        private readonly IInventoryRepository _inventoryRepository;
        public TradeResoursesUseCase(IRebelRepository rebelRepository, IInventoryRepository inventoryRepository){
            _rebelRepository = rebelRepository;
            _inventoryRepository = inventoryRepository;
        }

        public bool TradeResources(TradeResourcesRequest request, out string message){
            
            if (!CheckQuantityResources(request))
            {
                message = "Quantity of resources is invalid";
                return false;
            }

            Rebel rebelOne = FindRebel(request.FirstRebel.IdRebel, out message);

            if (message != "Ok")
            {
                return false;
            }

            Rebel rebelTwo =  FindRebel(request.SecondRebel.IdRebel, out message);

            if (message != "Ok")
            {
                return false;
            }

            if (!CheckValidResources(rebelOne, request.FirstRebel.Inventories, out message))
            {
                return false;
            }

            if (!CheckValidResources(rebelTwo, request.SecondRebel.Inventories, out message))
            {
                return false;
            }

            ChangeResources(rebelOne, rebelTwo, request.FirstRebel.Inventories);
            ChangeResources(rebelTwo, rebelOne, request.SecondRebel.Inventories);

            return true;
        }

        // Aplicar testes
        public Rebel FindRebel(long id, out string message){
            message = "Ok";

            Rebel rebel = _rebelRepository.SelectRebelInventory(id);

            if (rebel == null)
            {
                message = $"Rebel {id} not found";
                return null;
            }

            if (rebel.Traitor)
            {
                message = $"Rebel {id} is a TRAITOR! Negociation forbidden";
                return null;
            }
            
            return rebel;
        }

        public bool CheckQuantityResources(TradeResourcesRequest request){
            long totalOne = GetQuantityResources(request.FirstRebel);
            long totalTwo = GetQuantityResources(request.SecondRebel);

            if (totalOne == totalTwo)
            {
                return true;
            }

            return false;
        }

        public long GetQuantityResources(RebelAndResouces request){
            long total = 0;
            foreach(var inventory in request.Inventories){
                total += ResourceTypeMethod.GetTotalPoints(inventory.Resource, inventory.Quantity);
            }

            return total;
        }       
        
        // Aplicar testes
        public bool CheckValidResources(Rebel rebel, List<InventoryRequest> inventoryForTrade, out string message){
            message = "";
            foreach(var inventory in inventoryForTrade)
            {
                var item = rebel.Inventories.FirstOrDefault(x => x.Resource == inventory.Resource);
                if (item == null)
                {
                    message = $"Item {inventory.Resource} not available for trade with rebel {rebel.IdRebel}";
                    return false;
                }
                if (item.Quantity < inventory.Quantity)
                {
                    message = $"Insufficient quantity for item {inventory.Resource} with rebel {rebel.IdRebel}";
                    return false;
                }
            }

            return true;
        }
        
        /*
            * Troca recursos entre rebeldes
            * RebelOut é o rebel que está dando o item
            * RebelIn é o rebel que irá receber o item
            * Inventories são os itens que serão trocados
            */
        public bool ChangeResources(Rebel rebelOut, Rebel rebelIn, List<InventoryRequest> inventories)
        {
            // Para cada item no inventario
            foreach (var inventory in inventories)
            {
                // Pesquisa o item no inventorio do rebelde
                var item = rebelOut.Inventories.FirstOrDefault(x => x.Resource == inventory.Resource);
                var quantity = item.Quantity - inventory.Quantity;

                //Caso o item tenha acabado o estoque, remova-o
                //Caso ainda tenha, diminua a quantidade
                bool removedItem;
                if (quantity == 0)
                {
                    removedItem = _inventoryRepository.RemoveResource(item);
                }
                else
                {
                    removedItem = _inventoryRepository.UpdateQuantity(item, quantity);
                }

                if (!removedItem)
                {
                    return false;
                }

                //Pesquise o item no inventorio do rebelde que receberá o item
                //Caso não encontre, adicione
                //Caso encontre, aumente a quantidade
                bool addItem;
                var itemExist = _inventoryRepository.FindInventory(rebelIn.IdRebel, item.Resource);
                if (itemExist == null)
                {
                    addItem = _inventoryRepository.AddInventory(new Inventory()
                    {
                        IdRebel = rebelIn.IdRebel,
                        Quantity = inventory.Quantity,
                        Resource = inventory.Resource
                    });
                }
                else
                {
                    addItem = _inventoryRepository.UpdateQuantity(itemExist, itemExist.Quantity + inventory.Quantity);
                }

                if (!addItem)
                {
                    return false;
                }
            }
            return true;
        }

    }
}