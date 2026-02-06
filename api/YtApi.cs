using SharedLib.Models;
using System.Net.Http.Json;
using WASM.api;

public class YtApi : Iytapi
{
    private readonly HttpClient _http;

    // MUST match controller route
    private const string BaseUrl = "AdminYouTubeVideo";

    public YtApi(HttpClient http)
    {
        _http = http;
    }

    // ===============================
    // 📥 GET ALL
    // ===============================
    public async Task<List<YouTubeVideo>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<YouTubeVideo>>(BaseUrl)
               ?? new List<YouTubeVideo>();
    }

    // ===============================
    // 🔄 SYNC YOUTUBE
    // ===============================
    public async Task<bool> SyncAsync()
    {
        var res = await _http.PostAsync($"{BaseUrl}/sync", null);
        return res.IsSuccessStatusCode;
    }

    // ===============================
    // ➕ ADD MANUAL
    // ===============================
    public async Task<bool> AddManualAsync(YouTubeVideo video)
    {
        var res = await _http.PostAsJsonAsync(BaseUrl, video);
        return res.IsSuccessStatusCode;
    }

    // ===============================
    // ✏️ UPDATE MANUAL
    // ===============================
    public async Task<bool> UpdateManualAsync(Guid id, YouTubeVideo video)
    {
        var res = await _http.PutAsJsonAsync($"{BaseUrl}/{id}", video);
        return res.IsSuccessStatusCode;
    }

    // ===============================
    // 🗑️ DELETE MANUAL
    // ===============================
    public async Task<bool> DeleteManualAsync(Guid id)
    {
        var res = await _http.DeleteAsync($"{BaseUrl}/{id}");
        return res.IsSuccessStatusCode;
    }

    // ===============================
    // 💀 FORCE DELETE
    // ===============================
    public async Task<bool> ForceDeleteAsync(Guid id)
    {
        var res = await _http.DeleteAsync($"{BaseUrl}/force/{id}");
        return res.IsSuccessStatusCode;
    }
}
