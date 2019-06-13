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
    [Table("CPAR01COMPLAIN")]
    public partial class Complain : CRUD
    {
        public string DTA_STS { get; set; }
        public string COMPLAIN_STS { get; set; }
        public string COMPLAIN_ID { get; set; }
        public string COMPLAIN_NM { get; set; }
        public string COMPLAIN_TYPE { get; set; }
        public string COMPLAIN_SUBTYPE { get; set; }
        public string DESCRIPTION { get; set; }
        public string SOLUTION { get; set; }
        public DateTime? ISSUED_DT { get; set; }
        public DateTime? RESPONSE_DT { get; set; }
        public DateTime? TARGET_DT { get; set; }
        public string RECIPIENT_RUID { get; set; }
        public string PIC_RUID { get; set; }
        public string PROJ_RUID { get; set; }
        public string IS_CPAR { get; set; }
    } //End public partial class Complain : CRUD
} //End namespace APPBASE.Models

