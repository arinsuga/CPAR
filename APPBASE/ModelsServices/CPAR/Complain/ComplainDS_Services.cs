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
    public class ComplainDS
    {
        //Custom Access Control
        private string sROLE_RUID = "";
        private string sRES_RUID = "";
        private string sDEPT_RUID = "";
        private string CPAR_TYPE = "";

        //Constructor
        public ComplainDS() {
            this.sROLE_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            this.sRES_RUID = hlpConfig.SessionInfo.getAppUsrRES_RUID();
            this.sDEPT_RUID = hlpConfig.SessionInfo.getAppUsrDEPT_RUID();
        } //End public ComplainDS
        public List<Complain_ListVM> getDatalist()
        {
            List<Complain_ListVM> vReturn;

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Complain_infos
                           select new Complain_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               COMPLAIN_STS = tb.COMPLAIN_STS,
                               COMPLAIN_STS_ID = tb.COMPLAIN_STS_ID,
                               COMPLAIN_STS_NM = tb.COMPLAIN_STS_NM,
                               COMPLAIN_ID = tb.COMPLAIN_ID,
                               COMPLAIN_NM = tb.COMPLAIN_NM,
                               COMPLAIN_TYPE = tb.COMPLAIN_TYPE,
                               COMPLAIN_TYPE_ID = tb.COMPLAIN_TYPE_ID,
                               COMPLAIN_TYPE_NM = tb.COMPLAIN_TYPE_NM,
                               COMPLAIN_SUBTYPE = tb.COMPLAIN_SUBTYPE,
                               DESCRIPTION = tb.DESCRIPTION,
                               ISSUED_DT = tb.ISSUED_DT,

                               RECIPIENT_RUID = tb.RECIPIENT_RUID,
                               //RECIPIENT_NM = tb.RECIPIENT_NM,
                               //RECIPIENT_DEPTRUID = tb.RECIPIENT_DEPTRUID,
                               //RECIPIENT_DEPTID = tb.RECIPIENT_DEPTID,
                               //RECIPIENT_DEPTNM = tb.RECIPIENT_DEPTNM,
                               PIC_RUID = tb.PIC_RUID,
                               PIC_NM = tb.PIC_NM,
                               PIC_DEPTRUID = tb.PIC_DEPTRUID,
                               PIC_DEPTID = tb.PIC_DEPTID,
                               PIC_DEPTNM = tb.PIC_DEPTNM,

                               PROJ_RUID = tb.PROJ_RUID,
                               PROJ_ID = tb.PROJ_ID,
                               PROJ_NM = tb.PROJ_NM,
                               CLIENT_RUID = tb.CLIENT_RUID,
                               IS_CPAR = tb.IS_CPAR
                           };

                //Access Control
                //#disabled by changerequest#1
                //if ((this.sROLE_RUID != valFLAG.FLAG_ROLE_SYSADMIN) &&
                //    (this.sROLE_RUID != valFLAG.FLAG_ROLE_CPAR_ADMIN) &&
                //    (this.sROLE_RUID != valFLAG.FLAG_ROLE_PJXADMIN)) {
                //        oQRY = oQRY.Where(fld => fld.RECIPIENT_RUID == sRES_RUID ||
                //                          fld.PIC_DEPTRUID == sDEPT_RUID);
                //} //End if ((this.sROLE_RUID != valFLAG.FLAG_ROLE_SYSADMIN) &&
                

                vReturn = oQRY.OrderByDescending(fld=>fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Complain_ListVM> getDatalist()
        public Complain_DetailVM getData(string id = null)
        {
            Complain_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Complain_infos
                           where tb.RUID == id
                           select new Complain_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               COMPLAIN_STS = tb.COMPLAIN_STS,
                               COMPLAIN_ID = tb.COMPLAIN_ID,
                               COMPLAIN_TYPE = tb.COMPLAIN_TYPE,
                               COMPLAIN_TYPE_ID = tb.COMPLAIN_TYPE_ID,
                               COMPLAIN_TYPE_NM = tb.COMPLAIN_TYPE_NM,
                               DESCRIPTION = tb.DESCRIPTION,
                               SOLUTION = tb.SOLUTION,
                               ISSUED_DT = tb.ISSUED_DT,
                               RESPONSE_DT = tb.RESPONSE_DT,
                               TARGET_DT = tb.TARGET_DT,
                               RECIPIENT_RUID = tb.RECIPIENT_RUID,
                               RECIPIENT_NM = tb.RECIPIENT_NM,
                               RECIPIENT_DEPTRUID = tb.RECIPIENT_DEPTRUID,
                               RECIPIENT_DEPTID = tb.RECIPIENT_DEPTID,
                               RECIPIENT_DEPTNM = tb.RECIPIENT_DEPTNM,
                               PIC_RUID = tb.PIC_RUID,
                               PIC_NM = tb.PIC_NM,
                               PIC_DEPTRUID = tb.PIC_DEPTRUID,
                               PIC_DEPTID = tb.PIC_DEPTID,
                               PIC_DEPTNM = tb.PIC_DEPTNM,
                               PROJ_RUID = tb.PROJ_RUID,
                               PROJ_ID = tb.PROJ_ID,
                               PROJ_NM = tb.PROJ_NM,
                               PROJ_STS = tb.PROJ_STS,
                               PROJ_STS_ID = tb.PROJ_STS_ID,
                               PROJ_STS_NM = tb.PROJ_STS_NM,
                               CLIENT_RUID = tb.CLIENT_RUID,
                               IS_CPAR = tb.IS_CPAR
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Complain_DetailVM getData(string id = null)
        public Complain_DetailVM getData_create()
        {
            Complain_DetailVM oReturn = new Complain_DetailVM();
            return oReturn;
        } //End public Complain_DetailVM getData_create()
        public List<Complain_LogbookVM> getDatalist_logbookprint(FilterComplain_DetailVM poViewModel = null)
        {
            List<Complain_LogbookVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Complain_infos
                           select new Complain_LogbookVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               
                               COMPLAIN_STS = tb.COMPLAIN_STS,
                               //COMPLAIN_STS_ID = tb.COMPLAIN_STS_ID,
                               COMPLAIN_STS_NM = tb.COMPLAIN_STS_NM,
                               
                               COMPLAIN_ID = tb.COMPLAIN_ID,
                               //COMPLAIN_NM = tb.COMPLAIN_NM,

                               //COMPLAIN_TYPE = tb.COMPLAIN_TYPE,
                               //COMPLAIN_TYPE_ID = tb.COMPLAIN_TYPE_ID,
                               //COMPLAIN_TYPE_NM = tb.COMPLAIN_TYPE_NM,
                               //COMPLAIN_SUBTYPE = tb.COMPLAIN_SUBTYPE,

                               DESCRIPTION = tb.DESCRIPTION,
                               SOLUTION = tb.SOLUTION,

                               ISSUED_DT = tb.ISSUED_DT,
                               RESPONSE_DT = tb.RESPONSE_DT,
                               TARGET_DT = tb.TARGET_DT,
                               
                               RECIPIENT_RUID = tb.RECIPIENT_RUID,
                               RECIPIENT_NM = tb.RECIPIENT_NM,
                               RECIPIENT_DEPTRUID = tb.RECIPIENT_DEPTRUID,
                               //RECIPIENT_DEPTID = tb.RECIPIENT_DEPTID,
                               RECIPIENT_DEPTNM = tb.RECIPIENT_DEPTNM,
                               
                               PIC_RUID = tb.PIC_RUID,
                               PIC_NM = tb.PIC_NM,
                               PIC_DEPTRUID = tb.PIC_DEPTRUID,
                               //PIC_DEPTID = tb.PIC_DEPTID,
                               PIC_DEPTNM = tb.PIC_DEPTNM,
                               
                               PROJ_RUID = tb.PROJ_RUID,
                               PROJ_ID = tb.PROJ_ID,
                               PROJ_NM = tb.PROJ_NM,
                               PROJ_STS = tb.PROJ_STS,
                               //PROJ_STS_ID = tb.PROJ_STS_ID,
                               PROJ_STS_NM = tb.PROJ_STS_NM,
                               //CLIENT_RUID = tb.CLIENT_RUID,
                               //IS_CPAR = tb.IS_CPAR
                           };
                if ((poViewModel.Complain_DT1 != null) && (poViewModel.Complain_DT2 != null)) { oQRY = oQRY.Where(fld => fld.ISSUED_DT >= poViewModel.Complain_DT1 && fld.ISSUED_DT <= poViewModel.Complain_DT2); }

                //Access Control
                if ((this.sROLE_RUID != valFLAG.FLAG_ROLE_SYSADMIN) &&
                    (this.sROLE_RUID != valFLAG.FLAG_ROLE_PJXADMIN))
                {
                    oQRY = oQRY.Where(fld => fld.RECIPIENT_RUID == sRES_RUID ||
                                      fld.PIC_DEPTRUID == sDEPT_RUID);
                } //End if ((this.sROLE_RUID != valFLAG.FLAG_ROLE_SYSADMIN) &&

                vReturn = oQRY.OrderBy(fld => fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPAR_ListVM> getDatalist_logbook(string id = null)

        //Check Exists
        public Boolean isExists_COMPLAIN_ID(string id = null)
        {
            Boolean vReturn = false;


            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Complain_infos
                            where tb.COMPLAIN_ID == id
                            select new { COMPLAIN_ID = tb.COMPLAIN_ID }).ToList();

                if (oQRY.Count > 0) { vReturn = true; }


            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isExists_COMPLAIN_ID(string id = null)


    } //End public class ComplainDS
} //End namespace APPBASE.Models

