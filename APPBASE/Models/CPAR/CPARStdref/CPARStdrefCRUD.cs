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
    [Table("CPAR01CPAR_STDREF")]
    public class CPARStdref : CRUD
    {
        public string DTA_STS { get; set; }
        public string CPAR_RUID { get; set; }
        public string STDREF_RUID { get; set; }
    } //End public class CPARStdref : CRUD
} //End namespace APPBASE.Models

