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
using AutoMapper;

namespace APPBASE.Models
{
    public partial class CPAR_Validation
    {
        private CPAR_DetailVM oViewModel;
        private CPAR_VerifyVM oViewModel_verify;
        private CPARDS oDS = new CPARDS();
        public List<ValidationMSG_VM> aValidationMSG = new List<ValidationMSG_VM>();

        //Constructor 1
        public CPAR_Validation(CPAR_DetailVM poViewModel)
        {
            this.oViewModel = poViewModel;
            this.oViewModel_verify = new CPAR_VerifyVM();
            //Map Form Data
            Mapper.CreateMap<CPAR_DetailVM, CPAR_VerifyVM>();
            this.oViewModel_verify = Mapper.Map<CPAR_DetailVM, CPAR_VerifyVM>(oViewModel);

            this.sROLE_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            this.sRES_RUID = hlpConfig.SessionInfo.getAppUsrRES_RUID();
            this.sDEPT_RUID = hlpConfig.SessionInfo.getAppUsrDEPT_RUID();
            this.CPAR_TYPE = poViewModel.CPAR_TYPE;
        } //End public CPAR_Validation()
        //Constructor 2
        public CPAR_Validation(CPAR_VerifyVM poViewModel)
        {
            this.oViewModel_verify = poViewModel;
            this.oViewModel = new CPAR_DetailVM();
            //Map Form Data
            Mapper.CreateMap<CPAR_VerifyVM, CPAR_DetailVM>();
            this.oViewModel = Mapper.Map<CPAR_VerifyVM, CPAR_DetailVM>(oViewModel_verify);

            this.sROLE_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            this.sRES_RUID = hlpConfig.SessionInfo.getAppUsrRES_RUID();
            this.sDEPT_RUID = hlpConfig.SessionInfo.getAppUsrDEPT_RUID();
            this.CPAR_TYPE = poViewModel.CPAR_TYPE;
        } //End public CPAR_Validation()
        public void Validate_Create()
        {
            //Validate_RUID();
            Validate_CPAR_DT();
            Validate_AUDITOR_RUID();
            Validate_AUDITEE_RUID();
            Validate_AUDIT_RUID();
            if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA) { Validate_STDREF_RUID(); } //End if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA)
            Validate_CPAR_DESC();
        } //End public void Validate_Create()
        public void Validate_Edit()
        {
            //Validate_RUID();
            Validate_CPAR_DT();
            Validate_AUDITOR_RUID();
            Validate_AUDITEE_RUID();
            Validate_AUDIT_RUID();
            if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA) { Validate_STDREF_RUID(); } //End if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA)
            Validate_CPAR_DESC();
        } //End public void Validate_Edit()
        public void Validate_Delete()
        {
            //Validate_RUID();
        } //End public void Validate_Delete()

        public void Validate_Response()
        {
            //Validate_RUID();
            Validate_CPAR_FINISH_DT();
            Validate_CPAR_RESOLUTION1();
            Validate_CPAR_RESOLUTION2();
            Validate_CPAR_RESOLUTION3();
        } //End public void Validate_Response()
        public void Validate_Verify()
        {
            //Validate_RUID();
            Validate_VFKS1_DESC();
            Validate_VFKS2_DESC();
            Validate_VFKS3_DESC();
            Validate_VFKS4_DESC();
            Validate_VFKS5_DESC();
        } //End public void Validate_Verify()
        public void Validate_Close()
        {
            //Validate_RUID();
            Validate_CPAR_STS();
        } //End public void Validate_Close()
        public void Validate_Cancel()
        {
            //Validate_RUID();
        } //End public void Validate_Cancel()
    } //End public partial class CPAR_Validation
} //End namespace APPBASE.Models

