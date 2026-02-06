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

        public async Task LockMonthlyWinnersAsync(int year, int month, int top = 10)
        {
            var response = await _http.PostAsync(
                $"{BASE}/leaderboard/lock?year={year}&month={month}&top={top}",
                null
            );

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to lock winners: {error}");
            }
        }

        public async Task<List<UserRankDto>> GetMonthlyWinnersArrayAsync(int year, int month)
        {
            return await _http.GetFromJsonAsync<List<UserRankDto>>(
                $"{BASE}/leaderboard/monthwisewinner?year={year}&month={month}"
            ) ?? new();
        }
        public async Task<List<UserRankDto>> GetMonthlyWinnersAsync(int year, int month)
        {
            return await _http.GetFromJsonAsync<List<UserRankDto>>(
                $"{BASE}/leaderboard/winners?year={year}&month={month}"
            ) ?? new();
        }

        public async Task<bool> UnlockMonthlyWinnersAsync(int year, int month)
        {
            var response = await _http.PostAsync(
                 $"{BASE}/leaderboard/unlock?year={year}&month={month}",
                 null
             );

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> IsMonthLockedAsync(int year, int month)
        {
            return await _http.GetFromJsonAsync<bool>(
                       $"{BASE}/leaderboard/is-locked?year={year}&month={month}"
                   );
        }
        public async Task<User> CreateUserAsync(User user)
        {
            var res = await _http.PostAsJsonAsync($"{BASE}/create", user);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadFromJsonAsync<User>();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var res = await _http.PutAsJsonAsync($"{BASE}/update", user);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeactivateUserAsync(int userId)
        {
            var res = await _http.PutAsync($"{BASE}/deactivate/{userId}", null);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> ForceDeleteUserAsync(int userId)
        {
            var res = await _http.DeleteAsync($"{BASE}/force-delete/{userId}");
            return res.IsSuccessStatusCode;
        }
    }
}
