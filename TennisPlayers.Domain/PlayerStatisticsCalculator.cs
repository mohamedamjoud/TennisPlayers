namespace TennisPlayers.Domain;

public static class PlayerStatisticsCalculator
{
    
    private static double ConvertCmToMetre(int heightInCentimetres) => heightInCentimetres / 100.0;
    private static double ConvertGrammeToKg(int weightInGramme) => weightInGramme / 1000.0;
    
    public static double CalculateBmi(int weightInGramme, int heightInCentimetres) => ConvertGrammeToKg(weightInGramme)/Math.Pow(ConvertCmToMetre(heightInCentimetres), 2);

    
    public static double CalculateMedianHeight(IEnumerable<int> heights)
    {
        var ordered = heights.OrderBy(h => h).ToList();
        var count = ordered.Count;
        return count % 2 == 0
            ? (ordered[count / 2 - 1] + ordered[count / 2]) / 2.0
            : ordered[count / 2];
    }
}