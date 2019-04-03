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
            cmbMoneyType.Items.Add(nameof(EI.CurrencyCode.TRY));
            cmbMoneyType.Items.Add(nameof(EI.CurrencyCode.USD));
        }

        private void addItemScenario()
        {
            cmbScenario.Items.Add(nameof(EI.InvoiceProfileid.TEMELFATURA));
            cmbScenario.Items.Add(nameof(EI.InvoiceProfileid.TICARIFATURA));
        }

        private void addItemType()
        {
            cmbType.Items.Add(EI.invoiceTypeCodeValue.SATIS.ToString());
            cmbType.Items.Add(EI.invoiceTypeCodeValue.IADE.ToString());
            cmbType.Items.Add(EI.invoiceTypeCodeValue.TEVKİFAT.ToString());
            cmbType.Items.Add(EI.invoiceTypeCodeValue.ISTISNA.ToString());
            cmbType.Items.Add(EI.invoiceTypeCodeValue.OZELMATRAH.ToString());
            cmbType.Items.Add(EI.invoiceTypeCodeValue.IHRACKAYITLI.ToString());
        }

        private void addItemRowUnit()
        {
            DataGridViewComboBoxColumn theColumn = (DataGridViewComboBoxColumn)this.gridInvoiceLine.Columns["unit"];
            theColumn.Items.Add(nameof(EI.Unit.ADET));
            theColumn.Items.Add(nameof(EI.Unit.KILO));
            theColumn.Items.Add(nameof(EI.Unit.PAKET));
            theColumn.Items.Add(nameof(EI.Unit.GRAM));
        }



        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (gridInvoiceLine.Rows.Count == 10)
            {
                MessageBox.Show("en fazla 10 satır eklenebılır");
            }
            else
            {
                DataGridViewRow row = (DataGridViewRow)gridInvoiceLine.Rows[0].Clone();
                gridInvoiceLine.Rows.Add(row);
            }   
        }







        private void btnCreate_Click(object sender, EventArgs e)
        {
            string unitCode = "";
            //suplıer bılgılerı db den getirilecek
            string webUrı = "";
            string partyName ="";
            string streetName ="";
            string buldingName ="";
            string buldingNumber= "";
            string visionName ="";
            string cityName ="";
            string postalZone = "";
            string country = "";
            string telephone = "";
            string fax = "";
            string mail = "";
            string mersisNo = "";
            string sicilNo = "";
            string supVknTc = "11111111111";
            string firstName = "";
            string familyName = "";
            string taxScheme = "";



            CreateInvoiceUBL ublInvoice = new CreateInvoiceUBL(cmbScenario.SelectedText, cmbType.SelectedText);

            PartyType supParty;
            PartyType cusParty;

            //supp party olusturulması  
            supParty = ublInvoice.createParty(webUrı, partyName, streetName, buldingName, buldingNumber, visionName, cityName, postalZone, "", country, telephone, fax, mail);
            if (supVknTc.Length == 10) //sup vkn
            {              
                ublInvoice.addPartyIdentification(supParty,2, nameof(EI.VknTckn.VKN), supVknTc, mersisNo, sicilNo,"","");
                ublInvoice.addPartyTaxSchemeOnParty(supParty,taxScheme);
            }
            else  //sup tckn .. add person metodu eklenır
            {
                ublInvoice.addPartyIdentification(supParty,2, nameof(EI.VknTckn.TCKN), supVknTc, mersisNo, sicilNo,"","");
                ublInvoice.addPersonOnParty(supParty,firstName,familyName); 
            }
            ublInvoice.SetSupplierParty(supParty);

            //cust party olusturulması    
            cusParty = ublInvoice.createParty("", txtPartyName.Text, txtStreet.Text, txtBuldingName.Text, txtBuldingNo.Text, txtVision.Text, txtCity.Text, "", "", txtCountry.Text, msdPhone.Text, "", txtMail.Text);
            if (msdVknTc.Text.Length == 10) //customer vkn
            {
                ublInvoice.addPartyIdentification(cusParty,1, nameof(EI.VknTckn.VKN), msdVknTc.Text,"","","","");
                ublInvoice.addPartyTaxSchemeOnParty(cusParty,txtTaxScheme.Text);
            }
            else  //customer tckn
            {
                ublInvoice.addPartyIdentification(cusParty,1,nameof(EI.VknTckn.TCKN), msdVknTc.Text,"","","","");
            }               
            ublInvoice.SetCustomerParty(cusParty);

            foreach (DataGridViewRow row in gridInvoiceLine.Rows)
            {
                //unıt code get fonk cagırılacak

                ublInvoice.addTaxSubtotal(ublInvoice.createTaxTotal(cmbMoneyType.Text, ""),,,,);

              /*  ublInvoice.addInvoiceLine(row.Index.ToString(),txtNote.Text,unitCode, Convert.ToDecimal(row.Cells["quantity"].Value), cmbMoneyType.Text, Convert.ToDecimal(row.Cells["total"].Value),                              
                    Convert.ToDecimal(row.Cells["taxAmount"].Value), Convert.ToDecimal(row.Cells["total"].Value), Convert.ToDecimal(row.Cells["taxPercent"].Value),row.Cells["productName"].Value.ToString(),  
             Convert.ToDecimal(row.Cells["price"].Value));  */
            }
            ublInvoice.setInvLines();


            ublInvoice.setTaxTotal(ublInvoice.CalculateTaxTotal());

            ublInvoice.SetLegalMonetaryTotal(ublInvoice.CalculateLegalMonetaryTotal());
            ublInvoice.SetAllowanceCharge(ublInvoice.CalculateAllowanceCharges());

        }






    }
}
