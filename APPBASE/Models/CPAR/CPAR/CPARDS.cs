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
    [Table("VWCPAR01CPAR_INFO")]
    public class CPAR_info
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
        public string CPAR_RESOLUTION3 { get; set; }
        public string CPAR_TYPE { get; set; }
        public string CPAR_TYPE_ID { get; set; }
        public string CPAR_TYPE_NM { get; set; }
        public string CPAR_SUBTYPE { get; set; }
        public string CPAR_SUBTYPE_ID { get; set; }
        public string CPAR_SUBTYPE_NM { get; set; }
        //
        public string AUDITOR_RUID { get; set; }
        public string AUDITOR_ID { get; set; }
        public string AUDITOR_NM { get; set; }
        public string AUDITOR_USRRUID { get; set; }
        public string AUDITORDEPT_RUID { get; set; }
        public string AUDITORDEPT_ID { get; set; }
        public string AUDITORDEPT_NM { get; set; }
        //
        public string AUDITEE_RUID { get; set; }
        public string AUDITEE_ID { get; set; }
        public string AUDITEE_NM { get; set; }
        public string AUDITEE_USRRUID { get; set; }
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
        public string COMPLAIN_CLIENTRUID { get; set; }
        public string OWNER_NM { get; set; }

        public DateTime? CPAR_RSPN_DT { get; set; }
        public DateTime? CPAR_RSPNLMT_DT { get; set; }
        public DateTime? CPAR_VER_DT { get; set; }
        public DateTime? CPAR_VERLMT_DT { get; set; }

        public string VFKS1_PIC { get; set; }
        public string VFKS2_PIC { get; set; }
        public string VFKS3_PIC { get; set; }
        public string VFKS4_PIC { get; set; }
        public string VFKS5_PIC { get; set; }
    } //End public class CPAR_info
    [Table("VWCPAR01CPARSTDREF_INFO")]
    public class CPARCPARStdref_info
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
        public string CPAR_RESOLUTION3 { get; set; }
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
        public string OWNER_NM { get; set; }
    } //End public class CPARCPARStdref_info

    //Tidak ditambahkan field OWNER_NM karena akan merusak grouping
    [Table("VWCPAR01NOTIF_CPAR_INFO")]
    public class CPARNOTIF_info
    {
        //public string ADTRL_WKS { get; set; }
        //public string ADTRL_IP { get; set; }
        //public string ADTRL_USR { get; set; }
        //public string ADTRL_PRG { get; set; }
        //public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string CPAR_STS { get; set; }
        public string AUDITOR_RUID { get; set; }
        public string AUDITEE_RUID { get; set; }
        public string AUDITEEDEPT_RUID { get; set; }
        public int? PRECREATE { get; set; }
        public int? CREATED { get; set; }
        public int? RESPONDED { get; set; }
        public int? VERIFIED { get; set; }
    } //End public class CPARNOTIF_info

    [Table("VWCPAR01YEARALL_INFO")]
    public class CPARYEARALL_info
    {
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public int? CPAR_YEARS { get; set; }
        public string AUDITEE_RUID { get; set; }
        public int? CPAR_IA { get; set; }
        public int? CPAR_TM { get; set; }
        public int? CPAR_PP { get; set; }
        public int? CPAR_PI { get; set; }
        public int? CPAR_CC { get; set; }
        public int? CPAR_LL { get; set; }
    } //End public class CPARYEARALL_info
} //End namespace APPBASE.Models