using FluentAssertions;
using TennisPlayers.Domain;

namespace TennisPlayer.UnitTests;

public class PlayerStatisticsCalculatorTestes
{
    [Theory]
    [InlineData(80000, 180, 24.7)]

    public void Should_CalculateBmi_AsExpected(int weightInGramme, int heightInCentimetres, double expectedBMI)
    {
        //Act
        var bmi  =  PlayerStatisticsCalculator.CalculateBmi(weightInGramme,heightInCentimetres);

        //Assert
        bmi.Should().BeApproximately(expectedBMI,0.01);
    }

    [Theory]
    [InlineData(new[] { 190, 200, 165, 170, 192 }, 190)]
    [InlineData(new[] { 160, 170, 180 }, 170)]
    [InlineData(new[] { 160, 170 }, 165)] // (160+170)/2 = 165
    public void Should_CalculateMedianHeight_AsExpected(int[] heights, double expectedMedian)
    {
        // Act
        var medianHeight = PlayerStatisticsCalculator.CalculateMedianHeight(heights);

        // Assert
        medianHeight.Should().BeApproximately(expectedMedian, 0.01);
    }
}