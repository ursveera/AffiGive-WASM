using AffiGive_API_V1.Models;
using SharedLib.Models;
using System.Net.Http.Json;
using WASM.DTO;
using WASM.Pages;

namespace WASM.api
{
    public class AccountDeleteRequestApi : IAccountDeleteRequestApi
    {
        private readonly HttpClient _http;
        private const string BASE = "Gift";

        public Task<List<AccountDeletionRequest>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AccountDeletionRequest?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(AccountDeletionRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStatusAsync(int id, string status, string? remarks)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPendingRequestAsync(string googleId)
        {
            throw new NotImplementedException();
        }
    }
}
