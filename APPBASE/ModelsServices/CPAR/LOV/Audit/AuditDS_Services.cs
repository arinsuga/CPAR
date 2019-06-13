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
    public class AuditDS
    {
        //Constructor
        public AuditDS() { } //End public AuditDS
        public List<Audit_ListVM> getDatalist()
        {
            List<Audit_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Audit_infos
                           select new Audit_ListVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM,
                               DEPT_NM = tb.DEPT_NM
                           };
                vReturn = oQRY.OrderBy(fld => fld.DEPT_NM).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Audit_ListVM> getDatalist()
        public Audit_DetailVM getData(string id = null)
        {
            Audit_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Audit_infos
                           where tb.RUID == id
                           select new Audit_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM,
                               DEPT_RUID = tb.DEPT_RUID,
                               DEPT_NM = tb.DEPT_NM
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Audit_DetailVM getData(string id = null)
        public List<Audit_LookupVM> getDatalist_lookup()
        {
            List<Audit_LookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Audit_infos
                           select new Audit_LookupVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM,
                               DEPT_NM = tb.DEPT_NM
                           };
                vReturn = oQRY.OrderBy(fld=>fld.DEPT_NM).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Audit_ListVM> getDatalist()

        //Check Exists
        public Boolean isExists_LOV_ID(string id = null)
        {
            Boolean vReturn = false;


            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Audit_infos
                            where tb.LOV_ID == id
                            select new { LOV_ID = tb.LOV_ID }).ToList();
                if (oQRY.Count > 0) { vReturn = true; }
            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isExists_LOV_ID(string id = null)
        //Check Is Used by Complain
        public Boolean isUSEDBY_CPAR(string id = null)
        {
            Boolean vReturn = false;

            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Audit_infos
                            where tb.RUID == id
                            select new { ISUSEDBY_CPAR = tb.ISUSEDBY_CPAR }).SingleOrDefault();
                if (oQRY.ISUSEDBY_CPAR == valFLAG.FLAG_YES) { vReturn = true; } //End if (oQRY.ISUSEDBY_CPAR == valFLAG.FLAG_YES)
            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isUSEDBY_CPAR(string id = null)

    } //End public class AuditDS
} //End namespace APPBASE.Models

