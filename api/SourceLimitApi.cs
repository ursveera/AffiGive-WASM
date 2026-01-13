using SharedLib.Models;
using System.Net.Http.Json;

namespace WASM.api
{
    public class SourceLimitApi : ISourceLimitApi
    {
        private readonly HttpClient _http;
        private const string BASE = "SourceLimit";

        public SourceLimitApi(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SourceLimit>> GetAllAsync()
        {
            var result = await _http.GetFromJsonAsync<List<SourceLimit>>($"{BASE}");
            return result ?? new List<SourceLimit>();
        }

        public async Task<SourceLimit?> GetAsync(string source)
        {
            return await _http.GetFromJsonAsync<SourceLimit?>($"{BASE}/{source}");
        }

        public async Task UpdateAsync(SourceLimit model)
        {
            await _http.PutAsJsonAsync($"{BASE}", model);
        }

        public async Task DeleteAsync(string source)
        {
            await _http.DeleteAsync($"{BASE}/{source}");
        }

        public async Task CreateAsync(SourceLimit model)
        {
            await _http.PostAsJsonAsync($"{BASE}", model);
        }
    }
}
