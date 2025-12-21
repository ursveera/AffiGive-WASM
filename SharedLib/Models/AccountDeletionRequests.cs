namespace AffiGive_API_V1.Models
{
    public class AccountDeletionRequest
    {
        public int Id { get; set; }                 
        public string UserEmail { get; set; }       
        public DateTime RequestTime { get; set; }   
        public string Status { get; set; }         
        public DateTime? ProcessedTime { get; set; }
        public string Remarks { get; set; }         
    }
}
