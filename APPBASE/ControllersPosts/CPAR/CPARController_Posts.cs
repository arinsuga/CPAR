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
    public partial class CPARController : Controller
    {
        [HttpPost]
        public ActionResult Create(CPAR_DetailVM poViewModel)
        {
            CPAR_DetailVM oViewModel = poViewModel;
            oViewModel.CPAR_TYPE = this.CPAR_TYPE;
            oVAL = new CPAR_Validation(oViewModel);
            oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.setCPAR_TYPE(this.CPAR_TYPE);
                oCRUD.Create(poViewModel);
                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.RUID });
                //return RedirectToAction("Index");
            } //End if (ModelState.IsValid)

            //return View(poViewModel);
            ViewBag.CPAR_TYPE = this.CPAR_TYPE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            oDS.Init(oDSStdref, oDSLOVSubtype, oDSLOVClass);
            
            //var oData = oDS.getData_create();
            //oData.STDREF_LIST = new List<CPARStdref_ListVM>();

            if (poViewModel.STDREF_LIST == null) { poViewModel.STDREF_LIST = new List<CPARStdref_ListVM>(); }
            if (poViewModel.CPAR_SUBTYPE_LOV == null) { poViewModel.CPAR_SUBTYPE_LOV = oDSLOVSubtype.getDatalist(); }
            if (poViewModel.CLASS_RUID_LOV == null) { poViewModel.CLASS_RUID_LOV = oDSLOVClass.getDatalist(); }

            //return View("~/Views/CPAR/Create.cshtml", oData);
            return View("~/Views/CPAR/Create.cshtml", poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(CPAR_DetailVM poViewModel)
        {
            CPAR_DetailVM oViewModel = poViewModel;
            oViewModel.CPAR_TYPE = this.CPAR_TYPE;
            oVAL = new CPAR_Validation(oViewModel);
            oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Update(poViewModel);
                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Details", new { id = oCRUD.RUID });
            }

            ViewBag.CPAR_TYPE = this.CPAR_TYPE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;

            if (poViewModel.STDREF_LIST == null) { poViewModel.STDREF_LIST = new List<CPARStdref_ListVM>(); }
            if (poViewModel.CPAR_SUBTYPE_LOV == null) { poViewModel.CPAR_SUBTYPE_LOV = oDSLOVSubtype.getDatalist(); }
            if (poViewModel.CLASS_RUID_LOV == null) { poViewModel.CLASS_RUID_LOV = oDSLOVClass.getDatalist(); }

            return View("~/Views/CPAR/Edit.cshtml", poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            oCRUD.Delete(id);
            TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Patchmorefeature1(CPAR_DetailVM poViewModel)
        {
            CPAR_DetailVM oViewModel = poViewModel;
            oViewModel.CPAR_TYPE = this.CPAR_TYPE;
            oVAL = new CPAR_Validation(oViewModel);
            //oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.patch_morefeature1(poViewModel);
                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Patchmorefeature1");
            }

            ViewBag.CPAR_TYPE = this.CPAR_TYPE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;

            if (poViewModel.STDREF_LIST == null) { poViewModel.STDREF_LIST = new List<CPARStdref_ListVM>(); }
            if (poViewModel.CPAR_SUBTYPE_LOV == null) { poViewModel.CPAR_SUBTYPE_LOV = oDSLOVSubtype.getDatalist(); }
            if (poViewModel.CLASS_RUID_LOV == null) { poViewModel.CLASS_RUID_LOV = oDSLOVClass.getDatalist(); }

            return View("~/Views/CPAR/Patchmorefeature1.cshtml", poViewModel);
        }
        [HttpPost]
        public ActionResult Patchhotfix2(CPAR_DetailVM poViewModel)
        {
            CPAR_DetailVM oViewModel = poViewModel;
            oViewModel.CPAR_TYPE = this.CPAR_TYPE;
            oVAL = new CPAR_Validation(oViewModel);
            //oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.patch_hotfix2();
                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Patchhotfix2");
            }

            ViewBag.CPAR_TYPE = this.CPAR_TYPE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;

            if (poViewModel.STDREF_LIST == null) { poViewModel.STDREF_LIST = new List<CPARStdref_ListVM>(); }
            if (poViewModel.CPAR_SUBTYPE_LOV == null) { poViewModel.CPAR_SUBTYPE_LOV = oDSLOVSubtype.getDatalist(); }
            if (poViewModel.CLASS_RUID_LOV == null) { poViewModel.CLASS_RUID_LOV = oDSLOVClass.getDatalist(); }

            return View("~/Views/CPAR/Patchhotfix2.cshtml", poViewModel);
        }
        [HttpPost]
        public ActionResult Patchhotfix3(CPAR_DetailVM poViewModel)
        {
            CPAR_DetailVM oViewModel = poViewModel;
            oViewModel.CPAR_TYPE = this.CPAR_TYPE;
            oVAL = new CPAR_Validation(oViewModel);
            //oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.patch_hotfix3();
                TempData["CRUDSavedOrDelete"] = valFLAG.FLAG_TRUE;
                return RedirectToAction("Patchhotfix3");
            }

            ViewBag.CPAR_TYPE = this.CPAR_TYPE;
            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;

            if (poViewModel.STDREF_LIST == null) { poViewModel.STDREF_LIST = new List<CPARStdref_ListVM>(); }
            if (poViewModel.CPAR_SUBTYPE_LOV == null) { poViewModel.CPAR_SUBTYPE_LOV = oDSLOVSubtype.getDatalist(); }
            if (poViewModel.CLASS_RUID_LOV == null) { poViewModel.CLASS_RUID_LOV = oDSLOVClass.getDatalist(); }

            return View("~/Views/CPAR/Patchhotfix3.cshtml", poViewModel);
        }

        private StandardreffDS oDSStandardreff = new StandardreffDS();
        public ActionResult ShowStandardreff(List<string> paExistinglist, List<string> paSelectedlist)
        {
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);
            List<string> vaListitems = null;
            if (paExistinglist != null) { vaListitems = paExistinglist; } //End if (paExistinglist != null)
            if (paSelectedlist != null) {
                vaListitems = new List<string>();
                foreach (var item in paSelectedlist)
                {
                    vaListitems.Add(item);
                } //End foreach (var item in paSelectedlist)
            } //End if (paSelectedlist != null)
            return View("~/Views/CPAR/ShowStandardreff.cshtml", oDSStandardreff.getDatalist_lookupNotin(vaListitems));
            //return View(oDSStandardreff.getDatalist_lookupNotin(vaListitems));
        } //End public ActionResult ShowStandardreff
        public ActionResult ShowStandardreff_resultlist(List<string> paExistinglist, List<string> paSelectedlist, List<string> paSelectnewlist)
        {
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);

            //TODO: Nanti di improve di oDSStandardreff supaya single trip database retrieve
            ViewBag.oModel_existing = oDSStandardreff.getDatalist_lookupadditems(paExistinglist);
            ViewBag.oModel_selected = oDSStandardreff.getDatalist_lookupadditems(paSelectedlist);
            ViewBag.oModel_selectnew = oDSStandardreff.getDatalist_lookupadditems(paSelectnewlist);
            return View("~/Views/CPAR/ShowStandardreff_resultlist.cshtml");
            //return View();
        } //End public ActionResult ShowStandardreff
    } //End public partial class CPARController : Controller
} //End namespace APPBASE.Controllers

