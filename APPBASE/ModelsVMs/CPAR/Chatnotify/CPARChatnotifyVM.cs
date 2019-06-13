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
    public partial class CPARChatnotify_ListVM
    {
        public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
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
    } //End public partial class CPARChatnotify_ListVM
    public partial class CPARChatnotify_DetailVM
    {
        public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
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
    } //End public partial class CPARChatnotify_DetailVM

    public class CPARNOTIF_CPARCHATVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string CPAR_RUID { get; set; }
        public string CPAR_ID { get; set; }
        public DateTime? CPAR_DT { get; set; }
        public string USR_RUID { get; set; }
        public string USR_ID { get; set; }
        public string USR_NM { get; set; }
        public string USR_RESNM { get; set; }
        public int? COUNT_NOTIF { get; set; }
    } //End public class CPARNOTIF_CPARCHATVM
} //End namespace APPBASE.Models

