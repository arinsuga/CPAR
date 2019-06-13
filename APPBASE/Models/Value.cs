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
    public class DEFFAULT_FIELD
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }

        //Constructor
        public DEFFAULT_FIELD() {
            ADTRL_IP = hlpGeneral.ClientSystemInfo.getClientIPAddress();
            ADTRL_DT = hlpGeneral.ClientSystemInfo.getAppDateTime();
            RSEQNO = 0;
            RUID = Guid.NewGuid().ToString();
        } //End public DEFFAULT_FIELD()
    } //End public class DEFFAULT_FIELD
} //End namespace APPBASE.Models