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
    public class CPARDS
    {
        private SubtypeDS oDSLOVSubtype;
        private ClassauditDS oDSLOVClass;
        private CPARStdrefDS oDSStdref;
        //Custom Access Control
        private string sROLE_RUID = "";
        private string sRES_RUID = "";
        private string sDEPT_RUID = "";

        public Boolean isVIEWBYPRIVILEGE { get; set; }

        //Constructor
        public CPARDS() {
            this.sROLE_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            this.sRES_RUID = hlpConfig.SessionInfo.getAppUsrRES_RUID();
            this.sDEPT_RUID = hlpConfig.SessionInfo.getAppUsrDEPT_RUID();
            this.isVIEWBYPRIVILEGE = true;
        } //End public CPARDS
        public void Init(CPARStdrefDS poDSStdref, SubtypeDS poDSLOVSubtype, ClassauditDS poDSLOVClass)
        {
            oDSStdref = poDSStdref;
            oDSLOVSubtype = poDSLOVSubtype;
            oDSLOVClass = poDSLOVClass;
            this.sROLE_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            this.sRES_RUID = hlpConfig.SessionInfo.getAppUsrRES_RUID();
            this.sDEPT_RUID = hlpConfig.SessionInfo.getAppUsrDEPT_RUID();
        } //End public CPARDS(CPARSubtypeDS poDSLOVSubtype, CPARClassDS poDSLOVClass)
        public List<CPAR_ListVM> getDatalist(string id = null)
        {
            List<CPAR_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPAR_infos
                           select new CPAR_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_STS = tb.CPAR_STS,
                               CPAR_STS_ID = tb.CPAR_STS_ID,
                               CPAR_STS_NM = tb.CPAR_STS_NM,
                               CPAR_STEP = tb.CPAR_STEP,
                               CPAR_STEP_ID = tb.CPAR_STEP_ID,
                               CPAR_STEP_NM = tb.CPAR_STEP_NM,
                               CPAR_ID = tb.CPAR_ID,
                               CPAR_DT = tb.CPAR_DT,
                               CPAR_TRGT_DT = tb.CPAR_TRGT_DT,
                               CPAR_FINISH_DT = tb.CPAR_FINISH_DT,
                               CPAR_DESC = tb.CPAR_DESC,
                               CPAR_TYPE = tb.CPAR_TYPE,
                               CPAR_TYPE_ID = tb.CPAR_TYPE_ID,
                               CPAR_TYPE_NM = tb.CPAR_TYPE_NM,
                               CPAR_SUBTYPE = tb.CPAR_SUBTYPE,
                               CPAR_SUBTYPE_ID = tb.CPAR_SUBTYPE_ID,
                               CPAR_SUBTYPE_NM = tb.CPAR_SUBTYPE_NM,
                               AUDITOR_RUID = tb.AUDITOR_RUID,
                               //AUDITOR_ID = tb.AUDITOR_ID,
                               AUDITOR_NM = tb.AUDITOR_NM,
                               AUDITOR_USRRUID = tb.AUDITOR_USRRUID,
                               AUDITORDEPT_RUID = tb.AUDITORDEPT_RUID,
                               AUDITORDEPT_ID = tb.AUDITORDEPT_ID,
                               AUDITORDEPT_NM = tb.AUDITORDEPT_NM,
                               AUDITEE_RUID = tb.AUDITEE_RUID,
                               //AUDITEE_ID = tb.AUDITEE_ID,
                               AUDITEE_NM = tb.AUDITEE_NM,
                               AUDITEE_USRRUID = tb.AUDITEE_USRRUID,
                               AUDITEEDEPT_RUID = tb.AUDITEEDEPT_RUID,
                               AUDITEEDEPT_ID = tb.AUDITEEDEPT_ID,
                               AUDITEEDEPT_NM = tb.AUDITEEDEPT_NM,
                               COMPLAIN_CLIENTRUID = tb.COMPLAIN_CLIENTRUID,
                               OWNER_NM = tb.OWNER_NM,
                               CPAR_RSPNLMT_DT = tb.CPAR_RSPNLMT_DT,
                               CPAR_VERLMT_DT = tb.CPAR_VERLMT_DT
                           };
                if ((this.sROLE_RUID != valFLAG.FLAG_ROLE_SYSADMIN) &&
                    (this.sROLE_RUID != valFLAG.FLAG_ROLE_CPAR_ADMIN)) {
                    oQRY = oQRY.Where(fld => fld.AUDITOR_RUID == sRES_RUID ||
                                      fld.AUDITEEDEPT_RUID==sDEPT_RUID);
                } //End if (this.sROLE_RUID != valFLAG.FLAG_ROLE_SYSADMIN)


                if (id != null) { oQRY = oQRY.Where(fld => fld.CPAR_TYPE == id); }
                vReturn = oQRY.OrderByDescending(fld => fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPAR_ListVM> getDatalist(string id = null)
        public List<CPAR_ListVM> getDatalist_logbook(FilterCPAR_DetailVM poViewModel=null)
        {
            List<CPAR_ListVM> vReturn;
            

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPAR_infos
                           select new CPAR_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_STS = tb.CPAR_STS,
                               CPAR_STS_ID = tb.CPAR_STS_ID,
                               CPAR_STS_NM = tb.CPAR_STS_NM,
                               CPAR_STEP = tb.CPAR_STEP,
                               CPAR_STEP_ID = tb.CPAR_STEP_ID,
                               CPAR_STEP_NM = tb.CPAR_STEP_NM,
                               CPAR_ID = tb.CPAR_ID,
                               CPAR_DT = tb.CPAR_DT,
                               CPAR_TRGT_DT = tb.CPAR_TRGT_DT,
                               CPAR_FINISH_DT = tb.CPAR_FINISH_DT,
                               CPAR_DESC = tb.CPAR_DESC,
                               CPAR_TYPE = tb.CPAR_TYPE,
                               CPAR_TYPE_ID = tb.CPAR_TYPE_ID,
                               CPAR_TYPE_NM = tb.CPAR_TYPE_NM,
                               CPAR_SUBTYPE = tb.CPAR_SUBTYPE,
                               CPAR_SUBTYPE_ID = tb.CPAR_SUBTYPE_ID,
                               CPAR_SUBTYPE_NM = tb.CPAR_SUBTYPE_NM,
                               AUDITOR_RUID = tb.AUDITOR_RUID,
                               //AUDITOR_ID = tb.AUDITOR_ID,
                               AUDITOR_NM = tb.AUDITOR_NM,
                               AUDITOR_USRRUID = tb.AUDITOR_USRRUID,
                               AUDITORDEPT_RUID = tb.AUDITORDEPT_RUID,
                               AUDITORDEPT_ID = tb.AUDITORDEPT_ID,
                               AUDITORDEPT_NM = tb.AUDITORDEPT_NM,
                               AUDITEE_RUID = tb.AUDITEE_RUID,
                               //AUDITEE_ID = tb.AUDITEE_ID,
                               AUDITEE_NM = tb.AUDITEE_NM,
                               AUDITEE_USRRUID = tb.AUDITEE_USRRUID,
                               AUDITEEDEPT_RUID = tb.AUDITEEDEPT_RUID,
                               AUDITEEDEPT_ID = tb.AUDITEEDEPT_ID,
                               AUDITEEDEPT_NM = tb.AUDITEEDEPT_NM,
                               
                               AUDIT_RUID = tb.AUDIT_RUID,
                               AUDIT_ID = tb.AUDIT_ID,
                               AUDIT_NM = tb.AUDIT_NM,
                               CLASS_RUID = tb.CLASS_RUID,
                               CLASS_ID = tb.CLASS_ID,
                               CLASS_NM = tb.CLASS_NM,
                               COMPLAIN_CLIENTRUID = tb.COMPLAIN_CLIENTRUID,
                               OWNER_NM = tb.OWNER_NM,
                               CPAR_RSPNLMT_DT = tb.CPAR_RSPNLMT_DT,
                               CPAR_VERLMT_DT = tb.CPAR_VERLMT_DT
                           };

                if ((poViewModel.CPAR_DT1 != null) && (poViewModel.CPAR_DT2 != null)) { oQRY = oQRY.Where(fld => fld.CPAR_DT >= poViewModel.CPAR_DT1 && fld.CPAR_DT <= poViewModel.CPAR_DT2); }
                if (poViewModel.CPAR_TYPE != null) { oQRY = oQRY.Where(fld => fld.CPAR_TYPE == poViewModel.CPAR_TYPE); }
                //if (poViewModel.CPAR_SUBTYPE != null) { oQRY = oQRY.Where(fld => fld.CPAR_SUBTYPE == poViewModel.CPAR_SUBTYPE); }
                if (poViewModel.AUDIT_RUID != null) { oQRY = oQRY.Where(fld => fld.AUDIT_RUID == poViewModel.AUDIT_RUID); }
                if (poViewModel.CLASS_RUID != null) { oQRY = oQRY.Where(fld => fld.CLASS_RUID == poViewModel.CLASS_RUID); }

                if (poViewModel.AUDITEE_RUID != null) { oQRY = oQRY.Where(fld => fld.AUDITEE_RUID == poViewModel.AUDITEE_RUID); }
                if (poViewModel.AUDITEEDEPT_RUID != null) { oQRY = oQRY.Where(fld => fld.AUDITEEDEPT_RUID == poViewModel.AUDITEEDEPT_RUID); }
                if (poViewModel.CPAR_STS != null) { oQRY = oQRY.Where(fld => fld.CPAR_STS == poViewModel.CPAR_STS); }
                if (poViewModel.CPAR_STEP != null) { oQRY = oQRY.Where(fld => fld.CPAR_STEP == poViewModel.CPAR_STEP); }

                //if (poViewModel.CLASS_RUID != null) { oQRY = oQRY.Where(fld => fld.CLASS_RUID == poViewModel.CLASS_RUID); }
                //if (poViewModel.AUDITOR_RUID != null) { oQRY = oQRY.Where(fld => fld.AUDITOR_RUID == poViewModel.AUDITOR_RUID); }

                
                //Access Control
                if ((this.sROLE_RUID != valFLAG.FLAG_ROLE_SYSADMIN) &&
                    (this.sROLE_RUID != valFLAG.FLAG_ROLE_CPAR_ADMIN))
                {
                    if (this.isVIEWBYPRIVILEGE == true) {
                        oQRY = oQRY.Where(fld => fld.AUDITEE_RUID == sRES_RUID ||
                                          fld.AUDITEEDEPT_RUID == sDEPT_RUID);
                    } //End if (this.isVIEWBYPRIVILEGE == true)
                } //End if (this.sROLE_RUID != valFLAG.FLAG_ROLE_SYSADMIN)

                vReturn = oQRY.OrderByDescending(fld => fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPAR_ListVM> getDatalist_logbook(string id = null)
        public List<CPARNOTIFVM> getDatalist_notif(string id = null)
        {
            List<CPARNOTIFVM> vReturn;
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARNOTIF_infos
                           select new CPARNOTIFVM
                           {
                               //RSEQNO = tb.RSEQNO,
                               //RUID = tb.RUID,
                               CPAR_STS = tb.CPAR_STS,
                               AUDITOR_RUID = tb.AUDITOR_RUID,
                               AUDITEE_RUID = tb.AUDITEE_RUID,
                               AUDITEEDEPT_RUID = tb.AUDITEEDEPT_RUID,
                               PRECREATE = tb.PRECREATE,
                               CREATED = tb.CREATED,
                               RESPONDED = tb.RESPONDED,
                               VERIFIED = tb.VERIFIED
                           };
                if (id != null)
                {
                    oQRY = oQRY.Where(fld => fld.AUDITEE_RUID == id);
                    //if (psNOTIF_TO == valFLAG.FLAG_NOTIF_CPAR_AUDITEE) { oQRY = oQRY.Where(fld => fld.AUDITEE_RUID == psNOTIF_TORUID); }
                    //if (psNOTIF_TO == valFLAG.FLAG_NOTIF_CPAR_AUDITEE_DEPT) { oQRY = oQRY.Where(fld => fld.AUDITEEDEPT_RUID == psNOTIF_TORUID); }
                    //if (psNOTIF_TO == valFLAG.FLAG_NOTIF_CPAR_AUDITOR) { oQRY = oQRY.Where(fld => fld.AUDITOR_RUID == psNOTIF_TORUID); }
                } //End if (id != null)
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPARNOTIFVM> getDatalist_notif(string id = null)
        public List<CPARYEARALLVM> getDatalist_YEARALL(int? id, string id2 = null)
        {
            List<CPARYEARALLVM> oReturn;
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARYEARALL_infos
                           where tb.CPAR_YEARS == id
                           select new CPARYEARALLVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               CPAR_YEARS = tb.CPAR_YEARS,
                               AUDITEE_RUID = tb.AUDITEE_RUID,
                               CPAR_IA = tb.CPAR_IA,
                               CPAR_TM = tb.CPAR_TM,
                               CPAR_PP = tb.CPAR_PP,
                               CPAR_PI = tb.CPAR_PI,
                               CPAR_CC = tb.CPAR_CC,
                               CPAR_LL = tb.CPAR_LL
                           };
                if (id2 != null) { oQRY = oQRY.Where(fld => fld.AUDITEE_RUID == id2); }
                oReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public List<CPARYEARALLVM> getDatalist_YEARALL(int? id, string id2=null)
        public List<CPARYEARLISTVM> getDatalist_YEARLIST()
        {
            List<CPARYEARLISTVM> oReturn;
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARYEARALL_infos
                           group tb by tb.CPAR_YEARS into tbx
                           select new CPARYEARLISTVM { CPAR_YEARS = tbx.Key };
                oReturn = oQRY.OrderByDescending(fld => fld.CPAR_YEARS).ToList();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public List<CPARYEARALLVM> getDatalist_YEARALL(int? id, string id2=null)

        public CPAR_DetailVM getData(string id = null)
        {
            CPAR_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPAR_infos
                           where tb.RUID == id
                           select new CPAR_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_STS = tb.CPAR_STS,
                               CPAR_STS_ID = tb.CPAR_STS_ID,
                               CPAR_STS_NM = tb.CPAR_STS_NM,
                               CPAR_STEP = tb.CPAR_STEP,
                               CPAR_STEP_ID = tb.CPAR_STEP_ID,
                               CPAR_STEP_NM = tb.CPAR_STEP_NM,
                               CPAR_ID = tb.CPAR_ID,
                               CPAR_DT = tb.CPAR_DT,
                               CPAR_FINISH_DT = tb.CPAR_FINISH_DT,
                               CPAR_DESC = tb.CPAR_DESC,
                               CPAR_TYPE = tb.CPAR_TYPE,
                               CPAR_TYPE_ID = tb.CPAR_TYPE_ID,
                               CPAR_TYPE_NM = tb.CPAR_TYPE_NM,
                               CPAR_SUBTYPE = tb.CPAR_SUBTYPE,
                               CPAR_SUBTYPE_ID = tb.CPAR_SUBTYPE_ID,
                               CPAR_SUBTYPE_NM = tb.CPAR_SUBTYPE_NM,
                               AUDITOR_RUID = tb.AUDITOR_RUID,
                               AUDITOR_ID = tb.AUDITOR_ID,
                               AUDITOR_NM = tb.AUDITOR_NM,
                               AUDITOR_USRRUID=tb.AUDITOR_USRRUID,
                               AUDITORDEPT_RUID = tb.AUDITORDEPT_RUID,
                               AUDITORDEPT_ID = tb.AUDITORDEPT_ID,
                               AUDITORDEPT_NM = tb.AUDITORDEPT_NM,
                               AUDITEE_RUID = tb.AUDITEE_RUID,
                               AUDITEE_ID = tb.AUDITEE_ID,
                               AUDITEE_NM = tb.AUDITEE_NM,
                               AUDITEE_USRRUID = tb.AUDITEE_USRRUID,
                               AUDITEEDEPT_RUID = tb.AUDITEEDEPT_RUID,
                               AUDITEEDEPT_ID = tb.AUDITEEDEPT_ID,
                               AUDITEEDEPT_NM = tb.AUDITEEDEPT_NM,
                               AUDIT_RUID = tb.AUDIT_RUID,
                               AUDIT_ID = tb.AUDIT_ID,
                               AUDIT_NM = tb.AUDIT_NM,
                               CLASS_RUID = tb.CLASS_RUID,
                               CLASS_ID = tb.CLASS_ID,
                               CLASS_NM = tb.CLASS_NM,
                               COMPLAIN_RUID = tb.COMPLAIN_RUID,
                               COMPLAIN_ID = tb.COMPLAIN_ID,
                               COMPLAIN_NM = tb.COMPLAIN_NM,
                               COMPLAIN_CLIENTRUID = tb.COMPLAIN_CLIENTRUID,
                               OWNER_NM = tb.OWNER_NM
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public CPAR_DetailVM getData(string id = null)
        public CPAR_DetailVM getData_create()
        {
            CPAR_DetailVM oReturn = new CPAR_DetailVM();
            //oReturn.STDREF_LIST = oDSStdref.getDatalist();
            oReturn.CPAR_SUBTYPE_LOV = oDSLOVSubtype.getDatalist();
            oReturn.CLASS_RUID_LOV = oDSLOVClass.getDatalist();
            return oReturn;
        } //End public CPAR_DetailVM getData_create(string id = null)
        public CPAR_DetailVM getData_edit(string id = null)
        {
            CPAR_DetailVM oReturn = getData(id);
            oReturn.CPAR_SUBTYPE_LOV = oDSLOVSubtype.getDatalist();
            oReturn.CLASS_RUID_LOV = oDSLOVClass.getDatalist();
            return oReturn;
        } //End public CPAR_DetailVM getData_create(string id = null)
        public CPAR_VerifyVM getData_verify(string id = null)
        {
            CPAR_VerifyVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPAR_infos
                           where tb.RUID == id
                           select new CPAR_VerifyVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_STS = tb.CPAR_STS,
                               CPAR_STS_ID = tb.CPAR_STS_ID,
                               CPAR_STS_NM = tb.CPAR_STS_NM,
                               CPAR_STEP = tb.CPAR_STEP,
                               CPAR_STEP_ID = tb.CPAR_STEP_ID,
                               CPAR_STEP_NM = tb.CPAR_STEP_NM,
                               CPAR_ID = tb.CPAR_ID,
                               CPAR_DT = tb.CPAR_DT,
                               CPAR_TRGT_DT = tb.CPAR_TRGT_DT,
                               CPAR_FINISH_DT = tb.CPAR_FINISH_DT,
                               CPAR_DESC = tb.CPAR_DESC,
                               CPAR_RESOLUTION1 = tb.CPAR_RESOLUTION1,
                               CPAR_RESOLUTION2 = tb.CPAR_RESOLUTION2,
                               CPAR_RESOLUTION3 = tb.CPAR_RESOLUTION3,
                               CPAR_TYPE = tb.CPAR_TYPE,
                               CPAR_TYPE_ID = tb.CPAR_TYPE_ID,
                               CPAR_TYPE_NM = tb.CPAR_TYPE_NM,
                               CPAR_SUBTYPE = tb.CPAR_SUBTYPE,
                               CPAR_SUBTYPE_ID = tb.CPAR_SUBTYPE_ID,
                               CPAR_SUBTYPE_NM = tb.CPAR_SUBTYPE_NM,
                               AUDITOR_RUID = tb.AUDITOR_RUID,
                               AUDITOR_ID = tb.AUDITOR_ID,
                               AUDITOR_NM = tb.AUDITOR_NM,
                               AUDITOR_USRRUID = tb.AUDITOR_USRRUID,
                               AUDITORDEPT_RUID = tb.AUDITORDEPT_RUID,
                               AUDITORDEPT_ID = tb.AUDITORDEPT_ID,
                               AUDITORDEPT_NM = tb.AUDITORDEPT_NM,
                               AUDITEE_RUID = tb.AUDITEE_RUID,
                               AUDITEE_ID = tb.AUDITEE_ID,
                               AUDITEE_NM = tb.AUDITEE_NM,
                               AUDITEE_USRRUID = tb.AUDITEE_USRRUID,
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
                               VFKS1_PIC = tb.VFKS1_PIC,
                               
                               VFKS2_DT = tb.VFKS2_DT,
                               VFKS2_DESC = tb.VFKS2_DESC,
                               VFKS2_PIC = tb.VFKS2_PIC,
                               
                               VFKS3_DT = tb.VFKS3_DT,
                               VFKS3_DESC = tb.VFKS3_DESC,
                               VFKS3_PIC = tb.VFKS3_PIC,

                               VFKS4_DT = tb.VFKS4_DT,
                               VFKS4_DESC = tb.VFKS4_DESC,
                               VFKS4_PIC = tb.VFKS4_PIC,

                               VFKS5_DT = tb.VFKS5_DT,
                               VFKS5_DESC = tb.VFKS5_DESC,
                               VFKS5_PIC = tb.VFKS5_PIC,

                               COMPLAIN_RUID = tb.COMPLAIN_RUID,
                               COMPLAIN_ID = tb.COMPLAIN_ID,
                               COMPLAIN_NM = tb.COMPLAIN_NM,
                               COMPLAIN_CLIENTRUID = tb.COMPLAIN_CLIENTRUID,
                               OWNER_NM = tb.OWNER_NM
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public CPAR_VerifyVM getData_verify(string id = null)
        public CPAR_DetailVM getData_partial(string id = null)
        {
            CPAR_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPAR_infos
                           where tb.RUID == id
                           select new CPAR_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_STS = tb.CPAR_STS,
                               CPAR_STS_NM = tb.CPAR_STS_NM,
                               CPAR_STEP = tb.CPAR_STEP,
                               CPAR_STEP_NM = tb.CPAR_STEP_NM,
                               CPAR_ID = tb.CPAR_ID,
                               CPAR_DT = tb.CPAR_DT,
                               CPAR_DESC = tb.CPAR_DESC,
                               AUDITORDEPT_RUID = tb.AUDITORDEPT_RUID,
                               AUDITEE_RUID = tb.AUDITEE_RUID,
                               AUDITEEDEPT_RUID = tb.AUDITEEDEPT_RUID
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public CPAR_DetailVM getData_partial(string id = null)

        public string getData_CPAR_STEP(string id = null)
        {
            string oReturn;
            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.CPAR_infos
                           where tb.RUID == id
                           select new { CPAR_STEP = tb.CPAR_STEP }).SingleOrDefault();
                oReturn = oQRY.CPAR_STEP;
            } //End using (var = new DbContext())
            return oReturn;
        } //End public CPAR_DetailVM getData(string id = null)
        public int? getMax_CPARYEAR()
        {
            int? oReturn=null;
            using (var db = new DBMAINContext())
            {
                oReturn = db.CPARYEARALL_infos.Max(fld => fld.CPAR_YEARS);
            } //End using (var = new DbContext())
            return oReturn;
        } //End public CPAR_DetailVM getData(string id = null)


        public List<CPAR_ListVM> getDatalist_Patchhotfix2()
        {
            List<CPAR_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPAR_infos
                           select new CPAR_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_STS = tb.CPAR_STS,
                               CPAR_STS_ID = tb.CPAR_STS_ID,
                               CPAR_STS_NM = tb.CPAR_STS_NM,
                               CPAR_STEP = tb.CPAR_STEP,
                               CPAR_STEP_ID = tb.CPAR_STEP_ID,
                               CPAR_STEP_NM = tb.CPAR_STEP_NM,
                               CPAR_ID = tb.CPAR_ID,
                               CPAR_DT = tb.CPAR_DT,
                               CPAR_TRGT_DT = tb.CPAR_TRGT_DT,
                               CPAR_FINISH_DT = tb.CPAR_FINISH_DT,
                               CPAR_DESC = tb.CPAR_DESC,
                               CPAR_TYPE = tb.CPAR_TYPE,
                               CPAR_TYPE_ID = tb.CPAR_TYPE_ID,
                               CPAR_TYPE_NM = tb.CPAR_TYPE_NM,
                               CPAR_SUBTYPE = tb.CPAR_SUBTYPE,
                               CPAR_SUBTYPE_ID = tb.CPAR_SUBTYPE_ID,
                               CPAR_SUBTYPE_NM = tb.CPAR_SUBTYPE_NM,
                               AUDITOR_RUID = tb.AUDITOR_RUID,
                               //AUDITOR_ID = tb.AUDITOR_ID,
                               AUDITOR_NM = tb.AUDITOR_NM,
                               AUDITOR_USRRUID = tb.AUDITOR_USRRUID,
                               AUDITORDEPT_RUID = tb.AUDITORDEPT_RUID,
                               AUDITORDEPT_ID = tb.AUDITORDEPT_ID,
                               AUDITORDEPT_NM = tb.AUDITORDEPT_NM,
                               AUDITEE_RUID = tb.AUDITEE_RUID,
                               //AUDITEE_ID = tb.AUDITEE_ID,
                               AUDITEE_NM = tb.AUDITEE_NM,
                               AUDITEE_USRRUID = tb.AUDITEE_USRRUID,
                               AUDITEEDEPT_RUID = tb.AUDITEEDEPT_RUID,
                               AUDITEEDEPT_ID = tb.AUDITEEDEPT_ID,
                               AUDITEEDEPT_NM = tb.AUDITEEDEPT_NM,

                               AUDIT_RUID = tb.AUDIT_RUID,
                               AUDIT_ID = tb.AUDIT_ID,
                               AUDIT_NM = tb.AUDIT_NM,
                               CLASS_RUID = tb.CLASS_RUID,
                               CLASS_ID = tb.CLASS_ID,
                               CLASS_NM = tb.CLASS_NM,
                               COMPLAIN_CLIENTRUID = tb.COMPLAIN_CLIENTRUID,
                               OWNER_NM = tb.OWNER_NM,
                               CPAR_RSPNLMT_DT = tb.CPAR_RSPNLMT_DT,
                               CPAR_VERLMT_DT = tb.CPAR_VERLMT_DT
                           };

                oQRY = oQRY.Where(fld => fld.CPAR_STS == valFLAG.FLAG_CPAR_STS_OPEN);
                oQRY = oQRY.Where(fld => fld.CPAR_STEP != valFLAG.FLAG_CPAR_STEP_VERIFIED);
                vReturn = oQRY.OrderByDescending(fld => fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPAR_ListVM> getDatalist_Patchhotfix2()
        public List<CPAR_ListVM> getDatalist_Patchhotfix3()
        {
            List<CPAR_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPAR_infos
                           select new CPAR_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_STS = tb.CPAR_STS,
                               CPAR_STS_ID = tb.CPAR_STS_ID,
                               CPAR_STS_NM = tb.CPAR_STS_NM,
                               CPAR_STEP = tb.CPAR_STEP,
                               CPAR_STEP_ID = tb.CPAR_STEP_ID,
                               CPAR_STEP_NM = tb.CPAR_STEP_NM,
                               CPAR_ID = tb.CPAR_ID,
                               CPAR_DT = tb.CPAR_DT,
                               CPAR_TRGT_DT = tb.CPAR_TRGT_DT,
                               CPAR_FINISH_DT = tb.CPAR_FINISH_DT,
                               CPAR_DESC = tb.CPAR_DESC,
                               CPAR_TYPE = tb.CPAR_TYPE,
                               CPAR_TYPE_ID = tb.CPAR_TYPE_ID,
                               CPAR_TYPE_NM = tb.CPAR_TYPE_NM,
                               CPAR_SUBTYPE = tb.CPAR_SUBTYPE,
                               CPAR_SUBTYPE_ID = tb.CPAR_SUBTYPE_ID,
                               CPAR_SUBTYPE_NM = tb.CPAR_SUBTYPE_NM,
                               AUDITOR_RUID = tb.AUDITOR_RUID,
                               //AUDITOR_ID = tb.AUDITOR_ID,
                               AUDITOR_NM = tb.AUDITOR_NM,
                               AUDITOR_USRRUID = tb.AUDITOR_USRRUID,
                               AUDITORDEPT_RUID = tb.AUDITORDEPT_RUID,
                               AUDITORDEPT_ID = tb.AUDITORDEPT_ID,
                               AUDITORDEPT_NM = tb.AUDITORDEPT_NM,
                               AUDITEE_RUID = tb.AUDITEE_RUID,
                               //AUDITEE_ID = tb.AUDITEE_ID,
                               AUDITEE_NM = tb.AUDITEE_NM,
                               AUDITEE_USRRUID = tb.AUDITEE_USRRUID,
                               AUDITEEDEPT_RUID = tb.AUDITEEDEPT_RUID,
                               AUDITEEDEPT_ID = tb.AUDITEEDEPT_ID,
                               AUDITEEDEPT_NM = tb.AUDITEEDEPT_NM,

                               AUDIT_RUID = tb.AUDIT_RUID,
                               AUDIT_ID = tb.AUDIT_ID,
                               AUDIT_NM = tb.AUDIT_NM,
                               CLASS_RUID = tb.CLASS_RUID,
                               CLASS_ID = tb.CLASS_ID,
                               CLASS_NM = tb.CLASS_NM,
                               COMPLAIN_CLIENTRUID = tb.COMPLAIN_CLIENTRUID,
                               OWNER_NM = tb.OWNER_NM,
                               CPAR_RSPNLMT_DT = tb.CPAR_RSPNLMT_DT,
                               CPAR_VERLMT_DT = tb.CPAR_VERLMT_DT
                           };

                oQRY = oQRY.Where(fld => fld.CPAR_STS == valFLAG.FLAG_CPAR_STS_OPEN);
                oQRY = oQRY.Where(fld => fld.CPAR_STEP != valFLAG.FLAG_CPAR_STEP_VERIFIED);
                vReturn = oQRY.OrderByDescending(fld => fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPAR_ListVM> getDatalist_Patchhotfix3()
    
    } //End public class CPARDS
} //End namespace APPBASE.Models

