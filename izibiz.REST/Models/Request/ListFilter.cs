namespace izibiz.REST.Models.Request
{
    public class ListFilter
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 20;
        public string Folder { get; set; } = "outbox";
    }
}
