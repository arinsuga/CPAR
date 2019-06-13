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
    public partial class ComplainController : Controller
    {
        [HttpPost]
        public ActionResult Create(Complain_DetailVM poViewModel)
        {

            oVAL = new Complain_Validation(poViewModel);
            oVAL.Validate_Create();

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

            ViewBag.COMPLAIN_TYPE_LOV = oDSComplaintype.getDatalist();
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(Complain_DetailVM poViewModel)
        {
            oVAL = new Complain_Validation(poViewModel);
            oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Update(poViewModel);
                return RedirectToAction("Index");
            }
            ViewBag.COMPLAIN_TYPE_LOV = oDSComplaintype.getDatalist();
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            oCRUD.Delete(id);
            return RedirectToAction("Index");
        }
    } //End public partial class ComplainController : Controller
} //End namespace APPBASE.Controllers

