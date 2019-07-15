using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Data;
using izibiz.MODEL.DbTablesModels;
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
            using(DatabaseContext databaseContext = new DatabaseContext())
            {
                //db de tek bir kullanıcı kayıtlı oldugundan fırs ıle cagırabılırız
                return databaseContext.userInformations.First();
            }
        }

       


    }
}
