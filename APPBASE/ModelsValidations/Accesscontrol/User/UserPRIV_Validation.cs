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
        private void Validate_USR_ID()
        {
            Boolean bIsvalid = true;
            //[USR_ID] - User ID tidak boleh kosong
            if ((oViewModel.USR_ID == "") || (oViewModel.USR_ID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "USR_ID1";
                oMSG.VAL_ERRMSG = "User ID tidak boleh kosong";
                aValidationMSG.Add(oMSG);
            } //End if
            //[USR_ID] - Check if user ID exists
            if (oDS.isExists_USR_ID(oViewModel.USR_ID))
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
        } //End private void Validate_USR_ID()
        private void Validate_USR_NM1()
        {
            Boolean bIsvalid = true;
            //[USR_NM1] - Required
            if ((oViewModel.USR_NM1 == "") || (oViewModel.USR_NM1 == null))
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
        } //End private void Validate_USR_NM1()
        private void Validate_USR_PSWD() {
            Boolean bIsvalid = true;
            //[USR_PSWD] - Password tidak boleh kosong
            if ((oViewModel.USR_PSWD == "") || (oViewModel.USR_PSWD == null))
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
        } //End private void Validate_USR_PSWD()
    } //End public class User_Validation
} //End namespace APPBASE.Models