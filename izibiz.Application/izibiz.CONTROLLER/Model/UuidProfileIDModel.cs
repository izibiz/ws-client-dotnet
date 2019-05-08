using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.Model
{
    public class UuidProfileIDModel
    {
        private static int count ;


        public UuidProfileIDModel(int cnt)
        {
            count = cnt;
        }

       
        public string[] uuidArr = new string[count];

        public string[] profileIDArr = new string[count];
       

    }
}
