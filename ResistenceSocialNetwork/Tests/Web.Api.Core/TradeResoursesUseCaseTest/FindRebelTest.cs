using System.Collections.Generic;
using Moq;
using src.Web.Api.Core.Interface.Repository;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Core.UseCase;
using src.Web.Api.Infrastructure.EntityFramework.Entity;
using Xunit;

namespace Tests.Web.Api.Core.TradeResoursesUseCaseTest
{
    public class FindRebelTest
    {
        private TradeResoursesUseCase _tradeResoursesUseCase { get; set; }
        private Mock<IRebelRepository> _rebelRepository;
        private Mock<IInventoryRepository> _inventoryRepository;

        private void Initialize()
        {
            _rebelRepository = new Mock<IRebelRepository>();
            _inventoryRepository = new Mock<IInventoryRepository>();

            _rebelRepository.Setup(x => x.SelectRebelInventory(It.IsAny<long>()))
                .Returns(new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Comida",
                            Quantity = 10
                        }
                    }
                });

            _tradeResoursesUseCase = new TradeResoursesUseCase(_rebelRepository.Object, _inventoryRepository.Object);
        }

        [Fact]
        public void FindRebel_RebelExists_ReturnRebel()
        {
            Initialize();
            
            Rebel response = _tradeResoursesUseCase.FindRebel(1, out string message);
            
            Assert.Equal(1, response.IdRebel);
            Assert.Equal("Ok", message);
        }

        [Fact]
        public void FindRebel_RebelNotExists_ReturnNull()
        {
            Initialize();

            _rebelRepository.Setup(x => x.SelectRebelInventory(It.IsAny<long>()))
                .Returns((Rebel) null);
            
            Rebel response = _tradeResoursesUseCase.FindRebel(1, out string message);
            
            Assert.Null(response);
            Assert.Equal("Rebel 1 not found", message);
        }

        [Fact]
        public void FindRebel_Traitor_ReturnNull()
        {
            Initialize();
            _rebelRepository.Setup(x => x.SelectRebelInventory(It.IsAny<long>()))
                .Returns(new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 27,
                    Traitor = true,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Comida",
                            Quantity = 10
                        }
                    }
                });
            
            Rebel response = _tradeResoursesUseCase.FindRebel(1, out string message);
            
            Assert.Null(response);
            Assert.Equal("Rebel 1 is a TRAITOR! Negociation forbidden", message);
        }
    }
}