using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Models;
using APPBASE.Helpers;
using APPBASE.Filters;
//using APPBASE.Svcapp;
using APPBASE.Svcbiz;
using AutoMapper;


namespace APPBASE.Controllers
{
    [MyActionFilterAttribute]
    public partial class LogbookCPARController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private CPAR oSERVICES = new CPAR();
        //DS
        private CPARDS oDS = new CPARDS();
        private CPARStdrefDS oDSStdref = new CPARStdrefDS();
        private CPARTypeDS oDSLOVType = new CPARTypeDS();
        private SubtypeDS oDSLOVSubtype = new SubtypeDS();
        private ClassauditDS oDSLOVClass = new ClassauditDS();
        private CPARstsDS oDSLOVCPARsts = new CPARstsDS();
        private CPARChatDS oDSChat = new CPARChatDS();
        private CPARDS oDSCPAR = new CPARDS();
        
        //CRUD
        private CPARCRUD oCRUD = new CPARCRUD();
        private CPARChatCRUD oCRUDChat = new CPARChatCRUD();
        private CPARChatnotifyCRUD oCRUDChatnotify = new CPARChatnotifyCRUD();
        //VALIDATION
        private CPAR_Validation oVAL;
        private CPARChat_Validation oVALChat;
        private FilterCPAR_Validation oVAL_filterCPAR;

        public ActionResult Index(string id=null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_CPAR_INDEX;
            FilterCPAR_DetailVM oViewModel = new FilterCPAR_DetailVM();

            if (id != null) {
                oViewModel.CPAR_STS = valFLAG.FLAG_CPAR_STS_OPEN;
                if (id == "1") { oViewModel.CPAR_STEP = valFLAG.FLAG_CPAR_STEP_PRECREATE; }
                if (id == "2") { oViewModel.CPAR_STEP = valFLAG.FLAG_CPAR_STEP_CREATED; }
                if (id == "3") { oViewModel.CPAR_STEP = valFLAG.FLAG_CPAR_STEP_RESPONDED; }
                if (id == "4") { oViewModel.CPAR_STEP = valFLAG.FLAG_CPAR_STEP_VERIFIED; }
                if (id == "5") { oViewModel.CPAR_STS = valFLAG.FLAG_CPAR_STS_CLOSED; oViewModel.CPAR_STEP = valFLAG.FLAG_CPAR_STEP_VERIFIED; }

                //string sUSR_RUID = hlpConfig.SessionInfo.getAppUsrRUID();
                string sRES_RUID = hlpConfig.SessionInfo.getAppUsrRES_RUID();
                if (sRES_RUID != "")
                {
                    string sROLE_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
                    //if (sROLE_RUID == "") { }
                    //if (sROLE_RUID == valFLAG.FLAG_ROLE_SYSADMIN) {  }
                    //if (sROLE_RUID == valFLAG.FLAG_ROLE_CPAR_ADMIN) { }
                    if (sROLE_RUID == valFLAG.FLAG_ROLE_CPAR_PIC) { oViewModel.AUDITEE_RUID = sRES_RUID; }
                    if (sROLE_RUID == valFLAG.FLAG_ROLE_PJXADMIN) { oViewModel.AUDITEE_RUID = sRES_RUID; }
                } //End if (sUSR_RUID != "")
            } //End if (id != null)
            //View all without filter by PIC of Auditor or Audetee
            if (id == null) { oDS.isVIEWBYPRIVILEGE = false; }

            ViewBag.CLASS_RUID_LOV = oDSLOVClass.getDatalist();
            ViewBag.CPAR_STS_LOV = oDSLOVCPARsts.getDatalist();
            ViewBag.Model = oDS.getDatalist_logbook(oViewModel);
            ViewBag.Services = oSERVICES;
            ViewBag.vsClassCPAR_RSPNLMT_DT = "badge bg-green";

            //var oData = oDS.getDatalist_logbook();
            return View(oViewModel);
        }
        public ActionResult Details(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_CPAR_DETAILS;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData_verify(id);
            oData.STDREF_LIST = oDSStdref.getDatalist_byCPAR_RUID(id);
            ViewBag.CPAR_TYPE_NM = " - "+oData.CPAR_TYPE_NM;
            if (oData == null) { return HttpNotFound(); }

            //Custom Access Control
            oVAL = new CPAR_Validation(oData);
            //if (!oVAL.isGranted_View()) { return RedirectToAction("Error403", "Error"); } //End if (!oVAL.isValidAccess_CPAR())
            ViewBag.isGranted_Response = oVAL.isGranted_Response();
            ViewBag.isGranted_Chat = oVAL.isGranted_Chat();

            ViewBag.CPAR_TYPE = oData.CPAR_TYPE;
            ViewBag.Chatcount = oDSChat.getData_countbyCPAR(id);
            return View(oData);
        }
        public ActionResult Print(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_CPAR_DETAILS;
            //ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData_verify(id);
            oData.CPAR_TYPE_LOV = oDSLOVType.getDatalist();
            oData.CPAR_SUBTYPE_LOV = oDSLOVSubtype.getDatalist();
            oData.CLASS_RUID_LOV = oDSLOVClass.getDatalist();
            oData.STDREF_LIST = oDSStdref.getDatalist_byCPAR_RUID(id);
            
            ViewBag.CPAR_TYPE_NM = " - " + oData.CPAR_TYPE_NM;
            if (oData == null) { return HttpNotFound(); }

            //Custom Access Control
            oVAL = new CPAR_Validation(oData);
            if (!oVAL.isGranted_View()) { return RedirectToAction("Error403", "Error"); } //End if (!oVAL.isValidAccess_CPAR())
            ViewBag.isGranted_Response = oVAL.isGranted_Response();
            ViewBag.isGranted_Chat = oVAL.isGranted_Chat();

            ViewBag.CPAR_TYPE = oData.CPAR_TYPE;
            ViewBag.Chatcount = oDSChat.getData_countbyCPAR(id);
            return View(oData);
        }

        public ActionResult Response(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_CPAR_RESPONSE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            oDS.Init(oDSStdref, oDSLOVSubtype, oDSLOVClass);
            var oData = oDS.getData_verify(id);
            if (oData == null) { return HttpNotFound(); }
            //Custom Access Control
            oVAL = new CPAR_Validation(oData);
            if (!oVAL.isGranted_Response()) { return RedirectToAction("Error403", "Error"); } //End if (!oVAL.isValidAccess_CPAR())

            ViewBag.CPAR_TYPE = oData.CPAR_TYPE;
            return View(oData);
        }
        public ActionResult Verify(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_CPAR_VERIFY;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            oDS.Init(oDSStdref, oDSLOVSubtype, oDSLOVClass);
            var oData = oDS.getData_verify(id);
            if (oData == null) { return HttpNotFound(); }

            ViewBag.CPAR_TYPE = oData.CPAR_TYPE;
            return View(oData);
        }
        public ActionResult Close(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_CPAR_CLOSE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            oDS.Init(oDSStdref, oDSLOVSubtype, oDSLOVClass);
            var oData = oDS.getData_verify(id);
            if (oData == null) { return HttpNotFound(); }

            ViewBag.CPAR_TYPE = oData.CPAR_TYPE;
            return View(oData);
        }
        public ActionResult Cancel(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_CPAR_CANCEL;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            oDS.Init(oDSStdref, oDSLOVSubtype, oDSLOVClass);
            var oData = oDS.getData_verify(id);
            if (oData == null) { return HttpNotFound(); }

            ViewBag.CPAR_TYPE = oData.CPAR_TYPE;
            return View(oData);
        }
        public ActionResult Chat(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_CPAR_CHAT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDSChat.getData_details(id);
            if (oData == null) { return HttpNotFound(); }

            var oDataCPAR = oDSCPAR.getData_partial(id);
            //Custom Access Control
            oVAL = new CPAR_Validation(oDataCPAR);
            if (!oVAL.isGranted_Chat()) { return RedirectToAction("Error403", "Error"); } //End if (!oVAL.isValidAccess_CPAR())

            oData.CPAR_RUID = oDataCPAR.RUID;
            oData.CPAR_ID = oDataCPAR.CPAR_ID;
            oData.CPAR_DT = oDataCPAR.CPAR_DT;
            oData.CPAR_DESC = oDataCPAR.CPAR_DESC;

            ViewBag.CPAR_TYPE = oDataCPAR.CPAR_TYPE;
            oCRUDChatnotify.Delete_byUSR_RUID(hlpConfig.SessionInfo.getAppUsrRUID());
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class LogbookCPARController : Controller
} //End namespace APPBASE.Controllers

