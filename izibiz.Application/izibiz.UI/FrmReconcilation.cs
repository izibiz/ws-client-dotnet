using izibiz.COMMON;
using izibiz.COMMON.Language;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbTablesModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using izibiz.SERVICES.serviceReconcilation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace izibiz.UI
{
    public partial class FrmReconcilation : Form
    {

        private string reconcilationType;



        public FrmReconcilation()
        {
            InitializeComponent();
        }


        private void FrmReconcilation_Load(object sender, EventArgs e)
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

            this.Name = Lang.formReconcilation;
            lblInf.Text = Lang.rowClickForProses;
            btnHomePage.Text = Lang.homePage;
            lblWelcome.Text = Lang.welcome;
            itemCMReconcilations.Text = Lang.cmReconcilations;
            itemEMReconsilations.Text = Lang.emReconcilations;
            itemNewReconcilation.Text = Lang.newReconcilation;

            //panel butonlar
            btnSendReconcilation.Text = Lang.send;
            btnSendMailReconcilation.Text = Lang.sendToMail;
            btnGetStatusReconcilation.Text = Lang.updateState;
            #endregion

        }




        private void gridChangeReconcilationColumnHeadersText()
        {
            //datagrid colomn header lar degisecek
            tableGrid.Columns[EI.Reconcilation.uuid.ToString()].HeaderText = Lang.uuid;
            tableGrid.Columns[EI.Reconcilation.type.ToString()].HeaderText = Lang.type;
            tableGrid.Columns[EI.Reconcilation.customerTitle.ToString()].HeaderText = Lang.receiver + Lang.title;
            tableGrid.Columns[EI.Reconcilation.customerID.ToString()].HeaderText = Lang.receiverVkn;
            tableGrid.Columns[EI.Reconcilation.period.ToString()].HeaderText = Lang.period;
            tableGrid.Columns[EI.Reconcilation.status.ToString()].HeaderText = Lang.status;
            tableGrid.Columns[EI.Reconcilation.statusCode.ToString()].HeaderText = Lang.statusCode;
            tableGrid.Columns[EI.Reconcilation.createDate.ToString()].HeaderText = Lang.createDate;
            tableGrid.Columns[EI.Reconcilation.cmDate.ToString()].HeaderText = Lang.cmDate;
            tableGrid.Columns[EI.Reconcilation.email.ToString()].HeaderText = Lang.mail;
            tableGrid.Columns[EI.Reconcilation.emailStatusCode.ToString()].HeaderText = Lang.mailStatusCode;
            tableGrid.Columns[EI.Reconcilation.emailStatusDesc.ToString()].HeaderText = Lang.mailStatus;
            tableGrid.Columns[EI.Reconcilation.isSend.ToString()].HeaderText = Lang.isSend;
            tableGrid.Columns[EI.Reconcilation.baDocPiece.ToString()].HeaderText = Lang.baDocPiece;
            tableGrid.Columns[EI.Reconcilation.bsDocPiece.ToString()].HeaderText = Lang.bsDocPiece;
            tableGrid.Columns[EI.Reconcilation.currentAmount.ToString()].HeaderText = Lang.currentAmount;
            tableGrid.Columns[EI.Reconcilation.accountType.ToString()].HeaderText = Lang.accountType;
            tableGrid.Columns[EI.Reconcilation.baDocAmount.ToString()].HeaderText = Lang.baDocAmount;
            tableGrid.Columns[EI.Reconcilation.bsDocAmount.ToString()].HeaderText = Lang.bsDocAmount;

        }




        private string reconcilationStatusDescWrite(string statusCode)
        {

            if (statusCode == "100")
            {
                return "KUYRUĞA EKLENDİ";
            }
            if (statusCode == "105")
            {
                return "TASLAK İŞLENİYOR";
            }
            if (statusCode == "110")
            {
                return "İŞLENİYOR";
            }
            if (statusCode == "120")
            {
                return "İŞLENDİ";
            }
            if (statusCode == "125")
            {
                return "MUTABIK";
            }
            if (statusCode == "126")
            {
                return "MUTABIK DEĞİL";
            }
            return "durum ataması beklenıyor";
        }




        private string reconcilationMailStatusDescWrite(string mailStatusCode)
        {

            if (mailStatusCode == "100")
            {
                return "HENUZ İSLENMEDİ";
            }
            if (mailStatusCode == "110")
            {
                return "İŞLENİYOR";
            }
            if (mailStatusCode == "120")
            {
                return "İŞLENDİ";
            }
            if (mailStatusCode == "130")
            {
                return "E-POSTA GÖNDERİM SONLANDI";
            }
            return "durum ataması beklenıyor";
        }




        private void gridUpdateDespatchList(List<Reconcilations> gridListReconcilation)
        {
            tableGrid.DataSource = null;

            if (gridListReconcilation.Count == 0)
            {
                MessageBox.Show(Lang.noReconcilation);//"Getirilecek Mutabakat bulunamadı"
            }
            else
            {
                foreach (Reconcilations reconcilation in gridListReconcilation)
                {
                    reconcilation.status = reconcilationStatusDescWrite(reconcilation.statusCode);
                    reconcilation.emailStatusDesc = reconcilationMailStatusDescWrite(reconcilation.emailStatusCode);
                }

                tableGrid.DataSource = gridListReconcilation;
                gridChangeReconcilationColumnHeadersText();

                if (nameof(EI.Reconcilation.CM).Equals(reconcilationType)) //reconcı type CurrentReconcilation ise
                {
                    tableGrid.Columns[EI.Reconcilation.baDocPiece.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.bsDocPiece.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.baDocAmount.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.bsDocAmount.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.period.ToString()].Visible = false;
                }
                else  //ba bs secılı ıse
                {
                    tableGrid.Columns[EI.Reconcilation.currentAmount.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.accountType.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.createDate.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.cmDate.ToString()].Visible = false;
                }

                tableGrid.Columns[EI.Reconcilation.emailStatusCode.ToString()].Visible = false;
                tableGrid.Columns[EI.Reconcilation.emailStatusDate.ToString()].Visible = false;
                tableGrid.Columns[EI.Reconcilation.statusCode.ToString()].Visible = false;
                tableGrid.Columns[EI.Reconcilation.createDate.ToString()].Visible = false;


            }
        }





        private void İtemCurrentReconcilations_Click(object sender, EventArgs e)
        {
            reconcilationType = EI.Reconcilation.CM.ToString();
            pnlReconcilationButton.Enabled = false;
            try
            {
                //db den getır
                gridUpdateDespatchList(Singl.reconcilationDalGet.getReconcilationsWithType(reconcilationType));

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






        private void İtemBaBsReconsilations_Click(object sender, EventArgs e)
        {
            reconcilationType = EI.Reconcilation.EM.ToString();
            pnlReconcilationButton.Enabled = false;
            try
            {
                //db den getır
                gridUpdateDespatchList(Singl.reconcilationDalGet.getReconcilationsWithType(reconcilationType));

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





        private void İtemNewReconcilation_Click(object sender, EventArgs e)
        {
            FrmCreateReconcilation frmCreate = new FrmCreateReconcilation();
            frmCreate.Show();
        }






        private void BtnGetStatusReconcilation_Click(object sender, EventArgs e)
        {
            try
            {

                List<string> uuidList = new List<string>();
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    uuidList.Add(row.Cells[nameof(EI.Reconcilation.uuid)].Value.ToString());
                }


                if (uuidList.Count > 0) //gonderilerecek faturalar varsa
                {
                    var status = Singl.reconcilationControllerGet.getStatusReconcilation(uuidList.ToArray());

                    if (status != null)
                    {
                        MessageBox.Show(Lang.succGetStatus);//"Servisten durum sorgulama işlemi basarılı"

                        //db ye durumu gönderildi olarak guncelle
                        if (Singl.reconcilationDalGet.updateStatusReconcilation(status))

                            MessageBox.Show(Lang.succSaveStatus);//"Db ye  durum kaydetme basarılı"

                        // guncel durumunu gostermek ıcın tabloyu yenıleyelım
                        gridUpdateDespatchList(Singl.reconcilationDalGet.getReconcilationsWithType(reconcilationType));
                    }
                    else
                    {
                        MessageBox.Show(Lang.unSuccSaveStatus);//"Db ye mutaabakın  durumunu kaydetme basarısız"
                    }
                }
                else
                {
                    MessageBox.Show(Lang.unsuccesChangeState, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//"Servisten durum sorgulama işlemi basarısız"
                }
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







        private void BtnSendReconcilation_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> beforeSendList = new List<string>();
                List<string> validUuidList = new List<string>();

                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    if (Convert.ToBoolean(row.Cells[nameof(EI.Reconcilation.isSend)].Value))//daha once gonderılmıs ise
                    {
                        beforeSendList.Add(row.Cells[nameof(EI.Reconcilation.uuid)].Value.ToString());
                    }
                    else  //gonderılmemısse
                    {
                        if (reconcilationType == EI.Reconcilation.EM.ToString()) //tipi ba bs 
                        {
                            Singl.reconcilationControllerGet.addListToSendReconcilationEM(
                                row.Cells[nameof(EI.Reconcilation.uuid)].Value.ToString(), row.Cells[nameof(EI.Reconcilation.customerID)].Value.ToString(),
                                row.Cells[nameof(EI.Reconcilation.customerTitle)].Value.ToString(), row.Cells[nameof(EI.Reconcilation.email)].Value.ToString(),
                                row.Cells[nameof(EI.Reconcilation.period)].Value.ToString(), Convert.ToInt32(row.Cells[nameof(EI.Reconcilation.baDocPiece)].Value),
                                Convert.ToDecimal(row.Cells[nameof(EI.Reconcilation.baDocAmount)].Value.ToString()), Convert.ToInt32(row.Cells[nameof(EI.Reconcilation.bsDocPiece)].Value.ToString()),
                                Convert.ToDecimal(row.Cells[nameof(EI.Reconcilation.bsDocAmount)].Value.ToString()));
                        }
                        else //tipi carı mutabakat ıse
                        {
                            Singl.reconcilationControllerGet.addListToSendReconcilationCM(
                                row.Cells[nameof(EI.Reconcilation.uuid)].Value.ToString(), row.Cells[nameof(EI.Reconcilation.customerID)].Value.ToString(),
                                row.Cells[nameof(EI.Reconcilation.customerTitle)].Value.ToString(), row.Cells[nameof(EI.Reconcilation.email)].Value.ToString(),
                                Convert.ToDecimal(row.Cells[nameof(EI.Reconcilation.currentAmount)].Value.ToString()),
                                row.Cells[nameof(EI.Reconcilation.accountType)].Value.ToString(),
                                Convert.ToDateTime(row.Cells[nameof(EI.Reconcilation.cmDate)].Value.ToString())
                                );
                        }
                        validUuidList.Add(row.Cells[nameof(EI.Reconcilation.uuid)].Value.ToString());
                    }
                }

                if (beforeSendList.Count > 0) //onceden gonderılmıs olanlar
                {
                    MessageBox.Show(string.Join(Environment.NewLine, beforeSendList) + Environment.NewLine +Lang.hasIdReconBeforeSending);//nolu mutabak daha once gonderılmıs tekrar gonderemezsınız
                }

                if (validUuidList.Count > 0) //gonderilerecek faturalar varsa
                {
                    string errorMessage = Singl.reconcilationControllerGet.sendReconcilation();
                    if (errorMessage == null)
                    {
                        MessageBox.Show(Lang.successLoad);//"Servise yukleme işlemi basarılı"
                        //db ye durumu gönderildi olarak guncelle
                        if (Singl.reconcilationDalGet.updateReconcilationIsSend(validUuidList, true))
                        {
                            MessageBox.Show(Lang.succSaveStatus);//"Db ye mutaabakın gonderılme durumunu kaydetme basarılı"

                            //isSend in guncel durumunu gostermek ıcın tabloyu yenıleyelım
                            gridUpdateDespatchList(Singl.reconcilationDalGet.getReconcilationsWithType(reconcilationType));
                        }
                        else
                        {
                            MessageBox.Show(Lang.unSuccSaveStatus);//"Db ye mutaabakın gonderılme durumunu kaydetme basarısız"
                        }
                    }
                    else
                    {
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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



        private void TableGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlReconcilationButton.Enabled = true;
        }



        private void btnSendMailReconcilation_Click(object sender, EventArgs e)
        {
            try
            {

                List<string> uuidList = new List<string>();
                foreach (DataGridViewRow row in tableGrid.SelectedRows)
                {
                    uuidList.Add(row.Cells[nameof(EI.Reconcilation.uuid)].Value.ToString());
                }

                
                if (uuidList.Count > 0) //gonderilerecek faturalar varsa
                {
                    string errorMessage = Singl.reconcilationControllerGet.sendMailReconcilation(uuidList.ToArray());

                    if (errorMessage == null)
                    {
                        MessageBox.Show(Lang.succSendMail);//"mail gönderme işlemi basarılı"
                    }
                    else
                    {
                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
