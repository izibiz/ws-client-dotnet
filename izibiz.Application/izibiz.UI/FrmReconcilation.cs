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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace izibiz.UI
{
    public partial class FrmReconcilation : Form
    {

        private string reconcilationType;



        public FrmReconcilation()
        {
            InitializeComponent();
        }



        private void gridChangeReconcilationColumnHeadersText()
        {

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



        private void gridUpdateDespatchList(List<Reconcilations> gridListReconcilation)
        {
            tableGrid.DataSource = null;

            if (gridListReconcilation.Count == 0)
            {
                MessageBox.Show("Getirilecek Mutabakat bulunamadı");
            }
            else
            {
                foreach (Reconcilations reconcilation in gridListReconcilation)
                {
                    reconcilation.status = reconcilationStatusDescWrite(reconcilation.statusCode);
                }

                tableGrid.DataSource = gridListReconcilation;
                gridChangeReconcilationColumnHeadersText();

                if (nameof(EI.Reconcilation.CurrentReconcilation).Equals(reconcilationType)) //reconcı type CurrentReconcilation ise
                {
                    tableGrid.Columns[EI.Reconcilation.baDocPiece.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.bsDocPiece.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.baDocAmount.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.bsDocAmount.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.period.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.type.ToString()].Visible = false;
                }
                else  //ba bs secılı ıse
                {
                    tableGrid.Columns[EI.Reconcilation.type.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.currentAmount.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.accountType.ToString()].Visible = false;
                    tableGrid.Columns[EI.Reconcilation.createDate.ToString()].Visible = false;
                }
            }
        }





        private void İtemCurrentReconcilations_Click(object sender, EventArgs e)
        {
            reconcilationType = EI.Reconcilation.CurrentReconcilation.ToString();
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
            reconcilationType = EI.Reconcilation.BaBsDoc.ToString();
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
