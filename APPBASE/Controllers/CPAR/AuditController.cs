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
    public partial class AuditController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private AuditDS oDS = new AuditDS();
        private AuditCRUD oCRUD = new AuditCRUD();
        private Audit_Validation oVAL;

        public ActionResult Index()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_AUDIT_INDEX;
            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_AUDIT_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_AUDIT_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            return View();
        }
        public ActionResult Edit(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_AUDIT_EDIT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_AUDIT_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class AuditController : Controller
} //End namespace APPBASE.Controllers

