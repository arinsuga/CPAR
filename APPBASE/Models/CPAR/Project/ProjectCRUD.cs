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
    [Table("CPAR01PROJ")]
    public class Project : CRUD
    {
        public string DTA_STS { get; set; }
        public string PROJ_ID { get; set; }
        public string PROJ_NM { get; set; }
        public string PROJ_STS { get; set; }
        public string CLIENT_RUID { get; set; }
    } //End public class Project : CRUD
} //End namespace APPBASE.Models