using System;

namespace izibiz.REST.Concrete.Smm
{
    public class SmmListItem 
    {
        public long Id { get; set; }
        public string Uuid { get; set; }
        public string DocumentNo { get; set; }
        public string IssueDate { get; set; }
        public string Currency { get; set; }
        public SmmDocumentStatus DocumentStatus { get; set; }
        public SmmParty Sender { get; set; }
        public SmmParty Receiver { get; set; }
    }

    public class SmmDocumentStatus
    {
        public string Value { get; set; }
        public string Label { get; set; }

        public override string ToString() => Label ?? Value;
    }

    public class SmmParty
    {
        public string Identifier { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"{Name} ({Identifier})";
    }
}
