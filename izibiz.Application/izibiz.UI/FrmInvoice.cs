using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.Model;
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
using izibiz.COMMON;
using izibiz.COMMON.Languages;

namespace izibiz.UI
{
    public partial class FrmInvoice : Form
    {

        private int invType;
        private DataTable dt;

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
                Lcl.Culture = new CultureInfo("en-US");
            }
            else
            {
                Lcl.Culture = new CultureInfo("");
            }
            #region writeAllFormItem
            //eleman text yazdır
            this.Text = Lcl.formInvoice;
            itemIncomingInvoice.Text = Lcl.incomingInvoice;
            itemComingListInvoice.Text = Lcl.listInvoice;
            itemSentInvoice.Text = Lcl.sentInvoice;
            itemDraftInvoice.Text = Lcl.draftInvoice;
            itemDraftNewInvoice.Text = Lcl.newInvoice;
            itemSentInvoiceList.Text = Lcl.listInvoice;
            itemDraftInvoiceList.Text = Lcl.listDraftInvoice;
            //panelSentInvoices butonlar
            btnSentInvGetState.Text = Lcl.updateState;
            btnSentInvAgainSent.Text = Lcl.againSent;
            btnFaultyInvoices.Text = Lcl.faulty;
            //panelIncomingInvoices butonlar
            btnAccept.Text = Lcl.accept;
            btnReject.Text = Lcl.reject;
            btnGetInvoiceIncoming.Text = Lcl.getInvoice;
            btnIncomingInvGetState.Text = Lcl.updateState;
            #endregion
        }

        private void dataGridChangeColoumnName()
        {
            tableGrid.Columns[2].Name = "i";
        }




        private void itemComingListInvoice_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lcl.incomingInvoice;
            panelSentInvoice.Visible = false;
            panelIncomingInvoice.Visible = true;
            panelConfirmation.Visible = false;
            invType = 1;
            try
            {
                tableGrid.DataSource = null;
                addViewButtonToDatagridView();
                var invoiceList = Singleton.instanceInvoiceGet.getIncomingInvoice();
                if (invoiceList.Any() == false)
                {
                    MessageBox.Show("Gösterilecek faturanız yok");
                }
                else
                {
                    /*foreach (var inv in invoiceDT)
                    {
                        inv.statusDesc = invoiceIncomingStatusWrite(inv.status,inv.gibStatusCode);
                    }*/
                    tableGrid.DataSource = invoiceList;
               //     dataGridChangeColoumnName();
               //     tableGrid.Columns["ii"].Visible = false;
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

      


        private void itemSentInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lcl.sentInvoice;
            panelIncomingInvoice.Visible = false;
            panelSentInvoice.Visible = true;
            panelConfirmationSentInv.Visible = false;
            invType = 2;
            try
            {
                tableGrid.DataSource = null;
                addViewButtonToDatagridView();
                 dt= Singleton.instanceInvoiceGet.getSentInvoice();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Gösterilecek okunmamıs faturanız yok");
                }
                else //yenı fatura varsa
                {
                    foreach (DataRow row in dt.Rows)
                    {
                      //  row[Lcl.statusDesc] = invoiceIncomingStatusWrite(row[Lcl.status].ToString());
                    }
                    tableGrid.DataSource = dt;
                    tableGrid.Columns[Lcl.status].Visible = false;
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


        private void itemDraftInvoiceList_Click(object sender, EventArgs e)
        {
            lblTitle.Text = Lcl.draftInvoice;
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
                HeaderText = Lcl.preview
            });


            //xml goruntule butonu
            tableGrid.Columns.Add(new DataGridViewImageColumn()
            {
                Image = Properties.Resources.iconXml,
                Name = "PreviewXml",
                HeaderText = Lcl.preview,
            });
        }


        public string invoiceIncomingStatusWrite(string status, int envelopeOpcode)
        {
         //   string status = invoice.status;
          //  int envelopeOpcode = invoice.gibStatusCode;

            if (envelopeOpcode == 1210)
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
            return "Durum Atanması Bekleniyor";
            }



        public string invoiceSendStatusWrite(Invoice invoice)
        {
            string status = invoice.status;

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






        private void invoiceResponseAcceptOrReject(string state)
        {
            int verifiedrow = 0;
            int invoiceCount = tableGrid.SelectedRows.Count;
            string[] description = new string[invoiceCount];


            string desc = Interaction.InputBox(Lcl.writeDescription, Lcl.addDescription, "Default");

            foreach (DataGridViewRow row in tableGrid.SelectedRows)
            {
                DateTime dt = DateTime.Parse(row.Cells[Lcl.cDate].Value.ToString());
                TimeSpan fark = DateTime.Today - dt;

                if (row.Cells[Lcl.profileid].Value == null || row.Cells[5].Value.ToString() == EI.InvoiceProfileid.TEMELFATURA.ToString())//temel faturaysa
                {
                    MessageBox.Show((row.Cells[Lcl.id].Value.ToString()) + " " + Lcl.warningBasicInvoice);
                    break;
                }
                else if (fark.TotalDays > 8)//8 gün geçmis
                {
                    MessageBox.Show((row.Cells[Lcl.id].Value.ToString()) + " " + Lcl.warning8Day);
                    break;
                }
                else if (row.Cells[Lcl.status].Value == null || row.Cells[Lcl.status].Value.ToString() != EI.SubStatusType.WAIT_APPLICATION_RESPONSE.ToString())//olan varsa
                {
                    MessageBox.Show((row.Cells[Lcl.id].Value.ToString()) + " " + Lcl.warningHasAnswer);
                    break;
                }
                else//fatura noların oldugu kabul lıstesi olustur
                {
                    string id = row.Cells[Lcl.id].Value.ToString();
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
                invoiceResponseAcceptOrReject(EI.InvoiceResponseStatus.KABUL.ToString());
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
                invoiceResponseAcceptOrReject(EI.InvoiceResponseStatus.RED.ToString());
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

            if ((row.Cells[Lcl.gibStatusCode].Value.Equals(1300) || row.Cells[Lcl.gibStatusCode].Value.Equals(1215) || row.Cells[Lcl.gibStatusCode].Value.Equals(1230))
                         || (Convert.ToInt32(row.Cells[Lcl.gibStatusCode].Value) < 1100 || (Convert.ToInt32(row.Cells[Lcl.gibStatusCode].Value) > 1200)))
            {
                return false;
            }
            return true;
        }



        private void showStateInvoice(string invoiceType)
        {
            try
            {
                List<string> unvalidList = new List<string>();
                List<string> validList = new List<string>();
                string uuid;

                for (int i = 0; i < tableGrid.SelectedRows.Count; i++)
                {
                    uuid = tableGrid.Rows[i].Cells[Lcl.uuid].Value.ToString();
                    if (!statusValidCheck(tableGrid.SelectedRows[i])) //selectedrows valid degıl ise
                    {
                        unvalidList.Add(uuid);
                    }
                    else //valid ise modelde guncelle
                    {
                        validList.Add(uuid);
                        if (invoiceType == EI.InvType.INCOMING.ToString())
                        {
                            //entıtıy eklendıgınde acılacak
                //            DataListInvoice.incomingInvioces.Find(x => x.Uuid == uuid).status = Singleton.instanceInvoiceGet.getInvoiceState(uuid);
                        }
                        else  //ınvoiceType GİDEN
                        {
                  //          DataListInvoice.sentInvoices.Find(x => x.Uuid == uuid).status = Singleton.instanceInvoiceGet.getInvoiceState(uuid);
                        }
                    }
                }
                string message;
                if (validList.First() == null) //hicbiri krıterlere uygun degılse
                {
                    if (tableGrid.SelectedRows.Count == 1)//tekli secim
                    {
                        MessageBox.Show("temel fatura veya 8 gün gecmiş faturaların durum sorgulaması yapılamaz");
                    }
                    else//coklu secım
                    {
                        message = string.Join(Environment.NewLine, unvalidList);
                        MessageBox.Show(message + Environment.NewLine + "nolu faturalar uygun degil bu yuzden guncellenmedı");
                    }
                }
                else//valid fatura varsa modelden datagride guncelle
                {
                    tableGrid.DataSource = null;
                    addViewButtonToDatagridView();
                    if (invoiceType == EI.InvType.INCOMING.ToString())
                    {
               //         tableGrid.DataSource = DataListInvoice.incomingInvioces;
                    }
                    else
                    {
               //         tableGrid.DataSource = DataListInvoice.sentInvoices;
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
                    string id = row.Cells[Lcl.id].Value.ToString();
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
            showStateInvoice(EI.InvType.INCOMING.ToString());
        }

        private void btnSentInvGetState_Click(object sender, EventArgs e)
        {
            showStateInvoice(EI.InvType.SENT.ToString());
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
                    previewInvoiceType(EI.InvoiceDownloadType.PDF.ToString());
                }
                //xml göruntule butonuna tıkladıysa
                else if (e.ColumnIndex == tableGrid.Columns["PreviewXml"].Index)
                {
                    previewInvoiceType(EI.InvoiceDownloadType.XML.ToString());
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

        private void itemDraftNewInvoice_Click(object sender, EventArgs e)
        {

        }
    }

}

