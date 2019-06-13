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
        //Constructor
        public UserDS() { } //End public UserDS
        public List<User_ListVM> getDatalist(string psROLE_RUID=null)
        {
            List<User_ListVM> oReturn;


            using (var db = new DBMAINContext())
            {
                List<string> sNotIn = new List<string>();
                sNotIn.Add(valDFLT.USR_IDSYSTEM); sNotIn.Add(valDFLT.USR_IDGENERAL); sNotIn.Add(valDFLT.USR_IDDEMO);

                var oQRY = from tb in db.User_infos
                           where !sNotIn.Contains(tb.USR_ID)
                           select new User_ListVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               BP_STS = tb.BP_STS,
                               ROLE_RUID = tb.ROLE_RUID,
                               ROLE_NM = tb.ROLE_NM,
                               USR_ID = tb.USR_ID,
                               USR_NM1 = tb.USR_NM1,
                               RES_NM1 = tb.RES_NM1,
                               DEPT_NM = tb.DEPT_NM,
                               BRNCH_NM = tb.BRNCH_NM,
                               JOB_TITLE_NM = tb.JOB_TITLE_NM,
                               IMG_SRC = tb.IMG_SRC,
                               RES_RUID = tb.RES_RUID
                           };
                if ((psROLE_RUID != "") && (psROLE_RUID != null)) { oQRY = oQRY.Where(fld => fld.ROLE_RUID == psROLE_RUID); }
                oReturn = oQRY.OrderBy(fld => fld.USR_ID).ToList();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public static List<User_ListVM> getDatalist()
        public List<User_ListVM> getDatalist(User_DetailCPARVM poViewModel)
        {
            List<User_ListVM> oReturn;


            using (var db = new DBMAINContext())
            {
                List<string> sNotIn = new List<string>();
                sNotIn.Add(valDFLT.USR_IDSYSTEM); sNotIn.Add(valDFLT.USR_IDGENERAL); sNotIn.Add(valDFLT.USR_IDDEMO);

                var oQRY = from tb in db.User_infos
                           where !sNotIn.Contains(tb.USR_ID)
                           select new User_ListVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               BP_STS = tb.BP_STS,
                               ROLE_RUID = tb.ROLE_RUID,
                               ROLE_NM = tb.ROLE_NM,
                               USR_ID = tb.USR_ID,
                               USR_NM1 = tb.USR_NM1,
                               RES_NM1 = tb.RES_NM1,
                               DEPT_NM = tb.DEPT_NM,
                               BRNCH_NM = tb.BRNCH_NM,
                               JOB_TITLE_NM = tb.JOB_TITLE_NM,
                               IMG_SRC = tb.IMG_SRC,
                               RES_RUID = tb.RES_RUID
                           };
                if ((poViewModel.ROLE_RUID != "") && (poViewModel.ROLE_RUID != null)) { oQRY = oQRY.Where(fld => fld.ROLE_RUID == poViewModel.ROLE_RUID); }

                if ((poViewModel.FILTER_ROLE != "") && (poViewModel.FILTER_ROLE != null)) { oQRY = oQRY.Where(fld => fld.ROLE_NM.ToUpper().Contains(poViewModel.FILTER_ROLE.ToUpper())); }
                if ((poViewModel.FILTER_DEPARTEMEN != "") && (poViewModel.FILTER_DEPARTEMEN != null)) { oQRY = oQRY.Where(fld => fld.DEPT_NM.ToUpper().Contains(poViewModel.FILTER_DEPARTEMEN.ToUpper())); }
                if ((poViewModel.FILTER_NAMA != "") && (poViewModel.FILTER_NAMA != null)) { oQRY = oQRY.Where(fld => fld.USR_NM1.ToUpper().Contains(poViewModel.FILTER_NAMA.ToUpper())); }

                oReturn = oQRY.OrderBy(fld => fld.USR_ID).ToList();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public List<User_ListVM> getDatalist(User_DetailCPARVM poViewModel = null)
        public List<Userrolemenu_ListVM> getDatalist_Rolemenu(string psROLE_RUID, string psMDLE_RUID, string psUSR_RUID)
        {
            List<Userrolemenu_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tbRolemenu in db.Rolemenu_infos
                           from tbUsermenu in db.Usermenu_infos
                           .Where(fldUsermenu => (tbRolemenu.MNU_RUID == fldUsermenu.MNU_RUID)
                                  && (fldUsermenu.MDLE_RUID == psMDLE_RUID)
                                  && (fldUsermenu.USR_RUID == psUSR_RUID))
                           .DefaultIfEmpty()
                           where tbRolemenu.ROLE_RUID == psROLE_RUID
                           orderby tbRolemenu.RSEQNO
                           select new Userrolemenu_ListVM
                           {
                               RSEQNO = tbRolemenu.RSEQNO,
                               RUID = tbRolemenu.RUID,
                               DTA_STS = tbRolemenu.DTA_STS,
                               BP_STS = tbRolemenu.BP_STS,
                               USR_RUID = tbUsermenu.USR_RUID,
                               MDLE_RUID = tbRolemenu.MDLE_RUID,
                               MDLE_CAPTION = tbRolemenu.MDLE_CAPTION,
                               MNU_RUID = tbRolemenu.MNU_RUID,
                               MNU_RSEQNO = tbRolemenu.MNU_RSEQNO,
                               MNU_CAPTION = tbRolemenu.MNU_CAPTION,
                               MNU_PARENT_RUID = tbRolemenu.MNU_PARENT_RUID,
                               MNU_LEVEL = tbRolemenu.MNU_LEVEL,
                               MNU_TYPE = tbRolemenu.MNU_TYPE,
                               MNU_ISVISIBLE = tbRolemenu.MNU_ISVISIBLE,
                               ROLE_RUID = tbRolemenu.ROLE_RUID,
                               ROLE_CAPTION = tbRolemenu.ROLE_CAPTION,
                               ISGRANTED = tbUsermenu.MNU_RUID
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Userrolemenu_ListVM> getDatalist_Rolemenu(string psROLE_RUID, string psMDLE_RUID, string psUSR_RUID)
        public User_DetailVM getData(string id = null)
        {
            User_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                List<string> sNotIn = new List<string>();
                sNotIn.Add(valDFLT.USR_IDSYSTEM); sNotIn.Add(valDFLT.USR_IDGENERAL); sNotIn.Add(valDFLT.USR_IDDEMO);

                var oQRY = from tb in db.User_infos
                           where !sNotIn.Contains(tb.USR_ID) && tb.RUID == id
                           select new User_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               BP_STS = tb.BP_STS,
                               ROLE_RUID = tb.ROLE_RUID,
                               ROLE_NM = tb.ROLE_NM,
                               USR_ID = tb.USR_ID,
                               USR_NM1 = tb.USR_NM1,
                               RES_NM1 = tb.RES_NM1,
                               DEPT_NM = tb.DEPT_NM,
                               BRNCH_NM = tb.BRNCH_NM,
                               JOB_TITLE_NM = tb.JOB_TITLE_NM,
                               IMG_SRC = tb.IMG_SRC,
                               RES_RUID = tb.RES_RUID
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public static User_DetailVM getData(string id = null)
        public Userrole_DetailVM getData_Userrole_Detail(string psUSR_RUID, string psMDLE_RUID)
        {
            Userrole_DetailVM oReturn = null;
            string vsErrMsg = "";

            try
            {
                using (var db = new DBMAINContext())
                {
                    List<string> sNotIn = new List<string>();
                    sNotIn.Add(valDFLT.USR_IDSYSTEM); sNotIn.Add(valDFLT.USR_IDGENERAL); sNotIn.Add(valDFLT.USR_IDDEMO);

                    var oQRY = from tb in db.User_infos
                               where !sNotIn.Contains(tb.USR_ID) && tb.RUID == psUSR_RUID
                               select new Userrole_DetailVM
                               {
                                   RUID = tb.RUID,
                                   DTA_STS = tb.DTA_STS,
                                   BP_STS = tb.BP_STS,
                                   ROLE_RUID = tb.ROLE_RUID,
                                   ROLE_NM = tb.ROLE_NM,
                                   USR_ID = tb.USR_ID,
                                   USR_NM1 = tb.USR_NM1,
                                   RES_NM1 = tb.RES_NM1,
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
        public User_DetailVM getData_byUSR_ID(string id = null)
        {
            User_DetailVM oReturn;
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.User_infos
                           where tb.USR_ID.ToUpper() == id.ToUpper()
                           select new User_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               BP_STS = tb.BP_STS,
                               ROLE_RUID = tb.ROLE_RUID,
                               ROLE_NM = tb.ROLE_NM,
                               USR_ID = tb.USR_ID,
                               USR_PSWD = tb.USR_PSWD,
                               USR_NM1 = tb.USR_NM1,
                               RES_NM1 = tb.RES_NM1,
                               DEPT_RUID = tb.DEPT_RUID,
                               DEPT_NM = tb.DEPT_NM,
                               BRNCH_RUID = tb.BRNCH_RUID,
                               BRNCH_NM = tb.BRNCH_NM,
                               JOB_TITLE_RUID = tb.JOB_TITLE_RUID,
                               JOB_TITLE_NM = tb.JOB_TITLE_NM,
                               IMG_SRC = tb.IMG_SRC,
                               RES_RUID = tb.RES_RUID
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public User_DetailVM getData_byUSR_ID(string id = null)

        //Check Exists
        public Boolean isExists_USR_ID(string id = null)
        {
            Boolean vReturn = false;


            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.User_infos
                            where tb.USR_ID == id
                            select new { USR_ID = tb.USR_ID }).ToList();

                if (oQRY.Count > 0) { vReturn = true; }
                

            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isExists_USR_ID(string id = null)
        //Check Granted user to menu
        public Boolean isGranted_menu(string id = null)
        {
            Boolean vReturn = false;
            string sMDLE_RUID = hlpConfig.SessionInfo.getAppMdleRUID();
            string sUSR_RUID = hlpConfig.SessionInfo.getAppUsrRUID();

            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Usermenus
                            where tb.MNU_RUID==id && tb.MDLE_RUID==sMDLE_RUID && tb.USR_RUID==sUSR_RUID
                            select new { MNU_RUID = tb.MNU_RUID }).ToList();

                if (oQRY.Count > 0) { vReturn = true; }


            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isExists_USR_ID(string id = null)
    } //End public partial class UserDS : SEARCH_USER
} //End namespace APPBASE.Models