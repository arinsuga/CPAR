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
        private void Validate_COMPLAIN_ID()
        {
            Boolean bIsvalid = true;
            //[COMPLAIN_ID] - Required
            if ((oViewModel.COMPLAIN_ID == "") || (oViewModel.COMPLAIN_ID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "COMPLAIN_ID1";
                oMSG.VAL_ERRMSG = "Nomor Complain harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[COMPLAIN_ID] - Unique
            if (oDS.isExists_COMPLAIN_ID(oViewModel.COMPLAIN_ID))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "COMPLAIN_ID2";
                oMSG.VAL_ERRMSG = "Nomor Complain " + oViewModel.COMPLAIN_ID + " sudah digunakan";
                aValidationMSG.Add(oMSG);
            } //End if
            //[COMPLAIN_ID] - Maxlength
            if ((oViewModel.COMPLAIN_ID != "") && (oViewModel.COMPLAIN_ID != null))
            {
                if (oViewModel.COMPLAIN_ID.Length > valFLAG.FLAG_MAXLENGTH_ID)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "COMPLAIN_ID3";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_ID.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[COMPLAIN_ID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "COMPLAIN_ID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_COMPLAIN_ID()
        private void Validate_PROJ_RUID()
        {
            Boolean bIsvalid = true;
            //[PROJ_RUID] - Required
            if ((oViewModel.PROJ_RUID == "") || (oViewModel.PROJ_RUID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PROJ_RUID1";
                oMSG.VAL_ERRMSG = "Proyek harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[PROJ_RUID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PROJ_RUID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_PROJ_RUID()
        private void Validate_RECIPIENT_RUID()
        {
            Boolean bIsvalid = true;
            //[RECIPIENT_RUID] - Required
            if ((oViewModel.RECIPIENT_RUID == "") || (oViewModel.RECIPIENT_RUID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RECIPIENT_RUID1";
                oMSG.VAL_ERRMSG = "Penerima complain harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[RECIPIENT_RUID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "RECIPIENT_RUID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_RECIPIENT_RUID()
        private void Validate_PIC_RUID()
        {
            Boolean bIsvalid = true;
            //[PIC_RUID] - Required
            if ((oViewModel.PIC_RUID == "") || (oViewModel.PIC_RUID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PIC_RUID1";
                oMSG.VAL_ERRMSG = "PIC Complain harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[PIC_RUID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "PIC_RUID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_PIC_RUID()

        private void Validate_ISSUED_DT()
        {
            Boolean bIsvalid = true;
            //[ISSUED_DT] - Required
            if (oViewModel.ISSUED_DT == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ISSUED_DT1";
                oMSG.VAL_ERRMSG = "Tanggal Complain diterima harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[ISSUED_DT] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "ISSUED_DT0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_ISSUED_DT()
        private void Validate_TARGET_DT()
        {
            Boolean bIsvalid = true;
            //[TARGET_DT] - Required
            if (oViewModel.TARGET_DT == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "TARGET_DT1";
                oMSG.VAL_ERRMSG = "Target Selesai harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[TARGET_DT] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "TARGET_DT0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_TARGET_DT()
        private void Validate_DESCRIPTION()
        {
            Boolean bIsvalid = true;
            //[DESCRIPTION] - Required
            if ((oViewModel.DESCRIPTION == "") || (oViewModel.DESCRIPTION == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "DESCRIPTION1";
                oMSG.VAL_ERRMSG = "Penjelasan complain harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[DESCLONG] - Maxlength
            if ((oViewModel.DESCRIPTION != "") && (oViewModel.DESCRIPTION != null))
            {
                if (oViewModel.DESCRIPTION.Length > valFLAG.FLAG_MAXLENGTH_DESCLONG)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "DESCRIPTION2";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_DESCLONG.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[DESCRIPTION] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "DESCRIPTION0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_DESCRIPTION()
        private void Validate_SOLUTION()
        {
            Boolean bIsvalid = true;
            //[DESCRIPTION] - Required
            if ((oViewModel.SOLUTION == "") || (oViewModel.SOLUTION == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "SOLUTION1";
                oMSG.VAL_ERRMSG = "Koreksi harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[DESCLONG] - Maxlength
            if ((oViewModel.SOLUTION != "") && (oViewModel.SOLUTION != null))
            {
                if (oViewModel.SOLUTION.Length > valFLAG.FLAG_MAXLENGTH_DESCLONG)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "SOLUTION2";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_DESCLONG.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[DESCRIPTION] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "SOLUTION0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_SOLUTION()


    } //End public partial class Complain_Validation
} //End namespace APPBASE.Models

