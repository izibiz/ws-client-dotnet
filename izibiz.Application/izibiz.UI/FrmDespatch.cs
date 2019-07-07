﻿using izibiz.COMMON;
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
using izibiz.COMMON.FileControl;
using izibiz.CONTROLLER;
using izibiz.CONTROLLER.Model;

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

            gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(despactDirection));
        }

        private void itemSentInvoice_Click(object sender, EventArgs e)
        {
            despactDirection = EI.Direction.OUT.ToString();
            lblText.Text = despactDirection;
            btnTakeDespatch.Visible = true;
            selectPanelVisibilty(false, false, false);

            gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(despactDirection));
        }

        private void itemDraftInvoice_Click(object sender, EventArgs e)
        {
            despactDirection = EI.Direction.DRAFT.ToString();
            lblText.Text = despactDirection;
            btnTakeDespatch.Visible = false;
            selectPanelVisibilty(false, false, false);

            gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(despactDirection));
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



        public string despatchStatusDescWrite(string statusCode)
        {

            if (statusCode == "101")
            {
                return "KUYRUĞA EKLENDİ";
            }
            if (statusCode == "102")
            {
                return "TASLAK İŞLENİYOR";
            }
            if (statusCode == "103")
            {
                return "PAKETLENIYOR";
            }
            if (statusCode == "104")
            {
                return "PAKETLENDİ";
            }
            if (statusCode == "105")
            {
                return "PAKETLEME_HATASI";
            }
            if (statusCode == "106")
            {
                return "IMZALANIYOR";
            }
            if (statusCode == "107")
            {
                return "İMZALANDI";
            }
            if (statusCode == "109")
            {
                return "GİB DEN YANIT BEKLİYOR";
            }
            if (statusCode == "110")
            {
                return "ALICIDAN YANIT BEKLİYOR";
            }
            if (statusCode == "111")
            {
                return "ALICIDAN ONAY BEKLİYOR";
            }
            if (statusCode == "112")
            {
                return "KABUL EDİLDİ";
            }
            if (statusCode == "113")
            {
                return "KABUL İŞLENİYOR";
            }
            if (statusCode == "114")
            {
                return "KABUL GİBDEN YANIT BEKLİYOR";
            }
            if (statusCode == "115")
            {
                return "KABUL ALICIDAN YANIT BEKLİYOR";
            }
            if (statusCode == "116")
            {
                return "KABUL İŞLENİYOR";
            }
            if (statusCode == "117")
            {
                return "KABUL ALICIDAN YANIT BEKLİYOR";
            }
            if (statusCode == "118")
            {
                return "KABUL GİBDEN YANIT BEKLİYOR";
            }
            if (statusCode == "119")
            {
                return "KABUL İŞLENİYOR";
            }
            if (statusCode == "120")
            {
                return "KABUL EDİLDİ";
            }
            if (statusCode == "121")
            {
                return "KABUL İŞLEMİ BAŞARISIZ";
            }
            if (statusCode == "122")
            {
                return "KABUL EDİLDİ";
            }
            return "DURUM HENÜZ GÜNCELLENMEDİ";

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

            //  tableGrid.Columns[EI.Despatch.draftFlag.ToString()].HeaderText = Lang.DR;

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
                    despatch.status = despatchStatusDescWrite(despatch.statusCode);
                }

                addViewButtonToDatagridView();
                tableGrid.DataSource = gridListDespatch;
                dataGridChangeColumnHeaderText();

                if (!nameof(EI.Direction.DRAFT).Equals(despactDirection)) //direction draft degılse
                {
                    tableGrid.Columns[EI.Despatch.draftFlag.ToString()].Visible = false;
                }
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




        private void tableGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    if (despactDirection != nameof(EI.GibUser.GibUsers))
                    {

                        #region panelVisiblity
                        if (despactDirection == nameof(EI.Direction.IN))//gelen faturalara tıklandıysa
                        {
                            pnlIncomingDespatch.Visible = true;
                        }
                        else if (despactDirection == nameof(EI.Direction.OUT))//giden faturalar
                        {
                            pnlSendDespatch.Visible = true;
                        }
                        else if (despactDirection == nameof(EI.Direction.DRAFT))//taslak faturalar
                        {
                            pnlDraftDespatch.Visible = true;
                        }
                        #endregion


                        ////html göruntule butonuna tıkladıysa
                        //if (e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)].Index)
                        //{
                        //    string uuid = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                        //    string id = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.ID)].Value.ToString();

                        //    string content = Singl.invoiceControllerGet.getInvoiceContentXml(uuid, gridDirection);
                        //    if (content != null) //servisten veya dıskten getırlebılmısse
                        //    {
                        //        FrmView previewInvoices = new FrmView(content, nameof(EI.Invoice.Invoices));
                        //        previewInvoices.ShowDialog();
                        //    }
                        //    else
                        //    {
                        //        MessageBox.Show(Lang.cantGetContent);
                        //    }
                        //}
                    }
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
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }






        private void btnIncomingDespatchGetStatus_Click(object sender, EventArgs e)
        {
            getDespatchStatus();
        }



        private void btnSendDespatchGetStatus_Click(object sender, EventArgs e)
        {
            getDespatchStatus();
        }



        private void btnDraftDespatchGetStatus_Click(object sender, EventArgs e)
        {
            getDespatchStatus();
        }



        private void getDespatchStatus()
        {
            try
            {

                //gelen irsalıyelerın durumunu sorgula
                List<string> uuidList = new List<string>();

                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    //direction taslaksa portala yuklenme durumunu kontrol et
                    if (nameof(EI.Direction.DRAFT).Equals(row.Cells[nameof(EI.Despatch.direction)].Value) && true.Equals(row.Cells[nameof(EI.Despatch.draftFlag)].Value))
                    {

                        continue;
                    }
                    uuidList.Add(row.Cells[nameof(EI.Despatch.uuid)].Value.ToString());
                }
                if (uuidList.Count > 0)
                {
                    string errorMessage = Singl.despatchControllerGet.getDespatchStatusAndSaveDb(despactDirection, uuidList.ToArray());
                    if (errorMessage == null)//islem basarılı sekılde kaydedılmısse
                    {
                        MessageBox.Show(Lang.succesful); //işlem basarılı
                        gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(despactDirection));
                    }
                    else //islem basarızsa
                    {
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sorgulanacak uygun fatura bulunamadı");
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




        private void btnFilterList_Click(object sender, EventArgs e)
        {
            try
            {
                //servisten tarih aralığına uygun faturaları getır
                gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchListOnFilter(despactDirection, timeStartFilter.Value.Date, timeFinishFilter.Value.Date));
            }
            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private IdArrContentArrModel createInvListWithNewId(string serialName)
        {

            //verılmek ıstenen ıd on ekıye aıt yenı ıd serıal arr olusturulur
            IdArrContentArrModel idArrContentArr = new IdArrContentArrModel();

            //id serisi olusturuldu
            idArrContentArr.newIdArr = InvoiceIdSetSerilaze.createNewInvId(serialName, tableGrid.SelectedRows.Count);

            idArrContentArr.newXmlContentArr = new string[idArrContentArr.newIdArr.Length];


            for (int cnt = 0; cnt < tableGrid.SelectedRows.Count; cnt++)
            {
                string uuidRow = tableGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                string xmlContent = Singl.despatchControllerGet.getDespatchContentXml(uuidRow, despactDirection);
                if (xmlContent == null) //content gerılemedıyse
                {
                    MessageBox.Show("content getırılemedı  " + tableGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.ID)].Value.ToString());
                    return null;
                }

                idArrContentArr.newXmlContentArr[cnt] = XmlControl.xmlChangeIdValue(xmlContent, idArrContentArr.newIdArr[cnt]);

                Singl.despatchControllerGet.createDespatchListWithContent(idArrContentArr.newXmlContentArr[cnt]);

            }

            return idArrContentArr;
        }







        private void btnLoadDespatch_Click(object sender, EventArgs e)
        {
            try
            {
                //db den getırılen serı Namelerı comboboxda sectır
                FrmDialogSelectItem frmDialogIdSeriName = new FrmDialogSelectItem(true, "");
                if (frmDialogIdSeriName.ShowDialog() == DialogResult.OK)
                {
                    IdArrContentArrModel idArrContentArrModel = createInvListWithNewId(frmDialogIdSeriName.selectedValue); //load ınvda  direction degıstırmıyoruz o yuzden false

                    if (idArrContentArrModel != null)
                    {
                        string errorMessage = Singl.despatchControllerGet.loadDespatchToService();

                        if (errorMessage != null) //  basarısızsa
                        {
                            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else //servıse yukleme ıslemı basarılıysa
                        {

                            for (int cnt = 0; cnt < tableGrid.SelectedRows.Count; cnt++)
                            {
                                string uuidRow = tableGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                                //yenı ıd ile yenı folderpath olustur
                                string newFolderPath = FolderControl.createDespatchDocPath(idArrContentArrModel.newIdArr[cnt], nameof(EI.Direction.DRAFT), nameof(EI.DocumentType.XML));

                                //db verileri guncelle
                                if(Singl.DespatchAdviceDalGet.updateDespatchIdCdateStatusGibCodeStateNoteFolderPath(uuidRow, nameof(EI.Direction.DRAFT),
                                  idArrContentArrModel.newIdArr[cnt], DateTime.Now, nameof(EI.StatusType.LOAD) + " - " + nameof(EI.SubStatusType.SUCCEED),
                                   -1, nameof(EI.StatusType.LOAD), newFolderPath) == 1)
                                {
                                    //yenı olust. folderpath ıle xml ı dıske kaydet
                                    FolderControl.writeFileOnDiskWithString(idArrContentArrModel.newXmlContentArr[cnt], newFolderPath);

                                    //eskı folderPathdekı dosyayı konumdan sıler
                                    FolderControl.deleteFileFromPath(tableGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.folderPath)].Value.ToString());
                                }
                                else
                                {
                                    MessageBox.Show("Güncel bilgileri Db ye kaydetme işlemi basarısız,İşlemi tekrar gerceklestırınız" + tableGrid.SelectedRows[cnt].Cells[nameof(EI.Despatch.ID)].Value.ToString());
                                    return;
                                }
                            }

                            //db ye, en son olusturulan yenı ınv id serisinin son itemi ıle serı no ve yıl guncelle
                            Singl.invIdSerilazeDalGet.updateLastAddedInvIdSeri(idArrContentArrModel.newIdArr.Last());

                            // db den cekılen taslak faturaları datagrıdde listele
                            gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(nameof(EI.Direction.DRAFT)));

                            MessageBox.Show(Lang.successLoad);//"yukleme basarılı"
                        }
                    }
                    frmDialogIdSeriName.Dispose();
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
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                MessageBox.Show(Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }









    }
}