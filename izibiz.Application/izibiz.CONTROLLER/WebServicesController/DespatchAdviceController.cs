using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.InvoiceRequestSection;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbTablesModels;
using izibiz.SERVICES.serviceDespatch;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.WebServicesController
{

    public class DespatchAdviceController
    {


        private EIrsaliyeServicePortClient eDespatchPortClient = new EIrsaliyeServicePortClient();

        List<DESPATCHADVICE> despatchList = new List<DESPATCHADVICE>();



        public DespatchAdviceController()
        {
            InvoiceSearchKey.createDespatchSearchKey();
            RequestHeader.createRequestHeaderDespatch();
        }



        public string despatchListSaveDbFromService(string direction)
        {
            using (new OperationContextScope(eDespatchPortClient.InnerChannel))
            {
                GetDespatchAdviceRequest req = new GetDespatchAdviceRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderDespatch;
                req.SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetDespatch;
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();
                req.SEARCH_KEY.DIRECTION = direction;

                GetDespatchAdviceResponse response = eDespatchPortClient.GetDespatchAdvice(req);

                if (response.ERROR_TYPE != null)  //error message varsa
                {
                    return response.ERROR_TYPE.ERROR_SHORT_DES;
                }
                else //servisten irsalıye getırme islemi basarılıysa
                {
                    if (response.DESPATCHADVICE != null && response.DESPATCHADVICE.Length > 0) //getırılen ırsalıye varsa
                    {
                        //string markErrorMessage = despatchMarkRead(response.DESPATCHADVICE); //mark despatch yapıldı
                        //if (markErrorMessage != null) //mark despatch dan donen error message varsa
                        //{
                        //    return markErrorMessage;
                        //}
                        //getirilen faturaları db ye kaydetme basarılı mı ... hepsı kaydedıldı mı
                        if (Singl.DespatchAdviceDalGet.addDespatchFromServiceAndSaveContentOnDisk(response.DESPATCHADVICE, direction) != response.DESPATCHADVICE.Length)
                        {
                            return "DataBase'e kaydetme işlemi başarısız";
                        }

                        return null; //hiçbir hata yoksa null don
                    }
                    return "Servisten Getirilecek İrsaliye Bulunamadı";
                }
            }
        }




        public string getDespatchContentFromService(string uuid, string direction)
        {
            using (new OperationContextScope(eDespatchPortClient.InnerChannel))
            {
                GetDespatchAdviceRequest req = new GetDespatchAdviceRequest();
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderDespatch;
                req.SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetDespatch;
                req.SEARCH_KEY.READ_INCLUDED = true;  //okunmus olabilir
                req.SEARCH_KEY.READ_INCLUDEDSpecified = true;
                req.SEARCH_KEY.UUID = uuid;
                req.SEARCH_KEY.DIRECTION = direction;
                GetDespatchAdviceResponse response = eDespatchPortClient.GetDespatchAdvice(req);

                if (response.ERROR_TYPE == null)
                {
                    if (response.DESPATCHADVICE != null && response.DESPATCHADVICE.Length > 0
                        && response.DESPATCHADVICE[0].CONTENT != null && response.DESPATCHADVICE[0].CONTENT.Value != null) //getırılen ırsalıye varsa
                    {
                        return Encoding.UTF8.GetString(Compress.UncompressFile(response.DESPATCHADVICE[0].CONTENT.Value));
                    }
                }
                return null;
            }
        }



        private string despatchMarkRead(DESPATCHADVICE[] despatchArr)
        {
            using (new OperationContextScope(eDespatchPortClient.InnerChannel))
            {

                MarkDespatchAdviceRequest markReq = new MarkDespatchAdviceRequest();
                markReq.REQUEST_HEADER = RequestHeader.getRequestHeaderDespatch;

                MarkDespatchAdviceRequestMARK markDespatch = new MarkDespatchAdviceRequestMARK();
                markDespatch.value = MarkDespatchAdviceRequestMARKValue.READ;
                markDespatch.valueSpecified = true;
                markReq.MARK = markDespatch;

                DESPATCHADVICEINFO[] despatchAdviceInfoArr = new DESPATCHADVICEINFO[despatchArr.Length];
                DESPATCHADVICEINFO despatchAdviceInfo;

                for (int i = 0; i < despatchArr.Length; i++)
                {

                    despatchAdviceInfo = new DESPATCHADVICEINFO();
                    despatchAdviceInfo.DESPATCHADVICEHEADER = despatchArr[i].DESPATCHADVICEHEADER;
                    despatchAdviceInfo.UUID = despatchArr[i].UUID;
                    despatchAdviceInfo.ID = despatchArr[i].ID;
                    despatchAdviceInfo.DIRECTION = despatchArr[i].DIRECTION;

                    despatchAdviceInfoArr[i] = despatchAdviceInfo;
                }
                markReq.MARK.DESPATCHADVICEINFO = despatchAdviceInfoArr;

                MarkDespatchAdviceResponse markResponse = eDespatchPortClient.MarkDespatchAdvice(markReq);

                if (markResponse.REQUEST_RETURN == null || markResponse.ERROR_TYPE != null) //hata varsa
                {
                    return markResponse.ERROR_TYPE.ERROR_SHORT_DES;//hatayı don
                }
                return null; //basarılıysa null don

            }
        }





        public string getDespatchStatusAndSaveDb(string direction, string[] uuidArr)
        {
            using (new OperationContextScope(eDespatchPortClient.InnerChannel))
            {
                GetDespatchAdviceStatusRequest req = new GetDespatchAdviceStatusRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderDespatch;

                req.UUID = uuidArr;

                GetDespatchAdviceStatusResponse response = eDespatchPortClient.GetDespatchAdviceStatus(req);

                if (response.ERROR_TYPE != null)  //error message varsa
                {
                    return response.ERROR_TYPE.ERROR_SHORT_DES;
                }
                else //servisten irsalıye durumu getırme islemi basarılıysa
                {
                    if (response.DESPATCHADVICE_STATUS != null && response.DESPATCHADVICE_STATUS[0] != null) //getırılen ırsalıye varsa
                    {
                        //getirilen faturaları db ye kaydetme basarılı mı ... hepsı kaydedıldı mı
                        if (Singl.DespatchAdviceDalGet.addDespatchStatusFromService(response.DESPATCHADVICE_STATUS, direction) != uuidArr.Length)
                        {
                            return "DataBase'e kaydetme işlemi başarısız";
                        }

                        return null; //hiçbir hata yoksa null don
                    }
                    return "Servisten Getirilecek İrsaliye Durumu Bulunamadı";
                }
            }
        }




        public string getDespatchContentXml(string uuid, string direction)
        {
            //db den pathı getırdı
            string xmlPath = Singl.DespatchAdviceDalGet.getDespatch(uuid, direction).folderPath;

            if (!FolderControl.xmlFileIsInFolder(xmlPath)) // xml dosyası verılen pathde bulunmuyorsa
            {
                //servisten, gonderilen uuıd ye aıt faturanın contentını getır
                return getDespatchContentFromService(uuid, direction);
            }
            else
            {
                return File.ReadAllText(xmlPath);
            }
        }

        public void createDespatchListWithContent(string xmlStr)
        {
            DESPATCHADVICE despatch = new DESPATCHADVICE();
            base64Binary contentByte = new base64Binary();
            contentByte.Value = Encoding.UTF8.GetBytes(xmlStr);

            despatch.CONTENT = contentByte;

            despatchList.Add(despatch);
        }



        public string loadDespatchToService()
        {
            using (new OperationContextScope(eDespatchPortClient.InnerChannel))
            {
                LoadDespatchAdviceRequest req = new LoadDespatchAdviceRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderDespatch;
                req.REQUEST_HEADER.COMPRESSED = nameof(EI.ActiveOrPasive.N);//ziplenmeden gonderılır
                req.DESPATCHADVICE = despatchList.ToArray();

                LoadDespatchAdviceResponse response = eDespatchPortClient.LoadDespatchAdvice(req);
                despatchList.Clear();

                if (response.ERROR_TYPE != null || response.REQUEST_RETURN == null || response.REQUEST_RETURN.RETURN_CODE != 0)  //işlem basarısızsa
                {
                    return response.ERROR_TYPE.ERROR_SHORT_DES;
                }
                return null;//işlem basarılıysa null don
            }
        }



        public string sendDespatch(string receiverAlias)
        {
            using (new OperationContextScope(eDespatchPortClient.InnerChannel))
            {
                var req = new SendDespatchAdviceRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderDespatch;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();

                req.SENDER = new SendDespatchAdviceRequestSENDER();
                req.RECEIVER = new SendDespatchAdviceRequestRECEIVER();
                req.RECEIVER.alias = receiverAlias;

                req.DESPATCHADVICE = despatchList.ToArray();

                despatchList.Clear();
                var response = eDespatchPortClient.SendDespatchAdvice(req);

                if (response.ERROR_TYPE != null || response.REQUEST_RETURN == null || response.REQUEST_RETURN.RETURN_CODE != 0 )  //işlem basarısızsa
                {
                    return response.ERROR_TYPE.ERROR_SHORT_DES;
                }
                return null;//işlem basarılıysa null don
            }
        }





    }
}







