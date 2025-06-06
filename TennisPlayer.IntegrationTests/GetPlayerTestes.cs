using FluentAssertions;
using TennisPlayer.IntegrationTests.Abstractions;
using TennisPlayers.Application.Players.GetPlayer;

namespace TennisPlayer.IntegrationTests;

public class GetPlayerTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task Should_ReturnPlayer_WhenIdExists()
    {
        //Arrange
        var query = new GetPlayerQuery (1);

        //Act
        var player = await Sender.Send(query);

        //Assert
        player.Should().NotBeNull();
        player.Id.Should().Be(1);
    }
    
    [Fact]
    public async Task Should_ReturnNull_WhenIdNotExists()
    {
        //Arrange
        var query = new GetPlayerQuery (5);

        //Act
        var player = await Sender.Send(query);

        //Assert
        player.Should().BeNull();
    }
}