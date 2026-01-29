using SharedLib.DTO;
using SharedLib.Models;
using System.Net.Http.Json;
using WASM.DTO;

namespace WASM.api
{
    public class GiftApi : IGiftApi
    {
        private readonly HttpClient _http;
        private const string BASE = "Gift";

        public GiftApi(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<GiftMaster>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<GiftMaster>>($"{BASE}/getallGiftsForAdmin")
                       ?? Enumerable.Empty<GiftMaster>();
        }

        public async Task<GiftMaster?> GetByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<GiftMaster>($"{BASE}/{id}");
        }

        public async Task<int> CreateAsync(GiftMaster gift)
        {
            var response = await _http.PostAsJsonAsync(BASE, gift);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ApiIdResponse>();
            return result!.Id;
        }

        public async Task<bool> UpdateAsync(int id, GiftMaster gift)
        {
            var response = await _http.PutAsJsonAsync($"{BASE}/{id}", gift);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{BASE}/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> ForceDeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{BASE}/ForceDelete/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<GiftParticipation>> GetParticipantsByGiftIdAsync(int giftId)
        {
            return await _http.GetFromJsonAsync<List<GiftParticipation>>(
                $"{BASE}/{giftId}/participants"
            ) ?? new List<GiftParticipation>();
        }

        public async Task<List<GiftParticipation>> GetAllParticipantsAsync()
        {
            return await _http.GetFromJsonAsync<List<GiftParticipation>>($"{BASE}/participants") ?? new List<GiftParticipation>();
        }

        public async Task LockGiftWinnersAsync(int giftId)
        {
            var res = await _http.PostAsync($"{BASE}/{giftId}/lock-winners", null);
            res.EnsureSuccessStatusCode();
        }

        public async Task<List<GiftWinner>> GetWinnersAsync(int giftId)
        {
            return await _http.GetFromJsonAsync<List<GiftWinner>>($"{BASE}/{giftId}/winners") ?? new List<GiftWinner>();
        }

        public async Task<List<GiftWinnerDto>> GetWinnersWithUserAsync(int giftId)
        {
            return await _http.GetFromJsonAsync<List<GiftWinnerDto>>($"{BASE}/{giftId}/winners-with-user") ?? new List<GiftWinnerDto>();
        }
    }
}
