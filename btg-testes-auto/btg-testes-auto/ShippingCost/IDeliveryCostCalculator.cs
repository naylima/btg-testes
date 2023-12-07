namespace btg_testes_auto.ShippingCost
{
    public interface IDeliveryCostCalculator
    {
        double CalculateCost(double distance, DeliveryType deliveryType);
    }
}
