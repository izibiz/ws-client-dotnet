using izibiz.COMMON;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Data;
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

        public List<Invoices> getFaultyInvoices()
        {
            return Singl.databaseContextGet.Invoices.Where(inv => inv.invType == nameof(EI.InvDirection.OUT)
            && inv.status.Contains(nameof(EI.StatusType.LOAD))
            && inv.status.Contains(nameof(EI.SubStatusType.FAILED))).ToList();
        }



        public Invoices getInvoice(string uuid, string direction)
        {
            return Singl.databaseContextGet.Invoices.Where(inv => inv.invType == direction
            && inv.uuid == uuid).First();
        }

        public List<Invoices> getInvoiceList(string direction)
        {
            return Singl.databaseContextGet.Invoices.Where(inv => inv.invType == direction).ToList();
        }


        public void updateStateInv(string uuid, string direction, string status)
        {
             Singl.databaseContextGet.Invoices.Where(inv => inv.invType == direction
             && inv.uuid == uuid).First().statusDesc = status;
        }

        public void addInvoice(Invoices inv)
        {
            Singl.databaseContextGet.Invoices.Add(inv);
        }


        public void deleteInvoices(string uuid, string direction)
        {
            Invoices invoice = Singl.databaseContextGet.Invoices.Where(inv => inv.invType == direction
            && inv.uuid == uuid).First();

            Singl.databaseContextGet.Invoices.Remove(invoice);
        }

        public void dbSaveChanges()
        {
            Singl.databaseContextGet.SaveChanges();
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



        public void insertDraftInvoice(InvoiceType invoiceUbl, string xmlContent)
        {
            Invoices draftCreatedInv = new Invoices();

            draftCreatedInv.ID = invoiceUbl.ID.Value.ToString();
            draftCreatedInv.uuid = invoiceUbl.UUID.Value.ToString();
            draftCreatedInv.invType = EI.InvDirection.DRAFT.ToString();
            draftCreatedInv.draftFlag = EI.ActiveOrPasive.N.ToString();  //load ınv yapmadıklarımız flag N
            draftCreatedInv.issueDate = Convert.ToDateTime(invoiceUbl.IssueDate.Value);
            draftCreatedInv.profileid = invoiceUbl.ProfileID.Value.ToString();
            draftCreatedInv.type = invoiceUbl.InvoiceTypeCode.Value.ToString();
            //draftCreatedInv.suplier = invoiceUbl.AccountingSupplierParty.Party.PartyName.ToString();
            //  draftCreatedInv.sender = invoiceUbl.AccountingSupplierParty.Party.PartyIdentification.GetValue(0).ToString();  //sıfırıncı ındexde tc ya da vkn tutuluyor         
            draftCreatedInv.status = nameof(EI.StatusType.CREATED); //simdilik default deger atıyoruz load ınv yaparken guncellenecektır
            draftCreatedInv.content = xmlContent;

            Singl.databaseContextGet.Invoices.Add(draftCreatedInv);
        }



    }
}
