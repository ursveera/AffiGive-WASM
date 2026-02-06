using SharedLib.DTO;

namespace WASM.api
{
    public interface IAdminNotificationApi
    {
        // 📱 Mobile / App
        Task<AdminNotificationDto?> GetActiveAsync();

        // 🧑‍💼 Admin
        Task<List<AdminNotificationDto>> GetAllAsync();
        Task<AdminNotificationDto?> GetByIdAsync(int id);
        Task<int> CreateAsync(AdminNotificationDto model);
        Task<bool> UpdateAsync(AdminNotificationDto model);
        Task<bool> DeleteAsync(int id);
    }
}
