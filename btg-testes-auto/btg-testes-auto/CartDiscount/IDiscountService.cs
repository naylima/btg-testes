namespace btg_testes_auto.CartDiscount
{
    public interface IDiscountService
    {
        double CalculateDiscount(List<CartItem> items);
    }
}
