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
    public partial class UserController : Controller
    {
        [HttpPost]
        public ActionResult Create(User_DetailVM poViewModel)
        {
            
            oVAL = new User_Validation(poViewModel);
            oVAL.Validate_UserCreate();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Create(poViewModel);
                return RedirectToAction("Index");
            } //End if (ModelState.IsValid)

            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(User_DetailVM poViewModel)
        {
            if (ModelState.IsValid)
            {
                oCRUD.Update(poViewModel);
                return RedirectToAction("Index");
            }
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            oCRUD.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Activate")]
        public ActionResult ActivateConfirm(string id)
        {
            if (ModelState.IsValid) { oCRUD.Activate(id); }
            return RedirectToAction("Index");
        }
        [HttpPost, ActionName("Deactivate")]
        public ActionResult DeactivateConfirm(string id)
        {
            if (ModelState.IsValid) { oCRUD.Deactivate(id); }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Role(Userrole_DetailCPARVM poViewModel)
        {
            oCRUD.Create_UsermenuCPAR(poViewModel, hlpConfig.ConstantaInfo.MDLE_RUID);
            return RedirectToAction("Index");
        }
    } //End public partial class UserController : Controller
} //End namespace APPBASE.Controllers