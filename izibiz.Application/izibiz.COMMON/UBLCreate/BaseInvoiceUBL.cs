using izibiz.COMMON;
using izibiz.COMMON.Ubl_Tr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UblInvoice;


namespace izibiz.CONTROLLER
{
    public class BaseInvoiceUBL
    {

        public InvoiceType baseInvoiceUBL { get; protected set; }
        private List<InvoiceLineType> listInvLine = new List<InvoiceLineType>();
        public List<DocumentReferenceType> docRefList = new List<DocumentReferenceType>();





        public BaseInvoiceUBL(string profileId, string invoiceTypeCode)
        {
            baseInvoiceUBL = new InvoiceType();

            createInvoiceHeader(profileId, invoiceTypeCode);
            createSignature();
        }





        public void createInvoiceHeader(string profileid, string invTypeCode)
        {

            baseInvoiceUBL.UBLVersionID = new UBLVersionIDType { Value = "2.1" }; //uluslararası fatura standardı 2.1
            baseInvoiceUBL.CustomizationID = new CustomizationIDType { Value = "TR1.2" }; //fakat GİB UBLTR olarak isimlendirdiği Türkiye'ye özgü 1.2 efatura formatını kullanıyor.
            baseInvoiceUBL.ProfileID = new ProfileIDType { Value = profileid };
            baseInvoiceUBL.ID = new IDType { Value = DateTime.Now.ToString("MM/dd/yyyy-HH/mm/ss") };//id yi simdilik unıqıe bır deger verıyoruz ,servise gond. degıstırılecek
            baseInvoiceUBL.CopyIndicator = new CopyIndicatorType { Value = false };
            baseInvoiceUBL.UUID = new UUIDType { Value = Guid.NewGuid().ToString() };
            baseInvoiceUBL.IssueDate = new IssueDateType { Value = DateTime.Now };
            baseInvoiceUBL.IssueTime = new IssueTimeType { Value = DateTime.Now };
            baseInvoiceUBL.InvoiceTypeCode = new InvoiceTypeCodeType { Value = invTypeCode };
            baseInvoiceUBL.DocumentCurrencyCode = new DocumentCurrencyCodeType { Value = "TRY" };

        }








        public void addAdditionalDocumentReference(string documentType, string docTypeCode)
        {

            var arcRef = new DocumentReferenceType();
            arcRef.ID = new IDType { Value = Guid.NewGuid().ToString() };
            arcRef.IssueDate = baseInvoiceUBL.IssueDate;
            arcRef.DocumentType = new DocumentTypeType { Value = documentType };
            arcRef.DocumentTypeCode = new DocumentTypeCodeType { Value = docTypeCode };

            docRefList.Add(arcRef);

            baseInvoiceUBL.AdditionalDocumentReference = docRefList.ToArray();
        }



        public void createDelivery(PartyType carrierParty, DateTime despatchDate)
        {
            var deliveryArr = new[]
            {
                new DeliveryType
                {
                   CarrierParty=carrierParty,
                   Despatch= new DespatchType {ActualDespatchDate=new ActualDespatchDateType { Value= despatchDate } }
                }
            };
            baseInvoiceUBL.Delivery = deliveryArr;
        }


        public void createPaymentMeans(string paymentMeansCode, DateTime paymentDate, string note)
        {
            var paymentMeans = new[]
            {
                new PaymentMeansType
                {
                    PaymentMeansCode = new PaymentMeansCodeType { Value=paymentMeansCode},
                    PaymentDueDate = new PaymentDueDateType { Value= paymentDate},
                    InstructionNote = new InstructionNoteType { Value= note}
                }
            };
            baseInvoiceUBL.PaymentMeans = paymentMeans;
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

            baseInvoiceUBL.Signature = signature;
        }


        public void SetSupplierParty(PartyType supplierParty)
        {
            var accountingSupplierParty = new SupplierPartyType //göndericinin fatura üzerindeki bilgileri
            {
                Party = supplierParty
            };
            baseInvoiceUBL.AccountingSupplierParty = accountingSupplierParty;
        }



        public void SetCustomerParty(PartyType customerParty)
        {
            var accountingCustomerParty = new CustomerPartyType //Alıcının fatura üzerindeki bilgileri
            {
                Party = customerParty
            };
            baseInvoiceUBL.AccountingCustomerParty = accountingCustomerParty;
        }



        public PartyType createParty(string partyName,string cityName,string telephone, string mail)
        {
            PartyType party = new PartyType();
            party.WebsiteURI = new WebsiteURIType { Value = "izibiz" };
            party.PartyName = new PartyNameType { Name = new NameType1 { Value = partyName } };
            party.PostalAddress = new AddressType
            {
                StreetName = new StreetNameType { Value = "exampleStreet" },
                BuildingName = new BuildingNameType { Value = "BuildingName" },
                BuildingNumber = new BuildingNumberType { Value = "BuildingNumber" },
                CitySubdivisionName = new CitySubdivisionNameType { Value = "exampleVsion" },
                CityName = new CityNameType { Value = cityName },
                PostalZone = new PostalZoneType { Value = "PostalZone" },
                Region = new RegionType { Value = "Region" },
                Country = new CountryType { Name = new NameType1 { Value = "Turkey" } }
            };

            party.Contact = new ContactType();
            party.Contact.Telephone = new TelephoneType { Value = telephone };
            party.Contact.Telefax = new TelefaxType { Value = "Telefax" };
            party.Contact.ElectronicMail = new ElectronicMailType { Value = mail };

            return party;
        }



        public void addPartyTaxSchemeOnParty(PartyType party)
        {
            party.PartyTaxScheme = new PartyTaxSchemeType
            {
                TaxScheme = new TaxSchemeType { Name = new NameType1 { Value = "exampleTax" } }
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
                switch (i) //en fazla 2 degerını alabılır... 3 deger yazılabılır
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
            baseInvoiceUBL.InvoiceLine = listInvLine.ToArray();
            baseInvoiceUBL.LineCountNumeric = new LineCountNumericType { Value = listInvLine.Count };
        }


        public void addInvoiceLine(string invId, string currencyID,string unitCode, decimal quantity, decimal lineExtensionAmount, decimal taxAmount,
            decimal taxableAmount, decimal percent, string itemName, decimal price)
        {

            InvoiceLineType invoiceLine = new InvoiceLineType
            {

                ID = new IDType { Value = invId },
                Note = new NoteType[] { new NoteType { Value = "Note" } },
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
            baseInvoiceUBL.TaxTotal = taxTotal;
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
            TaxSubtotalType taxSubtotal = new TaxSubtotalType
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

            foreach (var line in baseInvoiceUBL.InvoiceLine)
            {

                taxTotal.TaxAmount.Value += line.TaxTotal.TaxAmount.Value;
                taxTotal.TaxAmount.currencyID = line.TaxTotal.TaxAmount.currencyID;

                foreach (var tax in line.TaxTotal.TaxSubtotal)
                {

                    if (taxSubTotalList.Where(subtotal => subtotal.Percent.Value == tax.Percent.Value).FirstOrDefault() != null)  //percent varsa
                    {
                        taxSubtotal.TaxableAmount.Value += tax.TaxableAmount.Value;
                        taxSubtotal.TaxAmount.Value += line.TaxTotal.TaxAmount.Value;
                    }
                    else //yoksa ekle
                    {
                        TaxSubtotalType taxSubtotalNew = new TaxSubtotalType();
                        taxSubtotalNew.TaxableAmount = new TaxableAmountType { Value = tax.TaxableAmount.Value, currencyID = tax.TaxableAmount.currencyID };

                        taxSubtotalNew.TaxAmount = new TaxAmountType { Value = line.TaxTotal.TaxAmount.Value, currencyID = tax.TaxAmount.currencyID };
                        taxSubtotalNew.Percent = new PercentType1 { Value = tax.Percent.Value };
                        taxSubtotalNew.TaxCategory = new TaxCategoryType();
                        if (tax.Percent.Value == 0)
                        {
                            taxSubtotalNew.TaxCategory.TaxExemptionReasonCode = new TaxExemptionReasonCodeType { Value = "351" };
                            taxSubtotalNew.TaxCategory.TaxExemptionReason = new TaxExemptionReasonType { Value = "ReasonTaxExemtion" };//Reson Value hard code basıldı
                                                                                                                                       //istenırse formdan da alınabılır
                        }

                        taxSubtotalNew.TaxCategory.TaxScheme = new TaxSchemeType();
                        taxSubtotalNew.TaxCategory.TaxScheme.Name = new NameType1 { Value = nameof(EI.TaxType.KDV) };
                        taxSubtotalNew.TaxCategory.TaxScheme.TaxTypeCode = new TaxTypeCodeType { Value = "0015" };

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

            foreach (var line in baseInvoiceUBL.InvoiceLine)
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
            baseInvoiceUBL.LegalMonetaryTotal = legalMonetoryTotal;
        }

        public virtual void SetAllowanceCharge(AllowanceChargeType[] allowenceCharges)
        {
            baseInvoiceUBL.AllowanceCharge = allowenceCharges;
        }


        public virtual AllowanceChargeType[] CalculateAllowanceCharges()
        {
            AllowanceChargeType allowanceCharge = new AllowanceChargeType
            {
                Amount = new AmountType2 { Value = 0 },
                BaseAmount = new BaseAmountType { Value = 0 },
                ChargeIndicator = new ChargeIndicatorType { Value = false },

            };
            foreach (var item in baseInvoiceUBL.InvoiceLine)
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
