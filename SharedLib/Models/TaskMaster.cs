namespace AffiGive_API_V1.Models
{
    public class TaskMaster
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public string Description { get; set; }
        public int CoinReward { get; set; }
        public bool IsActive { get; set; }
        public string TaskThumbnail { get; set; }
        public string TaskNavUrl { get; set; }
    }
}

