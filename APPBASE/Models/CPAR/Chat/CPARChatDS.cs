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
    [Table("VWCPAR01CHATCPAR_INFO")]
    public class CPARChat_info
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
        public string CPAR_RUID { get; set; }
        public string CPAR_ID { get; set; }
        public DateTime? CPAR_DT { get; set; }
        public string CPAR_DESC { get; set; }
        public string CPAR_STEP { get; set; }
        public string CPAR_STEP_ID { get; set; }
        public string CPAR_STEP_NM { get; set; }
        public string CPAR_TYPE { get; set; }
        public string CPAR_TYPE_ID { get; set; }
        public string CPAR_TYPE_NM { get; set; }
        public string CPAR_SUBTYPE { get; set; }
        public string CPAR_SUBTYPE_ID { get; set; }
        public string CPAR_SUBTYPE_NM { get; set; }
        public string AUDITOR_RUID { get; set; }
        public string AUDITOR_ID { get; set; }
        public string AUDITOR_NM { get; set; }
        public string AUDITORDEPT_RUID { get; set; }
        public string AUDITORDEPT_ID { get; set; }
        public string AUDITORDEPT_NM { get; set; }
        public string AUDITEE_RUID { get; set; }
        public string AUDITEE_ID { get; set; }
        public string AUDITEE_NM { get; set; }
        public string AUDITEEDEPT_RUID { get; set; }
        public string AUDITEEDEPT_ID { get; set; }
        public string AUDITEEDEPT_NM { get; set; }
        public string USR_RUID { get; set; }
        public string USR_ID { get; set; }
        public string USR_NM1 { get; set; }
        public string ROLE_RUID { get; set; }
        public string ROLE_ID { get; set; }
        public string ROLE_NM { get; set; }
        public string RES_RUID { get; set; }
        public string RES_ID { get; set; }
        public string RES_NM1 { get; set; }
        public string DEPT_RUID { get; set; }
        public string DEPT_ID { get; set; }
        public string DEPT_NM { get; set; }
        public string JOB_TITLE_RUID { get; set; }
        public string JOB_TITLE_ID { get; set; }
        public string JOB_TITLE_NM { get; set; }
        public string IMG_SRC { get; set; }
        public string CHAT_DESC_PLAIN { get; set; }
        public string CHAT_DESC_FMT { get; set; }
    } //End public class CPARChat_info
} //End namespace APPBASE.Models

