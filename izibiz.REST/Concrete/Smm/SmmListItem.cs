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

        public decimal Amount { get; set; }
        public string CDate { get; set; }
        public string CreateDate { get; set; }
        public string SendDate { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public string DocumentStatusLabel => DocumentStatus?.Label;

        [System.Text.Json.Serialization.JsonIgnore]
        public string ReceiverIdentifier => Receiver?.Identifier;

        [System.Text.Json.Serialization.JsonIgnore]
        public string ReceiverName => Receiver?.Name;

        [System.Text.Json.Serialization.JsonIgnore]
        public string ProfileId => "EARSIVBELGE";

        [System.Text.Json.Serialization.JsonIgnore]
        public string TypeCode => "SERBESTMESLEKMAKBUZ";

        [System.Text.Json.Serialization.JsonIgnore]
        public string SentTime => !string.IsNullOrEmpty(CDate) ? CDate : (!string.IsNullOrEmpty(CreateDate) ? CreateDate : (!string.IsNullOrEmpty(SendDate) ? SendDate : IssueDate));
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
