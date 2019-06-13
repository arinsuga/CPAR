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
    [Table("CPAR01CHATCPAR_NOTIFY")]
    public class CPARChatnotify : CRUD
    {
        public string DTA_STS { get; set; }
        public string CPARCHAT_RUID { get; set; }
        public string USR_RUID { get; set; }
    } //End public class CPARChat_notify : CRUD
} //End namespace APPBASE.Models

