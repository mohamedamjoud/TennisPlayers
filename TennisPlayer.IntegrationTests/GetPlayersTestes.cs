﻿using FluentAssertions;
using TennisPlayer.IntegrationTests.Abstractions;
using TennisPlayers.Application.Players.GetPlayers;

namespace TennisPlayer.IntegrationTests;

public class GetPlayersTests(IntegrationTestWebAppFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task Should_ReturnAllPlayers_SortedByRankAsc()
    {
        //Arrange
        var query = new GetPlayersQuery{SortBy = PlayerSortBy.Rank};

        //Act
        var players = await Sender.Send(query);
        
        //Assert
        players.IsSuccess.Should().BeTrue();
        players.Value.Should().HaveCountGreaterThan(1);
        players.Value.Should().BeInAscendingOrder(p => p.Rank);
    }
} 