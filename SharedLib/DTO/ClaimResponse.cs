namespace AffiGive_API_V1.DTO
{
    public class ClaimResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? ClaimedDay { get; set; }
    }
}
