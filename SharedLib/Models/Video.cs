namespace AffiGive_API_V1.Models
{
    public class Video
    {
        public Guid Id { get; set; }
        public string Code { get; set; }          // Video code for giveaway
        public string? Title { get; set; }        // Optional title
        public string? ThumbnailUrl { get; set; } // Thumbnail image URL
        public string? VideoUrl { get; set; }     // YouTube video URL
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
