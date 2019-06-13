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
        private Employee_DetailVM oViewModel;
        private EmployeeDS oDS = new EmployeeDS();
        public List<ValidationMSG_VM> aValidationMSG = new List<ValidationMSG_VM>();
        private HttpPostedFileBase oFileimage;

        //Constructor 1
        public Employee_Validation(Employee_DetailVM poViewModel, HttpPostedFileBase poFileimage)
        {
            oViewModel = poViewModel;
            oFileimage = poFileimage;
        } //End public Employee_Validation()
        //Constructor 2
        public Employee_Validation(Employee_DetailVM poViewModel)
        {
            oViewModel = poViewModel;
        } //End public Employee_Validation()
        public void Validate_Create()
        {
            Validate_RES_ID();
            Validate_RES_XID1();
            Validate_RES_NM1();
            if (oFileimage != null) { Validate_IMG_SRC(); }
        } //End public void Validate_Create()
        public void Validate_Edit()
        {
            Validate_RES_NM1();
            if (oFileimage != null) { Validate_IMG_SRC(); }
        } //End public void Validate_Edit()
        public void Validate_Delete()
        {
            //Validate_RES_ID();
        } //End public void Validate_Delete()
        public void Validate_Career()
        {
            //Validate_RES_ID();
        } //End public void Validate_Career()
        public void Validate_EditQuit()
        {
            //Validate_RES_NM1();
        } //End public void Validate_Edit()
    } //End public partial class Employee_Validation
} //End namespace APPBASE.Models

