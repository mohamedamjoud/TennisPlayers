
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
    statistics.IsSuccess.Should().BeTrue();
    statistics.Value.CountryWithHighestWinRatio.Should().Be("SUI");
    statistics.Value.AverageBmi.Should().BeApproximately(23.82, 0.01);
    statistics.Value.MedianHeight.Should().Be(185);
  }
}