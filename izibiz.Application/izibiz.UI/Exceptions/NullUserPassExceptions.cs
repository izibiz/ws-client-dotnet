using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.UI.Exceptions
{
    public class NullUserPassExceptions : Exception
    {
        public NullUserPassExceptions(string message) : base(message)
        {

        }
    }
}
