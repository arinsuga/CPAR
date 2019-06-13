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
    public partial class ProjectController : Controller
    {
        [HttpPost]
        public ActionResult Create(Project_DetailVM poViewModel)
        {

            oVAL = new Project_Validation(poViewModel);
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

            if (poViewModel.PROJ_STS_LOV == null) { poViewModel.PROJ_STS_LOV = oDSProjectsts.getDatalist_combobox(); }
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(Project_DetailVM poViewModel)
        {
            oVAL = new Project_Validation(poViewModel);
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

            if (poViewModel.PROJ_STS_LOV == null) { poViewModel.PROJ_STS_LOV = oDSProjectsts.getDatalist_combobox(); }
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            ViewBag.CRUD_type = hlpFlags_CRUDOption.DELETE;
            var oViewModel = oDS.getData(id);
            if (oViewModel != null) { oViewModel.PROJ_STS_LOV = oDSProjectsts.getDatalist_combobox(); }
            oVAL = new Project_Validation(oViewModel);
            oVAL.Validate_Delete();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Delete(id);
                return RedirectToAction("Index");
            }

            return View(oViewModel);
        }
    } //End public partial class ProjectController : Controller
} //End namespace APPBASE.Controllers

