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
    //Validator for model EmployeeCB_VM
    public partial class User_Validation
    {
        private void Validate_USR_ID_CPAR()
        {
            Boolean bIsvalid = true;
            //[USR_ID] - User ID tidak boleh kosong
            if ((oViewModelCPAR.USR_ID == "") || (oViewModelCPAR.USR_ID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USR_ID1";
                oMSG.VAL_ERRMSG = "User ID tidak boleh kosong";
                aValidationMSG.Add(oMSG);
            } //End if
            //[USR_ID] - Check if user ID exists
            if (oDS.isExists_USR_ID(oViewModelCPAR.USR_ID))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USR_ID2";
                oMSG.VAL_ERRMSG = "User ID sudah digunakan";
                aValidationMSG.Add(oMSG);
            } //End if

            //[USR_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USR_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_USR_ID_CPAR()
        private void Validate_USR_ID_CPAR2()
        {
            Boolean bIsvalid = true;
            //[USR_ID] - User ID tidak boleh kosong
            if ((oViewModelCPAR.USR_ID == "") || (oViewModelCPAR.USR_ID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USR_ID1";
                oMSG.VAL_ERRMSG = "User ID tidak boleh kosong";
                aValidationMSG.Add(oMSG);
            } //End if

            //[USR_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USR_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_USR_ID_CPAR2()
        private void Validate_USR_NM1_CPAR()
        {
            Boolean bIsvalid = true;
            //[USR_NM1] - Required
            if ((oViewModelCPAR.USR_NM1 == "") || (oViewModelCPAR.USR_NM1 == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USR_NM11";
                oMSG.VAL_ERRMSG = "User name tidak boleh kosong";
                aValidationMSG.Add(oMSG);
            } //End if

            //[USR_NM1] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USR_NM10";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_USR_NM1_CPAR()
        private void Validate_DEPT_RUID_CPAR()
        {
            Boolean bIsvalid = true;
            //[DEPT_RUID1] - Required
            if ((oViewModelCPAR.DEPT_RUID == "") || (oViewModelCPAR.DEPT_RUID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "DEPT_RUID1";
                oMSG.VAL_ERRMSG = "Departemen tidak boleh kosong";
                aValidationMSG.Add(oMSG);
            } //End if

            //[DEPT_RUID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "DEPT_RUID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_DEPT_RUID_CPAR()

        private void Validate_USR_PSWD_CPAR() {
            Boolean bIsvalid = true;
            //[USR_PSWD] - Password tidak boleh kosong
            if ((oViewModelCPAR.USR_PSWD == "") || (oViewModelCPAR.USR_PSWD == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USR_PSWD1";
                oMSG.VAL_ERRMSG = "Password tidak boleh kosong";
                aValidationMSG.Add(oMSG);
            } //End if

            //[USR_PSWD] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USR_PSWD0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_USR_PSWD_CPAR()
        private void Validate_IMG_SRC()
        {
            Boolean bIsvalid = true;
            Int64 nMaxsize = 1048576; //(1024*1024) = 1MB

            //[IMG_SRC] - Require JPG file format
            if (oFileimage.ContentType != "image/jpeg")
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "IMG_SRC1";
                oMSG.VAL_ERRMSG = "Format foto harus JPG";
                aValidationMSG.Add(oMSG);
            } //End if
            //[IMG_SRC] - max size 512KB
            if (oFileimage.ContentLength > nMaxsize)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "IMG_SRC2";
                oMSG.VAL_ERRMSG = "Ukuran foto maximal 1MB";
                aValidationMSG.Add(oMSG);
            } //End if

            //[IMG_SRC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "IMG_SRC0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_IMG_SRC()
    } //End public class User_Validation
} //End namespace APPBASE.Models