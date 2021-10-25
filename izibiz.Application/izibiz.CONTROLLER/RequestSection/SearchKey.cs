﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using izibiz.SERVICES.serviceOib;
using izibiz.SERVICES.serviceDespatch;
using izibiz.SERVICES.serviceSmm;
using izibiz.SERVICES.serviceCreditNote;

namespace izibiz.CONTROLLER.RequestSection
{
   public class SearchKey
    {

        public static GetInvoiceRequestINVOICE_SEARCH_KEY getSearchKeyInvoice;
        public static GetInvoiceWithTypeRequestINVOICE_SEARCH_KEY getSearchKeyInvoiceWithType;
        public static GetDespatchAdviceRequestSEARCH_KEY getSearchKeyDespatch;
        public static GetSmmRequestSMM_SEARCH_KEY GetSearchKeySmm;
        public static GetCreditNoteRequestCREDITNOTE_SEARCH_KEY GetSearchKeyCreditNotes;

       

        public static void createInvoiceSearchKey()
        {
            getSearchKeyInvoice = new GetInvoiceRequestINVOICE_SEARCH_KEY() //default degerler ısterse degısebılır
            {
                LIMIT = 10,
                LIMITSpecified =true,
                READ_INCLUDED = true,
                READ_INCLUDEDSpecified = true,              
            };
        }

        

        public static void createInvoiceSearchKeyGetInvoiceWithType()
        {
            getSearchKeyInvoiceWithType = new GetInvoiceWithTypeRequestINVOICE_SEARCH_KEY() //default degerler ısterse degısebılır
            {
                LIMIT = 10,
                LIMITSpecified = true,
                READ_INCLUDED = true,
                READ_INCLUDEDSpecified = true,          
            };
        }


        public static void createDespatchSearchKey()
        {
            getSearchKeyDespatch = new GetDespatchAdviceRequestSEARCH_KEY() //default degerler ısterse degısebılır
            {
                LIMIT = 10,
                LIMITSpecified = true,
                READ_INCLUDED = true,
                READ_INCLUDEDSpecified = true,
            };
        }

        public static void createSmmSearchKey()
        {
            GetSearchKeySmm = new GetSmmRequestSMM_SEARCH_KEY() //default degerler ısterse degısebılır
            {
                LIMIT = 10,
                LIMITSpecified = true,
                READ_INCLUDED = SERVICES.serviceSmm.FLAG_VALUE.Y,
                READ_INCLUDEDSpecified = true,
            };
        }
        public static void createCreditNoteSearchKey()
        {
            GetSearchKeyCreditNotes = new GetCreditNoteRequestCREDITNOTE_SEARCH_KEY() //default degerler ısterse degısebılır
            {
                LIMIT = 10,
                LIMITSpecified = true,
                READ_INCLUDED = SERVICES.serviceCreditNote.FLAG_VALUE.N,
                READ_INCLUDEDSpecified = true,
                UUID = "ACFBC9C4-1F83-D7A3-A579-E8B59C67581B",//müstahsil servisinde uuid zorunludur.
                //burada örnek bir uuid verilmiştir, siz hangi müstahsili getirmek istiyorsanız müstahsile ait uuid bilgisini parametre gecmeniz
                //gerekmektedir.
            };
        }

    }
}
