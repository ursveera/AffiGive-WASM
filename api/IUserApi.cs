using AffiGive_API_V1.Models;
using SharedLib.DTO;

namespace WASM.api
{
    public interface IUserApi
    {
        Task<User?> GetByGoogleIdAsync(string googleId);
        Task<User?> GetByUserId(string id);
        Task<int> GetUserTotalCoinsAsync(string userId);
        Task<List<CoinHistoryDto>> GetUserCoinHistoryAsync(string userId);
        Task<List<User>> GetAllUsersAsync();
        Task<List<UserRankDto>> GetTopUserRanksAsync(int top = 10);
    }
}
