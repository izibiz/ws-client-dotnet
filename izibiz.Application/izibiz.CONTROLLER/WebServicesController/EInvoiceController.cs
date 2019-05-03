﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using izibiz.MODEL.DbModels;
using izibiz.SERVICES.serviceOib;
using izibiz.COMMON;
using izibiz.CONTROLLER.Singleton;
using izibiz.CONTROLLER.InvoiceRequestSection;
using izibiz.COMMON.FileControl;
using System.IO;
using izibiz.COMMON.UblSerializer;
using Ubl_Invoice_2_1;


namespace izibiz.CONTROLLER.Web_Services
{



    public class EInvoiceController
    {

        private EFaturaOIBPortClient eInvoiceOIBPortClient = new EFaturaOIBPortClient();
      
        List<INVOICE> invoiceList = new List<INVOICE>();




        public EInvoiceController()
        {
            InvoiceSearchKey.createInvoiceSearchKeyGetInvoiceRequest();
            InvoiceSearchKey.createinvoiceSearchKeyGetInvoiceWithTypeRequest();
        }



        public List<Invoices> getInvoiceListOnService(string direction)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderOib;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                if (direction.Equals(nameof(EI.InvDirection.DRAFT))) //direction taslak fatura ıse
                {
                    req.INVOICE_SEARCH_KEY.DIRECTION = EI.InvDirection.OUT.ToString();
                    req.INVOICE_SEARCH_KEY.DRAFT_FLAG = EI.ActiveOrPasive.Y.ToString();
                }
                else
                {
                    req.INVOICE_SEARCH_KEY.DIRECTION = direction;
                }

                INVOICE[] invoiceArray = eInvoiceOIBPortClient.GetInvoice(req);
                if (invoiceArray.Length > 0)
                {
                    invoiceMarkRead(invoiceArray);
                    //getirilen faturaları db ye kaydet
                    SaveInvoiceArrayToDb(invoiceArray, direction);
                }
                return Singl.invoiceDalGet.getInvoiceList(direction);
            }
        }


        private void SaveInvoiceArrayToDb(INVOICE[] invoiceArray, string direction)
        {
            foreach (var inv in invoiceArray)
            {
                Invoices invoice = new Invoices();

                invoice.ID = inv.ID;
                invoice.uuid = inv.UUID;
                invoice.direction = direction;
                invoice.issueDate = inv.HEADER.ISSUE_DATE;
                invoice.profileid = inv.HEADER.PROFILEID;
                invoice.invoiceType = inv.HEADER.INVOICE_TYPE_CODE;
                invoice.suplier = inv.HEADER.SUPPLIER;
                invoice.senderVkn = inv.HEADER.SENDER;
                invoice.receiverVkn = inv.HEADER.RECEIVER;
                invoice.cDate = inv.HEADER.CDATE;
                invoice.envelopeIdentifier = inv.HEADER.ENVELOPE_IDENTIFIER;
                invoice.status = inv.HEADER.STATUS;
                invoice.gibStatusCode = inv.HEADER.GIB_STATUS_CODE;
                invoice.gibStatusDescription = inv.HEADER.GIB_STATUS_DESCRIPTION;
                invoice.senderAlias = inv.HEADER.FROM;
                invoice.receiverAlias = inv.HEADER.TO;
                invoice.folderPath = FolderControl.createInvXmlPath(inv.UUID, direction);

                byte[] unCompressedContent = Compress.UncompressFile(inv.CONTENT.Value);
                invoice.content = Encoding.UTF8.GetString(unCompressedContent);  //xml db de tututlur


                if (direction == nameof(EI.InvDirection.DRAFT))
                {
                    invoice.draftFlag = EI.ActiveOrPasive.Y.ToString();  //servisten cektıklerımız flag Y  ☺
                }


                FolderControl.writeFileOnDiskWithString(invoice.content, invoice.folderPath);

                Singl.invoiceDalGet.addInvoice(invoice);
            }
            Singl.invoiceDalGet.dbSaveChanges();
        }



        /// <summary>
        /// EGER DİSKE YAZDIGIM XML DOSYASI SILINMIS ISE SILINEN INVOICESIN CONTENTINI DISKE YAZMAK ICIN TEKRAR CAGIRIRIM
        /// </summary>
        public string getInvoiceWithUuidOnService(string uuid, string direction)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var req = new GetInvoiceRequest(); //sistemdeki gelen efatura listesi için request parametreleri
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderOib;
                req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceRequest;
                req.INVOICE_SEARCH_KEY.UUID = uuid;
                req.INVOICE_SEARCH_KEY.READ_INCLUDED = true;  //daha onceden cektıgımız ıcın mark ınv yapılmıstır o yuzden true
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                if (direction.Equals(nameof(EI.InvDirection.DRAFT))) //direction taslak fatura ıse
                {
                    req.INVOICE_SEARCH_KEY.DIRECTION = EI.InvDirection.OUT.ToString();
                    req.INVOICE_SEARCH_KEY.DRAFT_FLAG = EI.ActiveOrPasive.Y.ToString();
                }
                else
                {
                    req.INVOICE_SEARCH_KEY.DIRECTION = direction;
                }
                INVOICE[] invoiceArray = eInvoiceOIBPortClient.GetInvoice(req);

                byte[] unCompressedContent; //servisten getırılemezse content null doner

                if (invoiceArray.Length != 0)
                {
                    //getirilen faturanın contentını zipten cıkar
                    unCompressedContent = Compress.UncompressFile(invoiceArray[0].CONTENT.Value);
                    return Encoding.UTF8.GetString(unCompressedContent);
                }

                return null;
            }
        }



        private void invoiceMarkRead(INVOICE[] invoiceList)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var markReq = new MarkInvoiceRequest() //sistemdeki gelen efatura listesi için request parametreleri
                {
                    REQUEST_HEADER = RequestHeader.getRequestHeaderOib,
                    MARK = new MarkInvoiceRequestMARK()
                    {
                        INVOICE = invoiceList,
                        value = MarkInvoiceRequestMARKValue.READ,
                        valueSpecified = true
                    }
                };
                MarkInvoiceResponse markRes = eInvoiceOIBPortClient.MarkInvoice(markReq);
            }
        }




        public void createInvListWithContent(bool withZip, string xmlStr)
        {
            INVOICE invoice = new INVOICE();
            base64Binary contentByte = new base64Binary();

            if (withZip) //zipli gönderilmek isteniyorsa
            {
                contentByte.Value = Compress.compressFile(xmlStr);
            }
            else  //zipsiz content value
            {
                contentByte.Value =Encoding.UTF8.GetBytes(xmlStr);
            }
            invoice.CONTENT = contentByte;

            invoiceList.Add(invoice);
        }



        


        //public string getContentOnDisk(string uuid, string direction)
        //{
        //    string folderPath = Singl.invoiceDalGet.getInvoice(uuid, direction).folderPath;

        //    if (!invoiceXmlFileIsInFolder(folderPath)) // xml dıskte bulunmuyorsa
        //    {
        //        //servisten cekılemedıyse content db deki contentı diske kaydet
        //        if (getInvoiceWithUuidOnService(uuid, direction) == null)
        //        {
        //            saveContentWithString(Singl.invoiceDalGet.getInvoice(uuid, direction).content, inboxFolderDraft, uuid, nameof(EI.DocumentType.XML));
        //        }
        //    }
        //    return File.ReadAllText(folderPath, Encoding.UTF8);
        //}





        public int sendInvoice(string receiverAlias, bool isWithZip)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                var req = new SendInvoiceRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderOib;
                if (isWithZip)
                {
                    req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                }
                else
                {
                    req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.N.ToString();
                }
                req.SENDER = new SendInvoiceRequestSENDER();
                req.RECEIVER = new SendInvoiceRequestRECEIVER();
                req.RECEIVER.alias = receiverAlias;

                req.INVOICE = invoiceList.ToArray();

                invoiceList.Clear();

                return eInvoiceOIBPortClient.SendInvoice(req).REQUEST_RETURN.RETURN_CODE;
            }
        }



        public int loadInvoice(bool isWithZip)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                LoadInvoiceRequest req = new LoadInvoiceRequest();

                req.REQUEST_HEADER = RequestHeader.getRequestHeaderOib;
                if (isWithZip) //zipli gonderılmek ıstenıyorsa
                {
                    req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.Y.ToString();
                }
                else //zipsiz ise
                {
                    req.REQUEST_HEADER.COMPRESSED = EI.ActiveOrPasive.N.ToString();
                }
                req.INVOICE = invoiceList.ToArray();
                invoiceList.Clear();

                return eInvoiceOIBPortClient.LoadInvoice(req).REQUEST_RETURN.RETURN_CODE;
            }
        }



        public int sendInvoiceResponse(string status, List<string> description)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                SendInvoiceResponseWithServerSignRequest req = new SendInvoiceResponseWithServerSignRequest()
                {
                    REQUEST_HEADER = RequestHeader.getRequestHeaderOib,
                    STATUS = status,
                    INVOICE = invoiceList.ToArray(),
                    DESCRIPTION = description.ToArray(),
                };
                invoiceList.Clear();

                return eInvoiceOIBPortClient.SendInvoiceResponseWithServerSign(req).REQUEST_RETURN.RETURN_CODE;
            }
        }



        public void createInvListWithUuid(string uuid)
        {
            INVOICE invoice = new INVOICE();
            invoice.UUID = uuid;
            invoiceList.Add(invoice);
        }




        /*  public INVOICE[] ArrayUuidToInvoice(string[] invoiceUuid)
          {
              INVOICE[] invoiceArray = new INVOICE[invoiceUuid.Length];
              for(int i = 0; i <= invoiceUuid.Length; i++)
              {
                  INVOICE invoice = new INVOICE();
                  invoice.UUID = invoiceUuid[i];
              }
              return invoiceArray;
          }*/



        public GetInvoiceStatusResponseINVOICE_STATUS getInvoiceState(string invoiceUuid)
        {
            INVOICE invoice = new INVOICE();
            invoice.UUID = invoiceUuid;

            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                GetInvoiceStatusRequest req = new GetInvoiceStatusRequest()
                {
                    REQUEST_HEADER = RequestHeader.getRequestHeaderOib,
                    INVOICE = invoice,
                };

                return eInvoiceOIBPortClient.GetInvoiceStatus(req).INVOICE_STATUS;
            }
        }




        public List<GIBUSER> getGibUserList()
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                GetUserListRequest req = new GetUserListRequest();

                req.REQUEST_HEADER = RequestHeader.getRequestHeaderOib;
                req.DOCUMENT_TYPE = nameof(EI.ProductType.INVOICE);
                GetUserListResponse response = eInvoiceOIBPortClient.GetUserList(req);

                return response.Items.ToList();
            }
        }







        public string getInvoiceType(string invoiceUuid, string documentType, string direction)
        {
            using (new OperationContextScope(eInvoiceOIBPortClient.InnerChannel))
            {
                GetInvoiceWithTypeRequest req = new GetInvoiceWithTypeRequest();
                req.REQUEST_HEADER = RequestHeader.getRequestHeaderOib;
                req.REQUEST_HEADER.COMPRESSED = nameof(EI.ActiveOrPasive.N);
                req.INVOICE_SEARCH_KEY = InvoiceSearchKey.invoiceSearchKeyGetInvoiceWithTypeRequest;
                req.INVOICE_SEARCH_KEY.READ_INCLUDED = true;
                req.INVOICE_SEARCH_KEY.READ_INCLUDEDSpecified = true;
                req.INVOICE_SEARCH_KEY.UUID = invoiceUuid;
                req.INVOICE_SEARCH_KEY.TYPE = documentType;//XML,PDF 
                req.INVOICE_SEARCH_KEY.DIRECTION = direction;
                req.HEADER_ONLY = EI.ActiveOrPasive.N.ToString();

                INVOICE[] invoice = eInvoiceOIBPortClient.GetInvoiceWithType(req);
                if(invoice.Length != 0)
                {
                    return FolderControl.saveInvDocContentWithByte(invoice[0].CONTENT.Value, direction, invoice[0].UUID, documentType);
                }
                return null;
            }
        }






        public string checkInvFolderOnDisk(string uuid, string direction)
        {
            //db den pathı getırdı
            string xmlPath = Singl.invoiceDalGet.getInvoice(uuid, direction).folderPath;

            if (!FolderControl.xmlFileIsInFolder(xmlPath)) // xml dosyası verılen pathde bulunmuyorsa
            {
                //servisten, gonderilen uuıd ye aıt faturanın contentını getır
                string invContent = Singl.invoiceControllerGet.getInvoiceWithUuidOnService(uuid, direction);
                if (invContent != null)
                {
                    FolderControl.writeFileOnDiskWithString(invContent, xmlPath);
                }
                else  //servisten cekılemedıyse content db deki contentı diske kaydet
                {
                    FolderControl.writeFileOnDiskWithString(Singl.invoiceDalGet.getInvoice(uuid, direction).content, xmlPath);
                }
            }
            return xmlPath;
        }


      






    }
}



