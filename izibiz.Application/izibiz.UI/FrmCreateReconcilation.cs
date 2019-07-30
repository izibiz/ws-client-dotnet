using izibiz.COMMON;
using izibiz.COMMON.Language;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbTablesModels;
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

namespace izibiz.UI
{
    public partial class FrmCreateReconcilation : Form
    {

        private string reconcilationType;

        public FrmCreateReconcilation()
        {
            InitializeComponent();
        }

        private void FrmCreateReconcilation_Load(object sender, EventArgs e)
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

        private void pnlVisibleBaBsOrCurrentShow()
        {
            if (cmbReconcilationSenario.SelectedItem.ToString() == "BA/BS Mutabakat")
            {
                reconcilationType = EI.Reconcilation.EM.ToString();
                pnlBaBsDocPiece.Visible = true;
                pnlCurrentPiece.Visible = false;
                btnCreate.Enabled = true;
            }
            else
            {
                reconcilationType = EI.Reconcilation.CM.ToString();
                pnlCurrentPiece.Visible = true;
                pnlBaBsDocPiece.Visible = false;
                btnCreate.Enabled = true;
            }
        }

        private void CmbReconcilationSenario_SelectedValueChanged(object sender, EventArgs e)
        {
            pnlVisibleBaBsOrCurrentShow();
        }




        private Boolean isEmptyComponent()
        {
            bool valid = true;

            foreach (Control item in pnlPartner.Controls)  
            {
                if (item is TextBox || item is MaskedTextBox) //texbox veya maskedbox ıse
                {
                    if (item == msdReceiverVkn)  //vkn_Tckn
                    {
                        if (item.Text.Replace(" ", String.Empty).Length < 10) //10 veya 10 dan buyukse
                        {
                            item.BackColor = Color.IndianRed;
                            valid = false;
                        }
                        else //validse
                        {
                            item.BackColor = Color.White;
                        }
                    }

                    else   // maskedbox degılse
                    {
                        if (item.Text.Replace(" ", String.Empty).Length ==  0) //text null veya bos ise
                        {
                            item.BackColor = Color.IndianRed;
                            valid = false;
                        }
                        else
                        {
                            item.BackColor = Color.White;
                        }
                    }
                }
            }

            if (reconcilationType==EI.Reconcilation.EM.ToString())
            {
                foreach (Control item in pnlBaBsDocPiece.Controls)  //grupbox alıcı bilgileri
                {
                    if (item is TextBox) //texbox  ıse
                    {

                        if (item.Text.Replace(" ", String.Empty).Length ==0) //text null veya bos ise
                        {
                            item.BackColor = Color.IndianRed;
                            valid = false;
                        }
                        else
                        {
                            item.BackColor = Color.White;
                        }

                    }
                }
            }
            else
            {
                foreach (Control item in pnlCurrentPiece.Controls)  //grupbox alıcı bilgileri
                {
                    if (item is TextBox) //texbox  ıse
                    {
                        if (item.Text.Replace(" ", String.Empty).Length == 0) //text null veya bos ise
                        {
                            item.BackColor = Color.IndianRed;
                            valid = false;
                        }
                        else
                        {
                            item.BackColor = Color.White;
                        }
                    }
                }
            }
            return valid;
        }




        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (isEmptyComponent())
            {

                try
                {

                    Reconcilations reconcilation = new Reconcilations();

                    reconcilation.uuid = Guid.NewGuid().ToString();
                    reconcilation.customerTitle = txtReceiverTitle.Text;
                    reconcilation.customerID = msdReceiverVkn.Text;
                    reconcilation.email = txtMail.Text;
                    reconcilation.type = reconcilationType;
                    reconcilation.createDate =DateTime.Now;

                    if (reconcilationType.Equals(EI.Reconcilation.CM.ToString()))//carı mutabakt
                    {
                        reconcilation.currentAmount = Convert.ToDecimal(txtCurrentAmount.Text);
                        if (cmbAccountType.SelectedIndex == 0)//alacak
                        {
                            reconcilation.accountType = EI.ReconcilationAmountType.ALACAK.ToString();
                        }
                        else//borclu
                        {
                            reconcilation.accountType = EI.ReconcilationAmountType.BORC.ToString();
                        }
                        reconcilation.cmDate =dateReconcilation.Value;
                    }
                    else //ba bs mutabakat
                    {
                        reconcilation.baDocPiece = Convert.ToInt32(nmBaDocPiece.Value);
                        reconcilation.bsDocPiece = Convert.ToInt32(nmBsDocPiece.Value);
                        reconcilation.baDocAmount = Convert.ToDecimal(txtBaAmount.Text);
                        reconcilation.bsDocAmount = Convert.ToDecimal(txtBsAmount.Text);
                        reconcilation.period = txtPeriod.Text;
                    }

                    if (Singl.reconcilationDalGet.addReconcilation(reconcilation) == 1)
                    {
                        MessageBox.Show(Lang.succesful);
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
            else
            {
                MessageBox.Show(Lang.dontEmpty);
            }
        }










    }
}
