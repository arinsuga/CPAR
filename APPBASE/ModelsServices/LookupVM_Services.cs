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
using APPBASE.Svcapp;

namespace APPBASE.Models
{
    public partial class lkpResForUserVM {
        public static List<lkpResForUserVM> getDatalist() {
            List<lkpResForUserVM> oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.EmployeeHasnousr_infos
                           select new lkpResForUserVM
                           {
                               RUID = tb.RUID,
                               RES_NM1 = tb.RES_NM1,
                               BRNCH_NM = tb.BRNCH_NM,
                               DEPT_NM = tb.DEPT_NM,
                               JOB_TITLE_NM = tb.JOB_TITLE_NM
                           };
                oReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public static List<lkpResForUserVM> getLookupData()
    } //End public partial class lkpResForUserVM
} //End namespace APPBASE.Models
