using System.Collections.Generic;
using Moq;
using src.Web.Api.Core.Interface.Repository;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Core.UseCase;
using src.Web.Api.Model;
using Xunit;

namespace Tests.Web.Api.Core.TradeResoursesUseCaseTest
{
    public class CheckQuantityResourcesTest
    {
        private TradeResoursesUseCase _tradeResoursesUseCase { get; set; }
        private Mock<IRebelRepository> _rebelRepository;
        private Mock<IInventoryRepository> _inventoryRepository;

        private void Initialize()
        {
            _rebelRepository = new Mock<IRebelRepository>();
            _inventoryRepository = new Mock<IInventoryRepository>();

            _tradeResoursesUseCase = new TradeResoursesUseCase(_rebelRepository.Object, _inventoryRepository.Object);
        }

        [Fact]
        public void CheckQuantityResources_EqualValues_ReturnTrue()
        {
            Initialize();

            bool response = _tradeResoursesUseCase.CheckQuantityResources(new TradeResourcesRequest(){
                FirstRebel = new TradeResourcesRequest.RebelAndResouces(){
                    IdRebel = 1,
                    Inventories = new List<InventoryRequest>(){
                        new InventoryRequest(){
                            Resource = "Comida",
                            Quantity = 2
                        }
                    }
                },
                SecondRebel = new TradeResourcesRequest.RebelAndResouces(){
                    IdRebel = 2,
                    Inventories = new List<InventoryRequest>(){
                        new InventoryRequest(){
                            Resource = "Agua",
                            Quantity = 1
                        }
                    }
                }
            });

            Assert.True(response);
        }

        [Fact]
        public void CheckQuantityResources_DifferentValues_ReturnFalse()
        {
            Initialize();

            bool response = _tradeResoursesUseCase.CheckQuantityResources(new TradeResourcesRequest(){
                FirstRebel = new TradeResourcesRequest.RebelAndResouces(){
                    IdRebel = 1,
                    Inventories = new List<InventoryRequest>(){
                        new InventoryRequest(){
                            Resource = "Comida",
                            Quantity = 2
                        }
                    }
                },
                SecondRebel = new TradeResourcesRequest.RebelAndResouces(){
                    IdRebel = 2,
                    Inventories = new List<InventoryRequest>(){
                        new InventoryRequest(){
                            Resource = "Agua",
                            Quantity = 1
                        },
                        new InventoryRequest(){
                            Resource = "Municao",
                            Quantity = 1
                        }
                    }
                }
            });

            Assert.False(response);
        }
        
    }
}