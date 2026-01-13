using AffiGive_API_V1.Models;
using SharedLib.DTO;
using System.Net.Http.Json;

namespace WASM.api
{
    public class UserApi : IUserApi
    {
        private readonly HttpClient _http;
        private const string BASE = "Users";

        public UserApi(HttpClient http)
        {
            _http = http;
        }

        // ---------------- USER DETAILS ----------------

        public async Task<User?> GetByGoogleIdAsync(string googleId)
        {
            return await _http.GetFromJsonAsync<User>(
                $"{BASE}/google/{googleId}"
            );
        }
        public async Task<User?> GetByUserId(string userid)
        {
            return await _http.GetFromJsonAsync<User>(
                $"{BASE}/getuserByIdForAdmin/{userid}"
            );
        }

        // ---------------- TOTAL COINS ----------------

        public async Task<int> GetUserTotalCoinsAsync(string userId)
        {
            return await _http.GetFromJsonAsync<int>(
                $"{BASE}/{userId}/total"
            );
        }

        // ---------------- COIN HISTORY ----------------

        public async Task<List<CoinHistoryDto>> GetUserCoinHistoryAsync(string userId)
        {
            return await _http.GetFromJsonAsync<List<CoinHistoryDto>>(
                $"{BASE}/{userId}/history"
            ) ?? new();
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _http.GetFromJsonAsync<List<User>>($"{BASE}/getallusers") ?? new();
        }
        public async Task<List<UserRankDto>> GetTopUserRanksAsync(int top=10)
        {
            return await _http.GetFromJsonAsync<List<UserRankDto>>($"{BASE}/leaderboard") ?? new();
        }
    }
}
