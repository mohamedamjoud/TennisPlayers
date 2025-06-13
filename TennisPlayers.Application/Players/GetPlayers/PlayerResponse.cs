namespace TennisPlayers.Application.Players.GetPlayers;

public sealed record PlayerResponse(
    int Id,
    string FirstName,
    string LastName,
    string ShortName,
    string CountryCode,
    int Rank,
    List<int> LastMatches,
    int Weight,
    int Height);