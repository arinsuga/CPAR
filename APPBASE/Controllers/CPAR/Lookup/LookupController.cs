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
        AuditDS oDSAudit = new AuditDS();
        public ActionResult ShowAudit(List<string> paSearchValue, List<string> paTargetTag)
        {
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);

            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            return View(oDSAudit.getDatalist_lookup());
        } //End public ActionResult ShowAudit
        StandardreffDS oDSStandardreff = new StandardreffDS();
        public ActionResult ShowStandardreff(List<string> paSearchValue, List<string> paTargetTag)
        {
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);

            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            return View(oDSStandardreff.getDatalist_lookup());
        } //End public ActionResult ShowStandardreff
        CPARTypeDS oDSCPARType = new CPARTypeDS();
        public ActionResult ShowCPARType(List<string> paSearchValue, List<string> paTargetTag)
        {
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);

            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            return View(oDSCPARType.getDatalist());
        } //End public ActionResult ShowCPARType

    } //End public class LookupController : Controller
} //End namespace APPBASE.Controllers
