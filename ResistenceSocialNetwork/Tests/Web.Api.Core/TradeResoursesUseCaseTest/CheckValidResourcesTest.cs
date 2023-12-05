using System.Collections.Generic;
using Moq;
using src.Web.Api.Core.Interface.Repository;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Core.UseCase;
using src.Web.Api.Infrastructure.EntityFramework.Entity;
using src.Web.Api.Model;
using Xunit;

namespace Tests.Web.Api.Core.TradeResoursesUseCaseTest
{
    public class CheckValidResourcesTest
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
        public void CheckValidResources_ItemNull_ReturnNotAvaiable()
        {
            Initialize();
            
            bool response = _tradeResoursesUseCase.CheckValidResources(
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Location = new Location(){
                        GalaxyName = "Galaxy",
                        Longitude = 1.27M,
                        Latitude = 3.87M
                    },
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Comida",
                            Quantity = 10
                        }
                    }
                },
                new List<InventoryRequest>(){
                    new InventoryRequest(){
                        Resource = "Municao",
                        Quantity = 5
                    }
                }, out string message);
            
            Assert.False(response);
            Assert.Equal("Item Municao not available for trade with rebel 1", message);
        }

        [Fact]
        public void CheckValidResources_ItemFewQuantity_ReturnInsufficient()
        {
            Initialize();
            
            bool response = _tradeResoursesUseCase.CheckValidResources(
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Location = new Location(){
                        GalaxyName = "Galaxy",
                        Longitude = 1.27M,
                        Latitude = 3.87M
                    },
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Comida",
                            Quantity = 5
                        }
                    }
                },
                new List<InventoryRequest>(){
                    new InventoryRequest(){
                        Resource = "Comida",
                        Quantity = 10
                    }
                }, out string message);
            
            Assert.False(response);
            Assert.Equal("Insufficient quantity for item Comida with rebel 1", message);
        }

        [Fact]
        public void CheckValidResources_ItemOKAndItemFewQuantity_ReturnInsufficient()
        {
            Initialize();
            
            bool response = _tradeResoursesUseCase.CheckValidResources(
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Location = new Location(){
                        GalaxyName = "Galaxy",
                        Longitude = 1.27M,
                        Latitude = 3.87M
                    },
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Comida",
                            Quantity = 5
                        },
                        new Inventory(){
                            Resource = "Agua",
                            Quantity = 5
                        }
                    }
                },
                new List<InventoryRequest>(){
                    new InventoryRequest(){
                        Resource = "Agua",
                        Quantity = 5
                    },
                    new InventoryRequest(){
                        Resource = "Comida",
                        Quantity = 10
                    }
                }, out string message);
            
            Assert.False(response);
            Assert.Equal("Insufficient quantity for item Comida with rebel 1", message);
        }

        [Fact]
        public void CheckValidResources_ItemOK_ReturnTrue()
        {
            Initialize();
            
            bool response = _tradeResoursesUseCase.CheckValidResources(
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Location = new Location(){
                        GalaxyName = "Galaxy",
                        Longitude = 1.27M,
                        Latitude = 3.87M
                    },
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Comida",
                            Quantity = 15
                        },
                        new Inventory(){
                            Resource = "Agua",
                            Quantity = 5
                        }
                    }
                },
                new List<InventoryRequest>(){
                    new InventoryRequest(){
                        Resource = "Agua",
                        Quantity = 5
                    },
                    new InventoryRequest(){
                        Resource = "Comida",
                        Quantity = 10
                    }
                }, out string message);
            
            Assert.True(response);
            Assert.Equal("", message);
        }
        
    }
}