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
    [Table("CPAR01CPAR")]
    public partial class CPAR : CRUD
    {
        public string DTA_STS { get; set; }
        public string CPAR_STS { get; set; }
        public string CPAR_STEP { get; set; }
        public string CPAR_ID { get; set; }
        public DateTime? CPAR_DT { get; set; }
        public DateTime? CPAR_TRGT_DT { get; set; }
        public DateTime? CPAR_FINISH_DT { get; set; }
        public string CPAR_DESC { get; set; }
        public string CPAR_RESOLUTION1 { get; set; }
        public string CPAR_RESOLUTION2 { get; set; }
        public string CPAR_RESOLUTION3 { get; set; }
        public string CPAR_TYPE { get; set; }
        public string CPAR_SUBTYPE { get; set; }
        public string AUDITOR_RUID { get; set; }
        public string AUDITORDEPT_RUID { get; set; }
        public string AUDITEE_RUID { get; set; }
        public string AUDITEEDEPT_RUID { get; set; }
        public string AUDIT_RUID { get; set; }
        public string CLASS_RUID { get; set; }
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
    } //End public partial class CPAR : CRUD
} //End namespace APPBASE.Models