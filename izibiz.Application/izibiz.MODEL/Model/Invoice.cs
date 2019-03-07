using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.MODEL.Model
{
  public  class Invoice
    {

        public string ID { get; set; }
        public string ettn { get; set; }
        public DateTime issueDate { get; set; }
        public string profileid { get; set; }
        public string type { get; set; }
        public string supplier { get; set; }
        public string sender { get; set; }
        public DateTime cDate { get; set; }
        public string envelopeIdentifier { get; set; }
        public string status { get; set; }
        public int gibStatus { get; set; }
        public string gibSatusDescription { get; set; }
        public string Uuid { get; set; }
        public string from { get; set; }
        public string to { get; set; }

    }
}
