using FluentAssertions;
using NSubstitute;
using src.Web.Api.Core.Interface.Repository;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Core.UseCase;
using src.Web.Api.Infrastructure.EntityFramework.Entity;
using src.Web.Api.Model;

namespace ResistenceSocialNetworkTest
{
    public class UnitTest1
    {
        private readonly IRebelRepository _mockRebelRepository;
        private readonly IInventoryRepository _mockInventoryRepository;
        private TradeResoursesUseCase _sut;

        public UnitTest1()
        {
            _mockRebelRepository = Substitute.For<IRebelRepository>();
            _mockInventoryRepository = Substitute.For<IInventoryRepository>();
            _sut = new(_mockRebelRepository, _mockInventoryRepository);
        }

        [Fact]
        public void ChangeResources_ItemExists_TradeUpdatedSucess()
        {
            // Arrange
            Rebel rebelOut = new()
            {
                IdRebel = 1,
                Name = "Rebel 1",
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
                Name = "Rebel 2",
                Inventories = new()
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

            _mockInventoryRepository.UpdateQuantity(Arg.Any<Inventory>(), 2)
                .Returns(true);

            _mockInventoryRepository.FindInventory(2, "Faca")
                .Returns(new Inventory()
                {
                    Quantity = 1,
                    Resource = "Faca"
                });

            //Act
            bool response = _sut.ChangeResources(rebelOut, rebelIn, inventories);

            //Assert
            response.Should().BeTrue();
            _mockInventoryRepository.Received(2).UpdateQuantity(Arg.Any<Inventory>(), 2);
            _mockInventoryRepository.Received().FindInventory(Arg.Any<long>(), Arg.Any<string>());
            _mockInventoryRepository.DidNotReceive().AddInventory(Arg.Any<Inventory>());
            _mockInventoryRepository.DidNotReceive().RemoveResource(Arg.Any<Inventory>());
        }
    }
}