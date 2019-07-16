using izibiz.MODEL.DbTablesModels;
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
using UblInvoice;
using izibiz.COMMON;
using izibiz.CONTROLLER.Singleton;
using izibiz.CONTROLLER;
using izibiz.COMMON.FileControl;
using System.ServiceModel;
using izibiz.SERVICES.serviceOib;
using izibiz.COMMON.UBLCreate;

namespace izibiz.UI
{
    public partial class FrmCreateInvoice : Form
    {

        string senderVknTc;
        string partyName;
        string cityName;
        string telephone;
        string mail;
        string sicilNo;
        string firstName;
        string familyName;


        private string invoiceType;


        public FrmCreateInvoice(string invoiceType)
        {
            InitializeComponent();
            this.invoiceType = invoiceType;
        }


        private void FrmCreateInvoice_Load(object sender, EventArgs e)
        {
            localizationItemTextWrite();
            //comboxları ıtem ekle
            //eger arsıv ıse
            if (invoiceType == nameof(EI.Invoice.ArchiveInvoices))
            {
                pnlArchiveInformation.Visible = true;
                addItemArchiveSendingType();
                addItemArchiveType();
                addItemPaymentType();
            }
            addItemMoneyType();
            addItemScenario(invoiceType);
            addItemType();
            addItemRowUnit();
            //datagride 1 row ekle
            gridPrice.Rows.Add();
        }



        private void localizationItemTextWrite()
        {
            this.Text = Lang.FormCreateInvoice;
            //alıcı bılgılerı
            grpReceiver.Text = Lang.receiver;
            lblVknTckn.Text = Lang.vknTckn;
            lblName.Text = Lang.name;
            lblSurname.Text = Lang.surname;
            lblProvince.Text = Lang.province;
            lblDistrict.Text = Lang.district;
            lblTitle.Text = Lang.title;
            lblPhone.Text = Lang.phone;
            lblMail.Text = Lang.mail;
            //fatura bilgileri
            grpInvInformation.Text = Lang.invoiceInformation;
            lblScenario.Text = Lang.scenario;
            lblMoneyType.Text = Lang.moneyType;
            lblDate.Text = Lang.date;
            lblInvoiceChapiter.Text = Lang.invoiceChapter;
            lblType.Text = Lang.type;
            //
            lblArchiveSendingType.Text = Lang.archiveSendingType;
            lblArchiveType.Text = Lang.eArchiveType;
            chkSendMail.Text = Lang.sendToMail;
            //odeme Bilgisi
            grpPaymentInformation.Text = Lang.paymentInformation;
            lblPaymentType.Text = Lang.type;
            lblMiddleman.Text = Lang.middleman;
            lblPaymentDate.Text = Lang.date;
            lblInternetSalesInformation.Text = Lang.internetSalesInformation;
            //gönderim şekli
            grpSendingType.Text = Lang.sendingType;
            lblCarrier.Text = Lang.carrier;
            rdReal.Text = Lang.real;
            rdTuzel.Text = Lang.tuzel;
            lblCarrierVknTckn.Text = Lang.carrierVknTckn;
            lblCarrierTitle.Text = Lang.carrierTitle;
            lblSendingDate.Text = Lang.date;
            //satır bilgileri
            grpRowInformation.Text = Lang.rowInformation;
            gridPrice.Columns[nameof(EI.InvLineGridRowClm.productName)].HeaderText = Lang.productName;
            gridPrice.Columns[nameof(EI.InvLineGridRowClm.quantity)].HeaderText = Lang.quantity;
            gridPrice.Columns[nameof(EI.InvLineGridRowClm.unit)].HeaderText = Lang.unit;
            gridPrice.Columns[nameof(EI.InvLineGridRowClm.unitPrice)].HeaderText = Lang.unitPrice;
            gridPrice.Columns[nameof(EI.InvLineGridRowClm.taxPercent)].HeaderText = Lang.taxPercent;
            gridPrice.Columns[nameof(EI.InvLineGridRowClm.taxAmount)].HeaderText = Lang.taxAmount;
            gridPrice.Columns[nameof(EI.InvLineGridRowClm.total)].HeaderText = Lang.total;
            btnAddRow.Text = Lang.addRow;
            btnRemoveRow.Text = Lang.removeRow;
            //toplam
            grpTotal.Text = Lang.total;
            lblServiceAmount.Text = Lang.ServiceTotalAmount;
            lblCalculatedTaxAmount.Text = Lang.calculatedTax;
            lblTotalAmountWithTax.Text = Lang.totalAmountWithTax;
            lblPaidAmount.Text = Lang.paidAmount;
            //
            btnClear.Text = Lang.clear;
            btnCreate.Text = Lang.create;
        }




        private void addItemPaymentType()
        {
            cmbPaymentType.Items.Add(nameof(EI.ArchivePaymentType.EFT_HAVALE));
            cmbPaymentType.Items.Add(nameof(EI.ArchivePaymentType.KAPIDAODEME));
            cmbPaymentType.Items.Add(nameof(EI.ArchivePaymentType.KREDIKARTI_BANKAKARTI));
            cmbPaymentType.Items.Add(nameof(EI.ArchivePaymentType.DIGER));
        }



        private void addItemArchiveSendingType()
        {
            cmbArchiveSendingType.Items.Add(nameof(EI.ArchiveSendingType.ELEKTRONIK));
            cmbArchiveSendingType.Items.Add(nameof(EI.ArchiveSendingType.KAGIT));
        }



        private void addItemArchiveType()
        {
            cmbArchiveType.Items.Add(nameof(EI.ArchiveType.NORMAL));
            cmbArchiveType.Items.Add(nameof(EI.ArchiveType.INTERNET));
        }



        private void addItemMoneyType()
        {
            cmbMoneyType.Items.Add(nameof(EI.CurrencyCode.TRY));
            cmbMoneyType.Items.Add(nameof(EI.CurrencyCode.USD));
        }




        private void addItemScenario(string invoiceType)
        {
            if (invoiceType == nameof(EI.Invoice.Invoices))
            {
                cmbScenario.Items.Add(nameof(EI.Profileid.TEMELFATURA));
                cmbScenario.Items.Add(nameof(EI.Profileid.TICARIFATURA));
            }
            else if (invoiceType == nameof(EI.Invoice.ArchiveInvoices))
            {
                cmbScenario.Items.Add(nameof(EI.Profileid.EARSIVFATURA));
            }
        }



        private void addItemType()
        {
            cmbInvType.Items.Add(EI.TypeCodeValue.SATIS.ToString());
            cmbInvType.Items.Add(EI.TypeCodeValue.IADE.ToString());
            cmbInvType.Items.Add(EI.TypeCodeValue.TEVKIFAT.ToString());
            cmbInvType.Items.Add(EI.TypeCodeValue.ISTISNA.ToString());
            cmbInvType.Items.Add(EI.TypeCodeValue.OZELMATRAH.ToString());
            cmbInvType.Items.Add(EI.TypeCodeValue.IHRACKAYITLI.ToString());
        }



        private void addItemRowUnit()
        {
            DataGridViewComboBoxColumn theColumn = (DataGridViewComboBoxColumn)this.gridPrice.Columns[nameof(EI.InvLineGridRowClm.unit)];
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
                gridPrice.Rows.RemoveAt(gridPrice.Rows[gridPrice.Rows.Count-1].Index);
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
                        if (item.Text.Replace(" ", String.Empty).Length < 3) //text null veya bos ise
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
            if (invoiceType == nameof(EI.Invoice.ArchiveInvoices)) //arsıv ıse
            {
                foreach (Control item in pnlArchive.Controls)
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
                    }
                }

                if (grpPaymentInformation.Visible == true) //ınternetı sectıyse
                {
                    foreach (Control item in grpPaymentInformation.Controls) //odeme bılgılerı
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
                        }
                    }
                    foreach (Control item in grpSendingType.Controls)  //gonderım seklı
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
            foreach (Control item in grpTotal.Controls)  //grupbox not ve toplam bilgileri
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
                    item.Text = "";
                    item.BackColor = Color.White;
                }
            }

            if (invoiceType == nameof(EI.Invoice.ArchiveInvoices)) //arsıv ıse
            {
                foreach (Control item in pnlArchive.Controls)
                {
                    if (!(item is Label)) //label degılse
                    {

                        item.Text = "";
                        item.BackColor = Color.White;
                    }
                }

                if (grpPaymentInformation.Visible == true) //ınternetı sectıyse
                {
                    foreach (Control item in grpPaymentInformation.Controls) //odeme bılgılerı
                    {
                        if (!(item is Label)) //label degılse
                        {
                            item.Text = "";
                            item.BackColor = Color.White;
                        }
                    }
                    foreach (Control item in grpSendingType.Controls)  //gonderım seklı
                    {
                        if (!(item is Label)) //label degılse
                        {
                            item.Text = "";
                            item.BackColor = Color.White;
                        }
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


            foreach (Control item in grpTotal.Controls)  //grupbox not ve toplam bilgileri
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


        private string getPaymentCode(string paymentType)
        {
            switch (paymentType)
            {
                case nameof(EI.ArchivePaymentType.KREDIKARTI_BANKAKARTI): return "48";
                case nameof(EI.ArchivePaymentType.EFT_HAVALE): return "46";
                case nameof(EI.ArchivePaymentType.KAPIDAODEME): return "10";
                default: return "1";
            }
        }



        private void getUserInformationOnDb()
        {
            UserInformation user = Singl.userInformationDalGet.getUserInformation();
            senderVknTc = user.vknTckn;
            partyName = user.partyName;
            cityName = user.cityName;
            telephone = user.phone;
            mail = user.mail;
            sicilNo = user.sicilNo;
            firstName = user.firstName;
            familyName = user.familyName;
        }





        private void cmbArchiveType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbArchiveType.Text == nameof(EI.ArchiveType.INTERNET))
            {
                grpSendingType.Visible = true;
                grpPaymentInformation.Visible = true;
                rdReal.Checked = true;  //herhangı bırı secılı gelsın dıye
            }
            else
            {
                grpSendingType.Visible = false;
                grpPaymentInformation.Visible = false;
            }
        }



        private bool isValidInvoice()
        {
            if (invoiceType == nameof(EI.Invoice.Invoices))
            {
                if (cmbInvType.Text == EI.TypeCodeValue.IADE.ToString())
                {
                    if (cmbScenario.Text != nameof(EI.Profileid.TEMELFATURA))
                    {
                        return false;
                    }
                }
            }
            return true;
        }



        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                //bos eleamn olmaması
                if (validEmptyComponent())
                {
                    //iade secılı ıse temel fatura olarak gonderılmesı
                    if (isValidInvoice())
                    {
                        //tutar hesapla
                        calculateTotalMoney();

                        //kullanıcı bılgılerı getır              
                        getUserInformationOnDb();

                        ////////UBL OLUSTURMA ISLEMI////////
                        BaseInvoiceUBL invoice;

                        //eger INVOİCE ıse 
                        if (invoiceType == nameof(EI.Invoice.Invoices))
                        {
                            invoice = new InvoiceUBL(cmbScenario.Text, cmbInvType.Text);
                        }
                        else //ARCHİVE İSE
                        {
                            invoice = new ArchiveUBL(cmbArchiveSendingType.Text, cmbScenario.Text, cmbInvType.Text);

                            if (cmbArchiveType.Text == nameof(EI.ArchiveType.INTERNET))
                            {
                                //eger gonderım tıpı ınternet ıse ekstra adınatıonal ref ekle
                                invoice.addAdditionalDocumentReference(nameof(EI.Profileid.EARSIVFATURA), cmbArchiveType.Text);

                                //DELİVERY BOLUMU EKLE
                                //carrıer ekle
                                PartyType carrierParty = invoice.createParty(txtCarrierTitle.Text, "", "", "");
                                invoice.addPartyIdentification(carrierParty, 1, nameof(EI.VknTckn.VKN), msdDeliveryVkn.Text, "", "", "", "");
                                invoice.createDelivery(carrierParty, Convert.ToDateTime(datepicDespatchDate.Text));

                                //payment means ekle                   
                                invoice.createPaymentMeans(getPaymentCode(cmbPaymentType.Text), Convert.ToDateTime(datepicPaymentDate.Text), txtMediator.Text);
                            }
                        }

                        PartyType supParty;
                        PartyType cusParty;
                        string partyIdentificationSchemaType;
                      
                        //SUPPLİER  PARTY OLUSTURULMASI  
                        supParty = invoice.createParty(partyName, cityName, telephone, mail);
                        if (senderVknTc.Length == 10) //sup vkn
                        {
                            partyIdentificationSchemaType = nameof(EI.VknTckn.VKN);
                            invoice.addPartyTaxSchemeOnParty(supParty);
                        }
                        else  //sup tckn .. add person metodu eklenır
                        {
                            partyIdentificationSchemaType = nameof(EI.VknTckn.TCKN);
                            invoice.addPersonOnParty(supParty, firstName, familyName);
                        }
                        invoice.addPartyIdentification(supParty, 2, partyIdentificationSchemaType, senderVknTc, nameof(EI.Mersis.MERSISNO), sicilNo, "", "");
                        invoice.SetSupplierParty(supParty);

                        //CUST PARTY OLUSTURULMASI  
                        cusParty = invoice.createParty(txtPartyName.Text, txtCity.Text, msdPhone.Text, txtMail.Text);
                        if (msdVknTc.Text.Length == 10) //customer vkn
                        {
                            partyIdentificationSchemaType = nameof(EI.VknTckn.VKN);
                            invoice.addPartyTaxSchemeOnParty(cusParty);
                        }
                        else  //customer tckn
                        {
                            partyIdentificationSchemaType = nameof(EI.VknTckn.TCKN);
                            invoice.addPersonOnParty(cusParty, txtCustName.Text, txtCustSurname.Text);
                        }
                        invoice.addPartyIdentification(cusParty, 1, partyIdentificationSchemaType, msdVknTc.Text, "", "", "", "");
                        invoice.SetCustomerParty(cusParty);


                        //INV LINE OLUSTURULMASI
                        foreach (DataGridViewRow row in gridPrice.Rows)
                        {
                            //Inv Lıne Olusturulması
                            //unıt code get fonk cagırılarak secılen bırımın unıt codu getırılırilerek aktarılır
                            invoice.addInvoiceLine(row.Index.ToString(), cmbMoneyType.Text, getUnitCode(row.Cells[nameof(EI.InvLineGridRowClm.unit)].Value.ToString())
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
                        var invoiceUbl = invoice.baseInvoiceUBL;
                        //xml olustur
                        string xmlPath = FolderControl.writeDiscInvoiceConvertUblToXml(invoiceUbl, invoiceType).ToString();
                       
                        if(xmlPath != null)
                        {
                            //db ye kaydet
                            if (invoiceType == nameof(EI.Invoice.Invoices))
                            {
                                Singl.invoiceDalGet.insertDraftInvoice(invoiceUbl, xmlPath);
                            }
                            else if (invoiceType == nameof(EI.Invoice.ArchiveInvoices)) //arsıv ıse
                            {
                                Singl.archiveInvoiceDalGet.insertArchiveOnDbFromUbl(invoiceUbl, xmlPath, chkSendMail.Checked);
                            }

                            MessageBox.Show(xmlPath + "  faturalar kaydedıldı");
                        }
                        else
                        {
                            MessageBox.Show("işlem basarısız");
                        }
                    }
                    else
                    {
                        MessageBox.Show("iade faturası secılıyse temel olarak gonderılmelıdır");
                    }
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

