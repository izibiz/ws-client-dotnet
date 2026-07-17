using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.REST.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }
    }
}
