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





        public CreateInvoiceUBL(string profileId, string invoiceTypeCode)
        {
            BaseUBL = new InvoiceType();

            createInvoiceHeader(profileId, invoiceTypeCode);
            setAdditionalDocumentReference();
            SetSignature();
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
            BaseUBL.DocumentCurrencyCode = new DocumentCurrencyCodeType { Value = "TRY" };

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


        public virtual void SetCustomerParty(PartyType customerParty)
        {
            var accountingCustomerParty = new CustomerPartyType //Alıcının fatura üzerindeki bilgileri
            {
                Party = customerParty
            };
            BaseUBL.AccountingCustomerParty = accountingCustomerParty;
        }



        public PartyType GetParty(string webUrı, string partyName,
             string streetName, string buldingName, string buldingNumber, string visionName, string cityName,
            string postalZone, string region, string country, string telephone, string fax, string mail)
        {
            return new PartyType
            {
                WebsiteURI = new WebsiteURIType { Value = webUrı },

                PartyName = new PartyNameType { Name = new NameType1 { Value = partyName } },

                PostalAddress = new AddressType
                {
                    StreetName = new StreetNameType { Value = streetName },
                    BuildingName = new BuildingNameType { Value = buldingName },
                    BuildingNumber = new BuildingNumberType { Value = buldingNumber },
                    CitySubdivisionName = new CitySubdivisionNameType { Value = visionName },
                    CityName = new CityNameType { Value = cityName },
                    PostalZone = new PostalZoneType { Value = postalZone },
                    Region = new RegionType { Value = region },
                    Country = new CountryType { Name = new NameType1 { Value = country } }
                },

                Contact = new ContactType
                {
                    Telephone = new TelephoneType { Value = telephone },
                    Telefax = new TelefaxType { Value = fax },
                    ElectronicMail = new ElectronicMailType { Value = mail }
                },
            };
        }



        public void addPartyTaxSchemeOnParty(PartyType party, string taxScheme)
        {
            party.PartyTaxScheme = new PartyTaxSchemeType
            {
                TaxScheme = new TaxSchemeType { Name = new NameType1 { Value = taxScheme } }
            };
        }




        public void addPersonOnParty(PartyType party, string firstName, string familyName)
        {
            party.Person = new PersonType
            {
                FirstName = new FirstNameType { Value = firstName },
                FamilyName = new FamilyNameType { Value = familyName }
            };
        }



        public void addPartyIdentification(PartyType party, int paramCount, string param1, string param1Value,
            string param2, string param2Value, string param3, string param3Value)
        {
            PartyIdentificationType[] partyIdentificationArr = new PartyIdentificationType[paramCount];
            for (int i = 0; i < paramCount; i++)
            {
                PartyIdentificationType partyIdentification = new PartyIdentificationType();
                switch (i)
                {
                    case 0:
                        partyIdentification.ID.schemeID = param1;
                        partyIdentification.ID.schemeName = param1Value; break;
                    case 1:
                        partyIdentification.ID.schemeID = param2;
                        partyIdentification.ID.schemeName = param2Value; break;
                    case 2:
                        partyIdentification.ID.schemeID = param3;
                        partyIdentification.ID.schemeName = param3Value; break;
                }
                partyIdentificationArr[i] = partyIdentification;
            }
            party.PartyIdentification = partyIdentificationArr;
        }




        public virtual void getInvoiceLines(InvoiceLineType[] invoiceLines)
        {
            BaseUBL.InvoiceLine = invoiceLines;
            BaseUBL.LineCountNumeric = new LineCountNumericType { Value = invoiceLines.Length };
        }



        public void setTaxTotal(TaxTotalType[] taxTotal)
        {
            BaseUBL.TaxTotal = taxTotal;
        }


        public TaxTotalType[] createTaxTotal()
        {
            return new TaxTotalType[]
            {
                TaxAmount = new TaxAmountType
                {
                    currencyID = "TRY",
                    Value = 0.19M
                },
                TaxSubtotal = new[]
                {
                    new TaxSubtotalType
                    {
                        TaxableAmount = new TaxableAmountType
                        {
                            currencyID = "TRY",                      
                            Value = 19.00M
                        },

                        TaxAmount = new TaxAmountType
                        {
                            currencyID = "TRY",
                            Value = 0.19M
                        },

                        CalculationSequenceNumeric =new CalculationSequenceNumericType
                        {
                            Value =1
                        },
                        Percent = new PercentType1 { Value = 1},

                        TaxCategory = new TaxCategoryType
                        {
                            TaxScheme = new TaxSchemeType
                            {
                                Name = new NameType1 { Value = "KDV" },
                                TaxTypeCode = new TaxTypeCodeType { Value = "0015" }
                            }
                        }
                    }
                }
            };
        }



        public InvoiceLineType[] createInvoiceLines(int lineCount, TaxTotalType taxTotal)
        {
            List<InvoiceLineType> list = new List<InvoiceLineType>();
            for (int i = 1; i <= lineCount; i++)
            {
                #region invoiceLine
                InvoiceLineType invoiceLine = new InvoiceLineType
                {

                    ID = new IDType { Value = i.ToString() },
                    InvoicedQuantity = new InvoicedQuantityType { unitCode = "C62", Value = 10 },
                    LineExtensionAmount = new LineExtensionAmountType { currencyID = "TRY", Value = 20.00M },

                    AllowanceCharge = new[]
                        {
                            new AllowanceChargeType
                            {
                                ChargeIndicator = new ChargeIndicatorType { Value = false },
                                MultiplierFactorNumeric = new MultiplierFactorNumericType { Value = 0.05M },

                                Amount = new AmountType2
                                {
                                    currencyID = "TRY",
                                    Value = 1.00M
                                },

                                BaseAmount = new BaseAmountType
                                {
                                    currencyID = "TRY",
                                    Value = 20
                                }
                            }
                        },

                    Item = new ItemType
                    {
                        Name = new NameType1 { Value = "Kalem" }
                    },

                    Price = new PriceType
                    {
                        PriceAmount = new PriceAmountType
                        {
                            currencyID = "TRY",
                            Value = 2.00M
                        }
                    }
                };
                #endregion
                list.Add(invoiceLine);
            }

            return list.ToArray();
        }








    }
}
