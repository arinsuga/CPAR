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
    public partial class UsercparController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private UserDS oDS = new UserDS();
        private UserCRUD oCRUD = new UserCRUD();
        private User_Validation oVAL;

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_USER_INDEX;
            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_USER_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getDataCPAR(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_USER_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            return View();
        }
        public ActionResult Edit(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_USER_EDIT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            var oData = oDS.getDataCPAR(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_USER_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getDataCPAR(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Activate(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_USER_ACTIVATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getDataCPAR(id);
            if (oData == null) { return HttpNotFound(); }
            if (oData.BP_STS == valFLAG.FLAG_ACTIVE) { oData.BP_STS_NM = lblFIELD.USR_STS_ACTIVE; }
            else { oData.BP_STS_NM = lblFIELD.USR_STS_INACTIVE; }

            return View(oData);
        }
        public ActionResult Deactivate(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_USER_DEACTIVATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getDataCPAR(id);
            if (oData == null) { return HttpNotFound(); }
            if (oData.BP_STS == valFLAG.FLAG_ACTIVE) { oData.BP_STS_NM = lblFIELD.USR_STS_ACTIVE; }
            else { oData.BP_STS_NM = lblFIELD.USR_STS_INACTIVE; }

            return View(oData);
        }
        public ActionResult Role(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_USER_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData_Userrole_DetailCPAR(id, hlpConfig.ConstantaInfo.MDLE_RUID);
            //var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }

    } //End public partial class UsercparController : Controller
} //End namespace APPBASE.Controllers