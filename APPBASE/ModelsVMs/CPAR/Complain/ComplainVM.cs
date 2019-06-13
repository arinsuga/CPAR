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
    public partial class Complain_ListVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string COMPLAIN_STS { get; set; }
        public string COMPLAIN_STS_ID { get; set; }
        public string COMPLAIN_STS_NM { get; set; }
        public string COMPLAIN_ID { get; set; }
        public string COMPLAIN_NM { get; set; }
        public string COMPLAIN_TYPE { get; set; }
        public string COMPLAIN_TYPE_ID { get; set; }
        public string COMPLAIN_TYPE_NM { get; set; }
        public string COMPLAIN_SUBTYPE { get; set; }
        public string DESCRIPTION { get; set; }
        public DateTime? ISSUED_DT { get; set; }

        public string RECIPIENT_RUID { get; set; }
        public string RECIPIENT_NM { get; set; }
        public string RECIPIENT_DEPTRUID { get; set; }
        public string RECIPIENT_DEPTID { get; set; }
        public string RECIPIENT_DEPTNM { get; set; }
        public string PIC_RUID { get; set; }
        public string PIC_NM { get; set; }
        public string PIC_DEPTRUID { get; set; }
        public string PIC_DEPTID { get; set; }
        public string PIC_DEPTNM { get; set; }

        public string PROJ_RUID { get; set; }
        public string PROJ_ID { get; set; }
        public string PROJ_NM { get; set; }
        public string CLIENT_RUID { get; set; }
        public string IS_CPAR { get; set; }
    } //End public partial class Complain_ListVM
    public partial class Complain_DetailVM
    {
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string COMPLAIN_STS { get; set; }
        public string COMPLAIN_ID { get; set; }
        public string COMPLAIN_TYPE { get; set; }
        public string COMPLAIN_TYPE_ID { get; set; }
        public string COMPLAIN_TYPE_NM { get; set; }
        public string DESCRIPTION { get; set; }
        public string SOLUTION { get; set; }
        public DateTime? ISSUED_DT { get; set; }
        public DateTime? RESPONSE_DT { get; set; }
        public DateTime? TARGET_DT { get; set; }
        public string RECIPIENT_RUID { get; set; }
        public string RECIPIENT_NM { get; set; }
        public string RECIPIENT_DEPTRUID { get; set; }
        public string RECIPIENT_DEPTID { get; set; }
        public string RECIPIENT_DEPTNM { get; set; }
        public string PIC_RUID { get; set; }
        public string PIC_NM { get; set; }
        public string PIC_DEPTRUID { get; set; }
        public string PIC_DEPTID { get; set; }
        public string PIC_DEPTNM { get; set; }
        public string PROJ_RUID { get; set; }
        public string PROJ_ID { get; set; }
        public string PROJ_NM { get; set; }
        public string PROJ_STS { get; set; }
        public string PROJ_STS_ID { get; set; }
        public string PROJ_STS_NM { get; set; }
        public string CLIENT_RUID { get; set; }
        public string IS_CPAR { get; set; }
    } //End public partial class Complain_DetailVM
    public partial class Complain_LogbookVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string COMPLAIN_STS { get; set; }
        public string COMPLAIN_STS_ID { get; set; }
        public string COMPLAIN_STS_NM { get; set; }
        public string COMPLAIN_ID { get; set; }
        public string COMPLAIN_NM { get; set; }
        public string COMPLAIN_TYPE { get; set; }
        public string COMPLAIN_TYPE_ID { get; set; }
        public string COMPLAIN_TYPE_NM { get; set; }
        public string COMPLAIN_SUBTYPE { get; set; }
        public string DESCRIPTION { get; set; }
        public string SOLUTION { get; set; }
        public DateTime? ISSUED_DT { get; set; }
        public DateTime? RESPONSE_DT { get; set; }
        public DateTime? TARGET_DT { get; set; }
        public string RECIPIENT_RUID { get; set; }
        public string RECIPIENT_NM { get; set; }
        public string RECIPIENT_DEPTRUID { get; set; }
        public string RECIPIENT_DEPTID { get; set; }
        public string RECIPIENT_DEPTNM { get; set; }
        public string PIC_RUID { get; set; }
        public string PIC_NM { get; set; }
        public string PIC_DEPTRUID { get; set; }
        public string PIC_DEPTID { get; set; }
        public string PIC_DEPTNM { get; set; }
        public string PROJ_RUID { get; set; }
        public string PROJ_ID { get; set; }
        public string PROJ_NM { get; set; }
        public string PROJ_STS { get; set; }
        public string PROJ_STS_ID { get; set; }
        public string PROJ_STS_NM { get; set; }
        public string CLIENT_RUID { get; set; }
        public string IS_CPAR { get; set; }
    } //End public partial class Complain_ListVM

} //End namespace APPBASE.Models

