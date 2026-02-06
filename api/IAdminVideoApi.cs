using AffiGive_API_V1.DTO;
using AffiGive_API_V1.Models;

namespace AffigiveUIBalzor.api
{
    public interface IAdminVideoApi
    {
        Task<PagedResult<Video>> GetAll(int page, int pageSize);
        Task<PagedResult<Video>> Search(string code, int page, int pageSize);
        Task<Video?> GetByCode(string code);
        Task<bool> Add(Video video);
        Task<bool> Update(Video video);
        Task<bool> DeleteByCode(string code);
        Task<bool> DeleteById(Guid id);
        Task<Video?> GetActiveLuckyGiftVideo();
        Task<bool> PickLuckyGiftVideo(Guid videoId);
        Task<bool> UnPickLuckyGiftVideo(Guid videoId);
    }
}
