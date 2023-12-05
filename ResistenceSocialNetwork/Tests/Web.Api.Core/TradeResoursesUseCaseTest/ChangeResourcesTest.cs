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
    public class ChangeResourcesTest
    {
        private TradeResoursesUseCase _tradeResoursesUseCase { get; set; }
        private Mock<IRebelRepository> _rebelRepository;
        private Mock<IInventoryRepository> _inventoryRepository;

        private void Initialize()
        {
            _rebelRepository = new Mock<IRebelRepository>();
            _inventoryRepository = new Mock<IInventoryRepository>();

            _inventoryRepository.Setup(x => x.RemoveResource(It.IsAny<Inventory>()))
                .Returns(true);
            _inventoryRepository.Setup(x => x.UpdateQuantity(It.IsAny<Inventory>(), It.IsAny<long>()))
                .Returns(true);
            _inventoryRepository.Setup(x => x.AddInventory(It.IsAny<Inventory>()))
                .Returns(true);
            _inventoryRepository.Setup(x => x.FindInventory(It.IsAny<long>(), It.IsAny<string>()))
                .Returns((Inventory) null);

            _tradeResoursesUseCase = new TradeResoursesUseCase(_rebelRepository.Object, _inventoryRepository.Object);
        }

        [Fact]
        public void ChangeResources_ListRemoveAndAdd()
        {
            Initialize();
            
            _tradeResoursesUseCase.ChangeResources(
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Comida",
                            Quantity = 2
                        }
                    }
                },
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Agua",
                            Quantity = 1
                        }
                    }
                },
                new List<InventoryRequest>(){
                    new InventoryRequest(){
                        Resource = "Comida",
                        Quantity = 2
                    }
                }
            );
            
            _inventoryRepository.Verify(x => x.RemoveResource(It.IsAny<Inventory>()), Times.Once);
            _inventoryRepository.Verify(x => x.AddInventory(It.IsAny<Inventory>()), Times.Once);
            _inventoryRepository.Verify(x => x.UpdateQuantity(It.IsAny<Inventory>(), It.IsAny<long>()), Times.Never);
        }

        [Fact]
        public void ChangeResources_ListRemoveAndUpdate()
        {
            Initialize();

            _inventoryRepository.Setup(x => x.FindInventory(It.IsAny<long>(), It.IsAny<string>()))
                .Returns(new Inventory(){
                    Resource = "Comida",
                    Quantity = 3
                });
            
            _tradeResoursesUseCase.ChangeResources(
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Comida",
                            Quantity = 2
                        }
                    }
                },
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Agua",
                            Quantity = 1
                        }
                    }
                },
                new List<InventoryRequest>(){
                    new InventoryRequest(){
                        Resource = "Comida",
                        Quantity = 2
                    }
                }
            );
            
            _inventoryRepository.Verify(x => x.RemoveResource(It.IsAny<Inventory>()), Times.Once);
            _inventoryRepository.Verify(x => x.AddInventory(It.IsAny<Inventory>()), Times.Never);
            _inventoryRepository.Verify(x => x.UpdateQuantity(It.IsAny<Inventory>(), It.IsAny<long>()), Times.Once);
        }

        [Fact]
        public void ChangeResources_ListUpdate()
        {
            Initialize();

            _inventoryRepository.Setup(x => x.FindInventory(It.IsAny<long>(), It.IsAny<string>()))
                .Returns(new Inventory(){
                    Resource = "Comida",
                    Quantity = 3
                });
            
            _tradeResoursesUseCase.ChangeResources(
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Comida",
                            Quantity = 3
                        }
                    }
                },
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Agua",
                            Quantity = 1
                        }
                    }
                },
                new List<InventoryRequest>(){
                    new InventoryRequest(){
                        Resource = "Comida",
                        Quantity = 2
                    }
                }
            );
            
            _inventoryRepository.Verify(x => x.RemoveResource(It.IsAny<Inventory>()), Times.Never);
            _inventoryRepository.Verify(x => x.AddInventory(It.IsAny<Inventory>()), Times.Never);
            _inventoryRepository.Verify(x => x.UpdateQuantity(It.IsAny<Inventory>(), It.IsAny<long>()), Times.Exactly(2));
        }

        [Fact]
        public void ChangeResources_ListUpdateAndAdd()
        {
            Initialize();
            
            _tradeResoursesUseCase.ChangeResources(
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Comida",
                            Quantity = 3
                        }
                    }
                },
                new Rebel(){
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 27,
                    Inventories = new List<Inventory>(){
                        new Inventory(){
                            Resource = "Agua",
                            Quantity = 1
                        }
                    }
                },
                new List<InventoryRequest>(){
                    new InventoryRequest(){
                        Resource = "Comida",
                        Quantity = 2
                    }
                }
            );
            
            _inventoryRepository.Verify(x => x.RemoveResource(It.IsAny<Inventory>()), Times.Never);
            _inventoryRepository.Verify(x => x.AddInventory(It.IsAny<Inventory>()), Times.Once);
            _inventoryRepository.Verify(x => x.UpdateQuantity(It.IsAny<Inventory>(), It.IsAny<long>()), Times.Once);
        }
    }
}