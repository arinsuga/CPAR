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
    [Table("AC01ROLE")]
    public partial class Role
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string MDLE_RUID { get; set; }
        public string ROLE_ID { get; set; }
        public string ROLE_CAPTION { get; set; }
        public string ROLE_LANG_ID { get; set; }
    } //End public partial class Role
    [Table("VWAC01ROLE_INFO")]
    public partial class Role_info
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string MDLE_RUID { get; set; }
        public string MDLE_ID { get; set; }
        public string MDLE_CAPTION { get; set; }
        public string MDLE_LINKID { get; set; }
        public string ROLE_ID { get; set; }
        public string ROLE_CAPTION { get; set; }
        public string ROLE_LANG_ID { get; set; }
    } //End public partial class Role_info
    [Table("AC01ROLE_MNU")]
    public partial class Rolemenu
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string MDLE_RUID { get; set; }
        public string MNU_RUID { get; set; }
        public string ROLE_RUID { get; set; }
    } //End public partial class Rolemenu
    [Table("VWAC01ROLE_MNU_INFO")]
    public partial class Rolemenu_info
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string MDLE_RUID { get; set; }
        public int? MDLE_RSEQNO { get; set; }
        public string MDLE_ID { get; set; }
        public string MDLE_CAPTION { get; set; }
        public string MDLE_LANG_ID { get; set; }
        public string MDLE_LINK_ID { get; set; }
        public string MDLE_STYLE { get; set; }
        public string MDLE_IMG { get; set; }
        public string MNU_RUID { get; set; }
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
        public string ROLE_RUID { get; set; }
        public string ROLE_ID { get; set; }
        public string ROLE_CAPTION { get; set; }
        public string ROLE_LANG_ID { get; set; }
    } //End public partial class Rolemenu
} //End namespace APPBASE.Models

