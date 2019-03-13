using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Model;
using izibiz.UI.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using izibiz.SERVICES.serviceOib;
using izibiz.UI.Properties;
using Microsoft.VisualBasic;

namespace izibiz.UI
{
    public partial class FrmInvoice : Form
    {

        private int invType;


        public FrmInvoice()
        {
            InitializeComponent();
        }


        private void FrmInvoice_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
        }



        private void localizationItemTextWrite()
        {
            //dil secimini sorgula
            if (Settings.Default.language == "English")
            {
                Localization.Culture = new CultureInfo("en-US");
            }
            else
            {
                Localization.Culture = new CultureInfo("");
            }
            #region writeAllFormItem
            //eleman text yazdır
            this.Text = Localization.formInvoice;
            itemIncomingInvoice.Text = Localization.incomingInvoice;
            itemComingListInvoice.Text = Localization.listInvoice;
            itemSentInvoice.Text = Localization.sentInvoice;
            itemDraftInvoice.Text = Localization.draftInvoice;
            itemDraftNewInvoice.Text = Localization.newInvoice;
            itemSentInvoiceList.Text = Localization.listInvoice;
            itemDraftInvoiceList.Text = Localization.listDraftInvoice;
            //panelSentInvoices butonlar
            btnRefreshSentInvoice.Text = Localization.refresh;
            btnSentInvGetState.Text = Localization.updateState;
            btnSentInvAgainSent.Text = Localization.againSent;
            btnFaultyInvoices.Text = Localization.faulty;
            //panelIncomingInvoices butonlar
            btnIncomingRefresh.Text = Localization.refresh;
            btnAccept.Text = Localization.accept;
            btnReject.Text = Localization.reject;
            btnGetInvoiceIncoming.Text = Localization.getInvoice;
            btnIncomingInvGetState.Text = Localization.updateState;
            #endregion
        }



        private void itemComingListInvoice_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Localization.incomingInvoice;
            panelSentInvoice.Visible = false;
            panelIncomingInvoice.Visible = true;
            panelConfirmation.Visible = false;
            invType = 1;
            try
            {
                tableGrid.DataSource = null;
                addViewButtonToDatagridView();
                tableGrid.DataSource = Singleton.instanceInvoiceGet.getIncomingInvoice();
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singleton.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void itemSentInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Localization.sentInvoice;
            panelIncomingInvoice.Visible = false;
            panelSentInvoice.Visible = true;
            panelConfirmationSentInv.Visible = false;
            invType = 2;
            try
            {
                tableGrid.DataSource = null;
                addViewButtonToDatagridView();
                tableGrid.DataSource = Singleton.instanceInvoiceGet.getSentInvoice();
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singleton.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void itemDraftInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Localization.draftInvoice;
            panelSentInvoice.Visible = false;
            panelIncomingInvoice.Visible = false;
            invType = 3;
            try
            {
                tableGrid.DataSource = null;
                addViewButtonToDatagridView();
                //gelecek
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singleton.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void btnIncomingRefresh_Click(object sender, EventArgs e)
        {
            panelConfirmation.Visible = false;
            try
            {
                tableGrid.DataSource = null;
                addViewButtonToDatagridView();
                tableGrid.DataSource = Singleton.instanceInvoiceGet.getIncomingInvoice();
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singleton.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnRefreshSentInvoice_Click(object sender, EventArgs e)
        {
            panelConfirmationSentInv.Visible = false;
            try
            {
                tableGrid.DataSource = null;
                tableGrid.DataSource = Singleton.instanceInvoiceGet.getSentInvoice();
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singleton.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void addViewButtonToDatagridView()
        {
            tableGrid.Columns.Clear();
            //pdf goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconPdf,
                Name = "PreviewPdf",
                HeaderText = Localization.preview
            });


            //xml goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconXml,
                Name = "PreviewXml",
                HeaderText = Localization.preview,
            });
        }



        private void invoiceResponseAcceptOrReject(string state)
        {
            int verifiedrow = 0;
            int invoiceCount = tableGrid.SelectedRows.Count;
            string[] description = new string[invoiceCount];


            string desc = Interaction.InputBox(Localization.writeDescription, Localization.addDescription, "Default");

            foreach (DataGridViewRow row in tableGrid.SelectedRows)
            {
                DateTime dt = DateTime.Parse(row.Cells["issueDate"].Value.ToString());
                TimeSpan fark = DateTime.Today - dt;

                if (row.Cells["profileid"].Value == null || row.Cells[5].Value.ToString() == "TEMELFATURA")//ticari faturaysa
                {
                    MessageBox.Show((row.Cells["ID"].Value.ToString()) + " " + Localization.warningBasicInvoice);
                    break;
                }
                else if (fark.TotalDays > 8)//8 gün geçmis
                {
                    MessageBox.Show((row.Cells["ID"].Value.ToString()) + " " + Localization.warning8Day);
                    break;
                }
                else if (row.Cells["status"].Value == null || row.Cells["status"].Value.ToString() != "RECEIVE - WAIT_APPLICATION_RESPONSE")//olan varsa
                {
                    MessageBox.Show((row.Cells["ID"].Value.ToString()) + " " + Localization.warningHasAnswer);
                    break;
                }
                else//fatura noların oldugu kabul lıstesi olustur
                {
                    string id = row.Cells["ID"].Value.ToString();
                    Singleton.instanceInvoiceGet.createInvoiceWithId(invoiceCount, id, verifiedrow);

                    description[verifiedrow] = desc;
                    verifiedrow++;
                }
            }
            if (verifiedrow > 0)//hicbir ınvoıce verıfıed olmamıssa
            {

                string res = Singleton.instanceInvoiceGet.sendInvoiceResponse(state, description);
                if (res == "succes") //return code 0 ise
                {
                    MessageBox.Show(Localization.succesChangeState);
                }
                else
                {
                    MessageBox.Show(Localization.unsuccesChangeState);
                }
            }
        }



        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                invoiceResponseAcceptOrReject("KABUL");
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singleton.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void btnReject_Click(object sender, EventArgs e)
        {

            try
            {
                invoiceResponseAcceptOrReject("RED");
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singleton.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void showStateInvoice()
        {
            try
            {
                if (tableGrid.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow row in tableGrid.SelectedRows)
                    {
                        if (row.Cells["profileid"].Value.ToString() == "TEMELFATURA")
                        {
                            MessageBox.Show("Temel faturanın durumu değişmeyeceği için durum sorgulaması yapılmayacaktır");
                            break;
                        }
                        if (row.Cells["status"].Value.ToString().Contains("SUCCEED") || row.Cells[11].Value.ToString().Contains("FAILED"))
                        {
                            MessageBox.Show("Faturanızın durumu nihai duruma ulaştığından değişmeyeceği için durum sorgulaması yapılmayacaktır");
                            break;
                        }

                        string uuid = row.Cells["ettn"].Value.ToString();
                        InvoiceStatus invoiceStatus = Singleton.instanceInvoiceGet.getInvoiceState(uuid);

                        using (FrmDialog frmShowInvoiceState = new FrmDialog(invoiceStatus))
                        {
                            frmShowInvoiceState.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("secilen fatura sayısı 1 olmalıdır");
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singleton.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void previewInvoiceType(string type)
        {
            try
            {
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    string id = row.Cells["ID"].Value.ToString();
                    string filepath = Singleton.instanceInvoiceGet.getInvoiceType(id, type);
                    System.Diagnostics.Process.Start(filepath);
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singleton.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnIncomingInvGetState_Click(object sender, EventArgs e)
        {
            showStateInvoice();
        }

        private void btnSentInvGetState_Click(object sender, EventArgs e)
        {
            showStateInvoice();
        }






        private void tableGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                #region panelVisiblity
                if (invType == 1)//gelen faturalara tıklandıysa
                {
                    panelConfirmation.Visible = true;
                }
                else if (invType == 2)//giden faturalar
                {
                    panelConfirmationSentInv.Visible = true;
                }
                #endregion

                //PDF göruntule butonuna tıkladıysa
                if (e.ColumnIndex == tableGrid.Columns["PreviewPdf"].Index)
                {
                    previewInvoiceType("PDF");
                }
                //xml göruntule butonuna tıkladıysa
                else if (e.ColumnIndex == tableGrid.Columns["PreviewXml"].Index)
                {
                    previewInvoiceType("XML");
                }
            }
        }



        private void btnGetInvoiceIncoming_Click(object sender, EventArgs e)
        {
            try
            {
                Singleton.instanceInvoiceGet.downloadInvoice();
                MessageBox.Show("Gelen faturalar 'D:\\temp\\GELEN\\' klasorune kaydedılmıstır");

            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singleton.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSentInvAgainSent_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singleton.instanceAuthGet.Login(FrmLogin.usurname, FrmLogin.password);
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

