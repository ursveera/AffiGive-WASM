namespace AffiGive_API_V1.DTO
{
    public class RewardStatusResponse
    {
        public List<int> ClaimedDays { get; set; } = new();
        public int Today { get; set; }
        public bool CanClaimToday { get; set; }
    }
}
