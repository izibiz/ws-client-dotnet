using izibiz.COMMON;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Data;
using izibiz.MODEL.DbModels;
using izibiz.SERVICES.serviceOib;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubl_Invoice_2_1;

namespace izibiz.CONTROLLER.DAL
{
    public class InvoiceDal
    {

        public List<Invoices> getFaultyInvoices()
        {
            return Singl.databaseContextGet.invoices.Where(inv => inv.direction == nameof(EI.InvDirection.OUT)
            && inv.status.Contains(nameof(EI.StatusType.LOAD))
            && inv.status.Contains(nameof(EI.SubStatusType.FAILED))).ToList();
        }



        public Invoices getInvoice(string uuid, string direction)
        {
            return Singl.databaseContextGet.invoices.Where(inv => inv.direction == direction
            && inv.uuid == uuid).First();
        }



        public List<Invoices> getInvoiceList(string direction)
        {
            return Singl.databaseContextGet.invoices.Where(inv => inv.direction == direction).ToList();
        }



        public List<Invoices> getWaitResponseInvoiceList(string direction)
        {
            return Singl.databaseContextGet.invoices.Where(inv => inv.direction == direction  && inv.status.Contains(nameof(EI.StatusType.SEND)) &&
            inv.status.Contains(nameof(EI.SubStatusType.WAIT_APPLICATION_RESPONSE))).ToList();
        }


        public List<Invoices> getRejectedInvoiceList(string direction)
        {
            return Singl.databaseContextGet.invoices.Where(inv => inv.direction == direction && inv.status.Contains(nameof(EI.StatusType.REJECTED)) 
            && inv.status.Contains(nameof(EI.SubStatusType.SUCCEED))).ToList();
        }


        public List<Invoices> getInvoiceListOnFilter(string direction,DateTime startTime,DateTime finishTime)
        {
            return Singl.databaseContextGet.invoices.Where(inv => inv.direction == direction 
            && inv.cDate <= finishTime 
            && inv.cDate >=  startTime).ToList();
        }


        public void updateIdInv(string uuid, string direction, string newId)
        {
            Singl.databaseContextGet.invoices.Where(inv => inv.direction == direction
            && inv.uuid == uuid).First().ID = newId;
        }



        public void updateInvState(string uuid, string direction, GetInvoiceStatusResponseINVOICE_STATUS invStatusResponse)
        {
            var invoice = Singl.databaseContextGet.invoices.Where(inv => inv.direction == direction
              && inv.uuid == uuid).First();

            invoice.status = invStatusResponse.STATUS;
            invoice.cDate = invStatusResponse.CDATE;
            invoice.envelopeIdentifier = invStatusResponse.ENVELOPE_IDENTIFIER;
            invoice.gibStatusCode = invStatusResponse.GIB_STATUS_CODE;
            invoice.gibStatusDescription = invStatusResponse.GIB_STATUS_DESCRIPTION;
        }


        public void changeInvDirection(string uuid, string direction, string newDirection)
        {
            Singl.databaseContextGet.invoices.Where(inv => inv.direction == direction
            && inv.uuid == uuid).First().direction = newDirection;
        }



        public void addInvoice(Invoices inv)
        {
            Singl.databaseContextGet.invoices.Add(inv);
        }


        public void deleteInvoices(string uuid, string direction)
        {
            Invoices invoice = Singl.databaseContextGet.invoices.Where(inv => inv.direction == direction
            && inv.uuid == uuid).First();

            Singl.databaseContextGet.invoices.Remove(invoice);
        }

        public void dbSaveChanges()
        {
            Singl.databaseContextGet.SaveChanges();
        }


      


        public void insertDraftInvoice(InvoiceType invoiceUbl, string xmlPath)
        {
            Invoices draftCreatedInv = new Invoices();

            draftCreatedInv.ID = invoiceUbl.ID.Value;
            draftCreatedInv.uuid = invoiceUbl.UUID.Value;
            draftCreatedInv.direction = EI.InvDirection.DRAFT.ToString();
            draftCreatedInv.draftFlag = EI.ActiveOrPasive.N.ToString();  //load ınv yapmadıklarımız flag N
            draftCreatedInv.cDate = invoiceUbl.IssueDate.Value;
            draftCreatedInv.profileid = invoiceUbl.ProfileID.Value;
            draftCreatedInv.invoiceType = invoiceUbl.InvoiceTypeCode.Value;
            draftCreatedInv.suplier = invoiceUbl.AccountingSupplierParty.Party.PartyName.Name.Value;
            draftCreatedInv.receiverVkn = invoiceUbl.AccountingCustomerParty.Party.PartyIdentification.First().ID.Value;
            draftCreatedInv.senderVkn = invoiceUbl.AccountingSupplierParty.Party.PartyIdentification.First().ID.Value;  //sıfırıncı ındexde tc ya da vkn tutuluyor         
            draftCreatedInv.status = "";//simdilik bos deger atıyoruz load ınv yaparken guncellenecektır
            draftCreatedInv.stateNote = nameof(EI.StateNote.CREATED);
            draftCreatedInv.draftFlag = nameof(EI.ActiveOrPasive.N);//bizim olusturdugumuz fatura flag N
            draftCreatedInv.content =File.ReadAllText(xmlPath, Encoding.UTF8);
            draftCreatedInv.folderPath = xmlPath;

            Singl.databaseContextGet.invoices.Add(draftCreatedInv);
        }



    }
}
