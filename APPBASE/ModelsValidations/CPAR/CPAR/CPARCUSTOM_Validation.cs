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
using APPBASE;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class CPAR_Validation
    {
        //Custom Access Control
        private string sROLE_RUID = "";
        private string sRES_RUID = "";
        private string sDEPT_RUID = "";
        private string CPAR_TYPE = "";

        public Boolean isGranted_Response()
        {
            if (this.sROLE_RUID == valFLAG.FLAG_ROLE_SYSADMIN) { return true; }
            if (this.sRES_RUID == this.oViewModel_verify.AUDITEE_RUID) { return true; } //End if (this.sRES_RUID == this.oViewModel_verify.AUDITEE_RUID)

            return false;
        } //End public void Validate_Create()
        public Boolean isGranted_Chat()
        {
            if (this.sROLE_RUID == valFLAG.FLAG_ROLE_SYSADMIN) { return true; }
            if (this.sROLE_RUID == valFLAG.FLAG_ROLE_CPAR_ADMIN) { return true; }
            if (this.sRES_RUID == this.oViewModel_verify.AUDITEE_RUID) { return true; } //End if (this.sRES_RUID == this.oViewModel_verify.AUDITEE_RUID)

            return false;
        } //End public void Validate_Create()

        public Boolean isGranted_View()
        {
            if (this.sROLE_RUID == valFLAG.FLAG_ROLE_SYSADMIN) { return true; }
            if (this.sROLE_RUID == valFLAG.FLAG_ROLE_CPAR_ADMIN) { return true; }
            if (this.sRES_RUID == this.oViewModel_verify.AUDITOR_RUID) { return true; } //End if (this.sRES_RUID == this.oViewModel_verify.AUDITOR_RUID)
            if (this.sDEPT_RUID == this.oViewModel_verify.AUDITEEDEPT_RUID) { return true; } //End if (this.sDEPT_RUID == this.oViewModel_verify.AUDITEEDEPT_RUID)
            return false;
        } //End public void Validate_Create()
    } //End public partial class CPAR_Validation
} //End namespace APPBASE.Models

