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
    public partial class Project_Validation
    {
        private void Validate_RUID()
        {
            Boolean bIsvalid = true;
            //[RUID] - Required
            if ((oViewModel.RUID == "") || (oViewModel.RUID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RUID1";
                oMSG.VAL_ERRMSG = "RUID harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            ////[RUID] - Unique
            //if (oDS.isExists_RUID(oViewModel.RUID))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "RUID2";
            //    oMSG.VAL_ERRMSG = "ID " + oViewModel.RUID + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[RUID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RUID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_RUID()
        private void Validate_PROJ_ID()
        {
            Boolean bIsvalid = true;
            //[PROJ_ID] - Required
            if ((oViewModel.PROJ_ID == "") || (oViewModel.PROJ_ID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PROJ_ID1";
                oMSG.VAL_ERRMSG = "Kode harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[PROJ_ID] - Unique
            if (oDS.isExists_PROJ_ID(oViewModel.PROJ_ID))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PROJ_ID2";
                oMSG.VAL_ERRMSG = "Kode " + oViewModel.PROJ_ID + " sudah digunakan";
                aValidationMSG.Add(oMSG);
            } //End if
            //[LOV_ID] - Maxlength
            if ((oViewModel.PROJ_ID != "") && (oViewModel.PROJ_ID != null))
            {
                if (oViewModel.PROJ_ID.Length > valFLAG.FLAG_MAXLENGTH_ID)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "PROJ_ID3";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_ID.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[PROJ_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PROJ_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_PROJ_ID()
        private void Validate_PROJ_NM()
        {
            Boolean bIsvalid = true;
            //[LOV_NM] - Required
            if ((oViewModel.PROJ_NM == "") || (oViewModel.PROJ_NM == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PROJ_NM1";
                oMSG.VAL_ERRMSG = "Nama Project harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[LOV_NM] - Maxlength
            if ((oViewModel.PROJ_NM != "") && (oViewModel.PROJ_NM != null))
            {
                if (oViewModel.PROJ_NM.Length > valFLAG.FLAG_MAXLENGTH_NM)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "PROJ_NM2";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_NM.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[LOV_NM] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PROJ_NM0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_PROJ_NM()
        //TEMP: CLIENT_RUID untuk sementara diisi CLIENT NAME jadi validasi nya sementara juga mengikuti validasi NAME
        private void Validate_CLIENT_RUID()
        {
            Boolean bIsvalid = true;
            //[LOV_NM] - Maxlength
            if ((oViewModel.CLIENT_RUID != "") && (oViewModel.CLIENT_RUID != null))
            {
                if (oViewModel.CLIENT_RUID.Length > valFLAG.FLAG_MAXLENGTH_NM)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "CLIENT_RUID2";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_NM.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[LOV_NM] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CLIENT_RUID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_PROJ_NM()
        private void Validate_DELETE()
        {
            Boolean bIsvalid = true;
            //[ISUSEDBY_RES] - Inuse
            if (oDS.isUSEDBY_COMPLAIN(oViewModel.RUID))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "DELETE1";
                oMSG.VAL_ERRMSG = "Sudah digunakan oleh beberapa Complain";
                aValidationMSG.Add(oMSG);
            } //End if

            //[DELETE] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "DELETE0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_DELETE()
    } //End public partial class Project_Validation
} //End namespace APPBASE.Models

