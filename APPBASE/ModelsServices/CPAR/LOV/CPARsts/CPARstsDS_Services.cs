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
    public class CPARstsDS
    {
        //Constructor
        public CPARstsDS() { } //End public CPARstsDS
        public List<CPARsts_ListVM> getDatalist()
        {
            List<CPARsts_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARstss
                           select new CPARsts_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM
                           };
                vReturn = oQRY.OrderBy(fld=>fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPARsts_ListVM> getDatalist()
        public CPARsts_DetailVM getData(string id = null)
        {
            CPARsts_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARstss
                           where tb.RUID == id
                           select new CPARsts_DetailVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM
                           };
                oReturn = oQRY.OrderBy(fld => fld.RSEQNO).SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public CPARsts_DetailVM getData(string id = null)
    } //End public class CPARstsDS
} //End namespace APPBASE.Models

