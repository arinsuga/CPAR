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
    public partial class CPARChat_ListVM
    {
        public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string CPAR_RUID { get; set; }
        public string CPAR_ID { get; set; }
        public DateTime? CPAR_DT { get; set; }
        public string CPAR_DESC { get; set; }
        
        public string USR_RUID { get; set; }
        public string USR_ID { get; set; }
        public string USR_NM1 { get; set; }
        public string ROLE_RUID { get; set; }
        public string ROLE_ID { get; set; }
        public string ROLE_NM { get; set; }
        public string RES_RUID { get; set; }
        public string RES_ID { get; set; }
        public string RES_NM1 { get; set; }
        public string IMG_SRC { get; set; }
        public string CHAT_DESC_PLAIN { get; set; }
        public string CHAT_DESC_FMT { get; set; }
    } //End public partial class CPARChat_ListVM
    public partial class CPARChat_DetailVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string CPAR_RUID { get; set; }
        public string CPAR_ID { get; set; }
        public DateTime? CPAR_DT { get; set; }
        public string CPAR_DESC { get; set; }
        public string USR_RUID { get; set; }
        public string CHAT_DESC_PLAIN { get; set; }
        public string CHAT_DESC_FMT { get; set; }
        public List<CPARChat_ListVM> CPARCHAT { get; set; }
    } //End public partial class CPARChat_DetailVM
} //End namespace APPBASE.Models

