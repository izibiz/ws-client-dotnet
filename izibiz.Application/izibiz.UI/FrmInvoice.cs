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
using izibiz.CONTROLLER;
using izibiz.MODEL;

namespace izibiz.UI
{
    public partial class FrmInvoice : Form
    {

        private int invType;
        DataTable dt;

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
            btnSentInvGetState.Text = Localization.updateState;
            btnSentInvAgainSent.Text = Localization.againSent;
            btnFaultyInvoices.Text = Localization.faulty;
            //panelIncomingInvoices butonlar
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

        private void AddColumns()
        {
            dt.Columns.Add("ıd", typeof(int));
            dt.Columns.Add("tip", typeof(String));


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
                DateTime dt = DateTime.Parse(row.Cells["cDate"].Value.ToString());
                TimeSpan fark = DateTime.Today - dt;

                if (row.Cells["profileid"].Value == null || row.Cells[5].Value.ToString() == RequestEnum.GetInvoiceResponseInvoiceProfileid.TEMELFATURA.ToString())//temel faturaysa
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
            if (verifiedrow > 0)
            {
                Singleton.instanceInvoiceGet.sendInvoiceResponse(state, description);
            }
        }



        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                invoiceResponseAcceptOrReject(RequestEnum.SendInvoiceResponseWithServerSignRequestStatus.KABUL.ToString());
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
                invoiceResponseAcceptOrReject(RequestEnum.SendInvoiceResponseWithServerSignRequestStatus.RED.ToString());
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

        private bool statusValidCheck(DataGridViewRow row)
        {
            if (row.Cells["profileid"].Value.ToString() == RequestEnum.GetInvoiceResponseInvoiceProfileid.TEMELFATURA.ToString() ||
            row.Cells["status"].Value.ToString().Contains("SUCCEED") ||
            row.Cells["status"].Value.ToString().Contains("FAILED"))
            {
                return false;
            }

            return true;
        }

        /* string uuid = tableGrid.Rows[i].Cells["ettn"].Value.ToString();
         InvoiceStatus invoiceStatus = Singleton.instanceInvoiceGet.getInvoiceState(uuid);
                         */


        private void showStateInvoice(string invoiceType)
        {
            try
            {
                List<string> unvalidList = new List<string>();
                List<string> validList = new List<string>();
                string uuid;

                //   tableGrid.SelectedRows[0].Cells["status"] = Singleton.instanceInvoiceGet.getInvoiceState(validList);

                for (int i = 0; i < tableGrid.SelectedRows.Count; i++)
                {
                    uuid = tableGrid.Rows[i].Cells["ettn"].Value.ToString();
                    if (!statusValidCheck(tableGrid.SelectedRows[i])) //false ise
                    {
                        unvalidList.Add(uuid);
                    }
                    else //true ise
                    {
                        validList.Add(uuid);
                        if (invoiceType == "GELEN")
                        {
                            DataListInvoice.incomingInvioces.Find(x=>x.ettn==uuid).status=Singleton.instanceInvoiceGet.getInvoiceState(uuid);
                        }
                        else  //ınvoiceType GİDEN
                        {
                            DataListInvoice.sentInvoices.Find(x => x.ettn == uuid).status = Singleton.instanceInvoiceGet.getInvoiceState(uuid);
                        }
                    }
                }
                string message;
                if (validList.First() == null) //hicbiri krıterlere uygun degılse
                {
                     message = string.Join(Environment.NewLine, unvalidList);

                    MessageBox.Show(message + Environment.NewLine+ "nolu faturalar uygun degil bu yuzden guncellenmedı");
                }
                else//uygun fatura varsa
                {
                    tableGrid.DataSource = null;
                    addViewButtonToDatagridView();
                    if (invoiceType == "GELEN")
                    {
                        tableGrid.DataSource = DataListInvoice.incomingInvioces;
                    }
                    else
                    {
                        tableGrid.DataSource = DataListInvoice.sentInvoices;
                    }
                    message = string.Join(Environment.NewLine, validList);
                    MessageBox.Show(message + Environment.NewLine + "nolu faturalar guncellendı");
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
            showStateInvoice("GELEN");
        }

        private void btnSentInvGetState_Click(object sender, EventArgs e)
        {
            showStateInvoice("GİDEN");
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
                    previewInvoiceType(RequestEnum.InvoiceSearchKeyType.PDF.ToString());
                }
                //xml göruntule butonuna tıkladıysa
                else if (e.ColumnIndex == tableGrid.Columns["PreviewXml"].Index)
                {
                    previewInvoiceType(RequestEnum.InvoiceSearchKeyType.XML.ToString());
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

