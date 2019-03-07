using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.MODEL.Model
{
   public class InvoiceStatus
    {

        public string statusID { get; set; }

        public string status { get; set; }

        public string statusDescription { get; set; }

        public int gibStatusCode { get; set; }

        public string gibStatusDescription { get; set; }

        public DateTime cDate { get; set; }




    }
}
