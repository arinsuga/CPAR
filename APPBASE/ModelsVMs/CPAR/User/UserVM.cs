using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using APPBASE.Helpers;
using APPBASE.Models;
//using APPBASE.Svcapp;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class User_DetailCPARVM
    {
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        [Display(Name = lblFIELD.USR_STS)]
        public string BP_STS_NM { get; set; }
        public string ROLE_RUID { get; set; }
        [Display(Name = lblFIELD.ROLE_NM)]
        public string ROLE_NM { get; set; }
        [Display(Name = lblFIELD.USR_ID)]
        public string USR_ID { get; set; }
        [Display(Name = lblFIELD.USR_PSWD)]
        public string USR_PSWD { get; set; }
        [Display(Name = lblFIELD.USR_NM)]
        public string USR_NM1 { get; set; }
        public string RES_RUID { get; set; }
        [Display(Name = lblFIELD.RES_NM)]
        public string RES_NM1 { get; set; }
        public string DEPT_RUID { get; set; }
        [Display(Name = lblFIELD.DEPT_NM)]
        public string DEPT_NM { get; set; }
        [Display(Name = lblFIELD.BRNCH_NM)]
        public string BRNCH_NM { get; set; }
        [Display(Name = lblFIELD.JOB_TITLE_NM)]
        public string JOB_TITLE_NM { get; set; }
        public string IMG_SRC { get; set; }


        public string FILTER_NAMA { get; set; }
        public string FILTER_DEPARTEMEN { get; set; }
        public string FILTER_ROLE { get; set; }
    } //End public partial class User_DetailCPARVM
    public class Userrole_DetailCPARVM : User_DetailCPARVM
    {
        public List<Userrolemenu_ListVM> Userrolemenu_ListVM { get; set; }
    } //End public class Userrole_DetailCPARVM : User_DetailCPARVM
} //End namespace APPBASE.Models
