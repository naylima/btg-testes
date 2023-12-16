using System;
using btg_testes_auto.CartDiscount;
using FluentAssertions;
using NSubstitute;
using Xunit.Abstractions;

namespace btg_test.CartDiscountTest;

public class CartServiceTest
{
	private readonly IDiscountService _mockDiscountService;
	private CartService _sut;

	public CartServiceTest()
	{
		_mockDiscountService = Substitute.For<IDiscountService>();
		_sut = new(_mockDiscountService);
	}

	[Fact]
	public void CalculateTotalWithDiscount_ListOfCartItems_ReturnTotalWithDiscount()
	{
		// Arrange
		var items = new List<CartItem>
		{
			new CartItem { ProductId = "12345", Price = 10 },
            new CartItem { ProductId = "67890", Price = 20 },
        };

		_mockDiscountService.CalculateDiscount(items).Returns(5);

		// Act
		var result = _sut.CalculateTotalWithDiscount(items);

		// Assert
		result.Should().Be(25);
		_mockDiscountService.Received(1).CalculateDiscount(items);
	}
}

