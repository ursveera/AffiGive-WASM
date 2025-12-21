using System.Text.Json;

public static class JwtHelper
{
    public static bool IsExpired(string token)
    {
        var payload = token.Split('.')[1];
        var jsonBytes = Convert.FromBase64String(Pad(payload));
        var json = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes)!;

        if (!json.TryGetValue("exp", out var exp))
            return true;

        var expTime = DateTimeOffset.FromUnixTimeSeconds(long.Parse(exp.ToString()!));
        return expTime.UtcDateTime < DateTime.UtcNow;
    }

    private static string Pad(string base64)
        => base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
}
