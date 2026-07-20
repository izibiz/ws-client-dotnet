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
using izibiz.MODEL.Entities;
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
            try { this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath); } catch { }
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
            //eleman text yazdýr
            //panel gelen irsaliye

            //panel giden irsaliye

            //panel taslak irsaliye
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




        private void itemInDespatch_Click(object sender, EventArgs e)
        {
            despactDirection = EI.Direction.IN.ToString();
            lblText.Text = despactDirection;
            btnTakeDespatch.Visible = true;
            selectPanelVisibilty(false, false, false);

            gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(despactDirection));
        }



        private void itemOutDespatch_Click(object sender, EventArgs e)
        {
            despactDirection = EI.Direction.OUT.ToString();
            lblText.Text = despactDirection;
            btnTakeDespatch.Visible = true;
            selectPanelVisibilty(false, false, false);

            gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(despactDirection));
        }



        private void itemDraftDespatch_Click(object sender, EventArgs e)
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

            try
            {
                //Gönderici posta kutusu bilgilerini cekmek istiyor musunuz? Bu iþlem en az 15 dk surer.
                DialogResult response = MessageBox.Show(Lang.wantGetUserList, Lang.warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (response == DialogResult.OK)
                {
                    //servisten cek
                    string  errorMessage = Singl.GibUserControllerGet.getGibUserList(nameof(EI.ProductType.DESPATCHADVICE));
                    if (errorMessage != null)
                    {
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(Lang.succesful);
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
            catch (System.Data.Entity.Infrastructure.DbUpdateException  ex)
            {
                MessageBox.Show(ex.Message+Lang.dbFault, "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }



        private void itemGetListGibUserList_Click(object sender, EventArgs e)
        {
            despactDirection = EI.GibUser.GibUsers.ToString();
            btnTakeDespatch.Visible = false;
            selectPanelVisibilty(false, false, false);

            try
            {
                gridUpdateGibUserList(Singl.gibUsersDalGet.getGibUserList(nameof(EI.ProductType.DESPATCHADVICE)));

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



        public string despatchStatusDescWrite(string statusCode)
        {

            if (statusCode == "101")
            {
                return "KUYRUÐA EKLENDÝ";
            }
            if (statusCode == "102")
            {
                return "TASLAK ÝÞLENÝYOR";
            }
            if (statusCode == "103")
            {
                return "PAKETLENIYOR";
            }
            if (statusCode == "104")
            {
                return "PAKETLENDÝ";
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
                return "ÝMZALANDI";
            }
            if (statusCode == "109")
            {
                return "GÝB DEN YANIT BEKLÝYOR";
            }
            if (statusCode == "110")
            {
                return "ALICIDAN YANIT BEKLÝYOR";
            }
            if (statusCode == "111")
            {
                return "ALICIDAN ONAY BEKLÝYOR";
            }
            if (statusCode == "112")
            {
                return "KABUL EDÝLDÝ";
            }
            if (statusCode == "113")
            {
                return "KABUL ÝÞLENÝYOR";
            }
            if (statusCode == "114")
            {
                return "KABUL GÝBDEN YANIT BEKLÝYOR";
            }
            if (statusCode == "115")
            {
                return "KABUL ALICIDAN YANIT BEKLÝYOR";
            }
            if (statusCode == "116")
            {
                return "KABUL ÝÞLENÝYOR";
            }
            if (statusCode == "117")
            {
                return "KABUL ALICIDAN YANIT BEKLÝYOR";
            }
            if (statusCode == "118")
            {
                return "KABUL GÝBDEN YANIT BEKLÝYOR";
            }
            if (statusCode == "119")
            {
                return "KABUL ÝÞLENÝYOR";
            }
            if (statusCode == "120")
            {
                return "KABUL EDÝLDÝ";
            }
            if (statusCode == "121")
            {
                return "KABUL ÝÞLEMÝ BAÞARISIZ";
            }
            if (statusCode == "122")
            {
                return "KABUL EDÝLDÝ";
            }
            return "DURUM HENÜZ GÜNCELLENMEDÝ";

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

            //devamýný yap


        }




        private void gridChangeGibUsersColumnHeadersText()
        {

            tableGrid.Columns[EI.GibUser.aliasPk.ToString()].HeaderText = Lang.toAlias;

            tableGrid.Columns[EI.GibUser.identifier.ToString()].HeaderText = Lang.id;

            tableGrid.Columns[EI.GibUser.title.ToString()].HeaderText = Lang.title;
        }





        private void gridUpdateDespatchList(List<DespatchAdvices> gridListDespatch)
        {
            tableGrid.DataSource = null;
            tableGrid.Columns.Clear();

            if (gridListDespatch.Count == 0)
            {
                MessageBox.Show("Getirilecek irsaliye bulunamadý");
                lblRowClickInfo.Visible = false;
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

                if (!nameof(EI.Direction.DRAFT).Equals(despactDirection)) //direction draft degýlse
                {
                    tableGrid.Columns[EI.Despatch.draftFlag.ToString()].Visible = false;
                }

                lblRowClickInfo.Text = Lang.clickRowInvoice;
                lblRowClickInfo.Visible = true;
            }
        }



        private void gridUpdateGibUserList(List<GibUsers> gridListGibUsers)
        {
            tableGrid.DataSource = null;
            tableGrid.Columns.Clear();

            if (gridListGibUsers.Count == 0)
            {
                MessageBox.Show(Lang.noShowInvoice);
            }
            else
            {
                tableGrid.DataSource = gridListGibUsers;
                gridChangeGibUsersColumnHeadersText();
            }
        }



        private void btnTakeDespatch_Click(object sender, EventArgs e)
        {
            try
            {
                //servisten yený irsaliyeleri cek db ye kaydet ve datagridde göster            
                string errorMessage = Singl.despatchControllerGet.despatchListSaveDbFromService(despactDirection);

                if (errorMessage == null)//islem basarýlý sekýlde kaydedýlmýsse
                {
                    gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(despactDirection));
                }
                else //islem basarýzsa
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
                        if (despactDirection == nameof(EI.Direction.IN))//gelen faturalara týklandýysa
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

                        //html göruntule butonuna týkladýysa
                        if (e.ColumnIndex == tableGrid.Columns[nameof(EI.GridBtnClmName.previewHtml)].Index)
                        {
                            string uuid = tableGrid.Rows[e.RowIndex].Cells[nameof(EI.Invoice.uuid)].Value.ToString();
                          
                            string content = Singl.despatchControllerGet.getDespatchContentXml(uuid, despactDirection);
                            if (content != null) //servisten veya dýskten getýrlebýlmýsse
                            {
                                FrmView previewInvoices = new FrmView(content, nameof(EI.Despatch.DespatchAdvices));
                                previewInvoices.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show(Lang.cantGetContent);
                            }
                        }
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






        private void btnInDespatchGetStatus_Click(object sender, EventArgs e)
        {
            getDespatchStatus();
        }



        private void btnOutDespatchGetStatus_Click(object sender, EventArgs e)
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

                //gelen irsalýyelerýn durumunu sorgula
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
                    if (errorMessage == null)//islem basarýlý sekýlde kaydedýlmýsse
                    {
                        MessageBox.Show(Lang.succesful); //iþlem basarýlý
                        gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(despactDirection));
                    }
                    else //islem basarýzsa
                    {
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sorgulanacak uygun fatura bulunamadý");
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
                //servisten tarih aralýðýna uygun faturalarý getýr
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

            //verýlmek ýstenen ýd on ekýye aýt yený ýd serýal arr olusturulur
            IdArrContentArrModel idArrContentArr = new IdArrContentArrModel();

            //id serisi olusturuldu
            idArrContentArr.newIdArr = InvoiceIdSetSerilaze.createNewInvId(serialName, tableGrid.SelectedRows.Count);

            idArrContentArr.newXmlContentArr = new string[idArrContentArr.newIdArr.Length];


            for (int cnt = 0; cnt < tableGrid.SelectedRows.Count; cnt++)
            {
                string uuidRow = tableGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                string xmlContent = Singl.despatchControllerGet.getDespatchContentXml(uuidRow, despactDirection);
                if (xmlContent == null) //content gerýlemedýyse
                {
                    MessageBox.Show("content getýrýlemedý  " + tableGrid.SelectedRows[cnt].Cells[nameof(EI.Despatch.ID)].Value.ToString());
                    return null;
                }

                idArrContentArr.newXmlContentArr[cnt] = XmlControl.xmlDespatchChangeIdValue(xmlContent, idArrContentArr.newIdArr[cnt]);

                Singl.despatchControllerGet.createDespatchListWithContent(idArrContentArr.newXmlContentArr[cnt]);

            }

            return idArrContentArr;
        }







        private void btnLoadDespatch_Click(object sender, EventArgs e)
        {
            try
            {
                //db den getýrýlen serý Namelerý comboboxda sectýr
                FrmDialogSelectItem frmDialogIdSeriName = new FrmDialogSelectItem(true, "");
                if (frmDialogIdSeriName.ShowDialog() == DialogResult.OK)
                {
                    IdArrContentArrModel idArrContentArrModel = createInvListWithNewId(frmDialogIdSeriName.selectedValue); //load ýnvda  direction degýstýrmýyoruz o yuzden false

                    if (idArrContentArrModel != null)
                    {
                        string errorMessage = Singl.despatchControllerGet.loadDespatchToService();

                        if (errorMessage != null) //  basarýsýzsa
                        {
                            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else //servýse yukleme ýslemý basarýlýysa
                        {

                            for (int cnt = 0; cnt < tableGrid.SelectedRows.Count; cnt++)
                            {
                                string uuidRow = tableGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.uuid)].Value.ToString();

                                //yený ýd ile yený folderpath olustur
                                string newFolderPath = FolderControl.createDespatchDocPath(idArrContentArrModel.newIdArr[cnt], nameof(EI.Direction.DRAFT), nameof(EI.DocumentType.XML));

                                string oldFolderPath = Singl.DespatchAdviceDalGet.getDespatch(uuidRow, nameof(EI.Direction.DRAFT)).folderPath;


                                //db verileri guncelle
                                if (Singl.DespatchAdviceDalGet.updateDespatchIdCdateStatusGibCodeStateNoteFolderPath(uuidRow, nameof(EI.Direction.DRAFT),
                                  idArrContentArrModel.newIdArr[cnt], DateTime.Now, nameof(EI.StatusType.LOAD) + " - " + nameof(EI.SubStatusType.SUCCEED),
                                   -1, nameof(EI.StatusType.LOAD), newFolderPath) == 1)
                                {
                                    //yený olust. folderpath ýle xml ý dýske kaydet
                                    FolderControl.writeFileOnDiskWithString(idArrContentArrModel.newXmlContentArr[cnt], newFolderPath);

                                    //eský folderPathdeký dosyayý konumdan sýler
                                    FolderControl.deleteFileFromPath(oldFolderPath);
                                }
                                else
                                {
                                    MessageBox.Show("Güncel bilgileri Db ye kaydetme iþlemi basarýsýz,Ýþlemi tekrar gerceklestýrýnýz" + tableGrid.SelectedRows[cnt].Cells[nameof(EI.Despatch.ID)].Value.ToString());
                                    return;
                                }
                            }

                            //db ye, en son olusturulan yený ýnv id serisinin son itemi ýle serý no ve yýl guncelle
                            Singl.invIdSerilazeDalGet.updateLastAddedInvIdSeri(idArrContentArrModel.newIdArr.Last());

                            // db den cekýlen taslak faturalarý datagrýdde listele
                            gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(nameof(EI.Direction.DRAFT)));

                            MessageBox.Show(Lang.successLoad);//"yukleme basarýlý"
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




        private void btnSendDespatch_Click(object sender, EventArgs e)
        {
            try
            {
                bool valid = true;


                //ayný kýsýye gýdecek faturalar secýlý mý kontrolu
                string receiverVkn = tableGrid.SelectedRows[0].Cells[nameof(EI.Despatch.receiverVkn)].Value.ToString();
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    if (row.Cells[nameof(EI.Despatch.receiverVkn)].Value != null && row.Cells[nameof(EI.Despatch.receiverVkn)].Value.ToString() != receiverVkn) //vkn farklý ýse
                    {
                        MessageBox.Show(Lang.selectOnePerson);//sadece ayný kýsýye olan faturalarý býrlýkte gonderebýlýrsýnýz
                        valid = false; break;
                    }
                }

                if (valid) //uymayan irsaliye durumu yoksa
                {
                    //db den getýrýlen serý Namelerý comboboxda sectýr
                    FrmDialogSelectItem frmDialogSelectSeriName = new FrmDialogSelectItem(true, "");
                    if (frmDialogSelectSeriName.ShowDialog() == DialogResult.OK)
                    {

                        FrmDialogSelectItem frmDialogIdSelectAlias = new FrmDialogSelectItem(false, receiverVkn);
                        ////gb  sectýr
                        if (frmDialogIdSelectAlias.ShowDialog() == DialogResult.OK)
                        {
                            IdArrContentArrModel ýdContentModel = createInvListWithNewId(frmDialogSelectSeriName.selectedValue);

                            //send despatch 
                            string errorMessage = Singl.despatchControllerGet.sendDespatch(frmDialogIdSelectAlias.selectedValue,receiverVkn);
                            if (errorMessage != null)
                            {
                                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                for (int cnt = 0; cnt < tableGrid.SelectedRows.Count; cnt++)
                                {
                                    string uuidRow = tableGrid.SelectedRows[cnt].Cells[nameof(EI.Despatch.uuid)].Value.ToString();

                                    string oldFolderPath = Singl.DespatchAdviceDalGet.getDespatch(uuidRow, nameof(EI.Direction.DRAFT)).folderPath;

                                    //yený folderpath olustur
                                    string newFolderPath = FolderControl.createDespatchDocPath(ýdContentModel.newIdArr[cnt], nameof(EI.Direction.OUT),
                                        nameof(EI.DocumentType.XML)); // yený path db ye yazýlýr



                                    //db de yený id,direction,folderpath,statenote guncellenýr
                                    if (Singl.DespatchAdviceDalGet.updateDespatchIdDirectionFolderPathStateNote(uuidRow, nameof(EI.Direction.DRAFT),
                                         ýdContentModel.newIdArr[cnt], nameof(EI.Direction.OUT), newFolderPath, nameof(EI.StatusType.SEND)) == 1)
                                    {
                                        //eský folderPathdeký dosyayý konumdan sýler
                                        FolderControl.deleteFileFromPath(oldFolderPath);

                                        //yený folderpath ile yený id eklenmýs xmli diske kaydet
                                        FolderControl.writeFileOnDiskWithString(ýdContentModel.newXmlContentArr[cnt], newFolderPath);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Güncel bilgileri Db ye kaydetme iþlemi basarýsýz,Ýþlemi tekrar gerceklestýrýnýz" + tableGrid.SelectedRows[cnt].Cells[nameof(EI.Invoice.ID)].Value.ToString());
                                        return;
                                    }
                                }

                                //db ye, en son olusturulan yený ýnv id serisinin son itemi ýle serý no ve yýl guncelle
                                Singl.invIdSerilazeDalGet.updateLastAddedInvIdSeri(ýdContentModel.newIdArr.Last());

                                //datagrýd listesini guncelle
                                gridUpdateDespatchList(Singl.DespatchAdviceDalGet.getDespatchList(despactDirection));

                                MessageBox.Show(Lang.succesful);//"basarýlý"
                            }
                        }
                        frmDialogIdSelectAlias.Dispose();
                    }
                    frmDialogSelectSeriName.Dispose();
                }
            }


            catch (FaultException<REQUEST_ERRORType> ex)
            {
                if (ex.Detail.ERROR_CODE == 2005)
                {
                    Singl.authControllerGet.Login(FrmLogin.usurname, FrmLogin.password);
                }
                MessageBox.Show(Lang.operationFailed + ex.Detail.ERROR_SHORT_DES, "ProcessingFault", MessageBoxButtons.OK, MessageBoxIcon.Error); //iþlem basarýsýz
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

        private void btnInDespatchGetXml_Click(object sender, EventArgs e)
        {
            getXmlDespatch();
        }

        private void btnOutDespatchGetXml_Click(object sender, EventArgs e)
        {
            getXmlDespatch();
        }


        private void getXmlDespatch()
        {
            try
            {
               List<string> idList=new List<string>();
            
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    string content = Singl.despatchControllerGet.getDespatchXmlContentFromService(row.Cells[nameof(EI.Despatch.uuid)].Value.ToString(), despactDirection);
                    if (content != null)
                    {
                        FolderControl.writeFileOnDiskWithString(content,row.Cells[nameof(EI.Despatch.folderPath)].Value.ToString());
                        idList.Add(row.Cells[nameof(EI.Despatch.ID)].Value.ToString());
                    }
                }

                if (idList.Count > 0)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, idList) + Environment.NewLine + "Kaydedildi");//Seçili arsivler getirilemedi
                }
                else
                {
                    MessageBox.Show("iþlem Basarýsýz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Lang.dbFault + " " + ex.InnerException.Message.ToString(), "DataBaseFault", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.DataException ex)
            {
                MessageBox.Show(ex.InnerException.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }




        private void itemNewDespatch_Click(object sender, EventArgs e)
        {
            FrmCreateDespatch frmCreateDespatch = new FrmCreateDespatch();
            frmCreateDespatch.Show();
        }

        private void BtnHomePage_Click(object sender, EventArgs e)
        {
            FrmHome frmHome = new FrmHome();
            frmHome.Show();
            this.Dispose();
        }




    }
}
