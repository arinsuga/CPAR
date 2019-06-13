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
    public partial class CPARController : Controller
    {
        public DBMAINContext db = new DBMAINContext();
        //DS
        public CPARDS oDS = new CPARDS();
        public CPARStdrefDS oDSStdref = new CPARStdrefDS();
        public SubtypeDS oDSLOVSubtype = new SubtypeDS();
        public ClassauditDS oDSLOVClass = new ClassauditDS();
        //CRUD
        public CPARCRUD oCRUD = new CPARCRUD();
        //VALIDATION
        public CPAR_Validation oVAL;
        public string CPAR_TYPE = "";
        public string SUBTITLE = "";

        public ActionResult Index()
        {
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC) { return RedirectToAction("Error404", "Error"); }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_AUDIT_INDEX; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_DEFACT_INDEX; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PI) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_IMPROVE_INDEX; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_LL) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_OTHER_INDEX; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_TM) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_REVIEW_INDEX; }

            ViewBag.CPAR_TYPE = CPAR_TYPE;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];
            var oData = oDS.getDatalist(this.CPAR_TYPE);
            return View("~/Views/CPAR/Index.cshtml", oData);
            //return View(oData);
        }
        public ActionResult Details(string id = null)
        {
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC) {
                //return RedirectToAction("Error404", "Error");
                return RedirectToAction("Details", "LogbookCPAR", new { id=id });

            }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_AUDIT_DETAILS; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_DEFACT_DETAILS; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PI) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_IMPROVE_DETAILS; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_LL) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_OTHER_DETAILS; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_TM) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_REVIEW_DETAILS; }

            ViewBag.CPAR_TYPE = CPAR_TYPE;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData(id);
            oData.STDREF_LIST = oDSStdref.getDatalist_byCPAR_RUID(id);
            if (oData == null) { return HttpNotFound(); }
            return View("~/Views/CPAR/Details.cshtml", oData);
            //return View(oData);
        }
        public ActionResult Create()
        {
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC) { return RedirectToAction("Error404", "Error"); }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_AUDIT_CREATE; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_DEFACT_CREATE; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PI) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_IMPROVE_CREATE; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_LL) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_OTHER_CREATE; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_TM) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_REVIEW_CREATE; }

            ViewBag.CPAR_TYPE = CPAR_TYPE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            oDS.Init(oDSStdref, oDSLOVSubtype, oDSLOVClass);
            var oData = oDS.getData_create();
            oData.STDREF_LIST = new List<CPARStdref_ListVM>();
            return View("~/Views/CPAR/Create.cshtml", oData);
            //return View(oData);
        }
        public ActionResult Edit(string id = null)
        {
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_AUDIT_EDIT; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_DEFACT_EDIT; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PI) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_IMPROVE_EDIT; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_LL) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_OTHER_EDIT; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_TM) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_REVIEW_EDIT; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_CUSTCOMP_EDIT; }

            ViewBag.CPAR_TYPE = CPAR_TYPE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            oDS.Init(oDSStdref, oDSLOVSubtype, oDSLOVClass);
            var oData = oDS.getData_edit(id);
            oData.STDREF_LIST = oDSStdref.getDatalist_byCPAR_RUID(id);
            if (oData == null) { return HttpNotFound(); }


            //Display View
            return View("~/Views/CPAR/Edit.cshtml", oData);
            //return View(oData);
        }
        public ActionResult Delete(string id = null)
        {
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC) { return RedirectToAction("Error404", "Error"); }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_AUDIT_DELETE; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_DEFACT_DELETE; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PI) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_IMPROVE_DELETE; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_LL) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_OTHER_DELETE; }
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_TM) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_REVIEW_DELETE; }

            ViewBag.CPAR_TYPE = CPAR_TYPE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getData(id);
            oData.STDREF_LIST = oDSStdref.getDatalist_byCPAR_RUID(id);
            if (oData == null) { return HttpNotFound(); }
            return View("~/Views/CPAR/Delete.cshtml", oData);
            //return View(oData);
        }

        public ActionResult Patchmorefeature1()
        {
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC) { return RedirectToAction("Error404", "Error"); }
            //if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_AUDIT_INDEX; }
            //if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_DEFACT_INDEX; }
            //if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PI) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_IMPROVE_INDEX; }
            //if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_LL) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_OTHER_INDEX; }
            //if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_TM) { ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_REVIEW_INDEX; }

            ViewBag.AC_MENU_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            ViewBag.CPAR_TYPE = CPAR_TYPE;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];
            var oData = oDS.getDatalist();
            return View("~/Views/CPAR/Patchmorefeature1.cshtml", oData);
            //return View(oData);
        }
        public ActionResult Patchhotfix2()
        {
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC) { return RedirectToAction("Error404", "Error"); }

            ViewBag.AC_MENU_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            ViewBag.CPAR_TYPE = CPAR_TYPE;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];
            var oData = oDS.getDatalist_Patchhotfix2();
            return View("~/Views/CPAR/Patchhotfix2.cshtml", oData);
            //return View(oData);
        }
        public ActionResult Patchhotfix3()
        {
            if (CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC) { return RedirectToAction("Error404", "Error"); }

            ViewBag.AC_MENU_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            ViewBag.CPAR_TYPE = CPAR_TYPE;
            ViewBag.CRUDSavedOrDelete = TempData["CRUDSavedOrDelete"];
            var oData = oDS.getDatalist_Patchhotfix3();
            return View("~/Views/CPAR/Patchhotfix3.cshtml", oData);
            //return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class CPARController : Controller
} //End namespace APPBASE.Controllers

