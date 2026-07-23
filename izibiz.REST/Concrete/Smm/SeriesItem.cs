using System.Collections.Generic;

namespace izibiz.REST.Concrete.Smm
{
    public class SeriesItem
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long LastId { get; set; }
        public string Prefix { get; set; }
        public int YearPrefix { get; set; }
        public long PrevLastId { get; set; }
        public int PrevYearPrefix { get; set; }
        public bool Master { get; set; }
        public bool Active { get; set; }
        public string LastIssueDate { get; set; }
        public string SubType { get; set; }
        public List<long> AssignedUsers { get; set; }
        public string Description { get; set; }
    }
}
