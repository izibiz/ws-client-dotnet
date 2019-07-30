using izibiz.COMMON;
using izibiz.CONTROLLER.InvoiceRequestSection;
using izibiz.CONTROLLER.Singleton;
using izibiz.SERVICES.serviceReconcilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace izibiz.CONTROLLER.WebServicesController
{
    public class ReconcilationController
    {



        private ReconciliationPortClient reconcilationPortClient = new ReconciliationPortClient();


        private List<SendReconciliationRequestRECONCILIATION> sendReconciliationRequestRECONCILIATIONs;




        public ReconcilationController()
        {
            RequestHeader.createRequestHeaderReconcilation();
            sendReconciliationRequestRECONCILIATIONs = new List<SendReconciliationRequestRECONCILIATION>();

        }


        public string sendReconcilation()
        {
            using (new OperationContextScope(reconcilationPortClient.InnerChannel))
            {
                var req = new SendReconciliationRequest();

                req.REQUEST_HEADER = RequestHeader.getRequestHeaderReconcilation;
                req.RECONCILIATION = sendReconciliationRequestRECONCILIATIONs.ToArray();

                sendReconciliationRequestRECONCILIATIONs.Clear();

                var response = reconcilationPortClient.SendReconciliation(req);

                if (response.REQUEST_RETURN == null || response.REQUEST_RETURN.RETURN_CODE != 0)  //basarısızsa
                {
                    return "islem basarısız";
                }
                else //basarılıysa
                {
                    return null;//irsaliye sayısı 0 ancak hata yok
                }
            }
        }

        


        /// <summary>
        /// gonderilecek carı mutabakat tpipndekileri SendReconciliationRequestRECONCILIATION listesine aktarır
        /// </summary>
        public void addListToSendReconcilationCM(string uuid, string customerId, string customerTitle,
           string customerMail, decimal cmAmount, string amountType, DateTime cmDate)
        {
            SendReconciliationRequestRECONCILIATION sendReconciliation = new SendReconciliationRequestRECONCILIATION();

            sendReconciliation.UUID = uuid;
            sendReconciliation.CUSTOMER_IDENTIFIER = customerId;
            sendReconciliation.COMMERCIAL_NAME = customerTitle;
            sendReconciliation.CUSTOMER_ADDRESS = "Adres";
            sendReconciliation.EMAIL = customerMail;
            sendReconciliation.CURRENCY_CODE = CURRENCY_CODE.TRY;//BEN DEFAULT DEGERI YAZIYORUM
            sendReconciliation.TYPE = RECONCILIATION_TYPE.CM;
            sendReconciliation.CM_AMOUNT = cmAmount;
            sendReconciliation.CM_AMOUNTSpecified = true;
            sendReconciliation.CM_DATE = cmDate.ToString("yyyy-MM-dd");
            sendReconciliation.CM_AMOUNT_TYPESpecified = true;
            if (amountType == nameof(EI.ReconcilationAmountType.ALACAK))//alacaklı
            {
                sendReconciliation.CM_AMOUNT_TYPE = CM_TYPE.A;
            }
            else//borclu
            {
                sendReconciliation.CM_AMOUNT_TYPE = CM_TYPE.B;
            }

            sendReconciliationRequestRECONCILIATIONs.Add(sendReconciliation);
        }



        /// <summary>
        /// gonderilecek ba-bs tpipndekileri SendReconciliationRequestRECONCILIATION listesine aktarır
        /// </summary>
        public void addListToSendReconcilationEM(string uuid, string customerId, string customerTitle,
         string customerMail, string period, int baDocCount, decimal baDocAmount, int bsDocCount, decimal bsDocAmount)
        {
            SendReconciliationRequestRECONCILIATION sendReconciliation = new SendReconciliationRequestRECONCILIATION();

            sendReconciliation.UUID = uuid;
            sendReconciliation.CUSTOMER_IDENTIFIER = customerId;
            sendReconciliation.COMMERCIAL_NAME = customerTitle;
            sendReconciliation.CUSTOMER_ADDRESS = "Adres";
            sendReconciliation.EMAIL = customerMail;
            sendReconciliation.CURRENCY_CODE = CURRENCY_CODE.TRY;//BEN DEFAULT DEGERI YAZIYORUM
            sendReconciliation.TYPE = RECONCILIATION_TYPE.EM;
            sendReconciliation.BABS_ACCOUNTING_PERIOD = period;
            sendReconciliation.BA_DOCUMENT_COUNT = baDocCount;//count zorunlu degıl
            sendReconciliation.BA_DOCUMENT_AMOUNT = baDocAmount;
            sendReconciliation.BA_DOCUMENT_AMOUNTSpecified = true;
            sendReconciliation.BS_DOCUMENT_COUNT = bsDocCount;//count zorunlu degıl
            sendReconciliation.BS_DOCUMENT_AMOUNT = bsDocAmount;
            sendReconciliation.BS_DOCUMENT_AMOUNTSpecified = true;


            sendReconciliationRequestRECONCILIATIONs.Add(sendReconciliation);
        }




        /// <summary>
        /// basarılıysa status doner basarısızsa null
        /// </summary>
        public RECONCILIATION_STATUSRECONCILIATION[][] getStatusReconcilation(string[] uuids)
        {
            using (new OperationContextScope(reconcilationPortClient.InnerChannel))
            {
                var req = new GetReconciliationStatusRequest();

                req.REQUEST_HEADER = RequestHeader.getRequestHeaderReconcilation;
                req.RECONCILIATION_SEARCHING = uuids;


                 RECONCILIATION_STATUSRECONCILIATION[][] reconcilationsStatus = reconcilationPortClient.GetReconciliationStatus(req);

                if (reconcilationsStatus==null || reconcilationsStatus.First() == null || reconcilationsStatus.Length == 0)  //basarısızsa
                {
                    return null;
                }
                else //basarılıysa
                {
                    return reconcilationsStatus;
                }
            }
        }




        public string sendMailReconcilation(string[] uuids)
        {
            using (new OperationContextScope(reconcilationPortClient.InnerChannel))
            {
                var req = new SendMailReconciliationRequest();

                req.REQUEST_HEADER = RequestHeader.getRequestHeaderReconcilation;
                req.MAIL_SEARCHING = uuids;


                var response = reconcilationPortClient.SendMailReconciliation(req);
                if (response.REQUEST_RETURN == null || response.REQUEST_RETURN.RETURN_CODE != 0)  //basarısızsa
                {
                    return "islem basarısız";
                }
                else //basarılıysa
                {
                    return null;//irsaliye sayısı 0 ancak hata yok
                }
            }
        }


    }
}

