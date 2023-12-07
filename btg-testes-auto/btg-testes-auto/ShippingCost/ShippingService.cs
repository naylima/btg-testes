namespace btg_testes_auto.ShippingCost
{
    public class ShippingService
    {
        private readonly IDeliveryCostCalculator _deliveryCostCalculator;

        public ShippingService(IDeliveryCostCalculator deliveryCostCalculator)
        {
            _deliveryCostCalculator = deliveryCostCalculator;
        }

        public double CalculateShippingCost(double distance, DeliveryType deliveryType)
        {
            var cost = _deliveryCostCalculator.CalculateCost(distance, deliveryType);

            if (distance > 200 && deliveryType == DeliveryType.Express)
            {
                // Aplicar desconto de 50% para entregas expressas acima de 200 km
                cost *= 0.5;
            }

            return cost;
        }
    }
}
