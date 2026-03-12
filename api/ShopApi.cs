using SharedLib.Models;
using System.Net.Http.Json;

namespace WASM.Api
{
    public class ShopApi : IShopApi
    {
        private readonly HttpClient _http;

        private const string BASE = "shop";

        public ShopApi(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<ShopItems>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<ShopItems>>(
                $"{BASE}"
            ) ?? Enumerable.Empty<ShopItems>();
        }

        public async Task<ShopItems?> GetAsync(string id)
        {
            return await _http.GetFromJsonAsync<ShopItems>(
                $"{BASE}/{id}"
            );
        }

        public async Task<bool> CreateAsync(ShopItems item)
        {
            var response = await _http.PostAsJsonAsync(BASE, item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(string id, ShopItems item)
        {
            var response = await _http.PutAsJsonAsync(
                $"{BASE}/{id}",
                item
            );

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var response = await _http.DeleteAsync(
                $"{BASE}/{id}"
            );

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ForceDeleteAsync(string id)
        {
            var response = await _http.DeleteAsync(
                $"{BASE}/force/{id}"
            );

            return response.IsSuccessStatusCode;
        }
    }
}