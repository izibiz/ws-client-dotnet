using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.MODEL.Dto
{
  public  class Invoices
    {

        public string faturaNumarası { get; set; }
        public string ettn { get; set; }
        public DateTime faturaTarihi { get; set; }
        public string senaryo { get; set; }
        public string faturaTipi { get; set; }
        public string gönderenUnvan { get; set; }
        public string gönderenVknTckn { get; set; }
        public DateTime ulastıgiTarih { get; set; }
        public string zarfID { get; set; }
        public string durum { get; set; }
        public int gibDurum { get; set; }
        public string gibDurumAciklama { get; set; }
        public string uygulamaYanitDurumu { get; set; }
        public string gönderenGB { get; set; }
        public string alıcıPK { get; set; }

    }
}
