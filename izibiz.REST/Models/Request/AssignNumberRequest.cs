using System.Collections.Generic;

namespace izibiz.REST.Models.Request
{
    public class AssignNumberRequest
    {
        public List<long> Documents { get; set; }
        public string Prefix { get; set; }
        public bool AutoSend { get; set; }
    }
}
