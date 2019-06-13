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
        private User_DetailCPARVM oViewModelCPAR;
        private HttpPostedFileBase oFileimage;

        //Constructor 2
        public User_Validation(User_DetailCPARVM poViewModel, HttpPostedFileBase poFileimage)
        {
            oViewModelCPAR = poViewModel;
        } //End public User_Validation()
        public void Validate_UserCreateCPAR() {
            Validate_USR_ID_CPAR();
            Validate_USR_NM1_CPAR();
            Validate_DEPT_RUID_CPAR();
            Validate_USR_PSWD_CPAR();
            if (oFileimage != null) { Validate_IMG_SRC(); }
        } //End public void Validate_UserCreate()
        public void Validate_UserUpdateCPAR()
        {
            Validate_USR_ID_CPAR2();
            Validate_USR_NM1_CPAR();
            Validate_DEPT_RUID_CPAR();
            Validate_USR_PSWD_CPAR();
            if (oFileimage != null) { Validate_IMG_SRC(); }
        } //End public void Validate_UserCreate()
    } //End public class User_Validation
} //End namespace APPBASE.Models