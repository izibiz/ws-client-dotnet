using izibiz.COMMON;
using izibiz.COMMON.Language;
using izibiz.CONTROLLER.Singleton;
using izibiz.MODEL.DbTablesModels;
using izibiz.SERVICES.serviceDespatch;
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
    public partial class FrmCreateDespatch : Form
    {


        string senderVknTc;
        string partyName;
        string cityName;
        string telephone;
        string mail;
        string sicilNo;
        string firstName;
        string familyName;




        public FrmCreateDespatch()
        {
            InitializeComponent();
        }



        private void FrmCreateDespatch_Load(object sender, EventArgs e)
        {
            addItemMoneyType();
            addItemScenario();
            addItemType();

        }


        private void addItemMoneyType()
        {
            cmbMoneyType.Items.Add(nameof(EI.CurrencyCode.TRY));
            cmbMoneyType.Items.Add(nameof(EI.CurrencyCode.USD));
        }


        private void addItemType()
        {
            cmbType.Items.Add(EI.TypeCodeValue.SEVK.ToString());
        }


        private void addItemScenario()
        {
            cmbScenario.Items.Add(nameof(EI.Profileid.TEMELIRSALIYE));
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
                gridPrice.Rows.RemoveAt(gridPrice.Rows[gridPrice.Rows.Count - 1].Index);
            }
        }





        private void btnClean_Click(object sender, EventArgs e)
        {
            foreach (Control item in grpReceiver.Controls)  //grupbox alıcı bilgileri
            {
                if (item is TextBox || item is MaskedTextBox) //texbox veya maskedbox ıse
                {
                    item.Text = "";
                    item.BackColor = Color.White;
                }
            }
            foreach (Control item in grpDespatchInformation.Controls)
            {
                if (!(item is Label)) //label degılse
                {
                    item.Text = "";
                    item.BackColor = Color.White;
                }
            }
            foreach (Control item in grpOrderInformation.Controls)
            {
                if (!(item is Label)) //label degılse
                {

                    item.Text = "";
                    item.BackColor = Color.White;
                }
            }
            foreach (Control item in grpCarrierInformation.Controls)
            {
                if (!(item is Label)) //label degılse
                {
                    item.Text = "";
                    item.BackColor = Color.White;
                }
            }
            //toplam tutar
            txtTotalAmount.Text = "";
            txtTotalAmount.BackColor = Color.White;

            int rowCount = gridPrice.Rows.Count;
            for (int i = 0; i < rowCount; i++) //datagrid butun rowları sıl en son 1 tane row ekle
            {
                var r = gridPrice.Rows[0];
                gridPrice.Rows.Remove(r);
            }
            gridPrice.Rows.Add();


        }


        private void calculateTotalAmount()
        {
            decimal total = 0;


            foreach (DataGridViewRow row in gridPrice.Rows)
            {
                //kdv sız tutar
                decimal totalRevenue = Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.quantity)].Value)
                    * Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.unitPrice)].Value);

                total = +totalRevenue;
            }

            txtTotalAmount.Text = total.ToString();
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

                    else   // tckn degılse
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
            foreach (Control item in grpDespatchInformation.Controls)
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
            foreach (Control item in grpOrderInformation.Controls)  //grupbox not ve toplam bilgileri
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
            foreach (Control item in grpCarrierInformation.Controls)  //grupbox not ve toplam bilgileri
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
            foreach (DataGridViewRow row in gridPrice.Rows)  //datagrid rowlarında bos eleman var mı
            {
                for (int i = 0; i < gridPrice.ColumnCount; i++)
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

            return valid;
        }





        private void btnCreateDespatch_Click(object sender, EventArgs e)
        {
            try
            {
                //bos eleamn olmaması
                if (validEmptyComponent())
                {
                    //tutar hesapla
                    calculateTotalAmount();

                    //kullanıcı bılgılerı getır              
                    getUserInformationOnDb();

                    //////////UBL OLUSTURMA ISLEMI////////
                    //BaseInvoiceUBL despatch;


                    //despatch = new ArchiveUBL(cmbArchiveSendingType.Text, cmbScenario.Text, cmbInvType.Text);

                    //if (cmbArchiveType.Text == nameof(EI.ArchiveType.INTERNET))
                    //{
                    //    //eger gonderım tıpı ınternet ıse ekstra adınatıonal ref ekle
                    //    despatch.addAdditionalDocumentReference(nameof(EI.Profileid.EARSIVFATURA), cmbArchiveType.Text);

                    //    //DELİVERY BOLUMU EKLE
                    //    //carrıer ekle
                    //    PartyType carrierParty = despatch.createParty(txtCarrierTitle.Text, "", "", "");
                    //    despatch.addPartyIdentification(carrierParty, 1, nameof(EI.VknTckn.VKN), msdDeliveryVkn.Text, "", "", "", "");
                    //    despatch.createDelivery(carrierParty, Convert.ToDateTime(datepicDespatchDate.Text));

                    //    //payment means ekle                   
                    //    despatch.createPaymentMeans(getPaymentCode(cmbPaymentType.Text), Convert.ToDateTime(datepicPaymentDate.Text), txtMediator.Text);
                    //}


                    //PartyType supParty;
                    //PartyType cusParty;
                    ////SUPPLİER  PARTY OLUSTURULMASI  
                    //supParty = despatch.createParty(partyName, cityName, telephone, mail);
                    //if (senderVknTc.Length == 10) //sup vkn
                    //{
                    //    despatch.addPartyIdentification(supParty, 2, nameof(EI.VknTckn.VKN), senderVknTc, nameof(EI.Mersis.MERSISNO), sicilNo, "", "");
                    //    despatch.addPartyTaxSchemeOnParty(supParty);
                    //}
                    //else  //sup tckn .. add person metodu eklenır
                    //{
                    //    despatch.addPartyIdentification(supParty, 2, nameof(EI.VknTckn.TCKN), senderVknTc, nameof(EI.Mersis.MERSISNO), sicilNo, "", "");
                    //    despatch.addPersonOnParty(supParty, firstName, familyName);
                    //}
                    //despatch.SetSupplierParty(supParty);

                    ////CUST PARTY OLUSTURULMASI  
                    //cusParty = despatch.createParty(txtPartyName.Text, txtCity.Text, msdPhone.Text, txtMail.Text);
                    //if (msdVknTc.Text.Length == 10) //customer vkn
                    //{
                    //    despatch.addPartyIdentification(cusParty, 1, nameof(EI.VknTckn.VKN), msdVknTc.Text, "", "", "", "");
                    //    despatch.addPartyTaxSchemeOnParty(cusParty);
                    //}
                    //else  //customer tckn
                    //{
                    //    despatch.addPartyIdentification(cusParty, 1, nameof(EI.VknTckn.TCKN), msdVknTc.Text, "", "", "", "");
                    //    despatch.addPersonOnParty(cusParty, txtCustName.Text, txtCustSurname.Text);
                    //}
                    //despatch.SetCustomerParty(cusParty);


                    ////INV LINE OLUSTURULMASI
                    //foreach (DataGridViewRow row in gridPrice.Rows)
                    //{
                    //    //Inv Lıne Olusturulması
                    //    //unıt code get fonk cagırılarak secılen bırımın unıt codu getırılırilerek aktarılır
                    //    despatch.addInvoiceLine(row.Index.ToString(), cmbMoneyType.Text, getUnitCode(row.Cells[nameof(EI.InvLineGridRowClm.unit)].Value.ToString())
                    //        , Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.quantity)].Value), Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.total)].Value)
                    //        , Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.taxAmount)].Value), Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.total)].Value)
                    //        , Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.taxPercent)].Value), row.Cells[nameof(EI.InvLineGridRowClm.productName)].Value.ToString()
                    //        , Convert.ToDecimal(row.Cells[nameof(EI.InvLineGridRowClm.unitPrice)].Value));
                    //}

                    //despatch.setInvLines();
                    //despatch.setTaxTotal(despatch.invoiceTaxTotal());
                    //despatch.SetLegalMonetaryTotal(despatch.CalculateLegalMonetaryTotal());
                    //despatch.SetAllowanceCharge(despatch.CalculateAllowanceCharges());

                    ////olusturdugumuz nesne ubl turune cevrılır
                    //var invoiceUbl = despatch.BaseUBL;
                    ////xml olustur
                    //string xmlPath = FolderControl.createInvUblToXml(invoiceUbl, invoiceType).ToString();

                    ////db ye kaydet
                    //if (invoiceType == nameof(EI.Invoice.Invoices))
                    //{
                    //    Singl.invoiceDalGet.insertDraftInvoice(invoiceUbl, xmlPath);
                    //}
                    //else if (invoiceType == nameof(EI.Invoice.ArchiveInvoices)) //arsıv ıse
                    //{
                    //    Singl.archiveInvoiceDalGet.insertArchiveOnDbFromUbl(invoiceUbl, xmlPath, chkSendMail.Checked);
                    //}

                    //MessageBox.Show(xmlPath + "  faturalar kaydedıldı");

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
