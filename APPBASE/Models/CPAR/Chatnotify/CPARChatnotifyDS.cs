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
    [Table("VWCPAR01CHATCPAR_NOTIFY_INFO")]
    public class CPARChatnotify_info
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
        public string CPARCHAT_RUID { get; set; }
        public string USR_RUID { get; set; }
        public string USR_USRID { get; set; }
        public string USR_USRNM { get; set; }
        public string USR_ROLERUID { get; set; }
        public string USR_ROLENM { get; set; }
        public string USR_RESNM { get; set; }
        public string USR_DEPTNM { get; set; }
        public string USR_JOBTTLNM { get; set; }
        public string USR_IMG { get; set; }
        public string CPARCHAT_CPARRUID { get; set; }
        public string CPARCHAT_CPARID { get; set; }
        public DateTime? CPARCHAT_CPARDT { get; set; }
        public string CPARCHAT_USRRUID { get; set; }
        public string CPARCHAT_USRID { get; set; }
        public string CPARCHAT_USRNM { get; set; }
        public string CPARCHAT_ROLERUID { get; set; }
        public string CPARCHAT_ROLENM { get; set; }
        public string CPARCHAT_RESNM { get; set; }
        public string CPARCHAT_DEPTNM { get; set; }
        public string CPARCHAT_JOBTTLNM { get; set; }
        public string CPARCHAT_IMG { get; set; }
        public string CPARCHAT_DESCPLAIN { get; set; }
        public string CPARCHAT_DESCFMT { get; set; }
    } //End public class CPARChatnotify_info

    [Table("VWCPAR01NOTIF_CPARCHAT_INFO")]
    public class CPARNOTIF_CPARCHAT_info
    {
        //public string ADTRL_WKS { get; set; }
        //public string ADTRL_IP { get; set; }
        //public string ADTRL_USR { get; set; }
        //public string ADTRL_PRG { get; set; }
        //public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string CPAR_RUID { get; set; }
        public string CPAR_ID { get; set; }
        public DateTime? CPAR_DT { get; set; }
        public string USR_RUID { get; set; }
        public string USR_ID { get; set; }
        public string USR_NM { get; set; }
        public string USR_RESNM { get; set; }
        public int? COUNT_NOTIF { get; set; }
    } //End public class CPARChatnotify_info
} //End namespace APPBASE.Models

