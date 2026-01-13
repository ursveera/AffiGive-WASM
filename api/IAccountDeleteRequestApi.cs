using AffiGive_API_V1.Models;

namespace WASM.api
{
    public interface IAccountDeleteRequestApi
    {
        Task<List<AccountDeletionRequest>> GetAllAsync();
        Task<AccountDeletionRequest?> GetByIdAsync(int id);
        Task CreateAsync(AccountDeletionRequest request);
        Task UpdateStatusAsync(int id, string status, string? remarks);
        Task DeleteAsync(int id);
        Task<bool> HasPendingRequestAsync(string googleId);
    }
}
