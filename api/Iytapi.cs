using SharedLib.Models;

namespace WASM.api
{
    public interface Iytapi
    {
        // 🔄 System (YouTube sync)
        Task<bool> SyncAsync();

        // 📥 Read
        Task<List<YouTubeVideo>> GetAllAsync();

        // ➕ Manual CRUD
        Task<bool> AddManualAsync(YouTubeVideo video);
        Task<bool> UpdateManualAsync(Guid id, YouTubeVideo video);
        Task<bool> DeleteManualAsync(Guid id);

        // 💀 Force delete
        Task<bool> ForceDeleteAsync(Guid id);
    }
}
