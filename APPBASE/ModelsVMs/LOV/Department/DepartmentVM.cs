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
    public partial class Department_ListVM
    {
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string LOV_ID { get; set; }
        public string LOV_NM { get; set; }
        public string ISUSEDBY_RES { get; set; }
        public string ISUSEDBY_AUDIT { get; set; }
    } //End public partial class Department_ListVM
    public partial class Department_DetailVM
    {
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string LOV_ID { get; set; }
        public string LOV_NM { get; set; }
        public string ISUSEDBY_RES { get; set; }
        public string ISUSEDBY_AUDIT { get; set; }
    } //End public partial class Department_DetailVM

} //End namespace APPBASE.Models

