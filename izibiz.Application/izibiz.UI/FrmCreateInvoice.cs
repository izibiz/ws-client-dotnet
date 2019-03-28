using izibiz.MODEL.Model;
using izibiz.COMMON.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ubl_Invoice_2_1;
using izibiz.COMMON;
using izibiz.CONTROLLER.Singleton;
using izibiz.CONTROLLER;

namespace izibiz.UI
{
    public partial class FrmCreateInvoice : Form
    {
   

        public FrmCreateInvoice()
        {
            InitializeComponent();
        }


        private void FrmCreateInvoice_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
            addItemMoneyType();
            addItemScenario();
            addItemType();
            addItemRowUnit();
        }



        private void localizationItemTextWrite()
        {

        }


        private void addItemMoneyType()
        {
            cmbMoneyType.Items.Add("türk lirası");
            cmbMoneyType.Items.Add("dolar");
            cmbMoneyType.Items.Add("Euro");
        }

        private void addItemScenario()
        {
            cmbScenario.Items.Add("Temel fatura");
            cmbScenario.Items.Add("Ticari Fatura");
        }

        private void addItemType()
        {
            cmbType.Items.Add("Satıs");
            cmbType.Items.Add("iade");
            cmbType.Items.Add("tevkifat");
            cmbType.Items.Add("istisna");
            cmbType.Items.Add("ozel matrah");
            cmbType.Items.Add("ihrac kayıtlı");
        }

        private void addItemRowUnit()
        {
            DataGridViewComboBoxColumn theColumn = (DataGridViewComboBoxColumn)this.datagridRow.Columns["unit"];
            theColumn.Items.Add("Adet");
            theColumn.Items.Add("Kilo");
            theColumn.Items.Add("Paket");
        }



        private void btnAddRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)datagridRow.Rows[0].Clone();
            datagridRow.Rows.Add(row);        
        }




       


        private void btnCreate_Click(object sender, EventArgs e)
        {
            string profileId;
            string invoiceTypeCodeValue;

            if (cmbScenario.SelectedItem.ToString() == "Temel fatura")
            {
                profileId = EI.InvoiceProfileid.TEMELFATURA.ToString();
            }
            else
            {
                profileId = EI.InvoiceProfileid.TICARIFATURA.ToString();
            }

            switch (cmbType.SelectedItem)
            {
               case "Satıs":
                    invoiceTypeCodeValue = EI.invoiceTypeCodeValue.SATIS.ToString(); break;

                case "iade":
                    invoiceTypeCodeValue = EI.invoiceTypeCodeValue.IADE.ToString(); break;

                case "tevkifat":
                    invoiceTypeCodeValue = EI.invoiceTypeCodeValue.TEVKİFAT.ToString(); break;

                case "istisna":
                    invoiceTypeCodeValue = EI.invoiceTypeCodeValue.ISTISNA.ToString(); break;

                case "ozel matrah":
                    invoiceTypeCodeValue = EI.invoiceTypeCodeValue.OZELMATRAH.ToString(); break;

                case "ihrac kayıtlı":
                    invoiceTypeCodeValue = EI.invoiceTypeCodeValue.IHRACKAYITLI.ToString(); break;

                default:
                    MessageBox.Show("senaryo alanı default olarak satıs secıldı"); invoiceTypeCodeValue = EI.invoiceTypeCodeValue.SATIS.ToString(); break;
            }


            CreateInvoiceUBL ublInvoice = new CreateInvoiceUBL(profileId, invoiceTypeCodeValue, "TRY");

            ublInvoice.setAdditionalDocumentReference();
            ublInvoice.SetSignature();
            ublInvoice.SetInvoiceLines(ublInvoice.GetInvoiceLines());
            switch (txtTcVkn.Text.Length)
            {
                case 10:
                    ublInvoice.SetSupplierParty(ublInvoice.GetParty(txtTcVkn.Text, "VKN"));
                    ublInvoice.SetCustomerParty(ublInvoice.GetParty(txtTcVkn.Text, "VKN"));
                    break;
                case 11:
                    ublInvoice.SetSupplierParty(ublInvoice.GetParty(txtTcVkn.Text, "TCKN"));
                    ublInvoice.SetCustomerParty(ublInvoice.GetParty(txtTcVkn.Text, "TCKN"));
                    break;
            }

            ublInvoice.SetLegalMonetaryTotal(ublInvoice.CalculateLegalMonetaryTotal());
            ublInvoice.SetTaxTotal(ublInvoice.CalculateTaxTotal());
            ublInvoice.SetAllowanceCharge(ublInvoice.CalculateAllowanceCharges());


        }

      




    }
}
