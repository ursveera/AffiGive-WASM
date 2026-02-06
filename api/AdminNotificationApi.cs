namespace WASM.api
{
    using SharedLib.DTO;
    using System.Net.Http.Json;

    namespace WASM.api
    {
        public class AdminNotificationApi : IAdminNotificationApi
        {
            private readonly HttpClient _http;
            private const string BASE = "AdminNotification";

            public AdminNotificationApi(HttpClient http)
            {
                _http = http;
            }

            // ---------------- MOBILE ----------------

            public async Task<AdminNotificationDto?> GetActiveAsync()
            {
                return await _http.GetFromJsonAsync<AdminNotificationDto>(
                    $"{BASE}/active"
                );
            }

            // ---------------- ADMIN ----------------

            public async Task<List<AdminNotificationDto>> GetAllAsync()
            {
                try
                {
                    return await _http.GetFromJsonAsync<List<AdminNotificationDto>>(BASE)
                           ?? new();
                }
                catch
                {
                    return new();
                }
            }

            public async Task<AdminNotificationDto?> GetByIdAsync(int id)
            {
                return await _http.GetFromJsonAsync<AdminNotificationDto>(
                    $"{BASE}/{id}"
                );
            }

            public async Task<int> CreateAsync(AdminNotificationDto model)
            {
                var res = await _http.PostAsJsonAsync(BASE, model);
                res.EnsureSuccessStatusCode();

                var result = await res.Content.ReadFromJsonAsync<CreateResult>();
                return result?.Id ?? 0;
            }

            public async Task<bool> UpdateAsync(AdminNotificationDto model)
            {
                var res = await _http.PutAsJsonAsync(
                    $"{BASE}/{model.Id}", model
                );
                return res.IsSuccessStatusCode;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var res = await _http.DeleteAsync($"{BASE}/{id}");
                return res.IsSuccessStatusCode;
            }

            // helper for create response
            private class CreateResult
            {
                public int Id { get; set; }
            }
        }
    }

}
