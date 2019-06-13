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
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    [Table("AC01USR")]
    public partial class User : CRUD
    {
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string ROLE_RUID { get; set; }
        public string USR_PSWD { get; set; }
        public string USR_ID { get; set; }
        public string USR_NM1 { get; set; }
        public string USR_NM2 { get; set; }
        public string USR_NM3 { get; set; }
        public string USR_NM4 { get; set; }
        public string USR_NM5 { get; set; }
        public string RES_RUID { get; set; }
    } //End public partial class User
    [Table("VWAC01USR_INFO")]
    public partial class User_info
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string ROLE_RUID { get; set; }
        public string ROLE_ID { get; set; }
        public string ROLE_NM { get; set; }
        public string ROLE_LANGID { get; set; }
        public string USR_PSWD { get; set; }
        public string USR_ID { get; set; }
        public string USR_NM1 { get; set; }
        public string USR_NM2 { get; set; }
        public string USR_NM3 { get; set; }
        public string USR_NM4 { get; set; }
        public string USR_NM5 { get; set; }
        public string RES_RUID { get; set; }
        public string RES_ID { get; set; }
        public string RES_NM1 { get; set; }
        public string RES_NM2 { get; set; }
        public string RES_NM3 { get; set; }
        public string DEPT_RUID { get; set; }
        public string DEPT_ID { get; set; }
        public string DEPT_NM { get; set; }
        public string BRNCH_RUID { get; set; }
        public string BRNCH_ID { get; set; }
        public string BRNCH_NM { get; set; }
        public string JOB_TITLE_RUID { get; set; }
        public string JOB_TITLE_ID { get; set; }
        public string JOB_TITLE_NM { get; set; }
        public string RES_TYPE { get; set; }
        public string IMG_SRC { get; set; }
    } //End public partial class User

    [Table("AC01USR_MNU")]
    public partial class Usermenu : CRUD
    {
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string USR_RUID { get; set; }
        public string MDLE_RUID { get; set; }
        public string MNU_RUID { get; set; }
        public string IS_GRANTED { get; set; }
    } //End public partial class Usermenu : CRUD
    [Table("VWAC01USR_MNU_CSTM01")]
    public partial class Usermenu_info
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string USR_RUID { get; set; }
        public string MDLE_RUID { get; set; }
        public string MNU_RUID { get; set; }
        public string IS_GRANTED { get; set; }
        public int? MNU_RSEQNO { get; set; }
        public string MNU_ID { get; set; }
        public string MNU_CAPTION { get; set; }
        public string MNU_LANG_ID { get; set; }
        public string MNU_LINK_ID { get; set; }
        public string MNU_PARENT_RUID { get; set; }
        public int? MNU_LEVEL { get; set; }
        public string MNU_STYLE { get; set; }
        public string MNU_IMG { get; set; }
        public string MNU_TYPE { get; set; }
        public string MNU_ISVISIBLE { get; set; }
    } //End public partial class Usermenu_info
} //End namespace APPBASE.Models

