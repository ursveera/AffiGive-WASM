using SharedLib.Models;

namespace WASM.api
{
    public interface IGiftApi
    {
        Task<IEnumerable<GiftMaster>> GetAllAsync();
        Task<GiftMaster?> GetByIdAsync(int id);
        Task<int> CreateAsync(GiftMaster gift);
        Task<bool> UpdateAsync(int id, GiftMaster gift);
        Task<bool> DeleteAsync(int id);
        Task<List<GiftParticipation>> GetParticipantsByGiftIdAsync(int giftId);
        Task<List<GiftParticipation>> GetAllParticipantsAsync();
    }
}
