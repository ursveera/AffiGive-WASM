using AffiGive_API_V1.Models;
using SharedLib.Models;
using System.Net.Http.Json;
using WASM.DTO;
using WASM.Pages;

namespace WASM.api
{
    public class AccountDeleteRequestApi : IAccountDeleteRequestApi
    {
        private readonly HttpClient _http;
        private const string BASE = "AccountDeletionRequests";

        public AccountDeleteRequestApi(HttpClient http)
        {
            _http = http;
        }

        // 🔐 Admin – get all requests
        public async Task<List<AccountDeletionRequest>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<AccountDeletionRequest>>(BASE);
        }

        // 🔐 Admin – get request by id
        public async Task<AccountDeletionRequest?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<AccountDeletionRequest>($"{BASE}/{id}");
        }

        // 👤 User – create delete request
        public async Task CreateAsync(AccountDeletionRequest request)
        {
            var response = await _http.PostAsJsonAsync(BASE, request);
            response.EnsureSuccessStatusCode();
        }

        // 🔐 Admin – approve / reject / revert
        public async Task UpdateStatusAsync(int id, string status, string? remarks)
        {
            var response = await _http.PutAsJsonAsync(
                $"{BASE}/{id}/status?status={status}",
                remarks
            );

            response.EnsureSuccessStatusCode();
        }

        // 🔐 Admin – finalize delete (soft delete → Status = Deleted)
        public async Task DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{BASE}/{id}");
            response.EnsureSuccessStatusCode();
        }

        // 👤 User – check if already requested deletion
        public async Task<bool> HasPendingRequestAsync()
        {
            var response = await _http.GetFromJsonAsync<ApiBoolResponse>($"{BASE}/hasActive");
            return response?.Value ?? false;
        }

        // 🔹 helper DTO
        private class ApiBoolResponse
        {
            public bool Value { get; set; }
        }
    }
}
