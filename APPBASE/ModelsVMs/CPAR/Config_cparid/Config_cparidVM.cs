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
    public partial class Config_cparid_ListVM
    {
        public string RUID { get; set; }
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
    } //End public partial class Config_cparid_ListVM
    public partial class Config_cparid_DetailVM
    {
        public string RUID { get; set; }
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
    } //End public partial class Config_cparid_DetailVM
} //End namespace APPBASE.Models

