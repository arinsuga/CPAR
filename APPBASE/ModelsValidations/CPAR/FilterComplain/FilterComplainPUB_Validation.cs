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
    public partial class FilterComplain_Validation
    {
        private FilterComplain_DetailVM oViewModel;
        //private FilterCPARDS oDS = new FilterCPARDS();
        public List<ValidationMSG_VM> aValidationMSG = new List<ValidationMSG_VM>();

        //Constructor
        public FilterComplain_Validation(FilterComplain_DetailVM poViewModel)
        {
            oViewModel = poViewModel;
        } //End public FilterCPAR_Validation()
        public void Validate_Export()
        {
            //Validate_RUID();
            Validate_Complain_DT1();
            Validate_Complain_DT2();
        } //End public void Validate_Create()
    } //End public partial class FilterCPAR_Validation
} //End namespace APPBASE.Models

