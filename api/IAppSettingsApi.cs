using AffiGive_API_V1.DTO;
using AffiGive_API_V1.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

namespace AffigiveUIBalzor.api
{
    public interface IAppSettingsApi
    {
        Task<string> GetSettingsAsync();
        Task SaveSettingsAsync(string settings);
    }
}
