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
    public partial class FilterCPAR_DetailVM    {
        public DateTime? CPAR_DT1 { get; set; }
        public DateTime? CPAR_DT2 { get; set; }
        
        public string CPAR_TYPE { get; set; }
        public string CPAR_TYPE_NM { get; set; }
        
        //public string CPAR_SUBTYPE { get; set; }
        //public string CPAR_SUBTYPE_NM { get; set; }

        public string AUDIT_RUID { get; set; }
        public string AUDIT_NM { get; set; }

        public string CLASS_RUID { get; set; }
        public string CLASS_NM { get; set; }

        //public string AUDITOR_RUID { get; set; }
        //public string AUDITOR_NM { get; set; }
        //public string AUDITORDEPT_RUID { get; set; }
        //public string AUDITORDEPT_NM { get; set; }
        
        public string AUDITEE_RUID { get; set; }
        //public string AUDITEE_NM { get; set; }
        public string AUDITEEDEPT_RUID { get; set; }
        public string AUDITEEDEPT_NM { get; set; }

        public string CPAR_STS { get; set; }

        public string CPAR_STEP { get; set; }
        //public string CPAR_STEP_ID { get; set; }
        //public string CPAR_STEP_NM { get; set; }
    } //End public partial class FILTER_CPARVM
} //End namespace APPBASE.Models

