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
    public class ProjectDS
    {
        //Custom Access Control
        private string sROLE_RUID = "";
        private string sRES_RUID = "";
        private string sDEPT_RUID = "";

        //Constructor
        public ProjectDS() {
            this.sROLE_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            this.sRES_RUID = hlpConfig.SessionInfo.getAppUsrRES_RUID();
            this.sDEPT_RUID = hlpConfig.SessionInfo.getAppUsrDEPT_RUID();
        } //End public ProjectDS
        public List<Project_ListVM> getDatalist()
        {
            List<Project_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Project_infos
                           select new Project_ListVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               PROJ_ID = tb.PROJ_ID,
                               PROJ_NM = tb.PROJ_NM,
                               PROJ_STS = tb.PROJ_STS,
                               PROJ_STS_ID = tb.PROJ_STS_ID,
                               PROJ_STS_NM = tb.PROJ_STS_NM,
                               CLIENT_RUID = tb.CLIENT_RUID
                           };
                vReturn = oQRY.OrderBy(fld=>fld.PROJ_NM).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Project_ListVM> getDatalist()
        public Project_DetailVM getData(string id = null)
        {
            Project_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Project_infos
                           where tb.RUID == id
                           select new Project_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               PROJ_ID = tb.PROJ_ID,
                               PROJ_NM = tb.PROJ_NM,
                               PROJ_STS = tb.PROJ_STS,
                               PROJ_STS_ID = tb.PROJ_STS_ID,
                               PROJ_STS_NM = tb.PROJ_STS_NM,
                               CLIENT_RUID = tb.CLIENT_RUID
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Project_DetailVM getData(string id = null)

        //Check Exists
        public Boolean isExists_PROJ_ID(string id = null)
        {
            Boolean vReturn = false;


            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Project_infos
                            where tb.PROJ_ID == id
                            select new { PROJ_ID = tb.PROJ_ID }).ToList();
                if (oQRY.Count > 0) { vReturn = true; }
            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isExists_PROJ_ID(string id = null)
        //Check Is Used by Complain
        public Boolean isUSEDBY_COMPLAIN(string id = null)
        {
            Boolean vReturn = false;

            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Project_infos
                            where tb.RUID == id
                            select new { ISUSEDBY_COMPLAIN = tb.ISUSEDBY_COMPLAIN }).SingleOrDefault();
                if (oQRY.ISUSEDBY_COMPLAIN == valFLAG.FLAG_YES) { vReturn = true; } //End if (oQRY.ISUSEDBY_COMPLAIN == valFLAG.FLAG_YES)
            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isUSEDBY_COMPLAIN(string id = null)
    } //End public class ProjectDS
} //End namespace APPBASE.Models

