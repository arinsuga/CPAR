using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FluentValidation;
using FluentValidation.Mvc;
using FluentValidation.Attributes;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public class CPARStdrefDS
    {
        //Constructor
        public CPARStdrefDS() { } //End public CPARStdrefDS
        public List<CPARStdref_ListVM> getDatalist()
        {
            List<CPARStdref_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARStdref_infos
                           select new CPARStdref_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_RUID = tb.CPAR_RUID,
                               STDREF_RUID = tb.STDREF_RUID,
                               STDREF_ID = tb.STDREF_ID,
                               STDREF_NM = tb.STDREF_NM
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPARStdref_ListVM> getDatalist()
        public List<CPARStdref_ListVM> getDatalist_byCPAR_RUID(string id=null)
        {
            List<CPARStdref_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARStdref_infos
                           where tb.CPAR_RUID == id
                           select new CPARStdref_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_RUID = tb.CPAR_RUID,
                               STDREF_RUID = tb.STDREF_RUID,
                               STDREF_ID = tb.STDREF_ID,
                               STDREF_NM = tb.STDREF_NM
                           };
                vReturn = oQRY.OrderBy(fld=>fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPARStdref_ListVM> getDatalist()
        public List<CPARStdref_ListVM> getDatalist_notinCPAR_RUID(List<string> id)
        {
            List<CPARStdref_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARStdref_infos
                           select new CPARStdref_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_RUID = tb.CPAR_RUID,
                               STDREF_RUID = tb.STDREF_RUID,
                               STDREF_ID = tb.STDREF_ID,
                               STDREF_NM = tb.STDREF_NM
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPARStdref_ListVM> getDatalist()

        public CPARStdref_DetailVM getData(string id = null)
        {
            CPARStdref_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARStdref_infos
                           where tb.RUID == id
                           select new CPARStdref_DetailVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_RUID = tb.CPAR_RUID,
                               STDREF_RUID = tb.STDREF_RUID,
                               STDREF_ID = tb.STDREF_ID,
                               STDREF_NM = tb.STDREF_NM
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public CPARStdref_DetailVM getData(string id = null)
    } //End public class CPARStdrefDS
} //End namespace APPBASE.Models

