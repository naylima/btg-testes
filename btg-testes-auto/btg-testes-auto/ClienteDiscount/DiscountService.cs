namespace btg_testes_auto.Discount
{
    public class DiscountService
    {
        private readonly ICustomerService _customerService;

        public DiscountService(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public double GetDiscount(int customerId, double purchaseAmount)
        {
            var customerType = _customerService.GetCustomerType(customerId);

            switch (customerType)
            {
                case CustomerType.Regular:
                    return purchaseAmount * 0.05; // Desconto de 5% para clientes regulares
                case CustomerType.Premium:
                    return purchaseAmount * 0.1; // Desconto de 10% para clientes premium
                default:
                    return 0; // Sem desconto para outros tipos de cliente
            }
        }
    }
}
