using izibiz.MODEL.Models;
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
            //comboxları ıtem ekle
            addItemMoneyType();
            addItemScenario();
            addItemType();
            addItemRowUnit();
            //datagride 1 row ekle
            gridPrice.Rows.Add();
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
            DataGridViewComboBoxColumn theColumn = (DataGridViewComboBoxColumn)this.gridPrice.Columns["unit"];
            theColumn.Items.Add(nameof(EI.Unit.ADET));
            theColumn.Items.Add(nameof(EI.Unit.KILO));
            theColumn.Items.Add(nameof(EI.Unit.PAKET));
            theColumn.Items.Add(nameof(EI.Unit.GRAM));
        }




        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (gridPrice.Rows.Count == 10)
            {
                MessageBox.Show("en fazla 10 satır eklenebılır");
            }
            else
            {
                DataGridViewRow row = (DataGridViewRow)gridPrice.Rows[0].Clone();
                gridPrice.Rows.Add(row);
            }
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            //toplam satır satısı secılı satırdan en az 1 fazla olmak zorunda
            if (gridPrice.Rows.Count == 1)
            {
                MessageBox.Show("en az 1 satır bulunmak zorunda");
            }
            else
            {
                if (gridPrice.SelectedRows.Count > 0)
                {
                    gridPrice.Rows.RemoveAt(gridPrice.SelectedRows[0].Index);
                }
            }
        }




        private void gridPrice_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            //row miktar , birim fiyat ,kdv oranı  rowlarındaysa
            string clmName = gridPrice.Columns[e.ColumnIndex].Name;
            if (clmName.Equals("quantity") || clmName.Equals("unitPrice") || clmName.Equals("taxPercent") )
            {
                //girilen deger numerıc degilse
                int i = 0;
                if (!int.TryParse(e.FormattedValue.ToString(), out i))
                {
                    //   gridPrice.Rows[e.RowIndex].ErrorText = " must  be number";
                    MessageBox.Show("must  be number");
                    e.Cancel = true;
                }
            }
        }




        private bool validEmptyComponent()
        {
            bool valid = true;

            foreach (Control item in grpReceiver.Controls)  //grupbox alıcı bilgileri
            {
                if (item is TextBox || item is MaskedTextBox) //texbox veya maskedbox ıse
                {
                    if (item.Name == "msdVknTc")  //vkn_Tckn
                    {
                        if (item.Text.Replace(" ", String.Empty).Length < 10) //10 veya 10 dan buyukse
                        {
                            item.BackColor = Color.IndianRed;
                            valid = false;
                        }
                    }
                    else if (item.Name == "msdPhone")  //phone number
                    {
                        if (item.Text.Replace(" ", String.Empty).Length != 13)  //10 hane tel , 3 hane de parantezler
                        {
                            item.BackColor = Color.IndianRed;
                            valid = false;
                        }
                    }
                    else   //phone numver veya tckn degılse
                    {
                        if (String.IsNullOrEmpty(item.Text.Trim())) //text null veya bos ise
                        {
                            item.BackColor = Color.IndianRed;
                            valid = false;
                        }
                    }
                }
            }
            foreach (Control item in grpInvInformation.Controls)  //grupbox fatura bilgileri
            {
                if (!(item is Label)) //label degılse
                {
                    if (String.IsNullOrEmpty(item.Text.Trim())) //item null veya bos ise
                    {
                        item.BackColor = Color.IndianRed;
                        valid = false;
                    }
                    if (item is DateTimePicker)  //dateTimePicker ise
                    {
                        TimeSpan dateDifferent = DateTime.Today - Convert.ToDateTime(item.Text);
                        if (dateDifferent.TotalDays > 7) //aradakı fark 7 gunden buyukse
                        {
                            MessageBox.Show("en fazla 7 gun öncesıne fatura kesılebılır");
                            item.BackColor = Color.IndianRed;
                            valid = false;
                        }
                    }
                }
            }
            foreach (DataGridViewRow row in gridPrice.Rows)  //datagrid rowlarında bos eleman var mı
            {
                for (int i = 0; i < gridPrice.ColumnCount; i++)
                {
                    string clmName = gridPrice.Columns[i].Name;
                    if (row.Cells[i].Value == null || String.IsNullOrEmpty(row.Cells[i].Value.ToString().Trim()))
                    {
                        row.Cells[i].Style.BackColor = Color.IndianRed;
                        valid = false;
                    }
                }
            }
            foreach (Control item in grpboxTotal.Controls)  //grupbox not ve toplam bilgileri
            {
                if (item is RichTextBox) //label degılse
                {
                    if (String.IsNullOrEmpty(item.Text.Trim())) //item null veya bos ise
                    {
                        item.BackColor = Color.IndianRed;
                        valid = false;
                    }
                }
            }
            return valid;
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control item in grpReceiver.Controls)  //grupbox alıcı bilgileri
            {
                if (item is TextBox || item is MaskedTextBox) //texbox veya maskedbox ıse
                {
                    item.Text = "";
                    item.BackColor = Color.White;
                }
            }
            foreach (Control item in grpInvInformation.Controls)  //grupbox fatura bilgileri
            {
                if (!(item is Label)) //label degılse
                {
                    if (item is ComboBox)
                    {
                        item.Text = "";
                        item.BackColor = Color.White;
                    }
                    else
                    {
                        item.Text = "";
                        item.BackColor = Color.White;
                    }
                }
            }
            int rowCount = gridPrice.Rows.Count;
            for (int i=0; i< rowCount ; i++) //datagrid butun rowları sıl en son 1 tane row ekle
            {
                var r = gridPrice.Rows[0];
                gridPrice.Rows.Remove(r);
            }
            gridPrice.Rows.Add();


            foreach (Control item in grpboxTotal.Controls)  //grupbox not ve toplam bilgileri
            {
                if (!(item is Label)) //label degılse
                {
                    item.Text = "";
                    item.BackColor = Color.White;
                }
            }
        }


        private void calculateTotalMoney()
        {
            foreach (DataGridViewRow row in gridPrice.Rows)
            {
                decimal totalRevenue = Convert.ToDecimal(row.Cells["quantity"].Value) * Convert.ToDecimal(row.Cells["unitPrice"].Value); //kdv sız tutar


            //xml olustur
      //      string contentXml = Singl.invoiceControllerGet.CreateInvUblToXml(invoiceUbl).ToString();
           
            //db ye kaydet
     //       Singl.invoiceDalGet.insertDraftInvoice(invoiceUbl, contentXml);
            Singl.invoiceDalGet.dbSaveChanges();
                row.Cells["taxAmount"].Value = totalRevenue * (Convert.ToDecimal(row.Cells["taxPercent"].Value) / 100); //kdv tutarı
                row.Cells["total"].Value = totalRevenue + ((totalRevenue * Convert.ToDecimal(row.Cells["taxPercent"].Value)) / 100); //kdv tutarı; 
            }

        }

        private void btnCreateUbl_Click_1(object sender, EventArgs e)
        {
            if (validEmptyComponent())
            {
                calculateTotalMoney();




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
                foreach (DataGridViewRow row in gridPrice.Rows)
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
                string contentXml = Singl.invoiceControllerGet.CreateInvUblToXml(invoiceUbl).ToString();
                //db ye kaydet
              Singl.invoiceDalGet.insertDraftInvoice(invoiceUbl, contentXml);
                Singl.invoiceDalGet.dbSaveChanges();
            }
            else  //bos eleman varsa
            {
                MessageBox.Show("yıldızlı alanları bos bırakmayınız");
            }

          
        }


    }
}
