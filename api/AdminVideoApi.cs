using AffiGive_API_V1.DTO;
using AffiGive_API_V1.Models;
using System.Net.Http.Json;

namespace AffigiveUIBalzor.api
{
    public class AdminVideoApi : IAdminVideoApi
    {
        private readonly HttpClient _httpClient;

        // Base endpoint for this controller
        private const string _endpoint = "AdminVideos";

        public AdminVideoApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET ALL VIDEOS
        public async Task<PagedResult<Video>> GetAll(int page, int pageSize)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<PagedResult<Video>>(
                    $"{_endpoint}/GetAllVideos?page={page}&pageSize={pageSize}"
                ) ?? new PagedResult<Video>();
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        // SEARCH VIDEOS
        public async Task<PagedResult<Video>> Search(string code, int page, int pageSize)
        {
            return await _httpClient.GetFromJsonAsync<PagedResult<Video>>(
                $"{_endpoint}/SearchByCode?code={code}&page={page}&pageSize={pageSize}"
            ) ?? new PagedResult<Video>();
        }

        // GET BY CODE
        public async Task<Video?> GetByCode(string code)
        {
            return await _httpClient.GetFromJsonAsync<Video>(
                $"{_endpoint}/{code}/GetByCode"
            );
        }

        // ADD NEW VIDEO
        public async Task<bool> Add(Video video)
        {
            var response = await _httpClient.PostAsJsonAsync(
                $"{_endpoint}/AddVideo", video
            );

            return response.IsSuccessStatusCode;
        }

        // UPDATE VIDEO
        public async Task<bool> Update(Video video)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"{_endpoint}/UpdateVideo", video
            );

            return response.IsSuccessStatusCode;
        }

        // DELETE BY CODE
        public async Task<bool> DeleteByCode(string code)
        {
            var response = await _httpClient.DeleteAsync(
                $"{_endpoint}/{code}/DeleteByCode"
            );

            return response.IsSuccessStatusCode;
        }

        // DELETE BY ID
        public async Task<bool> DeleteById(Guid id)
        {
            var response = await _httpClient.DeleteAsync(
                $"{_endpoint}/{id}/DeleteById"
            );

            return response.IsSuccessStatusCode;
        }
    }
}
