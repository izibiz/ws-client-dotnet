using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbTablesModels;



namespace izibiz.CONTROLLER
{
    public class InvoiceIdSetSerilaze
    {
        public static string[] createNewInvId(string idSeriName, int idCount)
        {
           string[] newIdSeriArr = new string[idCount];

            string firstSeriNo;
            string serialName = idSeriName;
            string year = DateTime.Now.Year.ToString();
         

            //db den bu serinameye ait son eklenen id serilazeyı getır
            InvoiceIdSerials lastAddedIdserial = Singl.invIdSerilazeDalGet.getLastAddedSeri(idSeriName);

            //getırılen ıd serılazenın son eklenen ıd varsa ve yılı bu yılsa
            if (lastAddedIdserial.seriNo != null && lastAddedIdserial.year == year)
            {
                //baslangıc id si db den gelen id nin +1 arttır     
                firstSeriNo = (Convert.ToInt32(lastAddedIdserial.seriNo) + 1).ToString();
            }
            else
            {
                firstSeriNo = "000000001";
            }

            //new ıd arrayını doldur
            for (int i = 0; i < idCount; i++)
            {
                //onune uzunlugu 9 yapacak kadar 0 koy
                newIdSeriArr[i] = idSeriName+ year+ firstSeriNo.ToString().PadLeft(9, '0'); 

                //serı noyu +1 arttır ve  
                firstSeriNo = (Convert.ToInt32(firstSeriNo) + 1).ToString();        
            }

             return newIdSeriArr;
        }


        //public static string[] createNewInvId(string idSeriName, int idCount)
        //{
        //   string[] newIdSeriArr = new string[idCount];

        //    string firstSeriNo;
        //    string serialName = idSeriName;
        //    string year = DateTime.Now.Year.ToString();
         

        //    //db den bu serinameye ait son eklenen id serilazeyı getır
        //    InvoiceIdSerials lastAddedIdserial = Singl.invIdSerilazeDalGet.getLastAddedSeri(idSeriName);

        //    //getırılen ıd serılazenın son eklenen ıd varsa ve yılı bu yılsa
        //    if (lastAddedIdserial.seriNo != null && lastAddedIdserial.year == year)
        //    {
        //        //baslangıc id si db den gelen id nin +1 arttır     
        //        firstSeriNo = (Convert.ToInt32(lastAddedIdserial.seriNo) + 1).ToString();
        //    }
        //    else
        //    {
        //        firstSeriNo = "000000001";
        //    }

        //    //new ıd arrayını doldur
        //    for (int i = 0; i < idCount; i++)
        //    {
        //        //onune uzunlugu 9 yapacak kadar 0 koy
        //        newIdSeriArr[i] = idSeriName+ year+ firstSeriNo.ToString().PadLeft(9, '0'); 

        //        //serı noyu +1 arttır ve  
        //        firstSeriNo = (Convert.ToInt32(firstSeriNo) + 1).ToString();        
        //    }

        //    return newIdSeriArr;
        //}



    }
}
