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
        private List<InvoiceLineType> listInvLine = new List<InvoiceLineType>();




        public CreateInvoiceUBL(string profileId, string invoiceTypeCode)
        {
            BaseUBL = new InvoiceType();

            createInvoiceHeader(profileId, invoiceTypeCode);
            createAdditionalDocumentReference();
            createSignature();
        }





        public void createInvoiceHeader(string profileid, string invTypeCode)
        {

            BaseUBL.UBLVersionID = new UBLVersionIDType { Value = "2.1" }; //uluslararası fatura standardı 2.1
            BaseUBL.CustomizationID = new CustomizationIDType { Value = "TR1.2" }; //fakat GİB UBLTR olarak isimlendirdiği Türkiye'ye özgü 1.2 efatura formatını kullanıyor.
            BaseUBL.ProfileID = new ProfileIDType { Value = profileid };
            BaseUBL.ID = new IDType { Value = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") };//id yi simdilik unıqıe bır deger verıyoruz , load ınv da degıstırılecek
            BaseUBL.CopyIndicator = new CopyIndicatorType { Value = false };
            BaseUBL.UUID = new UUIDType { Value = Guid.NewGuid().ToString() };
            BaseUBL.IssueDate = new IssueDateType { Value = DateTime.Now };
            BaseUBL.IssueTime = new IssueTimeType { Value = DateTime.Now };
            BaseUBL.InvoiceTypeCode = new InvoiceTypeCodeType { Value = invTypeCode };
            BaseUBL.DocumentCurrencyCode = new DocumentCurrencyCodeType { Value = "TRY" };

        }





        public void createAdditionalDocumentReference()
        {
            var idRef = new DocumentReferenceType();

            idRef.ID = new IDType { Value = Guid.NewGuid().ToString() };
            idRef.IssueDate = BaseUBL.IssueDate;
            idRef.DocumentType = new DocumentTypeType { Value = nameof(EI.DocumentType.XSLT) };
            idRef.Attachment = new AttachmentType();
            idRef.Attachment.EmbeddedDocumentBinaryObject = new EmbeddedDocumentBinaryObjectType();

            idRef.Attachment.EmbeddedDocumentBinaryObject.characterSetCode = "UTF-8";
            idRef.Attachment.EmbeddedDocumentBinaryObject.encodingCode = "Base64";
            idRef.Attachment.EmbeddedDocumentBinaryObject.filename = BaseUBL.ID.Value.ToString() + ".xslt";
            idRef.Attachment.EmbeddedDocumentBinaryObject.mimeCode = "application/xml";
            idRef.Attachment.EmbeddedDocumentBinaryObject.Value = Encoding.UTF8.GetBytes(Xslt.xsltGibInvoice);


            DocumentReferenceType[] DocRefArr = new DocumentReferenceType[1];

            DocRefArr[0] = idRef;
            BaseUBL.AdditionalDocumentReference = DocRefArr;
        }



        public void createSignature()
        {
            var signature = new[]
            {
                new SignatureType
                {
                    ID = new IDType { schemeID = "VKN_TCKN", Value = "4840847211" },
                    SignatoryParty = new PartyType
                    {
                        WebsiteURI = new WebsiteURIType { Value = "www.izibiz.com.tr" },
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


        public void SetSupplierParty(PartyType supplierParty)
        {
            var accountingSupplierParty = new SupplierPartyType //göndericinin fatura üzerindeki bilgileri
            {
                Party = supplierParty
            };
            BaseUBL.AccountingSupplierParty = accountingSupplierParty;
        }


        public void SetCustomerParty(PartyType customerParty)
        {
            var accountingCustomerParty = new CustomerPartyType //Alıcının fatura üzerindeki bilgileri
            {
                Party = customerParty
            };
            BaseUBL.AccountingCustomerParty = accountingCustomerParty;
        }



        public PartyType createParty(string webUrı, string partyName,
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
                        partyIdentification.ID = new IDType();
                        partyIdentification.ID.schemeID = param1;
                        partyIdentification.ID.Value = param1Value; break;

                    case 1:
                        partyIdentification.ID = new IDType();
                        partyIdentification.ID.schemeID = param2;
                        partyIdentification.ID.Value = param2Value; break;

                    case 2:
                        partyIdentification.ID = new IDType();
                        partyIdentification.ID.schemeID = param3;
                        partyIdentification.ID.Value = param3Value; break;
                }
                partyIdentificationArr[i] = partyIdentification;
            }
            party.PartyIdentification = partyIdentificationArr;
        }





        public void setInvLines()
        {
            BaseUBL.InvoiceLine = listInvLine.ToArray();
            BaseUBL.LineCountNumeric = new LineCountNumericType { Value = listInvLine.Count };
        }


        public void addInvoiceLine(string invId, string currencyID, string note, string unitCode, decimal quantity, decimal lineExtensionAmount, decimal taxAmount,
            decimal taxableAmount, decimal percent, string itemName, decimal price)
        {



            InvoiceLineType invoiceLine = new InvoiceLineType
            {

                ID = new IDType { Value = invId },
                Note = new NoteType[] { new NoteType { Value = note } },
                InvoicedQuantity = new InvoicedQuantityType { unitCode = unitCode, Value = quantity },
                LineExtensionAmount = new LineExtensionAmountType { currencyID = currencyID, Value = lineExtensionAmount },
                AllowanceCharge = new[]
                 {
                             new AllowanceChargeType
                             {
                                 ChargeIndicator = new ChargeIndicatorType { Value = false },  //ıskonto false
                                 Amount = new AmountType2
                                 {
                                     currencyID = currencyID,
                                     Value = 0.00M                //suan ındırım yapmıyoruz
                                 },
                                 BaseAmount = new BaseAmountType
                                 {
                                     currencyID = currencyID,
                                     Value = 0
                                 }
                             }
                     },
                TaxTotal = new TaxTotalType
                {
                    TaxAmount = new TaxAmountType
                    {
                        currencyID = currencyID,
                        Value = taxAmount
                    },

                    TaxSubtotal = new[]
                        {
                                new TaxSubtotalType
                                {
                                    TaxableAmount = new TaxableAmountType
                                    {
                                        currencyID = currencyID,
                                        Value = taxableAmount
                                    },

                                    TaxAmount = new TaxAmountType
                                    {
                                        currencyID = currencyID,
                                        Value = taxAmount
                                    },
                                    CalculationSequenceNumeric=new CalculationSequenceNumericType
                                    {
                                        Value=1
                                    },
                                    Percent = new PercentType1 { Value =percent },

                                    TaxCategory = new TaxCategoryType
                                    {
                                        TaxScheme = new TaxSchemeType
                                        {
                                            Name = new NameType1 { Value = nameof(EI.TaxType.KDV)},
                                            TaxTypeCode = new TaxTypeCodeType { Value = "0015" }
                                        }
                                    }
                                }
                        }
                },
                Item = new ItemType
                {
                    Name = new NameType1 { Value = itemName }
                },

                Price = new PriceType
                {
                    PriceAmount = new PriceAmountType
                    {
                        currencyID = currencyID,
                        Value = price
                    }
                }
            };
            listInvLine.Add(invoiceLine);
        }



        public void setTaxTotal(TaxTotalType[] taxTotal)
        {
            BaseUBL.TaxTotal = taxTotal;
        }

        //public void addTaxSubtotal(TaxTotalType taxTotal,string currencyCode, decimal taxableAmount, decimal taxAmount, decimal taxRate)
        //{
        //    List<TaxSubtotalType> taxSubTotalList = new List<TaxSubtotalType>();


        //    TaxSubtotalType taxSubtotal=  new TaxSubtotalType
        //    {
        //        TaxableAmount = new TaxableAmountType
        //        {
        //            currencyID = currencyCode,
        //            Value = taxableAmount
        //        },

        //        TaxAmount = new TaxAmountType
        //        {
        //            currencyID = currencyCode,
        //            Value = taxAmount
        //        },

        //        CalculationSequenceNumeric = new CalculationSequenceNumericType
        //        {
        //            Value = 1
        //        },
        //        Percent = new PercentType1 { Value = taxRate },

        //        TaxCategory = new TaxCategoryType
        //        {
        //            TaxScheme = new TaxSchemeType
        //            {
        //                Name = new NameType1 { Value = nameof(EI.TaxType.KDV) },
        //                TaxTypeCode = new TaxTypeCodeType { Value = "0015" }
        //            }
        //        }
        //    };
        //   taxSubTotalList.Add(taxSubtotal);
        //   taxTotal.TaxSubtotal = taxSubTotalList.ToArray();
        //}



        //public TaxTotalType createTaxTotal(string currencyCode, decimal totalTaxAmount)
        //{
        //    return  new TaxTotalType
        //    {
        //        TaxAmount = new TaxAmountType
        //        {
        //            currencyID = currencyCode,
        //            Value = totalTaxAmount
        //        },
        //        TaxSubtotal = new TaxSubtotalType[] { }
        //    };
        //}



        //public virtual TaxTotalType[] invoiceTaxTotal()
        //{
        //    List<TaxTotalType> taxTotalList = new List<TaxTotalType>();
        //    List<TaxSubtotalType> taxSubTotalList = new List<TaxSubtotalType>();

        //    TaxTotalType taxTotal = new TaxTotalType { TaxAmount = new TaxAmountType { Value = 0 } };

        //    var taxSubtotal = new TaxSubtotalType
        //    {
        //        TaxableAmount = new TaxableAmountType { Value = 0 },
        //        TaxAmount = new TaxAmountType { Value = 0 },
        //        Percent = new PercentType1 { Value = 0 },
        //        TaxCategory = new TaxCategoryType
        //        {
        //            TaxScheme = new TaxSchemeType
        //            {
        //                Name = new NameType1 { Value = nameof(EI.TaxType.KDV) },
        //                TaxTypeCode = new TaxTypeCodeType
        //                {
        //                    Value = "0015"
        //                }
        //            }
        //        }
        //    };

        //    foreach (var line in BaseUBL.InvoiceLine)
        //    {

        //        taxTotal.TaxAmount.Value += line.TaxTotal.TaxAmount.Value;
        //        taxTotal.TaxAmount.currencyID = line.TaxTotal.TaxAmount.currencyID;



        //        foreach (var tax in line.TaxTotal.TaxSubtotal)
        //        {

        //            taxSubtotal.TaxableAmount.Value += tax.TaxableAmount.Value;
        //            taxSubtotal.TaxableAmount.currencyID = tax.TaxableAmount.currencyID;
        //            taxSubtotal.TaxAmount.Value += line.TaxTotal.TaxAmount.Value;
        //            taxSubtotal.TaxAmount.currencyID = tax.TaxAmount.currencyID;
        //            taxSubtotal.Percent.Value = tax.Percent.Value;

        //        }

        //    }
        //    taxSubTotalList.Add(taxSubtotal);
        //    taxTotal.TaxSubtotal = taxSubTotalList.ToArray();
        //    taxTotalList.Add(taxTotal);
        //    return taxTotalList.ToArray();
        //}



        public virtual TaxTotalType[] invoiceTaxTotal()
        {
            List<TaxTotalType> taxTotalList = new List<TaxTotalType>();
            List<TaxSubtotalType> taxSubTotalList = new List<TaxSubtotalType>();



            TaxTotalType taxTotal = new TaxTotalType { TaxAmount = new TaxAmountType { Value = 0 } };

            var taxSubtotalNew = new TaxSubtotalType
            {
                TaxableAmount = new TaxableAmountType { Value = 0 },
                TaxAmount = new TaxAmountType { Value = 0 },
                Percent = new PercentType1 { Value = 0 },
                TaxCategory = new TaxCategoryType
                {
                    TaxScheme = new TaxSchemeType
                    {
                        Name = new NameType1 { Value = nameof(EI.TaxType.KDV) },
                        TaxTypeCode = new TaxTypeCodeType
                        {
                            Value = "0015"
                        }
                    }
                }
            };



            foreach (var line in BaseUBL.InvoiceLine)
            {

                taxTotal.TaxAmount.Value += line.TaxTotal.TaxAmount.Value;
                taxTotal.TaxAmount.currencyID = line.TaxTotal.TaxAmount.currencyID;

                foreach (var tax in line.TaxTotal.TaxSubtotal)
                {
                    taxSubtotalNew.TaxableAmount.currencyID = tax.TaxableAmount.currencyID;
                    taxSubtotalNew.TaxAmount.currencyID = tax.TaxAmount.currencyID;
                    taxSubtotalNew.Percent.Value = tax.Percent.Value;


                    if (taxSubTotalList.Where(x => x.Percent.Value == tax.Percent.Value).FirstOrDefault() != null)  //percent varsa
                    {
                        taxSubtotalNew.TaxableAmount.Value += tax.TaxableAmount.Value;
                        taxSubtotalNew.TaxAmount.Value += line.TaxTotal.TaxAmount.Value;
                    }
                    else //yoksa ekle
                    {                      
                        taxSubtotalNew.TaxableAmount.Value = tax.TaxableAmount.Value;
                        taxSubtotalNew.TaxAmount.Value = line.TaxTotal.TaxAmount.Value;

                        taxSubTotalList.Add(taxSubtotalNew);
                    }
                }
            }

            taxTotal.TaxSubtotal = taxSubTotalList.ToArray();
            taxTotalList.Add(taxTotal);
            return taxTotalList.ToArray();
        }



        public MonetaryTotalType CalculateLegalMonetaryTotal()
        {
            MonetaryTotalType legalMonetaryTotal = new MonetaryTotalType
            {
                LineExtensionAmount = new LineExtensionAmountType { Value = 0 },

                TaxExclusiveAmount = new TaxExclusiveAmountType { Value = 0 },

                TaxInclusiveAmount = new TaxInclusiveAmountType { Value = 0 },

                AllowanceTotalAmount = new AllowanceTotalAmountType { Value = 0 },

                PayableAmount = new PayableAmountType { Value = 0 }
            };

            foreach (var line in BaseUBL.InvoiceLine)
            {

                foreach (var allowance in line.AllowanceCharge)
                {
                    legalMonetaryTotal.AllowanceTotalAmount.currencyID = allowance.Amount.currencyID;
                    legalMonetaryTotal.AllowanceTotalAmount.Value += allowance.Amount.Value;
                    legalMonetaryTotal.TaxInclusiveAmount.currencyID = line.LineExtensionAmount.currencyID;

                    legalMonetaryTotal.TaxInclusiveAmount.Value += line.LineExtensionAmount.Value -
                        allowance.Amount.Value + line.TaxTotal.TaxAmount.Value;
                }

                legalMonetaryTotal.LineExtensionAmount.currencyID = line.LineExtensionAmount.currencyID;
                legalMonetaryTotal.LineExtensionAmount.Value += line.LineExtensionAmount.Value;


                legalMonetaryTotal.PayableAmount.currencyID = line.LineExtensionAmount.currencyID;
                legalMonetaryTotal.PayableAmount.Value = legalMonetaryTotal.TaxInclusiveAmount.Value;

                foreach (var tax in line.TaxTotal.TaxSubtotal)
                {

                    legalMonetaryTotal.TaxExclusiveAmount.currencyID = tax.TaxableAmount.currencyID;
                    legalMonetaryTotal.TaxExclusiveAmount.Value += tax.TaxableAmount.Value;


                }

            }
            return legalMonetaryTotal;
        }


        public void SetLegalMonetaryTotal(MonetaryTotalType legalMonetoryTotal)
        {
            BaseUBL.LegalMonetaryTotal = legalMonetoryTotal;
        }

        public virtual void SetAllowanceCharge(AllowanceChargeType[] allowenceCharges)
        {
            BaseUBL.AllowanceCharge = allowenceCharges;
        }


        public virtual AllowanceChargeType[] CalculateAllowanceCharges()
        {
            AllowanceChargeType allowanceCharge = new AllowanceChargeType
            {
                Amount = new AmountType2 { Value = 0 },
                BaseAmount = new BaseAmountType { Value = 0 },
                ChargeIndicator = new ChargeIndicatorType { Value = false },

            };
            foreach (var item in BaseUBL.InvoiceLine)
            {
                foreach (var iskonto in item.AllowanceCharge)
                {
                    allowanceCharge.BaseAmount.currencyID = iskonto.Amount.currencyID;
                    allowanceCharge.Amount.currencyID = iskonto.Amount.currencyID;
                    allowanceCharge.Amount.Value += iskonto.Amount.Value;
                    allowanceCharge.BaseAmount.Value += iskonto.BaseAmount.Value;
                }
            }

            return new[] { allowanceCharge };
        }


    }
}
