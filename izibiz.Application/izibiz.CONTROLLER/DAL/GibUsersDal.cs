using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Data;
using izibiz.MODEL.DbModels;
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

        public List<GibUsers> getGibUserList()
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                return databaseContext.gibUsers.ToList();
            }
        }

        public void addGibUserList(List<GIBUSER> userList)
        {
            using (DatabaseContext databaseContext = new DatabaseContext())
            {
                GibUsers gibUsers;
                foreach (var user in userList)
                {
                    gibUsers = new GibUsers();
                    gibUsers.aliasPk = user.ALIAS;
                    gibUsers.identifier = user.IDENTIFIER;
                    gibUsers.title = user.TITLE;

                    databaseContext.gibUsers.Add(gibUsers);
                }
   
                databaseContext.SaveChanges();
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
