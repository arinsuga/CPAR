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
    public partial class StandardreffController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private StandardreffDS oDS = new StandardreffDS();
        private StandardreffCRUD oCRUD = new StandardreffCRUD();
        private Standardreff_Validation oVAL;

        public ActionResult Index()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_STDREFF_INDEX;
            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_STDREFF_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_STDREFF_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            return View();
        }
        public ActionResult Edit(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_STDREFF_EDIT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_STDREFF_DELETE;
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
    } //End public partial class CPARStandardreffController : Controller
} //End namespace APPBASE.Controllers

