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
    [Table("CPAR01CFG_CPARID")]
    public class Config_cparid : CRUD
    {
        public string DTA_STS { get; set; }
        public int? CPARID_COUNTER { get; set; }
        public int? CPARID_YEAR { get; set; }
        public int? CPARID_MONTH { get; set; }
        public string CPARID_LAST { get; set; }
        public string CPARID_IA { get; set; }
        public string CPARID_TM { get; set; }
        public string CPARID_PP { get; set; }
        public string CPARID_PI { get; set; }
        public string CPARID_CC { get; set; }
        public string CPARID_LL { get; set; }
    } //End public class Config_cparid : CRUD
} //End namespace APPBASE.Models

