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
    public partial class EmployeeController : Controller
    {
        [HttpPost]
        public ActionResult Create(Employee_DetailVM poViewModel, HttpPostedFileBase Fileimage)
        {

            oVAL = new Employee_Validation(poViewModel, Fileimage);
            oVAL.Validate_Create();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Create(poViewModel, Fileimage);
                return RedirectToAction("Index");
            } //End if (ModelState.IsValid)

            ViewBag.CRUD_type = hlpFlags_CRUDOption.CREATE;
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult Edit(Employee_DetailVM poViewModel, HttpPostedFileBase Fileimage)
        {
            oVAL = new Employee_Validation(poViewModel, Fileimage);
            oVAL.Validate_Edit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Update(poViewModel, Fileimage);
                return RedirectToAction("Index");
            }

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            return View(poViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            oCRUD.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Career(Employee_DetailVM poViewModel)
        {
            oVAL = new Employee_Validation(poViewModel);
            oVAL.Validate_Career();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.Career(poViewModel);
                return RedirectToAction("Index");
            }
            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult EditQuit(Employee_DetailVM poViewModel)
        {
            oVAL = new Employee_Validation(poViewModel);
            oVAL.Validate_EditQuit();

            //Add Error if exists
            for (int i = 0; i < oVAL.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL.aValidationMSG[i].VAL_ERRID, oVAL.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                oCRUD.UpdateQuit(poViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.CRUD_type = hlpFlags_CRUDOption.UPDATE;
            return View(poViewModel);
        }
    } //End public ActionResult EditQuit(Employee_DetailVM poViewModel, HttpPostedFileBase Fileimage)
} //End namespace APPBASE.Controllers

