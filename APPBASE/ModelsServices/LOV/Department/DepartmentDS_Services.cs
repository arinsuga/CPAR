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
    public class DepartmentDS
    {
        //Custom Access Control
        private string sROLE_RUID = "";
        private string sRES_RUID = "";
        private string sDEPT_RUID = "";

        //Constructor
        public DepartmentDS() {
            this.sROLE_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            this.sRES_RUID = hlpConfig.SessionInfo.getAppUsrRES_RUID();
            this.sDEPT_RUID = hlpConfig.SessionInfo.getAppUsrDEPT_RUID();
        } //End public DepartmentDS
        public List<Department_ListVM> getDatalist()
        {
            List<Department_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Department_infos
                           select new Department_ListVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM,
                               ISUSEDBY_RES = tb.ISUSEDBY_RES
                           };
                vReturn = oQRY.OrderBy(fld=>fld.LOV_NM).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Department_ListVM> getDatalist()
        public Department_DetailVM getData(string id = null)
        {
            Department_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Department_infos
                           where tb.RUID == id
                           select new Department_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM,
                               ISUSEDBY_RES = tb.ISUSEDBY_RES
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Department_DetailVM getData(string id = null)

        //Check Exists
        public Boolean isExists_LOV_ID(string id = null)
        {
            Boolean vReturn = false;


            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Department_infos
                            where tb.LOV_ID == id
                            select new { LOV_ID = tb.LOV_ID}).ToList();
                if (oQRY.Count > 0) { vReturn = true; }
            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isExists_LOV_ID(string id = null)
        //Check Is Used by RES
        public Boolean isUSEDBY_RES(string id = null)
        {
            Boolean vReturn = false;

            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Department_infos
                            where tb.RUID == id
                            select new { ISUSEDBY_RES = tb.ISUSEDBY_RES }).SingleOrDefault();
                if (oQRY.ISUSEDBY_RES == valFLAG.FLAG_YES) { vReturn = true; } //End if (oQRY.ISUSEDBY_RES == valFLAG.FLAG_YES)
            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isUSEDBY_RES(string id = null)
        //Check Is Used by AUDIT
        public Boolean isUSEDBY_AUDIT(string id = null)
        {
            Boolean vReturn = false;

            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Department_infos
                            where tb.RUID == id
                            select new { ISUSEDBY_AUDIT = tb.ISUSEDBY_AUDIT }).SingleOrDefault();
                if (oQRY.ISUSEDBY_AUDIT == valFLAG.FLAG_YES) { vReturn = true; } //End if (oQRY.ISUSEDBY_AUDIT == valFLAG.FLAG_YES)
            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isUSEDBY_AUDIT(string id = null)
    } //End public class DepartmentDS
} //End namespace APPBASE.Models

