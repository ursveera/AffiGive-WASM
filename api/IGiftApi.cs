using SharedLib.DTO;
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
        Task<bool> ForceDeleteAsync(int id);
        Task<List<GiftParticipation>> GetParticipantsByGiftIdAsync(int giftId);
        Task<List<GiftParticipation>> GetAllParticipantsAsync();
        Task<bool> LockGiftWinnersAsync(int giftId,bool isFromEntry,string? code=null);
        Task UnlockGiftWinnersAsync(int giftId);
        Task<List<GiftWinner>> GetWinnersAsync(int giftId);
        Task<List<GiftWinnerDto>> GetWinnersWithUserAsync(int giftId);
    }
}
