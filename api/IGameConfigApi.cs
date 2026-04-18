using SharedLib.Models;

namespace WASM.Api
{
    public interface IGameConfigApi
    {
        public Task<GameConfig?> Get();
        public Task<bool> Save(GameConfig config);
        public Task<bool> SyncFirebase();
        public Task<bool> UpdateAds(AdsConfiguration ads);
        public Task<bool> UpdateCoins(CoinConfiguration coins);
        public Task<bool> UpdateApp(Config app);
        public Task<bool> UpdateGameTime(GameTimeManager time);
        public Task<IEnumerable<CharacterConfiguration>> GetCharacters();
        public Task<bool> InsertCharacter(CharacterConfiguration character);
        public Task<bool> UpdateCharacter(CharacterConfiguration character);
        public Task<bool> DeleteCharacter(int id);

        public Task<IEnumerable<LevelConfiguration>> GetLevels();
        public Task<bool> InsertLevel(LevelConfiguration level);
        public Task<bool> UpdateLevel(LevelConfiguration level);
        public Task<bool> DeleteLevel(int id);

        public Task<IEnumerable<ShopItems>> GetShopItems();
        public Task<bool> InsertShopItem(ShopItems item);
        public Task<bool> UpdateShopItem(ShopItems item);
        public Task<bool> DeleteShopItem(string id);
    }
}