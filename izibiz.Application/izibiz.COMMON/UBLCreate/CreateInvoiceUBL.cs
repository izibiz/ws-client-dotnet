using izibiz.COMMON;
using izibiz.COMMON.Ubl_Tr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubl_Invoice_2_1;

namespace izibiz.CONTROLLER
{
    public class CreateInvoiceUBL
    {

        public InvoiceType BaseUBL { get; protected set; }





        public CreateInvoiceUBL(string profileId, string invoiceTypeCode, string documentCurrencyCode)
        {
            BaseUBL = new InvoiceType();

            createInvoiceHeader(profileId, invoiceTypeCode);
            setAdditionalDocumentReference();

            SetSignature();

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





        public void createInvoiceHeader(string profileid, string invTypeCode)
        {

            BaseUBL.UBLVersionID = new UBLVersionIDType { Value = "2.1" }; //uluslararası fatura standardı 2.1
            BaseUBL.CustomizationID = new CustomizationIDType { Value = "TR1.2" }; //fakat GİB UBLTR olarak isimlendirdiği Türkiye'ye özgü 1.2 efatura formatını kullanıyor.
            BaseUBL.ProfileID = new ProfileIDType { Value = profileid };
            /**/
            BaseUBL.ID = new IDType { Value = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") };//id yi simdilik unıqıe bır deger verıyoruz , load ınv da degıstırılecek
            BaseUBL.CopyIndicator = new CopyIndicatorType { Value = false };
            BaseUBL.UUID = new UUIDType { Value = Guid.NewGuid().ToString() };
            BaseUBL.IssueDate = new IssueDateType { Value = DateTime.Now };
            BaseUBL.IssueTime = new IssueTimeType { Value = DateTime.Now };
            BaseUBL.InvoiceTypeCode = new InvoiceTypeCodeType { Value = invTypeCode };
            /*  NoteType[] note = new NoteType[] { new NoteType { Value = "sdfasdfas" } };
          BaseUBL.Note = note;*/
            BaseUBL.DocumentCurrencyCode = new DocumentCurrencyCodeType { Value = EI.DocumentCurrencyCode.USD.ToString() };

        }





        public void setAdditionalDocumentReference()
        {
            var idRef = new DocumentReferenceType()
            {
                ID = new IDType { Value = Guid.NewGuid().ToString() },
                IssueDate = BaseUBL.IssueDate,
                DocumentType = new DocumentTypeType { Value = nameof(EI.DocumentType.XSLT) },
                Attachment = new AttachmentType
                {
                    EmbeddedDocumentBinaryObject = new EmbeddedDocumentBinaryObjectType
                    {
                        characterSetCode = "UTF-8",
                        encodingCode = "Base64",
                        filename = BaseUBL.ID.ToString() + ".xslt",
                        mimeCode = "application/xml",
                        Value = Encoding.UTF8.GetBytes(XSLTInvoice.xsltGib)
                    }
                }
            };
            DocumentReferenceType[] DocRefArr = new DocumentReferenceType[1];

            DocRefArr[0] = idRef;
            BaseUBL.AdditionalDocumentReference = DocRefArr;
        }



        public void SetSignature()
        {
            var signature = new[]
            {
                new SignatureType
                {
                    ID = new IDType { schemeID = "VKN_TCKN", Value = "4840847211" },
                    SignatoryParty = new PartyType
                    {
                        WebsiteURI = new WebsiteURIType { Value = "www.FITsolutions.com.tr" },
                        PartyIdentification = new[]                  
                        {
                            new PartyIdentificationType
                            {
                                ID = new IDType { schemeID = "VKN", Value = "4840847211" }
                            }
                        },
                        PostalAddress = new AddressType
                        {
                            StreetName = new StreetNameType { Value = "DAVUT PAŞA" },
                            BuildingName = new BuildingNameType { Value = "C1" },
                            BuildingNumber = new BuildingNumberType { Value = "402" },
                            CitySubdivisionName = new CitySubdivisionNameType { Value = "MAHALL" },
                            CityName = new CityNameType { Value = "İSTANBUL" },
                            PostalZone = new PostalZoneType { Value = "34100" },
                            Region = new RegionType { Value = "Marmara" },
                            Country = new CountryType { Name = new NameType1 { Value = "TR" } }
                        },
                    },
                    DigitalSignatureAttachment = new AttachmentType
                    {
                        ExternalReference = new ExternalReferenceType
                        {
                            URI = new URIType { Value = "#Signature_DMY20150922204254" }
                        }
                    }
                }
            };

            BaseUBL.Signature = signature;
        }


        public virtual void SetSupplierParty(PartyType supplierParty)
        {
            var accountingSupplierParty = new SupplierPartyType //göndericinin fatura üzerindeki bilgileri
            {
                Party = supplierParty
            };

            BaseUBL.AccountingSupplierParty = accountingSupplierParty;
        }



        public PartyType GetParty(string vknTckn, string parametre)
        {
            return new PartyType
            {
                WebsiteURI = new WebsiteURIType { Value = "web sitesi" },


                PartyIdentification = new[]
                {
                   new PartyIdentificationType { ID = new IDType { schemeID = parametre, Value = vknTckn } }
                },

                PartyName = new PartyNameType { Name = new NameType1 { Value = "asdasd" } },

                PostalAddress = new AddressType
                {
                    Room = new RoomType { Value = "kapi no" },
                    StreetName = new StreetNameType { Value = "cadde" },
                    BuildingName = new BuildingNameType { Value = "bina" },
                    BuildingNumber = new BuildingNumberType { Value = "bina no" },
                    CitySubdivisionName = new CitySubdivisionNameType { Value = "mahalle" },
                    CityName = new CityNameType { Value = "sehir" },
                    PostalZone = new PostalZoneType { Value = "posta kodu" },
                    Region = new RegionType { Value = "asdasd" },
                    Country = new CountryType { Name = new NameType1 { Value = "ülke" } }
                },

                PartyTaxScheme = new PartyTaxSchemeType
                {
                    TaxScheme = new TaxSchemeType { Name = new NameType1 { Value = "vergi dairesi" } }
                },

                Contact = new ContactType
                {
                    Telephone = new TelephoneType { Value = "telefon" },
                    Telefax = new TelefaxType { Value = "faks" },
                    ElectronicMail = new ElectronicMailType { Value = "mail" }
                },
                Person = new PersonType
                {
                    FirstName = new FirstNameType { Value = "İsim" },
                    FamilyName = new FamilyNameType { Value = "Soyisim" },
                }
            };




            suppParty.PartyIdentification = suppPartyid;
            suppParty.PartyName = new PartyNameType { Name = new NameType1 { Value = "İZİBİZ BİLİŞİM TEKNOLOJİLERİ" } };

            AddressType suppPartyAddr = new AddressType();
            suppPartyAddr.StreetName = new StreetNameType() { Value = "Bahalibahce Sok." };
            suppPartyAddr.BuildingName = new BuildingNameType() { Value = "Cenk Ap." };
            suppPartyAddr.BuildingNumber = new BuildingNumberType() { Value = "11/2" };
            suppPartyAddr.CitySubdivisionName = new CitySubdivisionNameType() { Value = "Bakirkoy" };
            suppPartyAddr.CityName = new CityNameType() { Value = "İSTANBUL" };
            suppPartyAddr.PostalZone = new PostalZoneType() { Value = "34100" };
            suppPartyAddr.Region = new RegionType() { Value = "INCIRLI" };
            suppPartyAddr.Country = new CountryType() { Name = new NameType1() { Value = "TR" } };

            suppParty.PostalAddress = suppPartyAddr;
            suppParty.PartyTaxScheme = new PartyTaxSchemeType { TaxScheme = new TaxSchemeType { Name = new NameType1 { Value = "BAKIRKOY" } } };
            suppParty.Contact = new ContactType { ElectronicMail = new ElectronicMailType { Value = "yasar.gunes@izibiz.com.tr" } };

            supplier.Party = suppParty;

            invoice.AccountingSupplierParty = supplier;












        }





    }
}
