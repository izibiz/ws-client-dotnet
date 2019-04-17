using izibiz.COMMON;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubl_Invoice_2_1;

namespace izibiz.CONTROLLER.Dal
{
    public class InvoiceDAL
    {

        public List<InvoicesTable> getFaultyInvoices()
        {
            return Singl.databaseContextGet.Invoices.Where(x => x.invType == nameof(EI.Direction.OUT)
            && x.status.Contains(nameof(EI.StatusType.LOAD))
            && x.status.Contains(nameof(EI.SubStatusType.FAILED))).ToList();
        }



        public InvoicesTable getInvoice(string uuid,string direction )
        {
            return Singl.databaseContextGet.Invoices.Where(x => x.invType == direction
            && x.Uuid==uuid ).First();
        }







     /*   public InvoicesTable[] getInvoiceArr(string[] uuid, string direction)
        {
            List<InvoicesTable> listInv = new List<InvoicesTable>();

            for (int i=0;i<uuid.Length;i++)
            {
                InvoicesTable invoice = Singl.databaseContextGet.Invoices.Where(x => x.invType == direction
                          && x.Uuid == uuid[i]).First();

                listInv.Add(invoice);
            }

            return listInv.ToArray();
        }*/



        public void insertDraftInvoice(InvoiceType invoiceUbl,string xmlContent)
        {
            InvoicesTable draftCreatedInv = new InvoicesTable();

            draftCreatedInv.ID = invoiceUbl.ID.Value.ToString();
            draftCreatedInv.Uuid = invoiceUbl.UUID.Value.ToString();
            draftCreatedInv.invType = EI.Direction.DRAFT.ToString();
            draftCreatedInv.draftFlag = EI.ActiveOrPasive.N.ToString();  //load ınv yapmadıklarımız flag N
            draftCreatedInv.issueDate =Convert.ToDateTime(invoiceUbl.IssueDate.Value);
            draftCreatedInv.profileid = invoiceUbl.ProfileID.Value.ToString();
            draftCreatedInv.type = invoiceUbl.InvoiceTypeCode.Value.ToString();
            //  draftCreatedInv.suplier = invoice.AccountingSupplierParty.Party.PartyName.ToString();
            //  draftCreatedInv.sender = invoice.AccountingSupplierParty.Party.PartyIdentification.GetValue(0).ToString();  //sıfırıncı ındexde tc ya da vkn tutuluyor         
            draftCreatedInv.status =  ""; //simdilik bos deger atıyoruz load ınv yaparken guncellenecektır
            draftCreatedInv.content = xmlContent;


            Singl.databaseContextGet.Invoices.Add(draftCreatedInv);
            Singl.databaseContextGet.SaveChanges();
        }



    }
}
