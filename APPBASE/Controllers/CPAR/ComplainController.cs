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
    public partial class ComplainController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private ComplainDS oDS = new ComplainDS();
        private ComplaintypeDS oDSComplaintype = new ComplaintypeDS();

        private ComplainCRUD oCRUD = new ComplainCRUD();
        private Complain_Validation oVAL;

        public ActionResult Index()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_COMPLAIN_INDEX;
            var oData = oDS.getDatalist();
            return View(oData);
        }
        public ActionResult Details(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_COMPLAIN_DETAILS;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.VIEW;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Create()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_COMPLAIN_CREATE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            ViewBag.COMPLAIN_TYPE_LOV = oDSComplaintype.getDatalist();
            return View(oDS.getData_create());
        }
        public ActionResult Edit(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_COMPLAIN_EDIT;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            ViewBag.COMPLAIN_TYPE_LOV = oDSComplaintype.getDatalist();
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }
        public ActionResult Delete(string id = null)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_SUMBERCPAR_COMPLAIN_DELETE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oData = oDS.getData(id);
            if (oData == null) { return HttpNotFound(); }
            return View(oData);
        }

        //Custom spesific lookup controller
        ProjectDS oDSProject = new ProjectDS();
        public ActionResult ShowProject(List<string> paSearchValue, List<string> paTargetTag)
        {
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);

            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            return View(oDSProject.getDatalist());
        } //End public ActionResult ShowProject


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    } //End public partial class ComplainController : Controller
} //End namespace APPBASE.Controllers

