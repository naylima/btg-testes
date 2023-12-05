using FluentAssertions;
using NSubstitute;
using src.Web.Api.Core.Interface.Repository;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Core.UseCase;
using src.Web.Api.Infrastructure.EntityFramework.Entity;
using src.Web.Api.Model;

namespace ResistenceSocialNetworkTest.TradeResoursesUseCaseTest
{
    public class ChangeResourcesTest
    {
        private readonly IRebelRepository _mockRebelRepository;
        private readonly IInventoryRepository _mockInventoryRepository;
        private TradeResoursesUseCase _sut;

        public ChangeResourcesTest()
        {
            _mockRebelRepository = Substitute.For<IRebelRepository>(); // = new(); no mock
            _mockInventoryRepository = Substitute.For<IInventoryRepository>(); // = new() no mock;

            _sut = new(_mockRebelRepository, _mockInventoryRepository);
        }

        [Fact]
        public void ChangeResources_ItemUpdatedAndItemExists_ReturnsTradeSuccess()
        {
            // ChangeResourcesTest();
            // Arrange
            
            Rebel rebelOut = new()
            {
                IdRebel = 1, //dummy
                Inventories = new()
                {
                    new()
                    {
                        IdRebel = 1,
                        IdInventory = 1,
                        Resource = "Faca",
                        Quantity = 3
                    }
                }
            };

            Rebel rebelIn = new()
            {
                IdRebel = 2,
                Inventories = new() // nao confundir com o retorno do mock FindInventory
                {
                    new()
                    {
                        IdRebel = 2,
                        IdInventory = 2,
                        Resource = "Faca",
                        Quantity = 1
                    }
                }
            };

            List<InventoryRequest> inventories = new()
            {
                new()
                {
                    Resource = "Faca",
                    Quantity = 1
                }
            };

            _mockInventoryRepository.UpdateQuantity(Arg.Any<Inventory>(), Arg.Any<long>())
                .Returns(true);

            _mockInventoryRepository.FindInventory(2, "Faca")
                .Returns(new Inventory()
                {
                    IdInventory = 3,
                    Resource = "Faca",
                    Quantity = 3
                });
            /*
            _mockInventoryRepository.UpdateQuantity(Arg.Any<Inventory>(), 2)
                .Returns(true);

            _mockInventoryRepository.UpdateQuantity(Arg.Any<Inventory>(), 4)
                .Returns(true);
            */

            // Act
            bool response = _sut.ChangeResources(rebelOut, rebelIn, inventories);

            // Assert
            response.Should().BeTrue();

            _mockInventoryRepository.DidNotReceive().RemoveResource(Arg.Any<Inventory>());
            //_mockInventoryRepository.Received(0).RemoveResource(Arg.Any<Inventory>());
            //_mockInventoryRepository.Received(2).UpdateQuantity(Arg.Any<Inventory>(), Arg.Any<long>());
            _mockInventoryRepository.Received().UpdateQuantity(Arg.Any<Inventory>(), 2);
            _mockInventoryRepository.Received().UpdateQuantity(Arg.Any<Inventory>(), 4);
            _mockInventoryRepository.DidNotReceive().AddInventory(Arg.Any<Inventory>());
            _mockInventoryRepository.Received().FindInventory(Arg.Any<long>(), Arg.Any<string>());

        }
    }
}
