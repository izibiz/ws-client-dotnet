using izibiz.CONTROLLER.Model;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Data;
using izibiz.MODEL.DbTablesModels;
using izibiz.SERVICES.serviceOib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.DAL
{
    public class GibUsersDal
    {

        public List<string> getGibUserAliasList(string vknTckn)
        {
            List<string> listAlias = new List<string>();

            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                List<GibUsers> userList = databaseContext.gibUsers.Where(usr => usr.identifier == vknTckn).ToList();
         
                foreach (GibUsers user in userList)
                {
                    listAlias.Add(user.aliasPk);
                }
            }

            return listAlias;
        }

        public List<GibUsers> getGibUserList(string productType)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.gibUsers.Where(gibUser => gibUser.productType== productType).ToList();
            }
        }

        public int addGibUserList(GibUserListXmlModel userList)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                GibUsers gibUser;
         
                foreach (var user in userList.Items)
                {
                    gibUser = new GibUsers();
                    gibUser.aliasPk = user.alias;
                    gibUser.identifier = user.identifier;
                    gibUser.title = user.title;
                    gibUser.productType = user.documentTpye;

                  //  databaseContext.gibUsers.Add(gibUser);
                 
                    if (user.identifier == "4840847211")
                    {
                        databaseContext.gibUsers.Add(gibUser);
                    }
                }
   
              return  databaseContext.SaveChanges();
            }

        }

        public void addGibUser(string aliasPk, string identifier, string title)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                GibUsers gibUsers = new GibUsers();
                gibUsers.aliasPk = aliasPk;
                gibUsers.identifier = identifier;
                gibUsers.title = title;

                databaseContext.gibUsers.Add(gibUsers);
                databaseContext.SaveChanges();
            }
        
        }


      

    }
}
