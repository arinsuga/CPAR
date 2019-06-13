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
using APPBASE.Svcapp;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class UserDS : SEARCH_USER
    {
        public User_DetailCPARVM getDataCPAR(string id = null) {
            User_DetailCPARVM oReturn;


            using (var db = new DBMAINContext())
            {
                List<string> sNotIn = new List<string>();
                sNotIn.Add(valDFLT.USR_IDSYSTEM); sNotIn.Add(valDFLT.USR_IDGENERAL); sNotIn.Add(valDFLT.USR_IDDEMO);

                var oQRY = from tb in db.User_infos
                           where !sNotIn.Contains(tb.USR_ID) && tb.RUID == id
                           select new User_DetailCPARVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               BP_STS = tb.BP_STS,
                               ROLE_RUID = tb.ROLE_RUID,
                               ROLE_NM = tb.ROLE_NM,
                               USR_ID = tb.USR_ID,
                               USR_NM1 = tb.USR_NM1,
                               RES_NM1 = tb.RES_NM1,
                               DEPT_RUID = tb.DEPT_RUID,
                               DEPT_NM = tb.DEPT_NM,
                               BRNCH_NM = tb.BRNCH_NM,
                               JOB_TITLE_NM = tb.JOB_TITLE_NM,
                               IMG_SRC = tb.IMG_SRC,
                               RES_RUID = tb.RES_RUID
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public User_DetailCPARVM getDataCPAR(string id = null)
        public Userrole_DetailCPARVM getData_Userrole_DetailCPAR(string psUSR_RUID, string psMDLE_RUID)
        {
            Userrole_DetailCPARVM oReturn = null;
            string vsErrMsg = "";

            try
            {
                using (var db = new DBMAINContext())
                {
                    List<string> sNotIn = new List<string>();
                    sNotIn.Add(valDFLT.USR_IDSYSTEM); sNotIn.Add(valDFLT.USR_IDGENERAL); sNotIn.Add(valDFLT.USR_IDDEMO);

                    var oQRY = from tb in db.User_infos
                               where !sNotIn.Contains(tb.USR_ID) && tb.RUID == psUSR_RUID
                               select new Userrole_DetailCPARVM
                               {
                                   RUID = tb.RUID,
                                   DTA_STS = tb.DTA_STS,
                                   BP_STS = tb.BP_STS,
                                   ROLE_RUID = tb.ROLE_RUID,
                                   ROLE_NM = tb.ROLE_NM,
                                   USR_ID = tb.USR_ID,
                                   USR_NM1 = tb.USR_NM1,
                                   RES_NM1 = tb.RES_NM1,
                                   DEPT_RUID = tb.DEPT_RUID,
                                   DEPT_NM = tb.DEPT_NM,
                                   BRNCH_NM = tb.BRNCH_NM,
                                   JOB_TITLE_NM = tb.JOB_TITLE_NM,
                                   IMG_SRC = tb.IMG_SRC,
                                   RES_RUID = tb.RES_RUID
                               };
                    oReturn = oQRY.SingleOrDefault();
                    string vsROLE_RUID = "";
                    if (oReturn.ROLE_RUID != null) { vsROLE_RUID = oReturn.ROLE_RUID; }

                    oReturn.Userrolemenu_ListVM = getDatalist_Rolemenu(vsROLE_RUID, psMDLE_RUID, psUSR_RUID);

                } //End using (var = new DbContext())
            } //End try
            catch (Exception e) { vsErrMsg = e.Message; } //End catch
            return oReturn;
        } //End public Userrole_DetailVM getData_Userrole_Detail(string id = null)
    } //End public partial class UserDS : SEARCH_USER
} //End namespace APPBASE.Models