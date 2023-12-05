using FluentAssertions;
using NSubstitute;
using src.Web.Api.Core.Interface.Repository;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Core.UseCase;
using src.Web.Api.Infrastructure.EntityFramework.Entity;

namespace ResistenceSocialNetworkTest.TradeResoursesUseCaseTest
{
    public class FindRebelTest
    {
        private readonly IRebelRepository _mockRebelRepository;
        private readonly IInventoryRepository _mockInventoryRepository;
        private TradeResoursesUseCase _sut;

        public FindRebelTest()
        {
            _mockInventoryRepository = Substitute.For<IInventoryRepository>();
            _mockRebelRepository = Substitute.For<IRebelRepository>();

            _sut = new TradeResoursesUseCase(_mockRebelRepository, _mockInventoryRepository);
        }

        [Fact]
        public void FindRebel_RebelNull_ReturnsNull()
        {
            // Arrange
            _mockRebelRepository.SelectRebelInventory(1)
                .Returns((Rebel)null);
            
            // Act
            Rebel result = _sut.FindRebel(1, out string message);

            // Assert
            result.Should().BeNull();
            message.Should().Contain("not found");
        }

        [Fact]
        public void FindRebel_RebelNotTraitor_ReturnsRebel()
        {
            // Arrange
            _mockRebelRepository.SelectRebelInventory(1)
                .Returns(new Rebel()
                {
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 29,
                    Traitor = false,
                    Inventories = new()
                    {
                        new()
                        {
                            IdRebel = 1,
                            IdInventory = 1,
                            Resource = "Comida",
                            Quantity = 10
                        }
                    }
                });

            // Act
            Rebel result = _sut.FindRebel(1, out string message);

            // Arrange
            message.Should().Be("Ok");
            result.Should().NotBeNull();
            result.IdRebel.Should().Be(1);
            result.Name.Should().Be("Amanda");
            result.Age.Should().Be(29);
            result.Inventories.Should().HaveCount(1);
        }

        [Fact]
        public void FindRebel_RebelTraitor_ReturnsRebel()
        {
            // Arrange
            _mockRebelRepository.SelectRebelInventory(1)
                .Returns(new Rebel()
                {
                    IdRebel = 1,
                    Name = "Amanda",
                    Age = 29,
                    Traitor = true,
                    Inventories = new()
                    {
                        new()
                        {
                            IdRebel = 1,
                            IdInventory = 1,
                            Resource = "Comida",
                            Quantity = 10
                        }
                    }
                });

            // Act
            Rebel result = _sut.FindRebel(1, out string message);

            // Arrange
            message.Should().Contain("TRAITOR!");
            result.Should().BeNull();
        }

    }
}
