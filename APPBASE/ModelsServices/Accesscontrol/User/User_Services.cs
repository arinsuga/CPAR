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
    public partial class User
    {
        //Constructor
        public User() {
        } //End public User()

        public void setFIELD_HEADER(string psCRUD_Option)
        {
            ADTRL_WKS = null;
            ADTRL_IP = hlpGeneral.ClientSystemInfo.getClientIPAddress();
            ADTRL_USR = hlpConfig.SessionInfo.getAppUsrID();
            ADTRL_PRG = null;
            ADTRL_DT = hlpGeneral.ClientSystemInfo.getAppDateTime();
            if (psCRUD_Option == hlpFlags_CRUDOption.CREATE)
            {
                RSEQNO = 0; //HACK: (Akal2an untuk mancing autoincremental field)
                RUID = Guid.NewGuid().ToString();
            } //End if
        } //End public void setDefaultField()
        public void setActivate(string id = null)
        {
            BP_STS = valFLAG.FLAG_ACTIVE;
        } //End public void setActivate(string id = null)
        public void setDeactivate(string id = null)
        {
            BP_STS = valFLAG.FLAG_INACTIVE;
        } //End public void setDeactivate(string id = null)
    } //End public partial class User
} //End namespace APPBASE.Models

