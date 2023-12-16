using btg_testes_auto.Discount;
using FluentAssertions;
using NSubstitute;

namespace btg_test.DiscountTest;

public class DiscountServiceTest
{
    private readonly ICustomerService _mockCustomerService;
    private DiscountService _sut;

    public DiscountServiceTest()
    {
        _mockCustomerService = Substitute.For<ICustomerService>();
        _sut = new DiscountService(_mockCustomerService);
    }

    [Fact]
    public void GetDiscount_RegularCustomer_Returns5PercentDiscount()
    {
        // Arrange
        const int customerId = 1;
        const double purchaseAmount = 100;

        _mockCustomerService.GetCustomerType(customerId).Returns(CustomerType.Regular);

        // Act
        var result = _sut.GetDiscount(customerId, purchaseAmount);

        // Assert
        result.Should().Be(5);
        _mockCustomerService.Received(1).GetCustomerType(customerId);
    }

    [Fact]
    public void GetDiscount_PremiumCustomer_Returns10PercentDiscount()
    {
        // Arrange
        const int customerId = 2;
        const double purchaseAmount = 200;

        _mockCustomerService.GetCustomerType(customerId).Returns(CustomerType.Premium);

        // Act
        var result = _sut.GetDiscount(customerId, purchaseAmount);

        // Assert
        result.Should().Be(20);
        _mockCustomerService.Received(1).GetCustomerType(customerId);
    }
}
