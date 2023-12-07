using btg_testes_auto.Order;
using FluentAssertions;
using NSubstitute;

namespace btg_test.OrderTest
{
    public class OrderServiceTest
    {
        private readonly IInventoryService _mockInventoryService;
        private OrderService _service; // _sut system under test

        public OrderServiceTest()
        {
            _mockInventoryService = Substitute.For<IInventoryService>();
            _service = new(_mockInventoryService);
        }

        [Fact]
        public void ProcessOrder_QuantityLowerThanStockUpdateSucess_ReturnTrue()
        {
            // Arrange
            PurchaseOrder purchaseOrder = new()
            {
                ProductId = "1",
                Quantity = 3
            };

            _mockInventoryService.GetStockQuantity("2")
                .Returns(5);

            _mockInventoryService.UpdateStock("1", -3)
                .Returns(true);

            // Act
            bool result = _service.ProcessOrder(purchaseOrder);

            // Assert
            result.Should().BeTrue();
            _mockInventoryService.Received().GetStockQuantity("1");
            _mockInventoryService.Received(1).UpdateStock("1", -3);
        }

        [Fact]
        public void ProcessOrder_QuantityLowerThanStockUpdateFail_ReturnFalse()
        {
            // Arrange
            PurchaseOrder purchaseOrder = new()
            {
                ProductId = "1",
                Quantity = 4
            };

            //_mockInventoryService.GetStockQuantity("1")
            _mockInventoryService.GetStockQuantity(Arg.Any<string>())
                .Returns(5);

            _mockInventoryService.UpdateStock(Arg.Any<string>(), Arg.Any<int>())
                .Returns(false);

            // Act
            bool result = _service.ProcessOrder(purchaseOrder);

            // Assert
            result.Should().BeFalse();
            _mockInventoryService.Received(1).GetStockQuantity(Arg.Any<string>());
            _mockInventoryService.Received(1).UpdateStock(Arg.Any<string>(), Arg.Any<int>());
        }

        [Fact]
        public void ProcessOrder_QuantityBiggerThanStock_ReturnFalse()
        {
            // Arrange
            PurchaseOrder purchaseOrder = new()
            {
                ProductId = "1",
                Quantity = 5
            };

            _mockInventoryService.GetStockQuantity(Arg.Any<string>())
                .Returns(3);

            // Act
            bool result = _service.ProcessOrder(purchaseOrder);

            // Assert
            result.Should().BeFalse();
            _mockInventoryService.Received().GetStockQuantity(Arg.Any<string>());
            _mockInventoryService.DidNotReceive().UpdateStock(Arg.Any<string>(), Arg.Any<int>());
        }
    }
}
