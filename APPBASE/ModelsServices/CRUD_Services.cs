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
    public class CRUD
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }

        //Constructor 1
        public CRUD()
        {
        } //End public Cutibesar()
        public void setFIELD_HEADER(string psCRUD_Option)
        {
            ADTRL_WKS = null;
            ADTRL_IP = hlpGeneral.ClientSystemInfo.getClientIPAddress();
            ADTRL_USR = hlpConfig.SessionInfo.getAppUsrRUID(); //hlpConfig.SessionInfo.getAppUsrID();
            ADTRL_PRG = null;
            ADTRL_DT = hlpGeneral.ClientSystemInfo.getAppDateTime();
            if (psCRUD_Option == hlpFlags_CRUDOption.CREATE)
            {
                RSEQNO = 0; //HACK: (Akal2an untuk mancing autoincremental field)
                RUID = Guid.NewGuid().ToString();
            } //End if
        } //End public void setFIELD_HEADER(string psCRUD_Option)
        public string setDTA_STS(string psCRUD_Option)
        {
            return psCRUD_Option;
        } //End public void setFIELD_HEADER(string psCRUD_Option)
    } //End public class CRUD
} //End namespace APPBASE.Models

