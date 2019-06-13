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
    [MyActionFilterAttribute]
    public partial class LookupController : Controller
    {
        private DBMAINContext db = new DBMAINContext();
        private EmployeeDS oDSEmployee = new EmployeeDS();
        private RoleDS oDSRole = new RoleDS();

        //Common
        public ActionResult ShowDept(List<string> paSearchValue, List<string> paTargetTag)
        {
            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);
            List<Department> MyLookup = new List<Department>();
            using (var dbmain = new DBMAINContext())
            {
                MyLookup = dbmain.Departments.ToList();
            } //End using (var dbmain = new DBMAINContext())
            return View(MyLookup);
        } //End public ActionResult ShowDept
        public ActionResult ShowEmp(List<string> paSearchValue, List<string> paTargetTag)
        {
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);
            string sDEPT_RUID = "";
            //Filter Data
            if (paSearchValue.Count > 0)
            {
                sDEPT_RUID = paSearchValue[0];
            } //End if (paSearchValue.Count > 0)

            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            //Get dataset by Departement
            return View(oDSEmployee.getDatalist_jobattr(sDEPT_RUID));
        } //End public ActionResult ShowEmp
        public ActionResult ShowJobttl(List<string> paSearchValue, List<string> paTargetTag)
        {
            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);
            List<Jobttl> MyLookup = new List<Jobttl>();
            using (var dbmain = new DBMAINContext())
            {
                MyLookup = dbmain.Jobttls.ToList();
            } //End using (var dbmain = new DBMAINContext())
            return View(MyLookup);
        } //End public ActionResult ShowDept
        public ActionResult ShowEmployeests(List<string> paSearchValue, List<string> paTargetTag)
        {
            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);
            List<Employeests> MyLookup = new List<Employeests>();
            using (var dbmain = new DBMAINContext())
            {
                MyLookup = dbmain.Employeestss.ToList();
            } //End using (var dbmain = new DBMAINContext())
            return View(MyLookup);
        } //End public ActionResult ShowEmployeests
        public ActionResult ShowCountry(List<string> paSearchValue, List<string> paTargetTag)
        {
            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);
            List<Country> MyLookup = new List<Country>();
            using (var dbmain = new DBMAINContext())
            {
                MyLookup = dbmain.Countrys.ToList();
            } //End using (var dbmain = new DBMAINContext())
            return View(MyLookup);
        } //End public ActionResult ShowDept
        public ActionResult ShowCity(List<string> paSearchValue, List<string> paTargetTag)
        {
            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);
            List<City> MyLookup = new List<City>();
            using (var dbmain = new DBMAINContext())
            {
                MyLookup = dbmain.Citys.ToList();
            } //End using (var dbmain = new DBMAINContext())
            return View(MyLookup);
        } //End public ActionResult ShowDept
        public ActionResult ShowReligion(List<string> paSearchValue, List<string> paTargetTag)
        {
            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);
            List<Religion> MyLookup = new List<Religion>();
            using (var dbmain = new DBMAINContext())
            {
                MyLookup = dbmain.Religions.ToList();
            } //End using (var dbmain = new DBMAINContext())
            return View(MyLookup);
        } //End public ActionResult ShowDept
        public ActionResult ShowSex(List<string> paSearchValue, List<string> paTargetTag)
        {
            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);
            List<Sex> MyLookup = new List<Sex>();
            using (var dbmain = new DBMAINContext())
            {
                MyLookup = dbmain.Sexs.ToList();
            } //End using (var dbmain = new DBMAINContext())
            return View(MyLookup);
        } //End public ActionResult ShowDept
        public ActionResult ShowMaritalsts(List<string> paSearchValue, List<string> paTargetTag)
        {
            //Tag to Target
            ViewBag.RUID_TAG = paTargetTag[0];
            ViewBag.ID_TAG = paTargetTag[1];
            ViewBag.NAME_TAG = paTargetTag[2];
            //TODO: Buat Access Control untuk lookup tertentu/Pilih Akses kontrol yang pas dari menu
            //hlpSecurity.CredentialInfo.isValidAccessMenu(MNURUID_CCS_INPUT_PJX_REG);
            List<Maritalsts> MyLookup = new List<Maritalsts>();
            using (var dbmain = new DBMAINContext())
            {
                MyLookup = dbmain.Maritalstss.ToList();
            } //End using (var dbmain = new DBMAINContext())
            return View(MyLookup);
        } //End public ActionResult ShowDept
    } //End public class LookupController : Controller
} //End namespace APPBASE.Controllers
