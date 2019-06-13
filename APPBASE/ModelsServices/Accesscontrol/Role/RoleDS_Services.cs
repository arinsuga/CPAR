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
using FluentValidation;
using FluentValidation.Mvc;
using FluentValidation.Attributes;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public class RoleDS
    {
        //Constructor
        public RoleDS() { } //End public RoleDS()
        public List<Role_LookupVM> getDatalist(string id = null)
        {
            List<Role_LookupVM> oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Role_infos
                           where tb.MDLE_RUID==id
                           select new Role_LookupVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               ROLE_ID = tb.ROLE_ID,
                               ROLE_CAPTION = tb.ROLE_CAPTION,
                               ROLE_LANG_ID = tb.ROLE_LANG_ID
                           };
                oReturn = oQRY.OrderBy(fld => fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public static List<lkpResForUserVM> getLookupData()
    } //End public class RoleDS
} //End namespace APPBASE.Models

