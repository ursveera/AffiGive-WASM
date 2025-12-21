using Newtonsoft.Json;

namespace AffiGive_API_V1.Models
{
    public class RaffleStatus
    {
        public string expiryAt { get; set; }
        public string fontSize { get; set; }
        public string title { get; set; }
        public bool winnerAnnounced { get; set; }
        public string winnerName { get; set; }
        public string code { get; set; }
    }
}
