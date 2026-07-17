using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.REST.Concrete.Mustahsil
{
    public class MustahsilListItem //apinin contents dizisindeki her bir kaydın şekli
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string DocumentNo { get; set; }
        public string IssueDate { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public MustahsilDocumentStatus DocumentStatus { get; set; }
        public MustahsilParty Sender { get; set; }
        public MustahsilParty Receiver { get; set; }
    }

    public class MustahsilDocumentStatus
    {
        public string Value { get; set; }
        public string Label { get; set; }
    }

    public class MustahsilParty
    {
        public string Identifier { get; set; }
        public string Name { get; set; }
    }
}
