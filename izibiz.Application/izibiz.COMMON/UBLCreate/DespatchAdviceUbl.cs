using izibiz.COMMON.Ubl_Tr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UblDespatchAdvice;

namespace izibiz.COMMON.UBLCreate
{
    public class DespatchAdviceUbl
    {


        public DespatchAdviceType baseDespatchUbl { get; }
        private List<DespatchLineType> despatchLines = new List<DespatchLineType>();



        public DespatchAdviceUbl(int lineCount, DateTime despatchDate, DateTime despatchTime, string orderId, DateTime orderDate)
        {
            baseDespatchUbl = new DespatchAdviceType();

            createDespatchHeader(despatchDate, despatchTime, lineCount);
            createOrderReference(orderId, orderDate);
            createDocumentReference();
            createSignature();

        }




        /// <summary>
        ///  Sevk irsaliyesi (Despatch Advice) UBL'inin ilk alanlarını oluşturma
        /// </summary>
        /// <returns>UBL'in Alanları</returns>
        public void createDespatchHeader(DateTime despatchDate, DateTime despatchTime, int lineNumber)
        {
          
            baseDespatchUbl.UBLVersionID = new UBLVersionIDType { Value = "2.1" };  // uluslararası fatura standardı 2.1
            baseDespatchUbl.CustomizationID = new CustomizationIDType { Value = "TR1.2.1" };// GİB UBLTR olarak isimlendirdiği Türkiye'ye özgü 1.2.1 eİrsaliye formatını kullanıyor.
            baseDespatchUbl.ProfileID = new ProfileIDType { Value = "TEMELIRSALIYE" }; //tek Senaryo var
            baseDespatchUbl.ID = new IDType { Value = DateTime.Now.ToString("MM/dd/yyyy-HH/mm/ss") };   //Sevk irsaliyesine Ait Numara  
            baseDespatchUbl.CopyIndicator = new CopyIndicatorType { Value = false }; // Sevk İrsaliyesinin Asıl veya Suret Bilgisi 
            baseDespatchUbl.UUID = new UUIDType { Value = Guid.NewGuid().ToString() }; //Sevk İrsaliyesinin Evrensel Tekliğini Sağlayan Numara 
            baseDespatchUbl.IssueDate = new IssueDateType { Value = despatchDate };  //Sevk İrsaliyesinin Düzenleme Tarihi
            baseDespatchUbl.IssueTime = new IssueTimeType { Value = despatchTime }; //Sevk İrsaliyesinin Düzenleme Zamanı 
            baseDespatchUbl.DespatchAdviceTypeCode = new DespatchAdviceTypeCodeType { Value = "SEVK" }; //Sevk İrsaliyesinin Tip Kodu 

            baseDespatchUbl.Note = new[]  //Sevk İrsaliyesi İle İlgili Genel Açıklamalar 
            {
                    new NoteType {Value="Mallar teslim edildi.." }
            };
            baseDespatchUbl.LineCountNumeric = new LineCountNumericType { Value = lineNumber }; //Sevk İrsaliyesi Kalem Sayısı  
        }




        /// <summary>
        ///  Sevk irsaliyesi (Despatch Advice) UBL'inin OrderReference alanını oluşturma.Birden 
        /// fazla OrderReference alanı oluşturulabilir.
        /// </summary>
        /// <returns>OrderReference Alanı</returns>
        public void createOrderReference(string orderId, DateTime orderDate)
        {
            baseDespatchUbl.OrderReference = new[]  //Sipariş Bilgileri                 
            {
                new OrderReferenceType
                {
                    ID =new IDType {Value= orderId },
                    IssueDate =new IssueDateType {Value= orderDate },//
                }
            };
        }


        /// <summary>
        ///  Sevk irsaliyesi (Despatch Advice) UBL'inin AdditionalDocumentReference alanını oluşturma.
        /// Birden fazla DocumentReference alanı oluşturulabilir.
        /// </summary>
        /// <returns>AdditionalDocumentReference Alanı</returns>
        public void createDocumentReference()
        {
            baseDespatchUbl.AdditionalDocumentReference = new[]
            {
                new DocumentReferenceType
                {
                    ID= new IDType { Value = Guid.NewGuid().ToString() },
                    IssueDate = baseDespatchUbl.IssueDate,
                    DocumentType = new DocumentTypeType { Value = nameof(EI.DocumentType.XSLT) },
                    Attachment = new AttachmentType
                    {
                       EmbeddedDocumentBinaryObject= new EmbeddedDocumentBinaryObjectType
                       {
                            characterSetCode = "UTF-8",
                            encodingCode = "Base64",
                            filename = baseDespatchUbl.ID.Value.ToString() + ".xslt",
                            mimeCode = "application/xml",
                            Value = Convert.FromBase64String(Xslt.xsltGibDespatch)
                       }
                    }
                }
            };
        }


        /// <summary>
        ///  Sevk irsaliyesi (Despatch Advice) UBL'inin Signature alanını oluşturma
        /// </summary>
        /// <returns>Signature alanı</returns>
        public void createSignature()
        {
            baseDespatchUbl.Signature = new[]  //Elektronik Mali Mühür ve/veya Elektronik İmza ile Bunlara Ait Sertifika Bilgileri
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
                            URI = new URIType { Value = "#Signature_DMY20190711153821v" }
                        }
                    }
                }
            };
        }



        public PartyType createParty(string partyName, string cityName, string telephone, string mail)
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



        ///// <summary>
        /////  Sevk irsaliyesi (Despatch Advice) UBL'inin DespatchSupplierParty alanını oluşturma
        ///// </summary>
        ///// <returns>DespatchSupplierParty Alanı</returns>
        //public SupplierPartyType GetSupplierParty(string vknTckn, string parametre)
        //{
        //    var despatchSupplierParty = new SupplierPartyType  //Sevk İrsaliyesindeki Malların Sevkiyatını Sağlayan Tarafın Bilgileri
        //    {
        //        Party = new PartyType
        //        {
        //            WebsiteURI = new WebsiteURIType { Value = "web sitesi" },
        //            PartyIdentification = new[]
        //           {
        //                new PartyIdentificationType
        //                {
        //                    ID= new IDType {schemeID=parametre,Value=vknTckn }
        //                }
        //           },
        //            // Sevkiyatı sağlayan tarafın VKN si yazılırsa bu alan kullanılmak zorundadır.
        //            PartyName = new PartyNameType
        //            {
        //                Name = new NameType1 { Value = "Kurum Adı" }
        //            },
        //            PostalAddress = new AddressType
        //            {
        //                ID = new IDType { Value = "123" },
        //                StreetName = new StreetNameType { Value = "Cadde" },
        //                BuildingName = new BuildingNameType { Value = "Bina" },
        //                BuildingNumber = new BuildingNumberType { Value = "Bina No" },
        //                CitySubdivisionName = new CitySubdivisionNameType { Value = "İlçe/Semt" },
        //                CityName = new CityNameType { Value = "Sehir" },
        //                PostalZone = new PostalZoneType { Value = "Posta Kodu" },
        //                Country = new CountryType { Name = new NameType1 { Value = "Ülke" } }
        //            },
        //            PhysicalLocation = new LocationType1
        //            {
        //                ID = new IDType { Value = "Depo Şube" },
        //                Address = new AddressType
        //                {
        //                    ID = new IDType { Value = "12345" },
        //                    StreetName = new StreetNameType { Value = "Cadde" },
        //                    BuildingName = new BuildingNameType { Value = "Bina" },
        //                    BuildingNumber = new BuildingNumberType { Value = "Bina no" },
        //                    CitySubdivisionName = new CitySubdivisionNameType { Value = "İlçe/Semt" },
        //                    CityName = new CityNameType { Value = "Sehir" },
        //                    PostalZone = new PostalZoneType { Value = "Posta Kodu" },
        //                    Country = new CountryType
        //                    {
        //                        Name = new NameType1 { Value = "Ülke" }
        //                    }
        //                }
        //            },
        //            PartyTaxScheme = new PartyTaxSchemeType
        //            {
        //                TaxScheme = new TaxSchemeType { Name = new NameType1 { Value = "Vergi Dairesi" } }
        //            },
        //            Contact = new ContactType
        //            {
        //                Telephone = new TelephoneType { Value = "Telefon" },
        //                Telefax = new TelefaxType { Value = "Fax" },
        //                ElectronicMail = new ElectronicMailType { Value = "Mail" }
        //            },
        //            // Sevkiyatı sağlayan tarafın TCKN si yazılırsa bu alan kullanılmak zorundadır.
        //            Person = new PersonType
        //            {
        //                FirstName = new FirstNameType { Value = "İsim" },
        //                FamilyName = new FamilyNameType { Value = "Soyisim" },
        //            }
        //        }
        //    };
        //    return despatchSupplierParty;
        //}


        ///// <summary>
        /////  Sevk irsaliyesi (Despatch Advice) UBL'inin DeliveryCustomerParty alanını oluşturma
        ///// </summary>
        ///// <returns>DeliveryCustomerParty Alanı</returns>
        //public CustomerPartyType GetCustomerParty(string vknTckn, string parametre)
        //{
        //    var deliveryCustomerParty = new CustomerPartyType  //Sevk İrsaliyesindeki Malların Sevkiyatını Teslim Alan Tarafın Bilgileri
        //    {
        //        Party = new PartyType
        //        {
        //            WebsiteURI = new WebsiteURIType { Value = "web sitesi" },
        //            PartyIdentification = new[]
        //          {
        //                new PartyIdentificationType
        //                {
        //                    ID= new IDType {schemeID=parametre,Value=vknTckn }
        //                },
        //                new PartyIdentificationType
        //                {
        //                    ID=new IDType {schemeID="MUSTERINO",Value="1123" }
        //                }
        //          },
        //            // Sevkiyatı alan tarafın VKN si yazılırsa bu alan kullanılmak zorundadır.
        //            PartyName = new PartyNameType
        //            {
        //                Name = new NameType1 { Value = "Kurum Adı" }
        //            },
        //            PostalAddress = new AddressType
        //            {
        //                ID = new IDType { Value = "123" },
        //                StreetName = new StreetNameType { Value = "Cadde" },
        //                BuildingName = new BuildingNameType { Value = "Bina" },
        //                BuildingNumber = new BuildingNumberType { Value = "Bina No" },
        //                CitySubdivisionName = new CitySubdivisionNameType { Value = "İlçe/Semt" },
        //                CityName = new CityNameType { Value = "Şehir" },
        //                PostalZone = new PostalZoneType { Value = "Posta Kodu" },
        //                Country = new CountryType { Name = new NameType1 { Value = "Ülke" } }
        //            },
        //            PhysicalLocation = new LocationType1
        //            {
        //                ID = new IDType { Value = "Depo Şube" },
        //                Address = new AddressType
        //                {
        //                    ID = new IDType { Value = "111" },
        //                    StreetName = new StreetNameType { Value = "Cadde" },
        //                    BuildingName = new BuildingNameType { Value = "Bina" },
        //                    BuildingNumber = new BuildingNumberType { Value = "Bina no" },
        //                    CitySubdivisionName = new CitySubdivisionNameType { Value = "İlçe/Semt" },
        //                    CityName = new CityNameType { Value = "Sehir" },
        //                    PostalZone = new PostalZoneType { Value = "Posta Kodu" },
        //                    Country = new CountryType
        //                    {
        //                        Name = new NameType1 { Value = "Ülke" }
        //                    }
        //                }
        //            },
        //            PartyTaxScheme = new PartyTaxSchemeType
        //            {
        //                TaxScheme = new TaxSchemeType { Name = new NameType1 { Value = "Vergi Dairesi" } }
        //            },
        //            Contact = new ContactType
        //            {
        //                Telephone = new TelephoneType { Value = "Telefon" },
        //                Telefax = new TelefaxType { Value = "Fax" },
        //                ElectronicMail = new ElectronicMailType { Value = "Mail" }
        //            },
        //            // Sevkiyatı alan tarafın TCKN si yazılırsa bu alan kullanılmak zorundadır.
        //            Person = new PersonType
        //            {
        //                FirstName = new FirstNameType { Value = "İsim" },
        //                FamilyName = new FamilyNameType { Value = "Soyisim" },
        //            }
        //        }
        //    };
        //    return deliveryCustomerParty;
        //}



        public void SetSupplierParty(PartyType supplierParty)
        {
            var despatchSupplierParty = new SupplierPartyType //göndericinin fatura üzerindeki bilgileri
            {
                Party = supplierParty
            };
            baseDespatchUbl.DespatchSupplierParty = despatchSupplierParty;
        }



        public void SetCustomerParty(PartyType customerParty)
        {
            var despatchCustomerParty = new CustomerPartyType //Alıcının fatura üzerindeki bilgileri
            {
                Party = customerParty
            };
            baseDespatchUbl.DeliveryCustomerParty = despatchCustomerParty;
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






        /// <summary>
        ///  Sevk irsaliyesi (Despatch Advice) UBL'inin Shipment alanını oluşturma
        /// </summary>
        /// <returns>Shipment Alanı</returns>
        public void createShipment(decimal totalAmount, string plate, string orderId, string driverName, string driverTc, DateTime consignmentDate, DateTime consignmentTime,
            string partyShemeType, string carrierVknTckn)

        {
            var shipment = new ShipmentType //Gönderi Hakkındaki Bilgiler
            {
                ID = new IDType { Value = orderId },  // Kargo numarası girilir.
                GoodsItem = new[] { new GoodsItemType { ValueAmount = new ValueAmountType { currencyID = "TRY", Value = totalAmount } } },
                ShipmentStage = new[]  // Gönderinin hangi aşamada olduğu bilgisi girilir. Ayrıca taşıyıcı (plaka, şoför) gibi detay bilgiler girilir.
                   {
                    new ShipmentStageType
                    {
                        TransportMeans=new TransportMeansType { RoadTransport=new RoadTransportType //Taşımada kullanılan vasıta hakkında bilgi girilir
                         {
                            LicensePlateID =new LicensePlateIDType {schemeID="PLAKA", Value=plate } //  Plaka numarası girilir. 
                         }
                        },
                     DriverPerson =new[]  // Şoför bilgileri girilir
                        {
                            new PersonType
                            {
                                FirstName=new FirstNameType {Value=driverName },
                                FamilyName=new FamilyNameType {Value="" },
                                Title=new TitleType {Value="Şoför" },
                                NationalityID=new NationalityIDType {Value=driverTc }
                            }
                        }
                }
               },
                Delivery = new DeliveryType
                {
                    CarrierParty = new PartyType
                    {
                        PartyIdentification = new[]
                           {
                            new PartyIdentificationType
                            {
                                ID=new IDType { schemeID=partyShemeType, Value=carrierVknTckn }
                            }
                           },
                        PartyName = new PartyNameType
                        {
                            Name = new NameType1 { Value = "Kurum Adı" }
                        },
                        PostalAddress = new AddressType
                        {
                            CitySubdivisionName = new CitySubdivisionNameType { Value = "İlçe/Semt" },
                            CityName = new CityNameType { Value = "Şehir" },
                            Country = new CountryType { Name = new NameType1 { Value = "Ülke" } }
                        }
                    },
                    Despatch = new DespatchType
                    {
                        ActualDespatchDate = new ActualDespatchDateType { Value = consignmentDate }, //Gerçekleşen gönderim tarihi girilir. (Fiili Sevk Tarihi) 
                        ActualDespatchTime = new ActualDespatchTimeType { Value = consignmentTime } //Gerçekleşen gönderim zamanı girilir. (Fiili Sevk Zamanı) 
                    }
                },
                TransportHandlingUnit = new[]  //Taşıma üniteleri bilgisi girilir
                   {
                    new TransportHandlingUnitType
                    {
                        TransportEquipment=new[]
                        {
                            new TransportEquipmentType
                            {
                                ID=new IDType {schemeID="DORSEPLAKA",Value="06DR4088" }
                            }
                         }
                     }
                }
            };
            baseDespatchUbl.Shipment = shipment;
        }


        ///// <summary>
        /////  Sevk irsaliyesi (Despatch Advice) UBL'inin DespatchLine alanlarını oluşturma.Birden fazla 
        ///// DespatchLine alanı oluşturulabilir.
        ///// </summary>
        ///// <returns>DespatchLine Listesi</returns>
        //public DespatchLineType[] GetDespatchLine(int kalemSayisi)
        //{

        //    List<DespatchLineType> list = new List<DespatchLineType>();

        //    for (int i = 1; i <= kalemSayisi; i++)
        //    {

        //        DespatchLineType despatchLine = new DespatchLineType()  //Sevk İrsaliyesindeki Kalemlerin Bilgileri
        //        {

        //            ID = new IDType { Value = i.ToString() },  //İrsaliye kalemi numarası girilir. 
        //            Note = new[] { new NoteType { Value = "" } },  // Kalem ile ilgili açıklama girilir. 
        //            DeliveredQuantity = new DeliveredQuantityType { unitCode = "C62", Value = 10 },  // Gönderimi gerçekleştirilen mal adedi girilir.
        //            OrderLineReference = new OrderLineReferenceType { LineID = new LineIDType { Value = i.ToString() } }, //Siparişin kalemlerine referans atmak için kullanılır. 
        //            Item = new ItemType  //Mal / hizmet bilgisi girilir.
        //            {
        //                Name = new NameType1 { Value = "Notebook Bilgisayar" }, //Mal/hizmet adı serbest metin olarak girilir
        //                SellersItemIdentification = new ItemIdentificationType
        //                {
        //                    ID = new IDType { Value = "PNC1234" } //Satıcının mal/hizmete verdiği tanımlama bilgisi girilir.

        //                }
        //            },
        //            Shipment = new[]
        //            {
        //                new ShipmentType
        //                {
        //                    ID= new IDType {Value="" },
        //                    GoodsItem=new[]
        //                    {
        //                        new GoodsItemType
        //                        {
        //                            InvoiceLine=new[]
        //                            {
        //                               new InvoiceLineType
        //                               {
        //                                    ID= new IDType {Value="" },
        //                                    InvoicedQuantity=new InvoicedQuantityType {Value=0 },
        //                                    LineExtensionAmount=new LineExtensionAmountType { currencyID="TRY", Value=10*2000 },
        //                                    Item=new ItemType
        //                                    {
        //                                        Name=new NameType1 {Value="Notebook Bilgisayar" }
        //                                    },
        //                                    Price=new PriceType
        //                                    {
        //                                        PriceAmount=new PriceAmountType {currencyID="TRY",Value=2000 }
        //                                    }
        //                               }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        };
        //        list.Add(despatchLine);
        //    }
        //    return list.ToArray();
        //}



        public void addDespatchLine(string indexCount, string unitCode, int quantity, string itemName,decimal unitPrice,string currencyType)
        {

            DespatchLineType despatchLine = new DespatchLineType()  //Sevk İrsaliyesindeki Kalemlerin Bilgileri
            {

                ID = new IDType { Value = indexCount },  //İrsaliye kalemi numarası girilir. 
                Note = new[] { new NoteType { Value = "" } },  // Kalem ile ilgili açıklama girilir. 
                DeliveredQuantity = new DeliveredQuantityType { unitCode = unitCode, Value = quantity },  // Gönderimi gerçekleştirilen mal adedi girilir.
                OrderLineReference = new OrderLineReferenceType { LineID = new LineIDType { Value = indexCount } }, //Siparişin kalemlerine referans atmak için kullanılır. 
                Item = new ItemType  //Mal / hizmet bilgisi girilir.
                {
                    Name = new NameType1 { Value = itemName }, //Mal/hizmet adı serbest metin olarak girilir
                    SellersItemIdentification = new ItemIdentificationType
                    {
                        ID = new IDType { Value = "PNC1234" } //Satıcının mal/hizmete verdiği tanımlama bilgisi girilir.
                    }
                },
                Shipment = new[]
                {
                        new ShipmentType
                        {
                            ID= new IDType {Value="" },
                            GoodsItem=new[]
                            {
                                new GoodsItemType
                                {
                                    InvoiceLine=new[]
                                    {
                                       new InvoiceLineType
                                       {
                                            ID= new IDType {Value="" },
                                            InvoicedQuantity=new InvoicedQuantityType {Value=quantity },
                                            LineExtensionAmount=new LineExtensionAmountType { currencyID=currencyType, Value=quantity*unitPrice },
                                            Item=new ItemType
                                            {
                                                Name=new NameType1 {Value="" }
                                            },
                                            Price=new PriceType
                                            {
                                                PriceAmount=new PriceAmountType {currencyID=currencyType,Value=unitPrice }
                                            }
                                       }
                                    }
                                }
                            }
                        }
                    }
            };
            despatchLines.Add(despatchLine);
        }



        public void setDespatchLines()
        {
            baseDespatchUbl.DespatchLine = despatchLines.ToArray();
        }




    }
}
