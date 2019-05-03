using izibiz.MODEL.DbModels;
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
using izibiz.COMMON.FileControl;
using System.ServiceModel;
using izibiz.SERVICES.serviceOib;

namespace izibiz.UI
{
    public partial class FrmCreateInvoice : Form
    {
        
        string senderVknTc;
        string webUrı;
        string partyName;
        string streetName;
        string buldingName ;
        string buldingNumber;
        string citySubdivisionName ;
        string cityName  ;
        string postalZone  ;
        string country ;
        string telephone ;
        string fax;
        string mail ;
        string sicilNo ;
        string firstName;
        string familyName;
        string taxScheme ;





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
            cmbType.Items.Add(EI.InvoiceTypeCodeValue.SATIS.ToString());
            cmbType.Items.Add(EI.InvoiceTypeCodeValue.IADE.ToString());
            cmbType.Items.Add(EI.InvoiceTypeCodeValue.TEVKİFAT.ToString());
            cmbType.Items.Add(EI.InvoiceTypeCodeValue.ISTISNA.ToString());
            cmbType.Items.Add(EI.InvoiceTypeCodeValue.OZELMATRAH.ToString());
            cmbType.Items.Add(EI.InvoiceTypeCodeValue.IHRACKAYITLI.ToString());
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
            if (gridPrice.Columns[e.ColumnIndex].Name.Equals(nameof(EI.InvLineGridRowClm.quantity))
                || gridPrice.Columns[e.ColumnIndex].Name.Equals((nameof(EI.InvLineGridRowClm.unitPrice)))
                || gridPrice.Columns[e.ColumnIndex].Name.Equals(nameof(EI.InvLineGridRowClm.taxPercent)))
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
                        else //validse
                        {
                            item.BackColor = Color.White;
                        }
                    }
                    else if (item.Name == "msdPhone")  //phone number
                    {
                        if (item.Text.Replace(" ", String.Empty).Length != 10)  //10 hane tel 
                        {
                            item.BackColor = Color.IndianRed;
                            valid = false;
                        }
                        else
                        {
                            item.BackColor = Color.White;
                        }
                    }
                    else   //phone numver veya tckn degılse
                    {
                        if (String.IsNullOrEmpty(item.Text.Trim())) //text null veya bos ise
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
            foreach (Control item in grpInvInformation.Controls)  //grupbox fatura bilgileri
            {
                if (!(item is Label)) //label degılse
                {
                    if (String.IsNullOrEmpty(item.Text.Trim())) //item null veya bos ise
                    {
                        item.BackColor = Color.IndianRed;
                        valid = false;
                    }
                    else
                    {
                        item.BackColor = Color.White;
                    }
                    if (item is DateTimePicker)  //dateTimePicker ise
                    {
                        TimeSpan dateDifferent = DateTime.Today - Convert.ToDateTime(item.Text);
                        if (dateDifferent.TotalDays > 7) //aradakı fark 7 gunden buyukse
                        {
                            MessageBox.Show("en fazla 7 gun öncesıne fatura kesılebılır");
                            valid = false;
                        }
                    }
                }
            }
            foreach (DataGridViewRow row in gridPrice.Rows)  //datagrid rowlarında bos eleman var mı
            {
                for (int i = 0; i < gridPrice.ColumnCount; i++)
                {
                    //total ve tax total clmları ıcın yapma
                    if (gridPrice.Columns[i].Name != nameof(EI.InvLineGridRowClm.taxAmount) && gridPrice.Columns[i].Name != nameof(EI.InvLineGridRowClm.total))
                        if (gridPrice.Columns[i].Name != "taxAmount" && gridPrice.Columns[i].Name != "total") //total ve tax total clmları ıcın yapma
                        {
                            if (row.Cells[i].Value == null || String.IsNullOrEmpty(row.Cells[i].Value.ToString().Trim()))
                            {
                                row.Cells[i].Style.BackColor = Color.IndianRed;
                                valid = false;
                            }
                            else
                            {
                                row.Cells[i].Style.BackColor = Color.White;
                            }
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
                    else
                    {
                        item.BackColor = Color.White;
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
            for (int i = 0; i < rowCount; i++) //datagrid butun rowları sıl en son 1 tane row ekle
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
            decimal total = 0;
            decimal taxTotal = 0;
            decimal totalWithTax = 0;


            foreach (DataGridViewRow row in gridPrice.Rows)
            {
                //kdv sız tutar
                decimal totalRevenue = Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.quantity)].Value)
                    * Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.unitPrice)].Value);


                decimal rowTaxAmount = totalRevenue * (Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.taxPercent)].Value) / 100); //kdv tutarı             
                decimal rowTotalWithTax = totalRevenue + ((totalRevenue * Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.taxPercent)].Value)) / 100); //kdv dahil tutarı; 

                row.Cells[nameof(EI.InvLineGridRowClm.taxAmount)].Value = rowTaxAmount;
                row.Cells[nameof(EI.InvLineGridRowClm.total)].Value = rowTotalWithTax;


                total = +totalRevenue;
                taxTotal = +rowTaxAmount;
                totalWithTax = +rowTotalWithTax;
            }

            txtServiceAmount.Text = total.ToString();
            txtTaxAmount.Text = taxTotal.ToString();
            txtTotalAmountWithTax.Text = totalWithTax.ToString();
            txtPayableAmount.Text = totalWithTax.ToString();
        }




        private string getUnitCode(string unitName)
        {
            switch (unitName)
            {
                case nameof(EI.Unit.ADET): return "C62";
                case nameof(EI.Unit.GRAM): return "GRM";
                case nameof(EI.Unit.KILO): return "KGM";
                case nameof(EI.Unit.PAKET): return "PA";
                default: return "";
            }
        }

        private void getUserInformationOnDb()
        {
            UserInformation user = Singl.userInformationDalGet.getUserInformation();
             senderVknTc = user.vknTckn;
             webUrı = user.webUri;
             partyName = user.partyName;
             streetName = user.streetName;
             buldingName = user.buldingName;
             buldingNumber = user.buldingNumber;
             citySubdivisionName = user.citySubdivisionName;
             cityName = user.cityName;
             postalZone = user.postalZone;
             country = user.country;
             telephone = user.phone;
             fax = user.fax;
             mail = user.mail;
             sicilNo = user.sicilNo;
             firstName = user.firstName;
             familyName = user.familyName;
             taxScheme = user.taxScheme;
        }



        private void btnCreateUbl_Click(object sender, EventArgs e)
        {
            try
            {

                if (validEmptyComponent())
                {
                    //tutar hesapla
                    calculateTotalMoney();

                    //kullanıcı bılgılerı getır              
                    getUserInformationOnDb();


                    ////////UBL OLUSTURMA ISLEMI////////
                    CreateInvoiceUBL invoice = new CreateInvoiceUBL(cmbScenario.Text, cmbType.Text);
                    PartyType supParty;
                    PartyType cusParty;


                    //SUPPLİER  PARTY OLUSTURULMASI  
                    supParty = invoice.createParty(webUrı, partyName, streetName, buldingName, buldingNumber, citySubdivisionName, cityName, postalZone, "", country, telephone, fax, mail);
                    if (senderVknTc.Length == 10) //sup vkn
                    {
                        invoice.addPartyIdentification(supParty, 2, nameof(EI.VknTckn.VKN), senderVknTc, nameof(EI.Mersis.MERSISNO), sicilNo, "", "");
                        invoice.addPartyTaxSchemeOnParty(supParty, taxScheme);
                    }
                    else  //sup tckn .. add person metodu eklenır
                    {
                        invoice.addPartyIdentification(supParty, 2, nameof(EI.VknTckn.TCKN), senderVknTc, nameof(EI.Mersis.MERSISNO), sicilNo, "", "");
                        invoice.addPersonOnParty(supParty, firstName, familyName);
                    }
                    invoice.SetSupplierParty(supParty);

                    //CUST PARTY OLUSTURULMASI        
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


                    //INV LINE OLUSTURULMASI
                    foreach (DataGridViewRow row in gridPrice.Rows)
                    {
                        //Inv Lıne Olusturulması

                        //unıt code get fonk cagırılarak secılen bırımın unıt codu getırılırilerek aktarılır
                        invoice.addInvoiceLine(row.Index.ToString(), cmbMoneyType.Text, txtNote.Text, getUnitCode(row.Cells[nameof(EI.InvLineGridRowClm.unit)].Value.ToString())
                            , Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.quantity)].Value), Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.total)].Value)
                            , Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.taxAmount)].Value), Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.total)].Value)
                            , Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.taxPercent)].Value), row.Cells[nameof(EI.InvLineGridRowClm.productName)].Value.ToString()
                            , Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.unitPrice)].Value));

                    }

                    invoice.setInvLines();
                    invoice.setTaxTotal(invoice.invoiceTaxTotal());
                    invoice.SetLegalMonetaryTotal(invoice.CalculateLegalMonetaryTotal());
                    invoice.SetAllowanceCharge(invoice.CalculateAllowanceCharges());

                    //olusturdugumuz nesne ubl turune cevrılır
                    var invoiceUbl = invoice.BaseUBL;
                    //xml olustur
                    string xmlPath = FolderControl.createInvUblToXml(invoiceUbl).ToString();
                    //db ye kaydet
                    Singl.invoiceDalGet.insertDraftInvoice(invoiceUbl, xmlPath);
                    Singl.invoiceDalGet.dbSaveChanges();

                    MessageBox.Show("taslak faturalara kaydedıldı");
                }
                else  //bos eleman varsa
                {
                    MessageBox.Show("yıldızlı alanları bos bırakmayınız");
                }
            }
            catch (FaultException<REQUEST_ERRORType> ex) //oib req error
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





    }
}

