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
            btnPdfDownload.Text = Localization.pdfDownload;
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
            DataGridViewButtonColumn viewButtonColumn = new DataGridViewButtonColumn();
            viewButtonColumn.Name = "Preview";
            viewButtonColumn.Text = "View Invioce";
            viewButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndex = 0;
            if (tableGrid.Columns["Preview"] == null)
            {
                tableGrid.Columns.Insert(columnIndex, viewButtonColumn);
            }
        }



        private void invoiceResponseAcceptOrReject(string response)
        {
            try
            {
                string[] acceptList = new string[tableGrid.SelectedRows.Count];
                int i = 0;

                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    DateTime dt = DateTime.Parse(row.Cells[3].Value.ToString());
                    TimeSpan fark = DateTime.Today - dt;

                    if (fark.TotalDays > 8)//8 gün geçmis
                    {
                        MessageBox.Show(Localization.warning8Day);
                        break;
                    }
                    else if (row.Cells[5].Value == null || row.Cells[5].Value.ToString() == "TEMELFATURA")//ticari faturaysa
                    {
                        MessageBox.Show(Localization.warningBasicInvoice);
                        break;
                    }
                    else if (row.Cells[9].Value == null || row.Cells[9].Value.ToString() != "RECEIVE - WAIT_APPLICATION_RESPONSE")//olan varsa
                    {
                        MessageBox.Show(Localization.warningHasAnswer);
                        break;
                    }
                    else//fatura noların oldugu kabul lıstesi olustur
                    {
                        acceptList[i] = row.Cells[1].Value.ToString();
                        i++;
                    }
                }
                if (acceptList[0] != null)
                {
                    string res = Singleton.instanceInvoiceGet.sendInvoiceResponse(acceptList, response);
                    if (res == "succes")
                    {
                        MessageBox.Show(Localization.succesChangeState);
                    }
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


        private void btnAccept_Click(object sender, EventArgs e)
        {
            invoiceResponseAcceptOrReject("KABUL");
        }



        private void btnReject_Click(object sender, EventArgs e)
        {
            invoiceResponseAcceptOrReject("RED");
        }


        private void showStateInvoice()
        {
            try
            {
                if (tableGrid.SelectedRows.Count == 1)
                {
                    foreach (DataGridViewRow row in tableGrid.SelectedRows)
                    {
                        if (row.Cells[4].Value.ToString() == "TEMELFATURA")
                        {
                            MessageBox.Show("Temel faturanın durumu değişmeyeceği için durum sorgulaması yapılmayacaktır");
                            break;
                        }
                        if (row.Cells[10].Value.ToString().Contains("SUCCEED") || row.Cells[10].Value.ToString().Contains("FAILED"))
                        {
                            MessageBox.Show("Faturanızın durumu nihai duruma ulaştığından değişmeyeceği için durum sorgulaması yapılmayacaktır");
                            break;
                        }

                        string id = row.Cells[1].Value.ToString();
                        InvoiceStatus invoiceStatus = Singleton.instanceInvoiceGet.getInvoiceState(id);

                        using (FrmShowInvoiceState frmShowInvoiceState = new FrmShowInvoiceState(invoiceStatus))
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

        private void previewInvoice()
        {
            try
            {
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    string id = row.Cells[1].Value.ToString();
                    //controllerda fonksıyonu yazılacak
                    /*
                   using (FrmShowInvoiceState frmShowInvoiceState = new FrmShowInvoiceState())
                   {
                       frmShowInvoiceState.ShowDialog();
                   }*/
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

       

        private void btnPdfDownload_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    string uuid = row.Cells[2].Value.ToString();
                    Singleton.instanceInvoiceGet.downloadPdf(uuid);
                    MessageBox.Show("secılı faturalar 'D:\\temp\\GELEN\\' klasorune kaydedılmıstır");
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


        private void tableGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (invType == 1)//gelen faturalara tıklandıysa
                {
                    panelConfirmation.Visible = true;
                }
                else if (invType == 2)//giden faturalar
                {
                    panelConfirmationSentInv.Visible = true;
                }

                //göruntule butonuna tıkladıysa
                if (e.ColumnIndex == tableGrid.Columns["Preview"].Index)
                {
                    previewInvoice();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnGetInvoiceIncoming_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    string uuid = row.Cells[2].Value.ToString();
                

                    MessageBox.Show("secılı faturalar 'D:\\temp\\GELEN\\' klasorune kaydedılmıstır");
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
    }

}

