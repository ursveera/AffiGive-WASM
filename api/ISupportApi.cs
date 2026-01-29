using SharedLib.Models;

namespace WASM.api
{
    public interface ISupportApi
    {
        // ADMIN
        Task<List<SupportMessage>> GetAllMessagesAsync();
        Task<List<SupportMessage>> GetMessagesByUserAsync(string userId);
        Task<SupportMessage> SendAdminReplyAsync(string userId, string reply);
        Task<bool> UpdateMessageAsync(long id, string text);
        Task<bool> DeleteMessageAsync(long id);
    }
}
