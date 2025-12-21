namespace AffiGive_API_V1.DTO
{
    public class PagedResult<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
