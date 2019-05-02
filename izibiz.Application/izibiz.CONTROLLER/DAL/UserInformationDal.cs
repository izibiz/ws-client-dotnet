using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.DAL
{
   public class UserInformationDal
    {


        public UserInformation getUserInformation()
        {
            //db de tek bir kullanıcı kayıtlı oldugundan fırs ıle cagırabılırız
            return Singl.databaseContextGet.userInformations.First();
        }

       


    }
}
