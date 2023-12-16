using btg_testes_auto.Notification;
using FluentAssertions;
using NSubstitute;

namespace btg_test.NotificationTest;

public class NotificationServiceTest
{
    private readonly IEmailService _mockEmailService;
    private NotificationService _sut;

    public NotificationServiceTest()
    {
        _mockEmailService = Substitute.For<IEmailService>();
        _sut = new NotificationService(_mockEmailService);
    }

    [Fact]
    public void SendNotification_WithValidMessage_ShouldReturnTrue()
    {
        // Arrange
        const string recipient = "test@example.com";
        const string validMessage = "This is a valid message.";

        _mockEmailService.SendEmail(recipient, "Notification", validMessage).Returns(true);

        // Act
        var result = _sut.SendNotification(recipient, validMessage);

        // Assert
        result.Should().BeTrue();
        _mockEmailService.Received(1).SendEmail(recipient, "Notification", validMessage);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void SendNotification_WithNullOrWhiteSpaceMessage_ShouldReturnFalse(string invalidMessage)
    {
        // Act
        var result = _sut.SendNotification("test@example.com", invalidMessage);

        // Assert
        result.Should().BeFalse();
        _mockEmailService.DidNotReceive().SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
    }

    [Fact]
    public void SendNotification_EmailServiceThrowsException_ShouldReturnFalse()
    {
        // Arrange
        const string recipient = "test@example.com";
        const string validMessage = "This is a valid message.";

        _mockEmailService.When(x => x.SendEmail(recipient, "Notification", validMessage)).Throw<Exception>();

        // Act
        var result = _sut.SendNotification(recipient, validMessage);

        // Assert
        result.Should().BeFalse();
        _mockEmailService.Received(1).SendEmail(recipient, "Notification", validMessage);
    }
}
