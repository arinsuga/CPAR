using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Filters;
using APPBASE.Svcbiz;

namespace APPBASE.Controllers
{
    public partial class LookupController : Controller
    {
        public ActionResult ShowUserRes_getData(List<string> paSearchValue, List<string> paTargetTag)
        {
            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            ViewBag.RSLTDATA_URL = paTargetTag[3];
            ViewBag.RSLTDATA_TAG = paTargetTag[4];
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);
            return View(lkpResForUserVM.getDatalist());
        } //End public ActionResult ShowUserRes_getData

    } //End public class LookupController : Controller
} //End namespace APPBASE.Controllers
