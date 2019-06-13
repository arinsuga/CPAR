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
    public partial class Projectsts_ListVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string LOV_ID { get; set; }
        public string LOV_NM { get; set; }
    } //End public partial class Audit_ListVM
    public partial class Projectsts_DetailVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string LOV_ID { get; set; }
        public string LOV_NM { get; set; }
    } //End public partial class Audit_DetailVM
    public partial class Projectsts_ComboboxVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string LOV_ID { get; set; }
        public string LOV_NM { get; set; }
    } //End public partial class Projectsts_LookupVM
} //End namespace APPBASE.Models

