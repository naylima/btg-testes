using btg_testes_auto.ShippingCost;
using FluentAssertions;
using NSubstitute;

namespace btg_test.ShippingCostTest;

public class ShippingServiceTest
{
    private readonly IDeliveryCostCalculator _mockDeliveryCostCalculator;
    private ShippingService _sut;

    public ShippingServiceTest()
    {
        _mockDeliveryCostCalculator = Substitute.For<IDeliveryCostCalculator>();
        _sut = new ShippingService(_mockDeliveryCostCalculator);
    }

    [Fact]
    public void CalculateShippingCost_ExpressWithin200Km_ShouldNotApplyDiscount()
    {
        // Arrange
        const double distance = 150;
        const DeliveryType deliveryType = DeliveryType.Express;

        _mockDeliveryCostCalculator.CalculateCost(distance, deliveryType).Returns(30);

        // Act
        var result = _sut.CalculateShippingCost(distance, deliveryType);

        // Assert
        result.Should().Be(30);
        _mockDeliveryCostCalculator.Received(1).CalculateCost(distance, deliveryType);
    }

    [Fact]
    public void CalculateShippingCost_ExpressAbove200Km_ShouldApply50PercentDiscount()
    {
        // Arrange
        const double distance = 250;
        const DeliveryType deliveryType = DeliveryType.Express;

        _mockDeliveryCostCalculator.CalculateCost(distance, deliveryType).Returns(40);

        // Act
        var result = _sut.CalculateShippingCost(distance, deliveryType);

        // Assert
        result.Should().Be(20);
        _mockDeliveryCostCalculator.Received(1).CalculateCost(distance, deliveryType);
    }

    [Fact]
    public void CalculateShippingCost_OrdinaryWithin200Km_ShouldNotApplyDiscount()
    {
        // Arrange
        const double distance = 150;
        const DeliveryType deliveryType = DeliveryType.Ordinary;

        _mockDeliveryCostCalculator.CalculateCost(distance, deliveryType).Returns(20);

        // Act
        var result = _sut.CalculateShippingCost(distance, deliveryType);

        // Assert
        result.Should().Be(20);
        _mockDeliveryCostCalculator.Received(1).CalculateCost(distance, deliveryType);
    }

    [Fact]
    public void CalculateShippingCost_OrdinaryAbove200Km_ShouldNotApplyDiscount()
    {
        // Arrange
        const double distance = 250;
        const DeliveryType deliveryType = DeliveryType.Ordinary;

        _mockDeliveryCostCalculator.CalculateCost(distance, deliveryType).Returns(35);

        // Act
        var result = _sut.CalculateShippingCost(distance, deliveryType);

        // Assert
        result.Should().Be(35);
        _mockDeliveryCostCalculator.Received(1).CalculateCost(distance, deliveryType);
    }

    [Fact]
    public void CalculateShippingCost_DistanceZero_ShouldReturnZeroCost()
    {
        // Arrange
        const double distance = 0;
        const DeliveryType deliveryType = DeliveryType.Express;

        // Act
        var result = _sut.CalculateShippingCost(distance, deliveryType);

        // Assert
        result.Should().Be(0);
        _mockDeliveryCostCalculator.Received(1).CalculateCost(distance, deliveryType);
    }
}
