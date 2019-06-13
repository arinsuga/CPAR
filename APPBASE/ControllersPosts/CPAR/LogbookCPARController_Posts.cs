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
    public partial class LogbookCPARController : Controller
    {
        [HttpPost]
        public ActionResult Index(FilterCPAR_DetailVM poViewModel)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_CPAR_INDEX;

            oVAL_filterCPAR = new FilterCPAR_Validation(poViewModel);
            oVAL_filterCPAR.Validate_Export();

            //Add Error if exists
            for (int i = 0; i < oVAL_filterCPAR.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL_filterCPAR.aValidationMSG[i].VAL_ERRID, oVAL_filterCPAR.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
            } //End if (ModelState.IsValid)

            FilterCPAR_DetailVM oViewModel = new FilterCPAR_DetailVM();
            ViewBag.CLASS_RUID_LOV = oDSLOVClass.getDatalist();
            ViewBag.CPAR_STS_LOV = oDSLOVCPARsts.getDatalist();
            ViewBag.Model = oDS.getDatalist_logbook(poViewModel);
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Response(CPAR_VerifyVM poViewModel)
        {
            oVAL = new CPAR_Validation(poViewModel);
            oVAL.Validate_Response();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Response(poViewModel);
                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.RUID });
            }

            if (poViewModel.STDREF_LIST == null) { poViewModel.STDREF_LIST = new List<CPARStdref_ListVM>(); }
            if (poViewModel.CPAR_SUBTYPE_LOV == null) { poViewModel.CPAR_SUBTYPE_LOV = oDSLOVSubtype.getDatalist(); }
            if (poViewModel.CLASS_RUID_LOV == null) { poViewModel.CLASS_RUID_LOV = oDSLOVClass.getDatalist(); }
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Verify(CPAR_VerifyVM poViewModel)
        {
            oVAL = new CPAR_Validation(poViewModel);
            oVAL.Validate_Verify();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Verify(poViewModel);
                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.RUID });
            }
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Close(CPAR_VerifyVM poViewModel)
        {
            poViewModel.CPAR_STEP = oDS.getData_CPAR_STEP(poViewModel.RUID);
            oVAL = new CPAR_Validation(poViewModel);
            oVAL.Validate_Close();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Close(poViewModel);
                //TempData["CRUDClosedOrCanceled"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.RUID });
            }
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Cancel(CPAR_VerifyVM poViewModel)
        {
            oVAL = new CPAR_Validation(poViewModel);
            oVAL.Validate_Cancel();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Cancel(poViewModel);
                //TempData["CRUDClosedOrCanceled"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.RUID });
            }
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Chat(CPARChat_DetailVM poViewModel)
        {
            oVALChat = new CPARChat_Validation(poViewModel);
            oVALChat.Validate_Chat();

            //Add Error if exists
            for (int i = 0; i < oVALChat.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVALChat.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUDChat.Create(poViewModel);
                //TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Chat", new { id = poViewModel.CPAR_RUID });
            }
            return View(poViewModel);
        }
    } //End public partial class LogbookCPARController : Controller
} //End namespace APPBASE.Controllers

