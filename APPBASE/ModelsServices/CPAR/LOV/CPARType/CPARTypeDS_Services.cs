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
    public class CPARTypeDS
    {
        //Constructor
        public CPARTypeDS() { } //End public CPARTypeDS
        public List<CPARType_ListVM> getDatalist()
        {
            List<CPARType_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARTypes
                           select new CPARType_ListVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPARType_ListVM> getDatalist()
        public CPARType_DetailVM getData(string id = null)
        {
            CPARType_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARTypes
                           where tb.RUID == id
                           select new CPARType_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public CPARType_DetailVM getData(string id = null)
    } //End public class CPARTypeDS
} //End namespace APPBASE.Models

