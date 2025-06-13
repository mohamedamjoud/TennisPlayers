using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace TennisPlayers.Infrastructure.Data;

public static class JsonFileHelper <T> where T : class  {

    public static async Task<T?> TryReadAsync(string filePath, ILogger logger)
    {
        try
        {
            string jsonString = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error reading file {filePath}", filePath);
            throw;
        }
    }
}