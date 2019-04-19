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
using izibiz.CONTROLLER.Dal;

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

            int rowId = dataGridView2.Rows.Add();
            DataGridViewRow row = dataGridView2.Rows[rowId];
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
            DataGridViewComboBoxColumn theColumn = (DataGridViewComboBoxColumn)this.dataGridView2.Columns["unit"];
            theColumn.Items.Add(nameof(EI.Unit.ADET));
            theColumn.Items.Add(nameof(EI.Unit.KILO));
            theColumn.Items.Add(nameof(EI.Unit.PAKET));
            theColumn.Items.Add(nameof(EI.Unit.GRAM));
        }



        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 10)
            {
                MessageBox.Show("en fazla 10 satır eklenebılır");
            }
            else
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                dataGridView2.Rows.Add(row);
            }

        }



    

        private void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            string unitCode = "";
            //suplıer bılgılerı db den getirilecek
            string webUrı = "";
            string partyName = "";
            string streetName = "";
            string buldingName = "";
            string buldingNumber = "";
            string visionName = "";
            string cityName = "";
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



            CreateInvoiceUBL invoice = new CreateInvoiceUBL(cmbScenario.Text, cmbType.Text);


            PartyType supParty;
            PartyType cusParty;           
            //supp party olusturulması  
            supParty = invoice.createParty(webUrı, partyName, streetName, buldingName, buldingNumber, visionName, cityName, postalZone, "", country, telephone, fax, mail);
            if (supVknTc.Length == 10) //sup vkn
            {
                invoice.addPartyIdentification(supParty, 2, nameof(EI.VknTckn.VKN), supVknTc, mersisNo, sicilNo, "", "");
                invoice.addPartyTaxSchemeOnParty(supParty, taxScheme);
            }
            else  //sup tckn .. add person metodu eklenır
            {
                invoice.addPartyIdentification(supParty, 2, nameof(EI.VknTckn.TCKN), supVknTc, mersisNo, sicilNo, "", "");
                invoice.addPersonOnParty(supParty, firstName, familyName);
            }
            invoice.SetSupplierParty(supParty);

          
            
            
            //cust party olusturulması        
            cusParty = invoice.createParty("", txtPartyName.Text, txtStreet.Text, txtBuldingName.Text, txtBuldingNo.Text, txtVision.Text, txtCity.Text, "", "", txtCountry.Text, msdPhone.Text, "", txtMail.Text);
            if (msdVknTc.Text.Length == 10) //customer vkn
            {
                invoice.addPartyIdentification(cusParty, 1, nameof(EI.VknTckn.VKN), msdVknTc.Text, "", "", "", "");
                invoice.addPartyTaxSchemeOnParty(cusParty, txtTaxScheme.Text);
            }
            else  //customer tckn
            {
                invoice.addPartyIdentification(cusParty, 1, nameof(EI.VknTckn.TCKN), msdVknTc.Text, "", "", "", "");
            }
            invoice.SetCustomerParty(cusParty);



            //ınv line olusturulması
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                //unıt code get fonk cagırılacak

                invoice.addInvoiceLine(row.Index.ToString(), txtNote.Text, unitCode, Convert.ToDecimal(row.Cells["quantity"].Value), cmbMoneyType.Text, Convert.ToDecimal(row.Cells["total"].Value),
                    Convert.ToDecimal(row.Cells["taxAmount"].Value), Convert.ToDecimal(row.Cells["total"].Value), Convert.ToDecimal(row.Cells["taxPercent"].Value), row.Cells["productName"].Value.ToString(),
             Convert.ToDecimal(row.Cells["unitPrice"].Value));
            }
            invoice.setInvLines();



            invoice.setTaxTotal(invoice.invoiceTaxTotal());
            invoice.SetLegalMonetaryTotal(invoice.CalculateLegalMonetaryTotal());
            invoice.SetAllowanceCharge(invoice.CalculateAllowanceCharges());

            var invoiceUbl = invoice.BaseUBL; //olusturdugumuz nesne ubl turune cevrılır

            //xml olustur
            string contentXml = Singl.invoiceControllerGet.CreateInvoiceXml(invoiceUbl).ToString();
           
            //db ye kaydet
            Singl.invoiceDALGet.insertDraftInvoice(invoiceUbl, contentXml);
            Singl.invoiceDALGet.dbSaveChanges();
        }


      



    }
}
