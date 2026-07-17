using System.Collections.Generic;

namespace izibiz.REST.Models
{
    public class PagedResult<TItem>
    {
        public List<TItem> Contents { get; set; } = new List<TItem>();
        public PageableInfo Pageable { get; set; }
    }

    public class PageableInfo
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
    }
}