using SharedLib.Models;
using System.Net.Http.Json;

namespace WASM.api
{
    public class SupportApi : ISupportApi
    {
        private readonly HttpClient _http;
        private const string BASE = "support/admin";

        public SupportApi(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SupportMessage>> GetAllMessagesAsync()
        {
            return await _http.GetFromJsonAsync<List<SupportMessage>>($"{BASE}/all")
                   ?? new List<SupportMessage>();
        }

        public async Task<List<SupportMessage>> GetMessagesByUserAsync(string userId)
        {
            return await _http.GetFromJsonAsync<List<SupportMessage>>(
                $"{BASE}/user/{userId}")
                ?? new List<SupportMessage>();
        }

        public async Task<SupportMessage> SendAdminReplyAsync(string userId, string reply)
        {
            var response = await _http.PostAsJsonAsync(
                $"{BASE}/reply",
                new { UserId = userId, Reply = reply });

            response.EnsureSuccessStatusCode();

            return (await response.Content.ReadFromJsonAsync<SupportMessage>())!;
        }

        public async Task<bool> UpdateMessageAsync(long id, string text)
        {
            var response = await _http.PutAsJsonAsync(
                $"{BASE}/{id}",
                new { Text = text });

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteMessageAsync(long id)
        {
            var response = await _http.DeleteAsync($"{BASE}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
