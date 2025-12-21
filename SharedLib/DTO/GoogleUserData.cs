namespace AffiGive_API_V1.DTO
{
    public class GoogleUserData
    {
        public string GoogleId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Name { get; set; }
        public string? ProfileImage { get; set; }
    }
}
