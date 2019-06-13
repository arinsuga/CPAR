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
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class Employee
    {
        //Constructor
        public Employee() {
        } //End public User()

        public void setRES_TYPE(string id = null)
        {
            RES_TYPE = valFLAG.FLAG_EMP_RESTYPE;
        } //End public void setActivate(string id = null)
        public void setActivate(string id = null)
        {
            BP_STS = valFLAG.FLAG_EMPBPSTS_ACTIVE;
        } //End public void setActivate(string id = null)
        public void setDeactivate(string id = null)
        {
            BP_STS = valFLAG.FLAG_EMPBPSTS_INACTIVE;
        } //End public void setDeactivate(string id = null)

        public string setAddressIC()
        {
            return valFLAG.FLAG_EMP_ADDRTYPE_IC;
        } //End public string setAddressIC()
        public string setAddressDMCL()
        {
            return valFLAG.FLAG_EMP_ADDRTYPE_DMCL;
        } //End public string setAddressDMCL()

    } //End public partial class Employee
} //End namespace APPBASE.Models

