namespace AffiGive_API_V1.Models
{
    public class UserTaskHistory
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TaskId { get; set; }
        public int CoinsEarned { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}
