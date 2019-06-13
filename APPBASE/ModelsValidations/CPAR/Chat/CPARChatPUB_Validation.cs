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
        private CPARChat_DetailVM oViewModel;
        private CPARChatDS oDS = new CPARChatDS();
        public List<ValidationMSG_VM> aValidationMSG = new List<ValidationMSG_VM>();

        //Constructor
        public CPARChat_Validation(CPARChat_DetailVM poViewModel)
        {
            oViewModel = poViewModel;
        } //End public CPARChat_Validation()
        public void Validate_Create()
        {
            //Validate_RUID();
        } //End public void Validate_Create()
        public void Validate_Edit()
        {
            //Validate_RUID();
        } //End public void Validate_Edit()
        public void Validate_Delete()
        {
            //Validate_RUID();
        } //End public void Validate_Delete()
        public void Validate_Chat()
        {
            //Validate_RUID();
        } //End public void Validate_Create()
    } //End public partial class CPARChat_Validation
} //End namespace APPBASE.Models

