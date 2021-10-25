using izibiz.COMMON;
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER.RequestSection;
using izibiz.CONTROLLER.Singleton;
using izibiz.SERVICES.serviceCreditNote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.WebServicesController
{
    public class CreditNoteController
    {

        private CreditNoteServicePortClient CreditNotePortClient = new CreditNoteServicePortClient();


        public CreditNoteController()
        {
            RequestHeader.createRequestHeaderCreditNote();
            SearchKey.createCreditNoteSearchKey();
        }


        /// <summary>
        /// error mesaj varsa doner yoksa null donup getırılen lısteyı db ye kaydeder
        /// </summary>
        public string getCreditNoteListOnServiceAndSaveDb()
        {
            using (new OperationContextScope(CreditNotePortClient.InnerChannel))
            {
                var req = new GetCreditNoteRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderCreditNotes;
                req.CREDITNOTE_SEARCH_KEY = SearchKey.GetSearchKeyCreditNotes;

                var response = CreditNotePortClient.GetCreditNote(req);
                if (response.ERROR_TYPE != null)  //error message varsa
                {
                    if (response.ERROR_TYPE.ERROR_SHORT_DES != null)
                    {
                        return response.ERROR_TYPE.ERROR_SHORT_DES;
                    }
                    return "Servisten CreditNote Getırme Basarısız";
                }
                else //servisten smm getırme islemi basarılıysa
                {
                    if (response.CREDITNOTE != null && response.CREDITNOTE.Length > 0) //getırılen smm varsa
                    {
                        string markErrorMessage = creditNoteMarkRead(response.CREDITNOTE);
                        if (markErrorMessage != null) //mark despatch dan donen error message varsa
                        {
                            return markErrorMessage;
                        }
                        //getirilen smmlerı db ye kaydetme basarılı mı ... hepsı kaydedıldı mı
                        if (Singl.creditNotesDalGet.addCreditNoteToDbAndSaveContentOnDisk(response.CREDITNOTE,"N") == response.CREDITNOTE.Length)
                        {
                        }
                        else
                        {
                            return "DataBase'e kaydetme işlemi başarısız";
                        }

                        return null; //hiçbir hata yoksa null don
                    }
                    return null;//smm sayısı 0 ancak hata yok
                }
            }
        }

        private string creditNoteMarkRead(CREDITNOTE[] creditNoteList)
        {
            using (new OperationContextScope(CreditNotePortClient.InnerChannel))
            {
                var markReq = new MarkCreditNoteRequest(); //sistemdeki gelen efatura listesi için request parametreleri

                markReq.REQUEST_HEADER = RequestHeader.getRequestHeaderCreditNotes;
                markReq.MARK = new MarkCreditNoteRequestMARK();
                markReq.MARK.UUID = new String[creditNoteList.Length];
                markReq.MARK.value = "READ";
                List<CREDITNOTE> listInvoiceMark = new List<CREDITNOTE>();
                for (int i = 0; i < creditNoteList.Length; i++)
                {
                    CREDITNOTE inv = new CREDITNOTE();
                    inv.ID = creditNoteList[i].ID;
                    inv.UUID = creditNoteList[i].UUID;
                    markReq.MARK.UUID[i] = creditNoteList[i].UUID; 
                    listInvoiceMark.Add(inv);
                }
                
                MarkCreditNoteResponse markRes = CreditNotePortClient.MarkCreditNote(markReq);

                if (markRes.REQUEST_RETURN != null && markRes.REQUEST_RETURN.RETURN_CODE == 0)//basarılıysa
                {
                    return null;
                }
                else
                {
                    return "mark creditnote basarısız";
                }
            }
        }

        public string getCreditNoteWithUuidOnService(string id)
        {
            using (new OperationContextScope(CreditNotePortClient.InnerChannel))
            {
                var req = new GetCreditNoteRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderCreditNotes;
                req.CREDITNOTE_SEARCH_KEY = SearchKey.GetSearchKeyCreditNotes;
                req.CREDITNOTE_SEARCH_KEY.READ_INCLUDED = FLAG_VALUE.Y;
                req.CREDITNOTE_SEARCH_KEY.ID = id;

                var CreditNoteArr = CreditNotePortClient.GetCreditNote(req).CREDITNOTE; //tek bır smm gelmesını beklıyoruz
                if (CreditNoteArr != null && CreditNoteArr.Length != 0 && CreditNoteArr[0].CONTENT != null)
                {
                    //getirilen faturanın contentını zipten cıkar,string halınde dondur
                    return Encoding.UTF8.GetString(Compress.UncompressFile(CreditNoteArr[0].CONTENT.Value));
                }
                return null;
            }
        }



        public string getCreditNotesContentXml(string uuid)
        {
            //db den pathı getırdı           
            string xmlPath = Singl.creditNotesDalGet.findCreditNoteWithUuid(uuid).folderPath;

            if (FolderControl.xmlFileIsInFolder(xmlPath)) // xml dosyası verılen pathde bulunuyorsa
            {
                return File.ReadAllText(xmlPath);
            }
            else
            {
                //servisten, gonderilen uuıd ye aıt faturanın contentını getır
                return getCreditNoteWithUuidOnService(uuid);
            }
        }


        public byte[] getCreditNoteWithType(string uuid, CONTENT_TYPE type)
        {
            using (new OperationContextScope(CreditNotePortClient.InnerChannel))
            {
                var req = new GetCreditNoteRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderCreditNotes;
                req.CREDITNOTE_SEARCH_KEY = new GetCreditNoteRequestCREDITNOTE_SEARCH_KEY();
                req.CREDITNOTE_SEARCH_KEY.UUID = uuid;
                req.CONTENT_TYPE = type;
                
                var response = CreditNotePortClient.GetCreditNote(req);
                if (response.ERROR_TYPE != null)  //error message varsa
                {
                    return null;
                }
                else //servisten smm getırme islemi basarılıysa
                {
                    if (response.CREDITNOTE != null && response.CREDITNOTE.Length > 0) //getırılen smm varsa
                    {

                        return Compress.UncompressFile(response.CREDITNOTE[0].CONTENT.Value);
                    }
                    return null;//smm sayısı 0 ancak hata yok
                }
            }
        }







    }
}
