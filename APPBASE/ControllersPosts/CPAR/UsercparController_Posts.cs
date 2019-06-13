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
    public partial class UsercparController : Controller
    {
        [HttpPost]
        public ActionResult Index(User_DetailCPARVM poViewModel)
        {
            var oData = oDS.getDatalist(poViewModel);
            return View(oData);
        }
        [HttpPost]
        public ActionResult Create(User_DetailCPARVM poViewModel, HttpPostedFileBase Fileimage)
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            oVAL = new User_Validation(poViewModel, Fileimage);
            oVAL.Validate_UserCreateCPAR();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.CreateCPAR(poViewModel, Fileimage);
                if (oCRUD.RUID != null) { return RedirectToAction("Role", new { id = oCRUD.RUID }); }
                else { return RedirectToAction("Index"); }
            } //End if (ModelState.IsValid)

            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(User_DetailCPARVM poViewModel, HttpPostedFileBase Fileimage)
        {
            oVAL = new User_Validation(poViewModel, Fileimage);
            oVAL.Validate_UserUpdateCPAR();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.UpdateCPAR(poViewModel, Fileimage);
                if (oCRUD.RUID != null) { return RedirectToAction("Details", new { id = oCRUD.RUID }); }
                else { return RedirectToAction("Index"); }
            }
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            oCRUD.DeleteCPAR(id);
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Activate")]
        public ActionResult ActivateConfirm(string id)
        {
            if (ModelState.IsValid) { oCRUD.ActivateCPAR(id); }
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Deactivate")]
        public ActionResult DeactivateConfirm(string id)
        {
            if (ModelState.IsValid) { oCRUD.DeactivateCPAR(id); }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Role(Userrole_DetailCPARVM poViewModel)
        {
            oCRUD.Create_UsermenuCPAR(poViewModel, hlpConfig.ConstantaInfo.MDLE_RUID);
            return RedirectToAction("Index");
        }
    } //End public partial class UsercparController : Controller
} //End namespace APPBASE.Controllers