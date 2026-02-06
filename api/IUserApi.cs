using AffiGive_API_V1.Models;
using SharedLib.DTO;
using System.Threading.Tasks;

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
        Task<List<UserRankDto>> GetMonthlyWinnersAsync(int year, int month);
        Task LockMonthlyWinnersAsync(int year, int month, int top = 10);
        Task<List<UserRankDto>> GetMonthlyWinnersArrayAsync(int year, int month);
        Task<bool> UnlockMonthlyWinnersAsync(int year, int month);
        Task<bool> IsMonthLockedAsync(int year, int month);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeactivateUserAsync(int userId);
        Task<bool> ForceDeleteUserAsync(int userId);
    }
}
