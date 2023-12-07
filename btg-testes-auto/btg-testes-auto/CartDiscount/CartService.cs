namespace btg_testes_auto.CartDiscount
{
    public class CartService
    {
        private readonly IDiscountService _discountService;

        public CartService(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public double CalculateTotalWithDiscount(List<CartItem> items)
        {
            var totalAmount = items.Sum(item => item.Price);

            var discount = _discountService.CalculateDiscount(items);

            return totalAmount - discount;
        }
    }
}
