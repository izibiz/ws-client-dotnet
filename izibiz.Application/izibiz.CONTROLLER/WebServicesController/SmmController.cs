using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.RequestSection;
using izibiz.CONTROLLER.Singleton;
using izibiz.SERVICES.serviceSmm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.WebServicesController
{
   public class SmmController
    {

        private SmmServicePortClient smmPortClient = new SmmServicePortClient();


        public SmmController()
        {
            RequestHeader.createRequestHeaderSmm();
            SearchKey.createSmmSearchKey();
        }


        /// <summary>
        /// error mesaj varsa doner yoksa null donup getırılen lısteyı db ye kaydeder
        /// </summary>
        public string getSmmListOnServiceAndSaveDb()
        {
            using (new OperationContextScope(smmPortClient.InnerChannel))
            {
                var req = new GetSmmRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderSmm;
                req.SMM_SEARCH_KEY = SearchKey.GetSearchKeySmm;

                var response = smmPortClient.GetSmm(req);
                if (response.ERROR_TYPE != null )  //error message varsa
                {
                    if (response.ERROR_TYPE.ERROR_SHORT_DES != null)
                    {
                        return response.ERROR_TYPE.ERROR_SHORT_DES;
                    }
                    return "Servisten Smm Getırme Basarısız";
                }
                else //servisten smm getırme islemi basarılıysa
                {
                    if (response.SMM != null && response.SMM.Length > 0) //getırılen smm varsa
                    {
                        //getirilen smmlerı db ye kaydetme basarılı mı ... hepsı kaydedıldı mı
                        if (Singl.smmDalGet.addSmmToDbAndSaveContentOnDisk(response.SMM) != response.SMM.Length)
                        {
                            return "DataBase'e kaydetme işlemi başarısız";
                        }

                        return null; //hiçbir hata yoksa null don
                    }
                    return null;//smm sayısı 0 ancak hata yok
                }
            }
        }
     

        public string getSmmWithUuidOnService(string uuid)
        {
            using (new OperationContextScope(smmPortClient.InnerChannel))
            {
                var req = new GetSmmRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderSmm;
                req.SMM_SEARCH_KEY = SearchKey.GetSearchKeySmm;
                req.SMM_SEARCH_KEY.READ_INCLUDED = FLAG_VALUE.Y;
                req.SMM_SEARCH_KEY.UUID = uuid;

                var smmArr = smmPortClient.GetSmm(req).SMM; //tek bır smm gelmesını beklıyoruz
                if (smmArr != null &&  smmArr.Length != 0 && smmArr[0].CONTENT != null)
                {
                    //getirilen faturanın contentını zipten cıkar,string halınde dondur
                    return Encoding.UTF8.GetString(Compress.UncompressFile(smmArr[0].CONTENT.Value));
                }
                return null;
            }
        }



        public string getSmmContentXml(string uuid)
        {
            //db den pathı getırdı           
            string xmlPath = Singl.smmDalGet.findSmmWithUuid(uuid).folderPath;

            if (FolderControl.xmlFileIsInFolder(xmlPath)) // xml dosyası verılen pathde bulunuyorsa
            {
                return File.ReadAllText(xmlPath);
            }
            else
            {
                //servisten, gonderilen uuıd ye aıt faturanın contentını getır
                return getSmmWithUuidOnService(uuid);
            }
        }

        public byte[] getSmmWithType(string uuid, CONTENT_TYPE type)
        {
            using (new OperationContextScope(smmPortClient.InnerChannel))
            {
                var req = new GetSmmRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderSmm;
                req.SMM_SEARCH_KEY = SearchKey.GetSearchKeySmm;
                req.SMM_SEARCH_KEY.UUID = uuid;
                req.CONTENT_TYPE = type;

                var response = smmPortClient.GetSmm(req);
              
                    if (response.SMM != null && response.SMM.Length > 0) //getırılen smm varsa
                    {
                        return Compress.UncompressFile(response.SMM[0].CONTENT.Value);
                    }
                    return null;//smm sayısı 0 ancak hata yok
            }
        }








    }
}
