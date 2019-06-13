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
    public partial class CPARStdref_ListVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string CPAR_RUID { get; set; }
        public string STDREF_RUID { get; set; }
        public string STDREF_ID { get; set; }
        public string STDREF_NM { get; set; }
    } //End public partial class CPARStdref_ListVM
    public partial class CPARStdref_DetailVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string CPAR_RUID { get; set; }
        public string STDREF_RUID { get; set; }
        public string STDREF_ID { get; set; }
        public string STDREF_NM { get; set; }
    } //End public partial class CPARStdref_DetailVM
} //End namespace APPBASE.Models

