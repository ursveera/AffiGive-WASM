using SharedLib.Models;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WASM.Api
{
    public class GameConfigApi : IGameConfigApi
    {
        private readonly HttpClient _http;
        private const string BASE = "GameConfig";

        public GameConfigApi(HttpClient http)
        {
            _http = http;
        }

        public async Task<GameConfig?> Get()
        {
            var result = await _http.GetFromJsonAsync<GameConfig>(BASE);
            return result;
        }

        public async Task<bool> Save(GameConfig config)
        {
            var res = await _http.PutAsJsonAsync(BASE, config);
            if (!res.IsSuccessStatusCode)
            {
                var error = await res.Content.ReadAsStringAsync();
                throw new Exception($"Failed to save config: {res.StatusCode} - {error}");
            }
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> SyncFirebase()
        {
            var res = await _http.PostAsync($"{BASE}/sync", null);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAds(AdsConfiguration ads)
        {
            var res = await _http.PutAsJsonAsync($"{BASE}/ads", ads);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCoins(CoinConfiguration coins)
        {
            var res = await _http.PutAsJsonAsync($"{BASE}/coins", coins);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateApp(Config app)
        {
            var res = await _http.PutAsJsonAsync($"{BASE}/app", app);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateGameTime(GameTimeManager time)
        {
            var res = await _http.PutAsJsonAsync($"{BASE}/time", time);
            return res.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<CharacterConfiguration>> GetCharacters()
        {
            try
            {
                var data = await _http.GetFromJsonAsync<IEnumerable<CharacterConfiguration>>($"{BASE}/characters");

                return (data ?? Enumerable.Empty<CharacterConfiguration>())
                       .Where(x => x != null);
            }
            catch
            {
                return Enumerable.Empty<CharacterConfiguration>();
            }
        }

        public async Task<bool> InsertCharacter(CharacterConfiguration character)
        {
            var res = await _http.PostAsJsonAsync($"{BASE}/characters", character);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCharacter(CharacterConfiguration character)
        {
            var res = await _http.PutAsJsonAsync($"{BASE}/characters/{character.Id}", character);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteCharacter(int id)
        {
            var res = await _http.DeleteAsync($"{BASE}/characters/{id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<LevelConfiguration>> GetLevels()
        {
            try
            {
                var data = await _http.GetFromJsonAsync<IEnumerable<LevelConfiguration>>($"{BASE}/levels");

                return (data ?? Enumerable.Empty<LevelConfiguration>())
                           .Where(x => x != null);
            }
            catch
            {
                return Enumerable.Empty<LevelConfiguration>();


            }
        }

        public async Task<bool> InsertLevel(LevelConfiguration level)
        {
            var res = await _http.PostAsJsonAsync($"{BASE}/levels", level);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateLevel(LevelConfiguration level)
        {
            var res = await _http.PutAsJsonAsync($"{BASE}/levels/{level.Id}", level);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteLevel(int id)
        {
            var res = await _http.DeleteAsync($"{BASE}/levels/{id}");
            return res.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ShopItems>> GetShopItems()
        {
            return await _http.GetFromJsonAsync<IEnumerable<ShopItems>>($"{BASE}/shop")
                   ?? Enumerable.Empty<ShopItems>();
        }

        public async Task<bool> InsertShopItem(ShopItems item)
        {
            var res = await _http.PostAsJsonAsync($"{BASE}/shop", item);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateShopItem(ShopItems item)
        {
            var res = await _http.PutAsJsonAsync($"{BASE}/shop/{item.Id}", item);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteShopItem(string id)
        {
            var res = await _http.DeleteAsync($"{BASE}/shop/{id}");
            return res.IsSuccessStatusCode;
        }
    }
}