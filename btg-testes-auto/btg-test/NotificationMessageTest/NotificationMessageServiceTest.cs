using System.Collections.Generic;
using btg_testes_auto.NotificationMessage;
using FluentAssertions;
using NSubstitute;

namespace btg_test.NotificationMessageTest;

public class NotificationMessageServiceTest
{
    private readonly IMessageService _mockMessageService;
    private NotificationMessageService _sut;

    public NotificationMessageServiceTest()
    {
        _mockMessageService = Substitute.For<IMessageService>();
        _sut = new NotificationMessageService(_mockMessageService);
    }

    [Fact]
    public void NotifyUsers_AllMessagesSent_ShouldReturnTrue()
    {
        // Arrange
        var notifications = new List<Notification>
        {
            new Notification { UserId = "user1", Message = "Message 1" },
            new Notification { UserId = "user2", Message = "Message 2" }
        };

        _mockMessageService.SendMessage(Arg.Any<string>(), Arg.Any<string>()).Returns(true);

        // Act
        var result = _sut.NotifyUsers(notifications);

        // Assert
        result.Should().BeTrue();
        _mockMessageService.Received(2).SendMessage(Arg.Any<string>(), Arg.Any<string>());
    }

    [Fact]
    public void NotifyUsers_OneMessageFailed_ShouldReturnFalse()
    {
        // Arrange
        var notifications = new List<Notification>
        {
            new Notification { UserId = "user1", Message = "Message 1" },
            new Notification { UserId = "user2", Message = "Message 2" }
        };

        _mockMessageService.SendMessage("user1", "Message 1").Returns(true);
        _mockMessageService.SendMessage("user2", "Message 2").Returns(false);

        // Act
        var result = _sut.NotifyUsers(notifications);

        // Assert
        result.Should().BeFalse();
        _mockMessageService.Received(2).SendMessage(Arg.Any<string>(), Arg.Any<string>());
    }
}
