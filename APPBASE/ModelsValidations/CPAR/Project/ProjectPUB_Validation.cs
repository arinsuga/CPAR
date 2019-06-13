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
    public partial class Project_Validation
    {
        private Project_DetailVM oViewModel;
        private ProjectDS oDS = new ProjectDS();
        public List<ValidationMSG_VM> aValidationMSG = new List<ValidationMSG_VM>();

        //Constructor
        public Project_Validation(Project_DetailVM poViewModel)
        {
            oViewModel = poViewModel;
        } //End public Project_Validation()
        public void Validate_Create()
        {
            //Validate_RUID();
            Validate_PROJ_ID();
            Validate_PROJ_NM();
            Validate_CLIENT_RUID();
        } //End public void Validate_Create()
        public void Validate_Edit()
        {
            //Validate_RUID();
            Validate_PROJ_NM();
            Validate_CLIENT_RUID();
        } //End public void Validate_Edit()
        public void Validate_Delete()
        {
            Validate_DELETE();
        } //End public void Validate_Delete()
    } //End public partial class Project_Validation
} //End namespace APPBASE.Models

