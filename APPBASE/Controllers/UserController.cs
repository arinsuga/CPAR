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
using APPBASE.Svcapp;
using AutoMapper;

namespace APPBASE.Controllers
{
    [MyActionFilterAttribute]
    public partial class UserController : Controller
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
        public ActionResult Create()
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
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
        public ActionResult Activate(string id = null)
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            if (oData.BP_STS == valFLAG.FLAG_ACTIVE) { oData.BP_STS_NM = lblFIELD.USR_STS_ACTIVE; }
            else { oData.BP_STS_NM = lblFIELD.USR_STS_INACTIVE; }

            return View(oData);
        }
        public ActionResult Deactivate(string id = null)
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            if (oData.BP_STS == valFLAG.FLAG_ACTIVE) { oData.BP_STS_NM = lblFIELD.USR_STS_ACTIVE; }
            else { oData.BP_STS_NM = lblFIELD.USR_STS_INACTIVE; }

            return View(oData);
        }
        public ActionResult Role(string id = null)
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData_Userrole_Detail(id, hlpConfig.ConstantaInfo.MDLE_RUID);
            //var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
    } //End public partial class UserController : Controller
} //End namespace APPBASE.Controllers