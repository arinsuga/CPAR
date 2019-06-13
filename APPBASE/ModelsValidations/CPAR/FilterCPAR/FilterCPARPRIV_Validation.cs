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
    public partial class FilterCPAR_Validation
    {
        private void Validate_CPAR_DT1()
        {
            Boolean bIsvalid = true;
            //[CPAR_DT1] - Required
            if ((oViewModel.CPAR_DT1 == null) && (oViewModel.CPAR_DT2 != null))
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_DT11";
                oMSG.VAL_ERRMSG = "Tanggal tidak boleh kosong";
                aValidationMSG.Add(oMSG);
            } //End if
            if ((oViewModel.CPAR_DT1 != null) && (oViewModel.CPAR_DT2 != null))
            {
                if (oViewModel.CPAR_DT1 >oViewModel.CPAR_DT2) {
                    bIsvalid = false;
                    ValidationMSG_VM oMSG = new ValidationMSG_VM();
                    oMSG.VAL_ERRID = "CPAR_DT11";
                    oMSG.VAL_ERRMSG = "Tanggal awal tidak boleh lebih besar dari tanggal kedua";
                    aValidationMSG.Add(oMSG);
                }
            } //End if


            //[CPAR_DT1] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_DT10";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_CPAR_DT1()
        private void Validate_CPAR_DT2()
        {
            Boolean bIsvalid = true;
            //[CPAR_DT2] - Required
            if ((oViewModel.CPAR_DT1 != null) && (oViewModel.CPAR_DT2 == null)) {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_DT21";
                oMSG.VAL_ERRMSG = "Tanggal tidak boleh kosong";
                aValidationMSG.Add(oMSG);
            } //End if

            //[CPAR_DT2] - If has error(s)
            if (!bIsvalid)
            {
                bIsvalid = false;
                ValidationMSG_VM oMSG = new ValidationMSG_VM();
                oMSG.VAL_ERRID = "CPAR_DT20";
                oMSG.VAL_ERRMSG = "ERROR";
                aValidationMSG.Add(oMSG);
            } //End if
        } //End private void Validate_CPAR_DT2()

    } //End public partial class FilterCPAR_Validation
} //End namespace APPBASE.Models

