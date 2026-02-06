using AffiGive_API_V1.DTO;
using AffiGive_API_V1.Models;
using System.Net.Http.Json;

namespace AffigiveUIBalzor.api
{
    public interface IWinnerApiGateway
    {
        Task<Winner?> PickWinnerAsync(string code);
        Task<List<Winner>> GetWinnersByCodeAsync(string code);
        Task<List<Winner>> GetAllWinnersAsync();
        Task<bool> DeleteWinnerAsync(string code);
        Task<List<WinnerEntryDto>> GetWinnerEntriesByCodeAsync(string code);
        Task<List<WinnerEntryDto>> GetAllWinnerEntriesAsync();

        // ----- New CRUD -----
        Task<bool> AddWinnerAsync(Winner winner);
        Task<Winner?> GetWinnerByIdAsync(Guid id);
        Task<List<Winner>> GetAllAsync();
        Task<bool> UpdateWinnerAsync(Winner winner);
        Task<bool> DeleteWinnerByIdAsync(Guid id);
        Task<bool> ForceDeleteWinnerAsync(Guid id);
    }

    public class WinnerApiGateway : IWinnerApiGateway
    {
        private readonly HttpClient _http;
        private const string _endpoint = "Winners";

        public WinnerApiGateway(HttpClient http)
        {
            _http = http;
        }

        // -------------------- PICK WINNER --------------------
        public async Task<Winner?> PickWinnerAsync(string code)
        {
            try
            {
                var response = await _http.PostAsJsonAsync(
                    $"{_endpoint}/AddWinnerByCode/{code}",
                    new { }  // empty body (required for POST)
                );

                if (!response.IsSuccessStatusCode)
                    return null;

                return await response.Content.ReadFromJsonAsync<Winner>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PickWinnerAsync ERROR: {ex.Message}");
                return null;
            }
        }

        // -------------------- GET WINNERS BY CODE --------------------
        public async Task<List<Winner>> GetWinnersByCodeAsync(string code)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<Winner>>(
                    $"{_endpoint}/GetWinnerByCode/{code}")
                    ?? new List<Winner>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetWinnersByCodeAsync ERROR: {ex.Message}");
                return new List<Winner>();
            }
        }

        // -------------------- GET ALL WINNERS --------------------
        public async Task<List<Winner>> GetAllWinnersAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<Winner>>(
                    $"{_endpoint}/GetAllWinnerEntries")
                    ?? new List<Winner>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllWinnersAsync ERROR: {ex.Message}");
                return new List<Winner>();
            }
        }

        // -------------------- DELETE WINNER --------------------
        public async Task<bool> DeleteWinnerAsync(string code)
        {
            try
            {
                var res = await _http.DeleteAsync(
                    $"{_endpoint}/DeleteWinnerByCode/{code}");

                return res.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteWinnerAsync ERROR: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> ForceDeleteWinnerAsync(Guid id)
        {
            var res = await _http.DeleteAsync(
                    $"{_endpoint}/ForceDeleteWinnerById/{id}");
            return res.IsSuccessStatusCode;
        }

        // -------------------- GET WINNER ENTRIES BY CODE --------------------
        public async Task<List<WinnerEntryDto>> GetWinnerEntriesByCodeAsync(string code)
        {
            try
            {
                return await _http.GetFromJsonAsync<List<WinnerEntryDto>>(
                    $"{_endpoint}/GetWinnerEntriesByCode/{code}")
                    ?? new List<WinnerEntryDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetWinnerEntriesByCodeAsync ERROR: {ex.Message}");
                return new List<WinnerEntryDto>();
            }
        }

        // -------------------- GET ALL WINNER + ENTRY JOIN --------------------
        public async Task<List<WinnerEntryDto>> GetAllWinnerEntriesAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<WinnerEntryDto>>(
                    $"{_endpoint}/GetAllWinnerEntries")
                    ?? new List<WinnerEntryDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAllWinnerEntriesAsync ERROR: {ex.Message}");
                return new List<WinnerEntryDto>();
            }
        }

        // -------------------- CRUD (added last) --------------------

        public async Task<bool> AddWinnerAsync(Winner winner)
        {
            try
            {
                var res = await _http.PostAsJsonAsync($"{_endpoint}/AddWinner", winner);
                return res.IsSuccessStatusCode;
            }
            catch { return false; }
        }

        public async Task<Winner?> GetWinnerByIdAsync(Guid id)
        {
            try
            {
                return await _http.GetFromJsonAsync<Winner>($"{_endpoint}/GetWinnerById/{id}");
            }
            catch { return null; }
        }

        public async Task<List<Winner>> GetAllAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<Winner>>($"{_endpoint}/GetAll")
                       ?? new List<Winner>();
            }
            catch { return new List<Winner>(); }
        }

        public async Task<bool> UpdateWinnerAsync(Winner winner)
        {
            try
            {
                var res = await _http.PutAsJsonAsync($"{_endpoint}/UpdateWinner", winner);
                return res.IsSuccessStatusCode;
            }
            catch { return false; }
        }

        public async Task<bool> DeleteWinnerByIdAsync(Guid id)
        {
            try
            {
                var res = await _http.DeleteAsync($"{_endpoint}/DeleteWinner/{id}");
                return res.IsSuccessStatusCode;
            }
            catch { return false; }
        }
    }
}
