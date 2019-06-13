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
    public class CPARCPARStdrefDS
    {
        private SubtypeDS oDSLOVSubtype;
        private ClassauditDS oDSLOVClass;
        private CPARStdrefDS oDSStdref;
        //Custom Access Control
        private string sROLE_RUID = "";
        private string sRES_RUID = "";
        private string sDEPT_RUID = "";

        //Constructor
        public CPARCPARStdrefDS() {
            this.sROLE_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            this.sRES_RUID = hlpConfig.SessionInfo.getAppUsrRES_RUID();
            this.sDEPT_RUID = hlpConfig.SessionInfo.getAppUsrDEPT_RUID();
        } //End public CPARCPARStdrefDS()
        public List<CPARCPARStdref_LogbookVM> getDatalist_logbookprint(FilterCPAR_DetailVM poViewModel = null)
        {
            List<CPARCPARStdref_LogbookVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARCPARStdref_infos
                           select new CPARCPARStdref_LogbookVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_STS = tb.CPAR_STS,
                               //CPAR_STS_ID = tb.CPAR_STS_ID,
                               CPAR_STS_NM = tb.CPAR_STS_NM,
                               //CPAR_STEP = tb.CPAR_STEP,
                               //CPAR_STEP_ID = tb.CPAR_STEP_ID,
                               //CPAR_STEP_NM = tb.CPAR_STEP_NM,
                               CPAR_ID = tb.CPAR_ID,
                               CPAR_DT = tb.CPAR_DT,
                               //CPAR_TRGT_DT = tb.CPAR_TRGT_DT,
                               CPAR_FINISH_DT = tb.CPAR_FINISH_DT,
                               CPAR_DESC = tb.CPAR_DESC,
                               CPAR_RESOLUTION1 = tb.CPAR_RESOLUTION1,
                               CPAR_RESOLUTION2 = tb.CPAR_RESOLUTION2,
                               CPAR_TYPE = tb.CPAR_TYPE,
                               //CPAR_TYPE_ID = tb.CPAR_TYPE_ID,
                               CPAR_TYPE_NM = tb.CPAR_TYPE_NM,
                               CPAR_SUBTYPE = tb.CPAR_SUBTYPE,
                               CPAR_SUBTYPE_ID = tb.CPAR_SUBTYPE_ID,
                               CPAR_SUBTYPE_NM = tb.CPAR_SUBTYPE_NM,
                               
                               AUDITOR_RUID = tb.AUDITOR_RUID,
                               //AUDITOR_ID = tb.AUDITOR_ID,
                               AUDITOR_NM = tb.AUDITOR_NM,
                               AUDITORDEPT_RUID = tb.AUDITORDEPT_RUID,
                               AUDITORDEPT_ID = tb.AUDITORDEPT_ID,
                               AUDITORDEPT_NM = tb.AUDITORDEPT_NM,
                               
                               AUDITEE_RUID = tb.AUDITEE_RUID,
                               //AUDITEE_ID = tb.AUDITEE_ID,
                               AUDITEE_NM = tb.AUDITEE_NM,
                               AUDITEEDEPT_RUID = tb.AUDITEEDEPT_RUID,
                               AUDITEEDEPT_ID = tb.AUDITEEDEPT_ID,
                               AUDITEEDEPT_NM = tb.AUDITEEDEPT_NM,
                               
                               AUDIT_RUID = tb.AUDIT_RUID,
                               AUDIT_ID = tb.AUDIT_ID,
                               AUDIT_NM = tb.AUDIT_NM,
                               CLASS_RUID = tb.CLASS_RUID,
                               CLASS_ID = tb.CLASS_ID,
                               CLASS_NM = tb.CLASS_NM,
                               
                               VFKS1_DT = tb.VFKS1_DT,
                               VFKS1_DESC = tb.VFKS1_DESC,
                               VFKS2_DT = tb.VFKS2_DT,
                               VFKS2_DESC = tb.VFKS2_DESC,
                               VFKS3_DT = tb.VFKS3_DT,
                               VFKS3_DESC = tb.VFKS3_DESC,
                               VFKS4_DT = tb.VFKS4_DT,
                               VFKS4_DESC = tb.VFKS4_DESC,
                               VFKS5_DT = tb.VFKS5_DT,
                               VFKS5_DESC = tb.VFKS5_DESC,
                               //COMPLAIN_RUID = tb.COMPLAIN_RUID,
                               //COMPLAIN_ID = tb.COMPLAIN_ID,
                               //COMPLAIN_NM = tb.COMPLAIN_NM,
                               STDREF_RUID = tb.STDREF_RUID,
                               STDREFLOV_RUID = tb.STDREFLOV_RUID,
                               STDREFLOV_ID = tb.STDREFLOV_ID,
                               STDREFLOV_NM = tb.STDREFLOV_NM
                           };

                if ((poViewModel.CPAR_DT1 != null) && (poViewModel.CPAR_DT2 != null)) { oQRY = oQRY.Where(fld => fld.CPAR_DT >= poViewModel.CPAR_DT1 && fld.CPAR_DT <= poViewModel.CPAR_DT2); }
                if (poViewModel.CPAR_TYPE != null) { oQRY = oQRY.Where(fld => fld.CPAR_TYPE == poViewModel.CPAR_TYPE); }
                //if (poViewModel.CPAR_SUBTYPE != null) { oQRY = oQRY.Where(fld => fld.CPAR_SUBTYPE == poViewModel.CPAR_SUBTYPE); }
                if (poViewModel.AUDIT_RUID != null) { oQRY = oQRY.Where(fld => fld.AUDIT_RUID == poViewModel.AUDIT_RUID); }
                if (poViewModel.CLASS_RUID != null) { oQRY = oQRY.Where(fld => fld.CLASS_RUID == poViewModel.CLASS_RUID); }

                if (poViewModel.AUDITEEDEPT_RUID != null) { oQRY = oQRY.Where(fld => fld.AUDITEEDEPT_RUID == poViewModel.AUDITEEDEPT_RUID); }
                if (poViewModel.CPAR_STS != null) { oQRY = oQRY.Where(fld => fld.CPAR_STS == poViewModel.CPAR_STS); }

                //if (poViewModel.CLASS_RUID != null) { oQRY = oQRY.Where(fld => fld.CLASS_RUID == poViewModel.CLASS_RUID); }
                //if (poViewModel.AUDITOR_RUID != null) { oQRY = oQRY.Where(fld => fld.AUDITOR_RUID == poViewModel.AUDITOR_RUID); }

                //Access Control
                if ((this.sROLE_RUID != valFLAG.FLAG_ROLE_SYSADMIN) &&
                    (this.sROLE_RUID != valFLAG.FLAG_ROLE_CPAR_ADMIN))
                {
                    oQRY = oQRY.Where(fld => fld.AUDITOR_RUID == sRES_RUID ||
                                      fld.AUDITEEDEPT_RUID == sDEPT_RUID);
                } //End if (this.sROLE_RUID != valFLAG.FLAG_ROLE_SYSADMIN)

                vReturn = oQRY.OrderBy(fld => fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPAR_ListVM> getDatalist_logbook(string id = null)

    } //End public class CPARCPARStdrefDS
} //End namespace APPBASE.Models

