namespace btg_testes_auto.Order
{
    public class OrderService
    {
        private readonly IInventoryService _inventoryService;

        public OrderService(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        public bool ProcessOrder(PurchaseOrder order)
        {
            var stockQuantity = _inventoryService.GetStockQuantity(order.ProductId);

            if (stockQuantity >= order.Quantity)
            {
                return _inventoryService.UpdateStock(order.ProductId, -order.Quantity);
            }

            return false;
        }
    }
}
