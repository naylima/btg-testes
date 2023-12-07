namespace btg_testes_auto.Order
{
    public interface IInventoryService
    {
        int GetStockQuantity(string productId);
        bool UpdateStock(string productId, int quantity);
    }
}
