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
    public partial class DepartmentController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private DepartmentDS oDS = new DepartmentDS();
        private DepartmentCRUD oCRUD = new DepartmentCRUD();
        private Department_Validation oVAL;

        public ActionResult Index()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_DEPARTEMEN_INDEX;
            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_DEPARTEMEN_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        //public ActionResult Create(string id=null)
        public ActionResult Create()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_DEPARTEMEN_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            //if (id != null) { return View("XCreate"); }

            return View();
        }
        public ActionResult Edit(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_DEPARTEMEN_EDIT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_DEPARTEMEN_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            //if (oData.ISUSEDBY_AUDIT) { }
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class DepartmentController : Controller
} //End namespace APPBASE.Controllers

