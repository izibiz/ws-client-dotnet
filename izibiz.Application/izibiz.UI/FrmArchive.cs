using izibiz.COMMON;
using izibiz.COMMON.Language;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbModels;
using izibiz.SERVICES.serviceArchive;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace izibiz.UI
{
    public partial class FrmArchive : Form
    {


      



        public FrmArchive()
        {
            InitializeComponent();
        }

        private void FrmArchive_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
        }




        private void localizationItemTextWrite()
        {
            //dil secimini sorgula
            if (Settings.Default.language == "English")
            {
                Lang.Culture = new CultureInfo("en-US");
            }
            else
            {
                Lang.Culture = new CultureInfo("");
            }
            #region writeAllFormItem

            itemArchiveInvoices.Text = Lang.eArchiveInvoices;
            itemListArchiveReport.Text = Lang.eArchiveReportList;
            itemArchiveNewCreated.Text = Lang.newInvoice;
            #endregion

        }






        private void dataGridChangeColoumnHeaderText()
        {

            tableArchiveGrid.Columns[EI.Invoice.status.ToString()].HeaderText = Lang.status;

            tableArchiveGrid.Columns[EI.Invoice.statusDesc.ToString()].HeaderText = Lang.statusDesc;

            tableArchiveGrid.Columns[EI.Invoice.gibStatusCode.ToString()].HeaderText = Lang.gibStatusCode;

            tableArchiveGrid.Columns[EI.Invoice.gibStatusDescription.ToString()].HeaderText = Lang.gibSatusDescription;

            tableArchiveGrid.Columns[EI.Invoice.ID.ToString()].HeaderText = Lang.id;

            tableArchiveGrid.Columns[EI.Invoice.uuid.ToString()].HeaderText = Lang.uuid;

            tableArchiveGrid.Columns[EI.Invoice.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableArchiveGrid.Columns[EI.Invoice.profileid.ToString()].HeaderText = Lang.profileid;

            tableArchiveGrid.Columns[EI.Invoice.invoiceType.ToString()].HeaderText = Lang.type;

            tableArchiveGrid.Columns[EI.Invoice.suplier.ToString()].HeaderText = Lang.supplier;

            tableArchiveGrid.Columns[EI.Invoice.senderVkn.ToString()].HeaderText = Lang.sender;

            tableArchiveGrid.Columns[EI.Invoice.receiverVkn.ToString()].HeaderText = Lang.receiver;

            tableArchiveGrid.Columns[EI.Invoice.cDate.ToString()].HeaderText = Lang.cDate;

            tableArchiveGrid.Columns[EI.Invoice.envelopeIdentifier.ToString()].HeaderText = Lang.envelopeIdentifier;

            tableArchiveGrid.Columns[EI.Invoice.senderAlias.ToString()].HeaderText = Lang.from;

            tableArchiveGrid.Columns[EI.Invoice.receiverAlias.ToString()].HeaderText = Lang.to;

            tableArchiveGrid.Columns[EI.Invoice.draftFlagDesc.ToString()].HeaderText = Lang.isDraftFlag;

        }







        private void itemListArchiveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                //db dekı raporlanmıs arsıv faturaları getır
                gridUpdateList(Singl.archiveInvoiceDalGet.getArchiveReportList());
            }

            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show(Lang.dbFault + " " + ex.InnerException.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(Lang.dataException + ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }






        private void gridUpdateList(List<ArchiveInvoices> gridListInv)
        {
            tableArchiveGrid.DataSource = null;

            if (gridListInv.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                foreach (ArchiveInvoices inv in gridListInv)
                {
                    //  inv.statusDesc = invoiceStatusDescWrite(inv.status, inv.gibStatusCode);

                    if (inv.draftFlag.Equals(true))
                    {
                        inv.draftFlagDesc = Lang.yes;
                    }
                    else if (inv.draftFlag.Equals(false))
                    {
                        inv.draftFlagDesc = Lang.no;
                    }
                }

                tableArchiveGrid.DataSource = gridListInv;
                dataGridChangeColoumnHeaderText();


                tableArchiveGrid.Columns[nameof(EI.Invoice.draftFlag)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.stateNote)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.status)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.gibStatusDescription)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.content)].Visible = false;
                tableArchiveGrid.Columns[nameof(EI.Invoice.folderPath)].Visible = false;
            }
        }



        private void btnArchiveView_Click(object sender, EventArgs e)
        {
            try
            {
                string docType;
                if (rdViewHtml.Checked)  //html
                {
                    docType = nameof(EI.DocumentType.HTML);
                }
                else if (rdViewXml.Checked) //xml
                {
                    docType = nameof(EI.DocumentType.XML);
                }
                else //pdf
                {
                    docType = nameof(EI.DocumentType.PDF);
                }





            }

            catch (FaultException<REQUEST_ERRORType> ex)  //archive req error
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show(Lang.dbFault + " " + ex.InnerException.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(Lang.dataException + ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnTakeArchiveInv_Click(object sender, EventArgs e)
        {
            try
            {
                //servisten yenı faturaları cek db ye kaydet ve datagridde göster
                gridUpdateList(Singl.archiveControllerGet.getInvoiceListOnService());

            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
