using SharedLib.DTO;
using System.Net.Http.Json;

namespace WASM.api
{
    public class AdminLottieApi : IAdminLottieApi
    {
        private readonly HttpClient _http;
        private const string BASE = "AdminSettings";


        public AdminLottieApi(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<LottieDto>> GetAll()
        {
            return await _http.GetFromJsonAsync<List<LottieDto>>(
                $"{BASE}/lottieGetAll") ?? [];
        }

        public async Task<LottieDto?> GetById(int id)
        {
            return await _http.GetFromJsonAsync<LottieDto>(
                $"{BASE}/lottieGetById/{id}");
        }

        public async Task<bool> Add(LottieDto lottie)
        {
            var res = await _http.PostAsJsonAsync($"{BASE}/lottieCreate", lottie);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> Update(LottieDto lottie)
        {
            var res = await _http.PutAsJsonAsync(
                $"{BASE}/lottieUpdate", lottie);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteById(int id)
        {
            var res = await _http.DeleteAsync($"{BASE}/lottieDelete/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}
