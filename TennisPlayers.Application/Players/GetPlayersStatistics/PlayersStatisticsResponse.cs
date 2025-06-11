namespace TennisPlayers.Application.Players.GetPlayersStatistics;

public sealed record PlayersStatisticsResponse(string CountryWithHighestWinRatio, double AverageBmi, double MedianHeight );