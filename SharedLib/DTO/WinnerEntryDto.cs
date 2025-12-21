namespace AffiGive_API_V1.DTO
{
    public class WinnerEntryDto
    {
        // Winner fields
        public Guid WinnerId { get; set; }
        public Guid EntryId { get; set; }
        public string Code { get; set; }
        public DateTime DrawDate { get; set; }
        public string Status { get; set; }
        public int SoftDelete { get; set; }

        // Entry fields
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsValid { get; set; }
    }
}
