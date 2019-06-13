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
    [Table("MST01LOV_MRTLSTS")]
    public partial class Maritalsts : CRUD
    {
        public string DTA_STS { get; set; }
        public int? LOV_SEQ1 { get; set; }
        public int? LOV_SEQ2 { get; set; }
        public string LOV_ID { get; set; }
        public string LOV_NM { get; set; }
    } //End public partial class Sex : CRUD
} //End namespace APPBASE.Models