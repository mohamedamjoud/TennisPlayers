using System.Text.Json;

namespace TennisPlayers.Infrastructure.Data;

public static class JsonFileHelper <T> where T : class  {

    public static async Task<T?> ReadAsync(string filePath)
    {
        try
        {
            string jsonString = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error reading player file.", ex);
        }
    }
}