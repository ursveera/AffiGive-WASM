using AffigiveUIBalzor.api;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

public class AppSettingsApi : IAppSettingsApi
{
    private readonly HttpClient _http;

    public AppSettingsApi(HttpClient http)
    {
        _http = http;
    }

    public async Task<string> GetSettingsAsync()
    {
        // Get settings ONLY from API
        var apiAppsettings = await _http.GetStringAsync("AdminSettings");
        var apiObj = JObject.Parse(apiAppsettings);

        // UI-friendly JSON
        var uiJson = new JObject
        {
            ["ApiAppSettings"] = apiObj
        };

        return uiJson.ToString(Newtonsoft.Json.Formatting.Indented);
    }

    public async Task SaveSettingsAsync(string json)
    {
        var appSettings = new AffiGive_API_V1.Models.AppSettings
        {
            all = json
        };

        var response = await _http.PostAsJsonAsync("AdminSettings", appSettings);
        response.EnsureSuccessStatusCode();
    }
}
