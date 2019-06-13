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
    public partial class CPARChat_Validation
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
    } //End public partial class CPARChat_Validation
} //End namespace APPBASE.Models

