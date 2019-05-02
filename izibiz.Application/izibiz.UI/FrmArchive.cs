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


        private bool gridIsDraft;




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

            itemArchiveInvoice.Text = Lang.eArchiveInvoices;
            itemListArchiveInvoice.Text = Lang.eArchiveInvoicesList;
            itemDraftArchiveInvoice.Text = Lang.eArchiveDraftInvoices;
            itemListDraftArchiveInvoice.Text = Lang.eArchiveDraftInvoicesList;


            #endregion

        }


        private void addViewButtonToDatagridView()
        {
            tableGrid.Columns.Clear();
            //pdf goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconPdf,
                Name = EI.GridBtnClmName.previewPdf.ToString(),
                HeaderText = Lang.preview
            });
            //xml goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconXml,
                Name = EI.GridBtnClmName.previewXml.ToString(),
                HeaderText = Lang.preview,
            });
        }




        private void dataGridChangeColoumnHeaderText()
        {

            tableGrid.Columns[EI.Invoice.status.ToString()].HeaderText = Lang.status;

            tableGrid.Columns[EI.Invoice.statusDesc.ToString()].HeaderText = Lang.statusDesc;

            tableGrid.Columns[EI.Invoice.gibStatusCode.ToString()].HeaderText = Lang.gibStatusCode;

            tableGrid.Columns[EI.Invoice.gibStatusDescription.ToString()].HeaderText = Lang.gibSatusDescription;

            tableGrid.Columns[EI.Invoice.ID.ToString()].HeaderText = Lang.id;

            tableGrid.Columns[EI.Invoice.uuid.ToString()].HeaderText = Lang.uuid;

            tableGrid.Columns[EI.Invoice.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableGrid.Columns[EI.Invoice.profileid.ToString()].HeaderText = Lang.profileid;

            tableGrid.Columns[EI.Invoice.type.ToString()].HeaderText = Lang.type;

            tableGrid.Columns[EI.Invoice.suplier.ToString()].HeaderText = Lang.supplier;

            tableGrid.Columns[EI.Invoice.senderVkn.ToString()].HeaderText = Lang.sender;

            tableGrid.Columns[EI.Invoice.receiverVkn.ToString()].HeaderText = Lang.receiver;

            tableGrid.Columns[EI.Invoice.cDate.ToString()].HeaderText = Lang.cDate;

            tableGrid.Columns[EI.Invoice.envelopeIdentifier.ToString()].HeaderText = Lang.envelopeIdentifier;

            tableGrid.Columns[EI.Invoice.senderAlias.ToString()].HeaderText = Lang.from;

            tableGrid.Columns[EI.Invoice.receiverAlias.ToString()].HeaderText = Lang.to;


            tableGrid.Columns[EI.Invoice.draftFlagDesc.ToString()].HeaderText = Lang.isDraftFlag;

        }







        private void itemListArchiveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                
                gridUpdateList(Singl.archiveInvoiceDalGet.getInvoiceList(gridIsDraft));
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
            tableGrid.DataSource = null;

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

                addViewButtonToDatagridView();
                tableGrid.DataSource = gridListInv;
                dataGridChangeColoumnHeaderText();

                //gridde taslak faturaları lısletemıyorsak
                if (gridIsDraft==false)
                {
                    tableGrid.Columns[nameof(EI.Invoice.draftFlagDesc)].Visible = false;
                }

                tableGrid.Columns[nameof(EI.Invoice.draftFlag)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.stateNote)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.status)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.gibStatusDescription)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.content)].Visible = false;
                tableGrid.Columns[nameof(EI.Invoice.folderPath)].Visible = false;
            }
        }









    }
    }
