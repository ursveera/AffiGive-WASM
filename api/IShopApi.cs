using SharedLib.Models;

namespace WASM.Api
{
    public interface IShopApi
    {
        Task<IEnumerable<ShopItems>> GetAllAsync();

        Task<ShopItems?> GetAsync(string id);

        Task<bool> CreateAsync(ShopItems item);

        Task<bool> UpdateAsync(string id, ShopItems item);

        Task<bool> DeleteAsync(string id);

        Task<bool> ForceDeleteAsync(string id);
    }
}