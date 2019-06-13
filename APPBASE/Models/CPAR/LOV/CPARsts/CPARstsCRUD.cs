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
    [Table("CPAR01LOV_CPARSTS")]
    public class CPARsts : CRUD
    {
        public string DTA_STS { get; set; }
        public int? LOV_SEQ1 { get; set; }
        public int? LOV_SEQ2 { get; set; }
        public string LOV_ID { get; set; }
        public string LOV_NM { get; set; }
        public string LOV_VAL { get; set; }
        public string LOV_SYM { get; set; }
    } //End public class CPARsts : CRUD
} //End namespace APPBASE.Models

