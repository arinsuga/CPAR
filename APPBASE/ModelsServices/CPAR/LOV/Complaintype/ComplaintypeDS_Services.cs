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
    public class ComplaintypeDS
    {
        //Constructor
        public ComplaintypeDS() { } //End public ComplaintypeDS
        public List<Complaintype_ListVM> getDatalist()
        {
            List<Complaintype_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Complaintype_infos
                           select new Complaintype_ListVM
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
        } //End public List<Complaintype_ListVM> getDatalist()
        public Complaintype_DetailVM getData(string id = null)
        {
            Complaintype_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Complaintype_infos
                           where tb.RUID == id
                           select new Complaintype_DetailVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Complaintype_DetailVM getData(string id = null)
    } //End public class ComplaintypeDS
} //End namespace APPBASE.Models

