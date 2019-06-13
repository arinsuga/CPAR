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
    public partial class LogbookComplainController : Controller
    {
        [HttpPost]
        public ActionResult Close(Complain_DetailVM poViewModel)
        {
            oVAL = new Complain_Validation(poViewModel);
            oVAL.Validate_Close();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Close(poViewModel);
                TempData["CRUDClosedOrCanceled"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.RUID });
            }
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Cancel(Complain_DetailVM poViewModel)
        {
            oVAL = new Complain_Validation(poViewModel);
            oVAL.Validate_Cancel();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Cancel(poViewModel);
                TempData["CRUDClosedOrCanceled"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.RUID });
            }
            return View(poViewModel);
        }
    } //End public partial class LogbookComplainController : Controller
} //End namespace APPBASE.Controllers

