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
    public partial class Complain_Validation
    {
        private Complain_DetailVM oViewModel;
        private ComplainDS oDS = new ComplainDS();
        public List<ValidationMSG_VM> aValidationMSG = new List<ValidationMSG_VM>();

        //Constructor
        public Complain_Validation(Complain_DetailVM poViewModel)
        {
            oViewModel = poViewModel;
            this.sROLE_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            this.sRES_RUID = hlpConfig.SessionInfo.getAppUsrRES_RUID();
            this.sDEPT_RUID = hlpConfig.SessionInfo.getAppUsrDEPT_RUID();
        } //End public Complain_Validation()
        public void Validate_Create()
        {
            //Validate_RUID();
            Validate_COMPLAIN_ID();
            Validate_PROJ_RUID();
            Validate_RECIPIENT_RUID();
            Validate_PIC_RUID();
            Validate_ISSUED_DT();
            Validate_TARGET_DT();
            Validate_DESCRIPTION();
            Validate_SOLUTION();
        } //End public void Validate_Create()
        public void Validate_Edit()
        {
            //Validate_RUID();
            Validate_PROJ_RUID();
            Validate_RECIPIENT_RUID();
            Validate_PIC_RUID();
            Validate_ISSUED_DT();
            Validate_TARGET_DT();
            Validate_DESCRIPTION();
            Validate_SOLUTION();
        } //End public void Validate_Edit()
        public void Validate_Delete()
        {
            //Validate_RUID();
        } //End public void Validate_Delete()

        public void Validate_Close()
        {
            //Validate_RUID();
        } //End public void Validate_Close()
        public void Validate_Cancel()
        {
            //Validate_RUID();
        } //End public void Validate_Cancel()
    } //End public partial class Complain_Validation
} //End namespace APPBASE.Models

