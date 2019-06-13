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
    public partial class Complaintype_ListVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public int? LOV_SEQ1 { get; set; }
        public int? LOV_SEQ2 { get; set; }
        public string LOV_ID { get; set; }
        public string LOV_NM { get; set; }
        public string LOV_VAL { get; set; }
        public string LOV_SYM { get; set; }
    } //End public partial class Complaintype_ListVM
    public partial class Complaintype_DetailVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public int? LOV_SEQ1 { get; set; }
        public int? LOV_SEQ2 { get; set; }
        public string LOV_ID { get; set; }
        public string LOV_NM { get; set; }
        public string LOV_VAL { get; set; }
        public string LOV_SYM { get; set; }
    } //End public partial class Complaintype_DetailVM

} //End namespace APPBASE.Models

