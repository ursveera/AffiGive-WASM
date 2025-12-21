using AffiGive_API_V1.DTO;
using AffiGive_API_V1.Models;
using System.Net.Http.Json;

namespace AffigiveUIBalzor.api
{
    public class EntryApiGateway : IEntryApiGateway
    {
        private readonly HttpClient _http;
        private const string BASE = "Entries";

        public EntryApiGateway(HttpClient http)
        {
            _http = http;
        }

        public async Task<EntryResponse> AddEntryAsync(Entry entry)
        {
            var er = new EntryResponse { entry = entry };
            var response = await _http.PostAsJsonAsync($"{BASE}/AddEntry", er);
            return await response.Content.ReadFromJsonAsync<EntryResponse>();
        }

        public async Task<PagedResult<Entry>> GetAllAsync(int page, int pageSize)
        {
            return await _http.GetFromJsonAsync<PagedResult<Entry>>(
                $"{BASE}/GetAllEntries?page={page}&pageSize={pageSize}");
        }

        public async Task<PagedResult<Entry>> GetAllValidAsync(int page, int pageSize)
        {
            return await _http.GetFromJsonAsync<PagedResult<Entry>>(
                $"{BASE}/GetAllValidEntries?page={page}&pageSize={pageSize}");
        }

        public async Task<PagedResult<Entry>> SearchByNickNameAsync(string nickname, int page, int pageSize)
        {
            return await _http.GetFromJsonAsync<PagedResult<Entry>>(
                $"{BASE}/SearchByNickName?nickname={nickname}&page={page}&pageSize={pageSize}");
        }

        public async Task<PagedResult<Entry>> SearchByCodeAsync(string code, int page, int pageSize)
        {
            return await _http.GetFromJsonAsync<PagedResult<Entry>>(
                $"{BASE}/{code}/GetByCode?page={page}&pageSize={pageSize}");
        }

        public async Task<bool> DeleteEntryAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"{BASE}/{id}/DeleteById");
            return response.IsSuccessStatusCode;
        }

        public async Task<int> UpdateEntryAsync(Entry entry)
        {
            var response = await _http.PutAsJsonAsync($"{BASE}/{entry.Id}/UpdateEntry", entry);
            return response.IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<bool> CheckNickNameExists(string nickname)
        {
            return await _http.GetFromJsonAsync<bool>($"{BASE}/{nickname}/CheckNickName");
        }

        public async Task<bool> CheckMailExists(string code, string email)
        {
            return await _http.GetFromJsonAsync<bool>($"{BASE}/{code}/{email}/CheckMailExists");
        }
    }
}
