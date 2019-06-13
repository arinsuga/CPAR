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
    public partial class CPARCPARStdref_LogbookVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string CPAR_STS { get; set; }
        public string CPAR_STS_ID { get; set; }
        public string CPAR_STS_NM { get; set; }
        public string CPAR_STEP { get; set; }
        public string CPAR_STEP_ID { get; set; }
        public string CPAR_STEP_NM { get; set; }
        public string CPAR_ID { get; set; }
        public DateTime? CPAR_DT { get; set; }
        public DateTime? CPAR_TRGT_DT { get; set; }
        public DateTime? CPAR_FINISH_DT { get; set; }
        public string CPAR_DESC { get; set; }
        public string CPAR_RESOLUTION1 { get; set; }
        public string CPAR_RESOLUTION2 { get; set; }
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
        
        public string AUDIT_RUID { get; set; }
        public string AUDIT_ID { get; set; }
        public string AUDIT_NM { get; set; }
        public string AUDITDEPT_RUID { get; set; }
        public string AUDITDEPT_ID { get; set; }
        public string AUDITDEPT_NM { get; set; }
        public string CLASS_RUID { get; set; }
        public string CLASS_ID { get; set; }
        public string CLASS_NM { get; set; }
        public DateTime? VFKS1_DT { get; set; }
        public string VFKS1_DESC { get; set; }
        public DateTime? VFKS2_DT { get; set; }
        public string VFKS2_DESC { get; set; }
        public DateTime? VFKS3_DT { get; set; }
        public string VFKS3_DESC { get; set; }
        public DateTime? VFKS4_DT { get; set; }
        public string VFKS4_DESC { get; set; }
        public DateTime? VFKS5_DT { get; set; }
        public string VFKS5_DESC { get; set; }
        public string COMPLAIN_RUID { get; set; }
        public string COMPLAIN_ID { get; set; }
        public string COMPLAIN_NM { get; set; }
        public string STDREF_RUID { get; set; }
        public string STDREFLOV_RUID { get; set; }
        public string STDREFLOV_ID { get; set; }
        public string STDREFLOV_NM { get; set; }
    } //End public partial class CPARCPARStdref_LogbookVM

} //End namespace APPBASE.Models
