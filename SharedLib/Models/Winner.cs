namespace AffiGive_API_V1.Models
{
    public class Winner
    {
    public Guid Id { get; set; }
    public Guid EntryId { get; set; }
    public string? Code { get; set; }
    public DateTime DrawDate { get; set; }
    public string? Status { get; set; }
    public int SoftDelete { get; set; } = 0;
    }
}
