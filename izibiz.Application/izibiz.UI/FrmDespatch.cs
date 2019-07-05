using izibiz.COMMON;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using izibiz.COMMON.Language;
using System.Windows.Forms;
using System.Globalization;
using izibiz.SERVICES.serviceDespatch;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbModels;
using System.ServiceModel;
using System.Data.Entity.Validation;

namespace izibiz.UI
{
    public partial class FrmDespatch : Form
    {

        private string despactDirection;




        public FrmDespatch()
        {
            InitializeComponent();
        }


        private void FrmDespatch_Load(object sender, EventArgs e)
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
            //eleman text yazdır

            #endregion
        }




        private void addViewButtonToDatagridView()
        {
            tableGrid.Columns.Clear();
            //html goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconHtml,
                Name = EI.GridBtnClmName.previewHtml.ToString(),
                HeaderText = Lang.preview,
            });
        }


        private void FrmDespatch_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void selectPanelVisibilty(bool panelIncoming, bool panelSend, bool panelDraft)
        {
            pnlIncomingDespatch.Visible = panelIncoming;
            pnlSendDespatch.Visible = panelSend;
            pnlDraftDespatch.Visible = panelDraft;
        }




        private void itemIncomingInvoice_Click(object sender, EventArgs e)
        {
            despactDirection = EI.Direction.IN.ToString();
            lblText.Text = despactDirection;
            btnTakeDespatch.Visible = true;
            selectPanelVisibilty(false, false, false);


        }

        private void itemSentInvoice_Click(object sender, EventArgs e)
        {
            despactDirection = EI.Direction.OUT.ToString();
            lblText.Text = despactDirection;
            btnTakeDespatch.Visible = true;
            selectPanelVisibilty(false, false, false);


        }

        private void itemDraftInvoice_Click(object sender, EventArgs e)
        {
            despactDirection = EI.Direction.DRAFT.ToString();
            lblText.Text = despactDirection;
            btnTakeDespatch.Visible = false;
            selectPanelVisibilty(false, false, false);


        }

        private void itemTakeGibUsers_Click(object sender, EventArgs e)
        {
            despactDirection = EI.GibUser.GibUsers.ToString();
            btnTakeDespatch.Visible = false;
            selectPanelVisibilty(false, false, false);

        }



        private void itemListGibUserList_Click(object sender, EventArgs e)
        {
            despactDirection = EI.GibUser.GibUsers.ToString();
            btnTakeDespatch.Visible = false;
            selectPanelVisibilty(false, false, false);

        }



        public string despatchStatusDescWrite(string status, int gibStatusCode)
        {
            //   string status = invoice.status;
            //  int envelopeOpcode = invoice.gibStatusCode;

            if (gibStatusCode == 1210)
            {
                return "GİB'e gönderildi";
            }
            // RECEIVE
            if (status.Contains(EI.StatusType.RECEIVE.ToString()))
            {
                return "Alındı";
            }
            // LOAD
            if (status.Contains(EI.StatusType.LOAD.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "Yüklendi";
            }
            if (status.Contains(EI.StatusType.LOAD.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "Yüklenemedi";
            }
            // PACKAGE
            if (status.Contains(EI.StatusType.PACKAGE.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "İşleniyor";
            }
            if (status.Contains(EI.StatusType.PACKAGE.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "Yüklendi";
            }
            if (status.Contains(EI.StatusType.PACKAGE.ToString()) && status.Contains(EI.SubStatusType.PROCESSING.ToString()))
            {
                return "Paketleniyor";
            }
            if (status.Contains(EI.StatusType.SIGN.ToString()) && status.Contains(EI.SubStatusType.PROCESSING.ToString()))
            {
                return "İşleniyor";
            }
            if (status.Contains(EI.StatusType.SIGN.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "İmzalandı";
            }
            if (status.Contains(EI.StatusType.SIGN.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "İşleniyor";
            }

            // SEND
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.PROCESSING.ToString()))
            {
                return "İşleniyor";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.SUCCEED.ToString()))
            {
                return "Ulaştırıldı";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.FAILED.ToString()))
            {
                return "Ulaştırılamadı";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_GIB_RESPONSE.ToString()))
            {
                return "GİB'e gönderildi";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_SYSTEM_RESPONSE.ToString()))
            {
                return "Ulaştırıldı";
            }
            if (status.Contains(EI.StatusType.SEND.ToString()) && status.Contains(EI.SubStatusType.WAIT_APPLICATION_RESPONSE.ToString()))
            {
                return "Ulaştırıldı";
            }
            // ACCEPTED
            if (status.Contains(EI.StatusType.ACCEPTED.ToString()))
            {
                return "Kabul edildi";
            }
            // REJECTED
            if (status.Contains(EI.StatusType.REJECTED.ToString()))
            {
                return "Red edildi";
            }
            // ACCEPT
            if (status.Contains(EI.StatusType.ACCEPT.ToString()))
            {
                return "Kabul";
            }
            // REJECT
            if (status.Contains(EI.StatusType.REJECT.ToString()))
            {
                return "Red";
            }
            return "Durum Atanması Bekleniyor";
        }




        private void dataGridChangeColumnHeaderText()
        {

            tableGrid.Columns[EI.Despatch.status.ToString()].HeaderText = Lang.status;

            tableGrid.Columns[EI.Despatch.gibStatusCode.ToString()].HeaderText = Lang.gibStatusCode;

            tableGrid.Columns[EI.Despatch.gibStatusDescription.ToString()].HeaderText = Lang.gibSatusDescription;

            tableGrid.Columns[EI.Despatch.ID.ToString()].HeaderText = Lang.id;

            tableGrid.Columns[EI.Despatch.uuid.ToString()].HeaderText = Lang.uuid;

            tableGrid.Columns[EI.Despatch.direction.ToString()].HeaderText = Lang.invType;

            tableGrid.Columns[EI.Despatch.issueDate.ToString()].HeaderText = Lang.issueDate;

            tableGrid.Columns[EI.Despatch.profileId.ToString()].HeaderText = Lang.profileid;

            tableGrid.Columns[EI.Despatch.senderVkn.ToString()].HeaderText = Lang.senderVkn;

            tableGrid.Columns[EI.Despatch.cDate.ToString()].HeaderText = Lang.cDate;

            tableGrid.Columns[EI.Despatch.envelopeIdentifier.ToString()].HeaderText = Lang.envelopeIdentifier;
            //devamını yap


        }


        private void gridUpdateDespatchList(List<DespatchAdvices> gridListDespatch)
        {
            tableGrid.DataSource = null;
            tableGrid.Columns.Clear();

            if (gridListDespatch.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                foreach (DespatchAdvices despatch in gridListDespatch)
                {
                    despatch.status = despatchStatusDescWrite(despatch.status, despatch.gibStatusCode);
                }

                addViewButtonToDatagridView();
                tableGrid.DataSource = gridListDespatch;
                dataGridChangeColumnHeaderText();

            }
        }







        private void btnTakeDespatch_Click(object sender, EventArgs e)
        {
            try
            {
                //servisten yenı irsaliyeleri cek db ye kaydet ve datagridde göster            
                string errorMessage = Singl.despatchControllerGet.despatchListSaveDbFromService(despactDirection);

                if (errorMessage == null)//islem basarılı sekılde kaydedılmısse
                {
                    gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(despactDirection));
                }
                else //islem basarızsa
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
                MessageBox.Show(Lang.dbFault + ex.InnerException.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
  
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }










    }
}
