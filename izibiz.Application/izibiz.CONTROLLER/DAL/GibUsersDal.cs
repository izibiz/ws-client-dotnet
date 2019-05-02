using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbModels;
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
            List<GibUsers> userList = Singl.databaseContextGet.gibUsers.Where(usr => usr.identifier == vknTckn).ToList();

            List<string> listAlias = new List<string>();
            foreach (GibUsers user in userList)
            {
                listAlias.Add(user.aliasPk);
            }

            return listAlias;
        }


        public void addGibUser(string aliasPk, string identifier, string title)
        {
            GibUsers gibUsers = new GibUsers();
            gibUsers.aliasPk = aliasPk;
            gibUsers.identifier = identifier;
            gibUsers.title = title;

            Singl.databaseContextGet.gibUsers.Add(gibUsers);
        }


        public void dbSaveChanges()
        {
            Singl.databaseContextGet.SaveChanges();
        }

    }
}
