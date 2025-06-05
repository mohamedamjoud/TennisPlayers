namespace TennisPlayers.Application.Players.GetPlayers;

public sealed record PlayerResponse(int Id, string FirstName, string LastName, string ShortName, int Rank, int Points);