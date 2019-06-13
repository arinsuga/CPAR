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
    public partial class ProjectController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private ProjectDS oDS = new ProjectDS();
        private ProjectCRUD oCRUD = new ProjectCRUD();
        private Project_Validation oVAL;
        private ProjectstsDS oDSProjectsts = new ProjectstsDS();
        private Project_DetailVM oVM = new Project_DetailVM();

        public ActionResult Index()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_PROJECT_INDEX;
            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_PROJECT_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_PROJECT_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            var oData = oVM;
            oData.PROJ_STS_LOV = oDSProjectsts.getDatalist_combobox();
            return View(oData);
        }
        public ActionResult Edit(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_PROJECT_EDIT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getData(id);
            if (oData != null) { oData.PROJ_STS_LOV = oDSProjectsts.getDatalist_combobox(); }
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_MASTER_PROJECT_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getData(id);
            if (oData != null) { oData.PROJ_STS_LOV = oDSProjectsts.getDatalist_combobox(); }
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class ProjectController : Controller
} //End namespace APPBASE.Controllers

