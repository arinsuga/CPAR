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
        private User_DetailVM oViewModel;
        private UserDS oDS = new UserDS();
        public List<ValidationMSG_VM> aValidationMSG = new List<ValidationMSG_VM>();

        //Constructor
        public User_Validation(User_DetailVM poViewModel)
        {
            oViewModel = poViewModel;
        } //End public User_Validation()
        public void Validate_UserCreate() {
            Validate_USR_ID();
            Validate_USR_NM1();
            Validate_USR_PSWD();
        } //End public void Validate_UserCreate()
    } //End public class User_Validation
} //End namespace APPBASE.Models