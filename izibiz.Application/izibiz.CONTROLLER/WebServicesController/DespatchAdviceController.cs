using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.InvoiceRequestSection;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbModels;
using izibiz.SERVICES.serviceDespatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.WebServicesController
{
    public class DespatchAdviceController
    {

        private EIrsaliyeServicePortClient eDespatchPortClient = new EIrsaliyeServicePortClient();


        public DespatchAdviceController()
        {
            InvoiceSearchKey.createDespatchSearchKey();
            RequestHeader.createRequestHeaderDespatch();
        }



        public string despatchListSaveDbFromService(string direction)
        {
            using (new OperationContextScope(eDespatchPortClient.InnerChannel))
            {
                var req = new GetDespatchAdviceRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderDespatch;
                req.SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetDespatch;
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();
                req.SEARCH_KEY.DIRECTION = direction;


                GetDespatchAdviceResponse response = eDespatchPortClient.GetDespatchAdvice(req);

                if (response.ERROR_TYPE != null)  //error message yoksa
                {
                    return response.ERROR_TYPE.ERROR_SHORT_DES;
                }
                else //servisten getırme islemi basarılıysa
                {
                    if (response.DESPATCHADVICE != null && response.DESPATCHADVICE.Length > 0)
                    {
                        despatchMarkRead(response.DESPATCHADVICE);
                        //getirilen faturaları db ye kaydetme basarılı mı ... hepsı kaydedıldı mı
                        if (Singl.DespatchAdviceDalGet.addDespatchFromDespatchAdviceAndSaveContentOnDisk(response.DESPATCHADVICE, direction) != response.DESPATCHADVICE.Length)
                        {
                            return "DataBase'e kaydetme işlemi başarısız";
                        }
                        return null; //bir hata yoksa null don
                    }
                    return "Servisten Getirilecek İrsaliye Bulunamadı";
                }
            }
        }



        private void despatchMarkRead(DESPATCHADVICE[] despatchList)
        {
            using (new OperationContextScope(eDespatchPortClient.InnerChannel))
            {
                int i = 0;

                var markReq = new MarkDespatchAdviceRequest();
                foreach (var des in despatchList)
                {
                  
                    markReq.REQUEST_HEADER = RequestHeader.getRequestHeaderDespatch;

                    MarkDespatchAdviceRequestMARK mark = new MarkDespatchAdviceRequestMARK();
                    mark.value = MarkDespatchAdviceRequestMARKValue.READ;
                    mark.valueSpecified = true;
                    markReq.MARK = mark;


                   DESPATCHADVICEINFO[] despatchAdviceInfoArr = new DESPATCHADVICEINFO[despatchList.Length];
                    despatchAdviceInfoArr[i].DESPATCHADVICEHEADER = des.DESPATCHADVICEHEADER;



                    markReq.MARK.DESPATCHADVICEINFO = despatchAdviceInfoArr;
                    i++;
                }
                MarkDespatchAdviceResponse markRes = eDespatchPortClient.MarkDespatchAdvice(markReq);




                int il = 0;
            }
        }








    }
}






