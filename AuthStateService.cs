using Blazored.LocalStorage;
using System.Net.Http.Json;
using System.Text.Json;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _storage;

    public string? Token { get; private set; }

    public AuthService(
        IHttpClientFactory factory,
        ILocalStorageService storage)
    {
        _http = factory.CreateClient("AuthClient"); // 👈 NO handler
        _storage = storage;
    }

    public async Task<bool> LoginAsync(string username, string password)
    {
        var response = await _http.PostAsJsonAsync(
            "tokenv2/login",
            new { Email = username, Password = password });

        if (!response.IsSuccessStatusCode)
            return false;

        var json = await response.Content.ReadFromJsonAsync<JsonElement>();
        Token = json.GetProperty("token").GetString();

        await _storage.SetItemAsync("auth_token", Token);
        return true;
    }
    public async Task LoadTokenAsync()
    {
        Token = await _storage.GetItemAsync<string>("auth_token");
    }
}
