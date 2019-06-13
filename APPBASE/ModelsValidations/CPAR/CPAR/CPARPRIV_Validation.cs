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
        private void Validate_CPAR_DT()
        {
            Boolean bIsvalid = true;
            //[CPAR_DT] - Required
            if (oViewModel.CPAR_DT == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_DT1";
                oMSG.VAL_ERRMSG = "Tanggal temuan harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[CPAR_DT] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_DT0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_CPAR_DT()
        private void Validate_AUDITOR_RUID()
        {
            Boolean bIsvalid = true;

            if (oViewModel.CPAR_TYPE != valFLAG.FLAG_CPAR_TYPE_CC) {
                //[AUDITOR_RUID] - Required
                if ((oViewModel.AUDITOR_RUID == "") || (oViewModel.AUDITOR_RUID == null))
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "AUDITOR_RUID1";
                    oMSG.VAL_ERRMSG = "Auditor harus diisi";
                    aValidationMSG.Add(oMSG);
                } //End if
            } //End if (oViewModel.CPAR_TYPE != valFLAG.FLAG_CPAR_TYPE_CC)

            //[AUDITOR_RUID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "AUDITOR_RUID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_AUDITOR_RUID()
        private void Validate_AUDITEE_RUID()
        {
            Boolean bIsvalid = true;
            //[AUDITEE_RUID] - Required
            if ((oViewModel.AUDITEE_RUID == "") || (oViewModel.AUDITEE_RUID == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "AUDITEE_RUID1";
                oMSG.VAL_ERRMSG = "Auditee harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[AUDITEE_RUID] - Unique

            //[AUDITEE_RUID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "AUDITEE_RUID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_AUDITEE_RUID()
        private void Validate_AUDIT_RUID()
        {
            Boolean bIsvalid = true;

            if (oViewModel.CPAR_TYPE != valFLAG.FLAG_CPAR_TYPE_CC) {
                //[AUDIT_RUID] - Required
                if ((oViewModel.AUDIT_RUID == "") || (oViewModel.AUDIT_RUID == null))
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "AUDIT_RUID1";
                    oMSG.VAL_ERRMSG = "Proses audit harus diisi";
                    aValidationMSG.Add(oMSG);
                } //End if
            } //End if (oViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC)

            ////[AUDIT_RUID] - Unique
            //if (oDS.isExists_AUDIT_RUID(oViewModel.AUDIT_RUID))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "AUDIT_RUID2";
            //    oMSG.VAL_ERRMSG = "AUDIT_RUID " + oViewModel.AUDIT_RUID + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[AUDIT_RUID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "AUDIT_RUID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_AUDIT_RUID()

        private void Validate_STDREF_RUID()
        {
            Boolean bIsvalid = true;
            //[STDREF_LIST] - Required
            if (oViewModel.STDREF_LIST == null) { bIsvalid = false; } //End if (oViewModel.STDREF_LIST == null)
            if (oViewModel.STDREF_LIST != null) {
                if (oViewModel.STDREF_LIST.Count <= 0) { bIsvalid = false; } //End if (oViewModel.STDREF_LIST.Count > 0)
            } //End if (oViewModel.STDREF_LIST != null)

            //[STDREF_RUID] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG1 = new ValidationMSG_VM();
                oMSG1.VAL_ERRID = "STDREF_RUID1";
                oMSG1.VAL_ERRMSG = "Referensi/standard harus diisi";
                aValidationMSG.Add(oMSG1);

                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "STDREF_RUID0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_STDREF_RUID()
        private void Validate_CPAR_DESC()
        {
            Boolean bIsvalid = true;
            //[CPAR_DESC] - Required
            if ((oViewModel.CPAR_DESC == "") || (oViewModel.CPAR_DESC == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_DESC1";
                oMSG.VAL_ERRMSG = "Temuan/ketidak sesuaian/potensi masalah harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[DESCLONG] - Maxlength
            if ((oViewModel.CPAR_DESC != "") && (oViewModel.CPAR_DESC != null))
            {
                if (oViewModel.CPAR_DESC.Length > valFLAG.FLAG_MAXLENGTH_DESCLONG)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "CPAR_DESC2";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_DESCLONG.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[CPAR_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_DESC0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_CPAR_DESC()
        private void Validate_CPAR_FINISH_DT()
        {
            Boolean bIsvalid = true;
            //[CPAR_DESC] - Required
            if (oViewModel_verify.CPAR_FINISH_DT == null)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_FINISH_DT1";
                oMSG.VAL_ERRMSG = "Tanggal penyelesaian harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[CPAR_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_FINISH_DT0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_CPAR_FINISH_DT()

        private void Validate_CPAR_RESOLUTION1()
        {
            Boolean bIsvalid = true;
            //[CPAR_DESC] - Required
            if ((oViewModel_verify.CPAR_RESOLUTION1 == "") || (oViewModel_verify.CPAR_RESOLUTION1 == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_RESOLUTION11";
                oMSG.VAL_ERRMSG = "Akar penyebab harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[DESCLONG] - Maxlength
            if ((oViewModel.CPAR_RESOLUTION1 != "") && (oViewModel.CPAR_RESOLUTION1 != null))
            {
                if (oViewModel.CPAR_RESOLUTION1.Length > valFLAG.FLAG_MAXLENGTH_DESCLONG)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "CPAR_RESOLUTION12";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_DESCLONG.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[CPAR_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_RESOLUTION10";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_CPAR_RESOLUTION1()
        private void Validate_CPAR_RESOLUTION2()
        {
            Boolean bIsvalid = true;
            //[CPAR_DESC] - Required
            if ((oViewModel_verify.CPAR_RESOLUTION2 == "") || (oViewModel_verify.CPAR_RESOLUTION2 == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_RESOLUTION21";
                oMSG.VAL_ERRMSG = "Tindakan koreksi harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[DESCLONG] - Maxlength
            if ((oViewModel.CPAR_RESOLUTION2 != "") && (oViewModel.CPAR_RESOLUTION2 != null))
            {
                if (oViewModel.CPAR_RESOLUTION2.Length > valFLAG.FLAG_MAXLENGTH_DESCLONG)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "CPAR_RESOLUTION22";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_DESCLONG.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[CPAR_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_RESOLUTION20";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_CPAR_RESOLUTION2()
        private void Validate_CPAR_RESOLUTION3()
        {
            Boolean bIsvalid = true;
            //[CPAR_DESC] - Required
            if ((oViewModel_verify.CPAR_RESOLUTION3 == "") || (oViewModel_verify.CPAR_RESOLUTION3 == null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_RESOLUTION31";
                oMSG.VAL_ERRMSG = "Tindakan korektif harus diisi";
                aValidationMSG.Add(oMSG);
            } //End if
            //[DESCLONG] - Maxlength
            if ((oViewModel.CPAR_RESOLUTION3 != "") && (oViewModel.CPAR_RESOLUTION3 != null))
            {
                if (oViewModel.CPAR_RESOLUTION3.Length > valFLAG.FLAG_MAXLENGTH_DESCLONG)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "CPAR_RESOLUTION32";
                    oMSG.VAL_ERRMSG = "Maximal " + valFLAG.FLAG_MAXLENGTH_DESCLONG.ToString() + " character";
                    aValidationMSG.Add(oMSG);
                }
            } //End if

            //[CPAR_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_RESOLUTION30";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_CPAR_RESOLUTION3()
        
        private void Validate_CPAR_STS()
        {
            Boolean bIsvalid = true;
            //[CPAR_DESC] - Required
            if ((oViewModel_verify.CPAR_STEP == "") || (oViewModel_verify.CPAR_STEP == null)
                || (oViewModel_verify.CPAR_STEP != valFLAG.FLAG_CPAR_STEP_VERIFIED))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_STS1";
                oMSG.VAL_ERRMSG = "CPAR belum diverifikasi";
                aValidationMSG.Add(oMSG);
            } //End if

            //[CPAR_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_STS0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_CPAR_RESOLUTION2()


        private void Validate_VFKS1_DESC()
        {
            Boolean bIsvalid = true;
            //[VFKS1_DESC] - maxlength
            if ((oViewModel_verify.VFKS1_DESC != "") && (oViewModel_verify.VFKS1_DESC != null))
            {
                if (oViewModel_verify.VFKS1_DESC.Length > 100) {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "VFKS1_DESC1";
                    oMSG.VAL_ERRMSG = "Komentar maximal 100 karakter";
                    aValidationMSG.Add(oMSG);
                } //End if (oViewModel_verify.VFKS1_DESC.Length > 100
            } //End if
            //[VFKS1_DESC] - Unique
            //if (oDS.isExists_VFKS1_DESC(oViewModel.VFKS1_DESC))
            //{
            //    bIsvalid = false;
            //    ValidationMSG_VM oMSG = new ValidationMSG_VM();
            //    oMSG.VAL_ERRID = "VFKS1_DESC2";
            //    oMSG.VAL_ERRMSG = "VFKS1_DESC " + oViewModel.VFKS1_DESC + " sudah digunakan";
            //    aValidationMSG.Add(oMSG);
            //} //End if

            //[VFKS1_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "VFKS1_DESC0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_VFKS1_DESC()
        private void Validate_VFKS2_DESC()
        {
            Boolean bIsvalid = true;
            //[VFKS1_DESC] - maxlength
            if ((oViewModel_verify.VFKS2_DESC != "") && (oViewModel_verify.VFKS2_DESC != null))
            {
                if (oViewModel_verify.VFKS2_DESC.Length > 100)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "VFKS2_DESC1";
                    oMSG.VAL_ERRMSG = "Komentar maximal 100 karakter";
                    aValidationMSG.Add(oMSG);
                } //End if (oViewModel_verify.VFKS2_DESC.Length > 100
            } //End if

            //[VFKS2_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "VFKS2_DESC0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_VFKS2_DESC()
        private void Validate_VFKS3_DESC()
        {
            Boolean bIsvalid = true;
            //[VFKS1_DESC] - maxlength
            if ((oViewModel_verify.VFKS3_DESC != "") && (oViewModel_verify.VFKS3_DESC != null))
            {
                if (oViewModel_verify.VFKS3_DESC.Length > 100)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "VFKS3_DESC1";
                    oMSG.VAL_ERRMSG = "Komentar maximal 100 karakter";
                    aValidationMSG.Add(oMSG);
                } //End if (oViewModel_verify.VFKS3_DESC.Length > 100
            } //End if

            //[VFKS3_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "VFKS3_DESC0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_VFKS3_DESC()
        private void Validate_VFKS4_DESC()
        {
            Boolean bIsvalid = true;
            //[VFKS1_DESC] - maxlength
            if ((oViewModel_verify.VFKS4_DESC != "") && (oViewModel_verify.VFKS4_DESC != null))
            {
                if (oViewModel_verify.VFKS4_DESC.Length > 100)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "VFKS4_DESC1";
                    oMSG.VAL_ERRMSG = "Komentar maximal 100 karakter";
                    aValidationMSG.Add(oMSG);
                } //End if (oViewModel_verify.VFKS1_DESC.Length > 100
            } //End if

            //[VFKS4_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "VFKS4_DESC0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_VFKS4_DESC()
        private void Validate_VFKS5_DESC()
        {
            Boolean bIsvalid = true;
            //[VFKS1_DESC] - maxlength
            if ((oViewModel_verify.VFKS5_DESC != "") && (oViewModel_verify.VFKS5_DESC != null))
            {
                if (oViewModel_verify.VFKS5_DESC.Length > 100)
                {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "VFKS5_DESC1";
                    oMSG.VAL_ERRMSG = "Komentar maximal 100 karakter";
                    aValidationMSG.Add(oMSG);
                } //End if (oViewModel_verify.VFKS1_DESC.Length > 100
            } //End if

            //[VFKS5_DESC] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "VFKS5_DESC0";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_VFKS5_DESC()

    } //End public partial class CPAR_Validation
} //End namespace APPBASE.Models

