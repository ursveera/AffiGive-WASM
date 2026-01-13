using SharedLib.Models;

namespace WASM.api
{
    public interface ISourceLimitApi
    {
        Task CreateAsync(SourceLimit model);
        Task<List<SourceLimit>> GetAllAsync();
        Task<SourceLimit?> GetAsync(string source);
        Task UpdateAsync(SourceLimit model);
        Task DeleteAsync(string source);
    }
}
