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
    public partial class Employee_Validation
    {
        private void Validate_RES_ID()
        {
            Boolean bIsvalid = true;
            //[RES_ID] - Required
            if ((oViewModel.RES_ID == "") || (oViewModel.RES_ID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RES_ID1";
                oMSG.VAL_ERRMSG = "NIK harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[RES_ID] - Unique
            if (oDS.isExists_RES_ID(oViewModel.RES_ID))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RES_ID2";
                oMSG.VAL_ERRMSG = "NIK " + oViewModel.RES_ID + " sudah digunakan";
                aValidationMSG.Add(oMSG);
            } //End if

            //[RES_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RES_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_RES_ID()
        private void Validate_RES_XID1()
        {
            Boolean bIsvalid = true;
            //[RES_XID1] - Required
            if ((oViewModel.RES_XID1 == "") || (oViewModel.RES_XID1 == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RES_XID11";
                oMSG.VAL_ERRMSG = "No. Absen harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[RES_XID1] - Unique
            if (oDS.isExists_RES_XID1(oViewModel.RES_XID1))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RES_XID12";
                oMSG.VAL_ERRMSG = "No. Absen " + oViewModel.RES_XID1 + " sudah digunakan";
                aValidationMSG.Add(oMSG);
            } //End if

            //[RES_XID1] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RES_XID10";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_RES_XID1()
        private void Validate_RES_NM1()
        {
            Boolean bIsvalid = true;
            //[RES_NM1] - Required
            if ((oViewModel.RES_NM1 == "") || (oViewModel.RES_NM1 == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RES_NM11";
                oMSG.VAL_ERRMSG = "Nama harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[RES_NM1] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RES_NM10";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_RES_NM1()
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

    } //End public partial class Employee_Validation
} //End namespace APPBASE.Models

