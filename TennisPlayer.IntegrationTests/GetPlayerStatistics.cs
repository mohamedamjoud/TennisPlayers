
using FluentAssertions;
using TennisPlayer.IntegrationTests.Abstractions;
using TennisPlayers.Application.Players.GetPlayersStatistics;

namespace TennisPlayer.IntegrationTests;

public class GetPlayerStatistics(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
  
  [Fact]
  public async Task Should_ReturnValidPlayersStatistics_ForGivenPlayersData()
  {
    //Arrange
    var query = new GetPlayersStatisticsQuery();
    
    //Act
    var statistics = await Sender.Send(query);
    
    //Assert
    statistics.Should().NotBeNull();
    statistics.CountryWithHighestWinRatio.Should().Be("SUI");
    statistics.AverageBmi.Should().BeApproximately(23.82, 0.01);
    statistics.MedianHeight.Should().Be(185);
  }
}