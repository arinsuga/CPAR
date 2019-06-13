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
    public partial class EmployeeController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private EmployeeDS oDS = new EmployeeDS();
        private EmployeeCRUD oCRUD = new EmployeeCRUD();
        private Employee_Validation oVAL;

        public ActionResult Index()
        {
            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(string id = null)
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        //public ActionResult Create(string XOver = null)
        public ActionResult Create()
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            //if (XOver != null) { return View("XCreate"); }
            return View();
        }
        public ActionResult Edit(string id = null)
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(string id = null)
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Career(string id = null)
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            ViewBag.ACT_type = valFLAG.FLAG_EMPACT_CAREER;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult EditQuit(string id = null)
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }

        public ActionResult Previewlist(int id)
        {
            if (id == 1) { ViewBag.RES_STS_NM = "Permanen"; }
            if (id == 2) { ViewBag.RES_STS_NM = "Kontrak"; }
            if (id == 3) { ViewBag.RES_STS_NM = "Orientasi"; }
            if (id == 4) { ViewBag.RES_STS_NM = "Outsource"; }
            var oData = oDS.getDatalist_bystatus(id);
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class EmployeeController : Controller
} //End namespace APPBASE.Controllers

