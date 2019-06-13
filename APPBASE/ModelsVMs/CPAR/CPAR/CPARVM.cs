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
    public partial class CPAR_IndexVM
    {
        public List<CPAR_ListVM> CPARList { get; set; }
        public FilterCPAR_DetailVM CPARFilter { get; set; }
    } //End public partial class CPAR_IndexVM
    public partial class CPAR_ListVM
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
        public string CPAR_TYPE { get; set; }
        public string CPAR_TYPE_ID { get; set; }
        public string CPAR_TYPE_NM { get; set; }
        public string CPAR_SUBTYPE { get; set; }
        public string CPAR_SUBTYPE_ID { get; set; }
        public string CPAR_SUBTYPE_NM { get; set; }

        public string AUDITEE_RUID { get; set; }
        public string AUDITEE_ID { get; set; }
        public string AUDITEE_NM { get; set; }
        public string AUDITEE_USRRUID { get; set; }

        public string AUDITEEDEPT_RUID { get; set; }
        public string AUDITEEDEPT_ID { get; set; }
        public string AUDITEEDEPT_NM { get; set; }

        public string AUDITOR_RUID { get; set; }
        public string AUDITOR_ID { get; set; }
        public string AUDITOR_NM { get; set; }
        public string AUDITOR_USRRUID { get; set; }

        public string AUDITORDEPT_RUID { get; set; }
        public string AUDITORDEPT_ID { get; set; }
        public string AUDITORDEPT_NM { get; set; }

        public string AUDIT_RUID { get; set; }
        public string AUDIT_ID { get; set; }
        public string AUDIT_NM { get; set; }
        public string AUDITDEPT_RUID { get; set; }
        public string AUDITDEPT_ID { get; set; }
        public string AUDITDEPT_NM { get; set; }
        public string CLASS_RUID { get; set; }
        public string CLASS_ID { get; set; }
        public string CLASS_NM { get; set; }
        public string COMPLAIN_CLIENTRUID { get; set; }
        public string OWNER_NM { get; set; }

        public DateTime? CPAR_RSPN_DT { get; set; }
        public DateTime? CPAR_RSPNLMT_DT { get; set; }
        public DateTime? CPAR_VER_DT { get; set; }
        public DateTime? CPAR_VERLMT_DT { get; set; }
    } //End public partial class CPAR_ListVM
    public partial class CPAR_DetailVM
    {
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
        public string AUDITOR_USRRUID { get; set; }

        public string AUDITORDEPT_RUID { get; set; }
        public string AUDITORDEPT_ID { get; set; }
        public string AUDITORDEPT_NM { get; set; }
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

        public List<CPARStdref_ListVM> STDREF_LIST { get; set; }

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

        public List<Subtype_ListVM> CPAR_SUBTYPE_LOV { get; set; }
        public List<Classaudit_ListVM> CLASS_RUID_LOV { get; set; }
    } //End public partial class CPAR_DetailVM
    public partial class CPAR_VerifyVM : CPAR_DetailVM
    {
        public string CPAR_RESOLUTION1 { get; set; }
        public string CPAR_RESOLUTION2 { get; set; }
        public string CPAR_RESOLUTION3 { get; set; }
        public DateTime? VFKS1_DT { get; set; }
        public string VFKS1_DESC { get; set; }
        public string VFKS1_PIC { get; set; }

        public DateTime? VFKS2_DT { get; set; }
        public string VFKS2_DESC { get; set; }
        public string VFKS2_PIC { get; set; }
        
        public DateTime? VFKS3_DT { get; set; }
        public string VFKS3_DESC { get; set; }
        public string VFKS3_PIC { get; set; }
        
        public DateTime? VFKS4_DT { get; set; }
        public string VFKS4_DESC { get; set; }
        public string VFKS4_PIC { get; set; }
        
        public DateTime? VFKS5_DT { get; set; }
        public string VFKS5_DESC { get; set; }
        public string VFKS5_PIC { get; set; }

        public List<CPARType_ListVM> CPAR_TYPE_LOV { get; set; }
    } //End public partial class CPAR_VerifyVM : CPAR_DetailVM
    public partial class CPAR_LogbookVM
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
        public string AUDITOR_USRRUID { get; set; }

        public string AUDITORDEPT_RUID { get; set; }
        public string AUDITORDEPT_ID { get; set; }
        public string AUDITORDEPT_NM { get; set; }
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

        public List<CPARStdref_ListVM> STDREF_LIST { get; set; }

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

        public List<Subtype_ListVM> CPAR_SUBTYPE_LOV { get; set; }
        public List<Classaudit_ListVM> CLASS_RUID_LOV { get; set; }
    } //End public partial class CPAR_LogbookVM

    public class CPARDASH_CPARSTEPVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public int? PRECREATE { get; set; }
        public int? CREATED { get; set; }
        public int? RESPONDED { get; set; }
        public int? VERIFIED { get; set; }
    } //End public class CPARDASH_CPARSTEPVM

    public class CPARNOTIFVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string CPAR_STS { get; set; }
        public string AUDITOR_RUID { get; set; }
        public string AUDITEE_RUID { get; set; }
        public string AUDITEEDEPT_RUID { get; set; }
        public int? PRECREATE { get; set; }
        public int? CREATED { get; set; }
        public int? RESPONDED { get; set; }
        public int? VERIFIED { get; set; }
    } //End public class CPARNOTIFVM

    public class CPARYEARALLVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public int? CPAR_YEARS { get; set; }
        public string AUDITEE_RUID { get; set; }
        public int? CPAR_IA { get; set; }
        public int? CPAR_TM { get; set; }
        public int? CPAR_PP { get; set; }
        public int? CPAR_PI { get; set; }
        public int? CPAR_CC { get; set; }
        public int? CPAR_LL { get; set; }
    } //End public class CPARYEARALLVM
    public class CPARYEARLISTVM
    {
        public int? CPAR_YEARS { get; set; }
    } //End public class CPARYEARALLVM
} //End namespace APPBASE.Models
