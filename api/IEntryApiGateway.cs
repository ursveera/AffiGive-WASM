using AffiGive_API_V1.DTO;
using AffiGive_API_V1.Models;

namespace AffigiveUIBalzor.api
{
    public interface IEntryApiGateway
    {
        Task<EntryResponse> AddEntryAsync(Entry entry);
        Task<PagedResult<Entry>> GetAllAsync(int page, int pageSize);
        Task<PagedResult<Entry>> GetAllValidAsync(int page, int pageSize);
        Task<PagedResult<Entry>> SearchByNickNameAsync(string nickname, int page, int pageSize);
        Task<PagedResult<Entry>> SearchByCodeAsync(string code, int page, int pageSize);
        Task<bool> DeleteEntryAsync(Guid id);
        Task<int> UpdateEntryAsync(Entry entry);
        Task<bool> CheckNickNameExists(string nickname);
        Task<bool> CheckMailExists(string code, string email);
    }
}
