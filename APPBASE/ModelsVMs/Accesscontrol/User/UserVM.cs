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
    public partial class UserloginVM
    {
        [Required]
        [Display(Name = lblFIELD.USR_NM)]
        public string USR_ID { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = lblFIELD.USR_PSWD)]
        public string USR_PSWD { get; set; }
    } //End public partial class User
    public partial class User_ListVM : SEARCH_USER {
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
        [Display(Name = lblFIELD.USR_NM)]
        public string USR_NM1 { get; set; }
        public string RES_RUID { get; set; }
        [Display(Name = lblFIELD.RES_NM)]
        public string RES_NM1 { get; set; }
        [Display(Name = lblFIELD.DEPT_NM)]
        public string DEPT_NM { get; set; }
        [Display(Name = lblFIELD.BRNCH_NM)]
        public string BRNCH_NM { get; set; }
        [Display(Name = lblFIELD.JOB_TITLE_NM)]
        public string JOB_TITLE_NM { get; set; }
        public string IMG_SRC { get; set; }
    } //End public partial class User_ListVM : SEARCH_USER
    public partial class User_DetailVM
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
        public string BRNCH_RUID { get; set; }
        [Display(Name = lblFIELD.BRNCH_NM)]
        public string BRNCH_NM { get; set; }
        public string JOB_TITLE_RUID { get; set; }
        [Display(Name = lblFIELD.JOB_TITLE_NM)]
        public string JOB_TITLE_NM { get; set; }
        public string IMG_SRC { get; set; }
    } //End public partial class User_DetailVM

    public partial class UserMenuVM
    {
        public string RUID { get; set; }
        public string USR_RUID { get; set; }
        public string MDLE_RUID { get; set; }
        public string MNU_RUID { get; set; }
        public string IS_GRANTED { get; set; }
        public string MNU_CAPTION { get; set; }
        public string MNU_PARENT_RUID { get; set; }
        public int? MNU_LEVEL { get; set; }
        public string MNU_TYPE { get; set; }
        public string MNU_ISVISIBLE { get; set; }
    } //End public partial class Usermenu_info

    public class Userrole_DetailVM : User_DetailVM
    {
        public List<Userrolemenu_ListVM> Userrolemenu_ListVM { get; set; }
    } //End public class Userrole_DetailVM : User_DetailVM
    public class Userrolemenu_ListVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string USR_RUID { get; set; }
        public string MDLE_RUID { get; set; }
        public string MDLE_CAPTION { get; set; }
        public string MNU_RUID { get; set; }
        public int? MNU_RSEQNO { get; set; }
        public string MNU_CAPTION { get; set; }
        public string MNU_PARENT_RUID { get; set; }
        public int? MNU_LEVEL { get; set; }
        public string MNU_TYPE { get; set; }
        public string MNU_ISVISIBLE { get; set; }
        public string ROLE_RUID { get; set; }
        public string ROLE_CAPTION { get; set; }
        public string ISGRANTED { get; set; }
    } //End public class Userrolemenu_ListVM

    public partial class lkpResForUserVM
    {
        public string RUID { get; set; }
        public string RES_ID { get; set; }
        public string RES_NM1 { get; set; }
        public string BRNCH_NM { get; set; }
        public string DEPT_NM { get; set; }
        public string JOB_TITLE_NM { get; set; }
    } //End public partial class UserlistVM

} //End namespace APPBASE.Models
