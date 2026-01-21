using SharedLib.Models;
using System.Net.Http.Json;
using WASM.DTO;

namespace WASM.api
{
    public class FaqApi : IFaqApi
    {
        private readonly HttpClient _http;
        private const string BASE = "Faq";

        public FaqApi(HttpClient http)
        {
            _http = http;
        }

        // ---------------- ADMIN ----------------
        public async Task<IEnumerable<Faq>> GetAllForAdminAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<Faq>>(
                $"{BASE}/admin"
            ) ?? Enumerable.Empty<Faq>();
        }

        // ---------------- USER APP ----------------
        public async Task<IEnumerable<Faq>> GetActiveForUserAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<Faq>>(
                $"{BASE}/public"
            ) ?? Enumerable.Empty<Faq>();
        }

        public async Task<Faq?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Faq>(
                $"{BASE}/{id}"
            );
        }

        public async Task<int> CreateAsync(Faq faq)
        {
            var response = await _http.PostAsJsonAsync(BASE, faq);
            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<ApiIdResponse>();

            return result!.Id;
        }

        public async Task<bool> UpdateAsync(int id, Faq faq)
        {
            var response = await _http.PutAsJsonAsync($"{BASE}/{id}", faq);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{BASE}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
