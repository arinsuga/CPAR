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
    public partial class Department_Validation
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
        private void Validate_LOV_ID()
        {
            Boolean bIsvalid = true;
            //[LOV_ID] - Required
            if ((oViewModel.LOV_ID == "") || (oViewModel.LOV_ID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "LOV_ID1";
                oMSG.VAL_ERRMSG = "Kode harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[LOV_ID] - Unique
            if (oDS.isExists_LOV_ID(oViewModel.LOV_ID))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "LOV_ID2";
                oMSG.VAL_ERRMSG = "Kode " + oViewModel.LOV_ID + " sudah digunakan";
                aValidationMSG.Add(oMSG);
            } //End if
            //[LOV_ID] - Maxlength
            if ((oViewModel.LOV_ID != "") && (oViewModel.LOV_ID != null))
            {
                if (oViewModel.LOV_ID.Length > valFLAG.FLAG_MAXLENGTH_ID) {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "LOV_ID3";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_ID.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[LOV_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "LOV_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_LOV_ID()
        private void Validate_LOV_NM()
        {
            Boolean bIsvalid = true;
            //[LOV_NM] - Required
            if ((oViewModel.LOV_NM == "") || (oViewModel.LOV_NM == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "LOV_NM1";
                oMSG.VAL_ERRMSG = "Nama Departemen harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[LOV_NM] - Maxlength
            if ((oViewModel.LOV_NM != "") && (oViewModel.LOV_NM != null))
            {
                if (oViewModel.LOV_NM.Length > valFLAG.FLAG_MAXLENGTH_NM)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "LOV_NM2";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_NM.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[LOV_NM] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "LOV_NM0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_LOV_NM()
        private void Validate_DELETE()
        {
            Boolean bIsvalid = true;
            //[ISUSEDBY_RES] - Inuse
            if (oDS.isUSEDBY_RES(oViewModel.RUID))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "DELETE1";
                oMSG.VAL_ERRMSG = "Sudah digunakan oleh beberapa user";
                aValidationMSG.Add(oMSG);
            } //End if
            //[USEDBY_AUDIT] - Inuse
            if (oDS.isUSEDBY_AUDIT(oViewModel.RUID))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "DELETE2";
                oMSG.VAL_ERRMSG = "Sudah digunakan oleh beberapa proses audit";
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
    } //End public partial class Department_Validation
} //End namespace APPBASE.Models

