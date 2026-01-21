using SharedLib.Models;

namespace WASM.api
{
    public interface IFaqApi
    {
        Task<IEnumerable<Faq>> GetAllForAdminAsync();
        Task<IEnumerable<Faq>> GetActiveForUserAsync();
        Task<Faq?> GetByIdAsync(int id);
        Task<int> CreateAsync(Faq faq);
        Task<bool> UpdateAsync(int id, Faq faq);
        Task<bool> DeleteAsync(int id);
    }
}
