using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.REST.Infrastructure 
{
    public class RestApiOptions //her ürün ortak kullanacak
    {
        public string BaseUrl { get; set; } = "https://apitest.izibiz.com.tr"; //apinin adresi
        public string Version { get; set; } = "v2";
        public string Username { get; set; }
        public string Password { get; set; }
        public string ErpCode { get; set; } = "erp-code";
    }

}
