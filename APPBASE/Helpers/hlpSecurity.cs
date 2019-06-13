using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using APPBASE.Helpers;
using APPBASE.Models;

namespace APPBASE.Helpers
{
    public class hlpCredentialInfo
    {
        //public static Boolean
        public static Boolean isValidDBLogin(string psUserID, string psPassword, string psMdleRUID)
        {
            Boolean vReturn = false;
            string vsUserID = psUserID.ToUpper();
            string vsUserPassword = psPassword;
            string vsMdleRUID = psMdleRUID.ToUpper();
            string vsUserIDDS = null;
            string vsUserPasswordDS = null;
            string vsUserRUIDDS = null;
            string vsUserRES_RUID = "";

            try
            {
                using (var db = new DBMAINContext())
                {
                    //modAccessControl.LoginInfo LoginInfoDS = new modAccessControl.LoginInfo(vsUserID);

                    //var qryLogin = db.Users
                    //    .Select(fld => new {fld.RUID, fld.USR_ID, fld.USR_PSWD, fld.RES_RUID})
                    //    .SingleOrDefault(fld => fld.USR_ID.ToUpper() == vsUserID);

                    UserDS oDSUser = new UserDS();
                    var qryLogin = oDSUser.getData_byUSR_ID(vsUserID);

                    //vsUserIDDS = qryLogin.USR_ID.ToString();
                    vsUserIDDS = qryLogin.USR_ID.ToUpper();
                    vsUserPasswordDS = hlpObf.randomDecrypt(qryLogin.USR_PSWD.ToString());
                    vsUserRUIDDS = qryLogin.RUID.ToString();
                    if (qryLogin.RES_RUID != null)
                    {
                        vsUserRES_RUID = qryLogin.RES_RUID.ToString();
                    } //End if
                    if ((vsUserID == vsUserIDDS) && (vsUserPassword == vsUserPasswordDS))
                    {
                        //setValidCredential(psUserID, vsUserRUIDDS, vsMdleRUID, hlpGeneral.FlagInfo.getFlagValid());
                        setValidCredential(vsMdleRUID, qryLogin);
                        setEmployee_Jobinfo(qryLogin);
                        vReturn = true;
                    } //End if


                } //End using (var db = new DBMAINContext())
            } //End try
            catch (Exception e) { vsUserIDDS = e.Message; }
            finally { } //End finally

            return vReturn;
        } //End public static Boolean isValidDBLogin
        public static void isValidCredential(ActionExecutedContext context)
        {
            //Validate Is User logged in
            if ((hlpConfig.SessionInfo.getAppUsrID() == "") ||
                (hlpConfig.SessionInfo.getAppUsrID() == null))
            {

                context.Result = new RedirectToRouteResult(new RouteValueDictionary 
                { 
                    { "controller", "Account" }, 
                    { "action", "Login" } 
                });

                //HttpContext.Current.Response.Redirect("~/Account/Login");
            } //End if ((hlpConfig.SessionInfo.getAppUsrID() == "") ||

            //Validate user access control
            string sAC_MENU_RUID = context.Controller.ViewBag.AC_MENU_RUID;
            if (sAC_MENU_RUID != null)
            {
                if (sAC_MENU_RUID != APPBASE.Svcbiz.valFLAG.FLAG_ROLE_SYSADMIN) {
                    UserDS oDS = new UserDS();
                    Boolean isValid = oDS.isGranted_menu(sAC_MENU_RUID);
                    if (!isValid)
                    {

                        context.Result = new RedirectToRouteResult(new RouteValueDictionary 
                    { 
                        { "controller", "Error" }, 
                        { "action", "Error403" } 
                    });
                    } //End if (!isValid)
                } //End if (sAC_MENU_RUID != APPBASE.Svcbiz.valFLAG.FLAG_ROLE_SYSADMIN)
            } //End if (sAC_MENU_RUID != null)

        } //End public static string isValidCredential
        public static void setValidCredential(string psAppUsrID, string psAppUsrRUID,
                                              string psAppMdleRUID, string psAppIsLoggedIn)
        {
            hlpConfig.SessionInfo.setAppUsrID(psAppUsrID);
            hlpConfig.SessionInfo.setAppUsrRUID(psAppUsrRUID);
            hlpConfig.SessionInfo.setAppMdleRUID(psAppMdleRUID);
            hlpConfig.SessionInfo.setAppIsLoggedIn(psAppIsLoggedIn);
        } //End public static void setValidCredential()
        public static void setValidCredential(string psMdleRUID, User_DetailVM poViewmodel)
        {
            hlpConfig.SessionInfo.setAppUsrID(poViewmodel.USR_ID.ToUpper());
            hlpConfig.SessionInfo.setAppUsrRUID(poViewmodel.RUID.ToString());
            hlpConfig.SessionInfo.setAppMdleRUID(psMdleRUID);
            hlpConfig.SessionInfo.setAppRoleRUID(poViewmodel.ROLE_RUID);
            hlpConfig.SessionInfo.setAppIsLoggedIn(hlpGeneral.FlagInfo.getFlagValid());
        } //End public static void setValidCredential(User_DetailVM poViewmodel)
        public static void setEmployee_Jobinfo(string psRES_RUID)
        {
            if ((psRES_RUID != null) && (psRES_RUID != "")) {
                EmployeeDS oDS = new EmployeeDS();
                //EmployeeJobinfo oVM = oDS.getData_Jobinfo(psRES_RUID);
                Employee_jobattrVM oVM = oDS.getData_jobattr(psRES_RUID);

                hlpConfig.SessionInfo.setAppUsrRES_RUID(psRES_RUID);
                hlpConfig.SessionInfo.setAppUsrRES_NM(oVM.RES_NM1);

                hlpConfig.SessionInfo.setAppUsrDEPT_RUID(oVM.DEPT_RUID);
                hlpConfig.SessionInfo.setAppUsrDEPT_NM(oVM.DEPT_NM);

                hlpConfig.SessionInfo.setAppUsrJOBTTL_RUID(oVM.JOB_TITLE_RUID);
                hlpConfig.SessionInfo.setAppUsrJOBTTL_NM(oVM.JOB_TITLE_NM);
            } //End if ((psRES_RUID != null) && (psRES_RUID != ""))
        } //End public static void setEmployee_Jobinfo(string psRES_RUID)
        public static void setEmployee_Jobinfo(User_DetailVM poViewmodel)
        {
            hlpConfig.SessionInfo.setAppUsrRES_RUID(poViewmodel.RES_RUID);
            hlpConfig.SessionInfo.setAppUsrRES_NM(poViewmodel.RES_NM1);

            hlpConfig.SessionInfo.setAppUsrDEPT_RUID(poViewmodel.DEPT_RUID);
            hlpConfig.SessionInfo.setAppUsrDEPT_NM(poViewmodel.DEPT_NM);

            hlpConfig.SessionInfo.setAppUsrJOBTTL_RUID(poViewmodel.JOB_TITLE_RUID);
            hlpConfig.SessionInfo.setAppUsrJOBTTL_NM(poViewmodel.JOB_TITLE_NM);

            hlpConfig.SessionInfo.setAppUsrIMG_SRC(poViewmodel.IMG_SRC);
        } //End public static void setEmployee_Jobinfo(UserDS poDSUser)
        public static void isValidAccessMenu(string psAppMnuRUID)
        {

            //string vsForbidenAccess = "~/AccCtrl/ForbidenAccess";
            //string vsUserRUID = hlpConfig.SessionInfo.getAppUsrRUID();
            //string vsMdleRUID = hlpConfig.SessionInfo.getAppMdleRUID();
            //modACModuleMenu.ACUserMenu1RowDS voACUserMenu1RowDS = new modACModuleMenu.ACUserMenu1RowDS(vsUserRUID, vsMdleRUID, psAppMnuRUID);
            //if (voACUserMenu1RowDS.TBLData != null)
            //{
            //    int vnRowCount = voACUserMenu1RowDS.TBLData.Length;
            //    if (vnRowCount <= 0) { HttpContext.Current.Response.Redirect(vsForbidenAccess); } //End if
            //}
            //else { HttpContext.Current.Response.Redirect(vsForbidenAccess); } //End if

        } //End public static string isValidCredential

        public static Boolean isGranted_menu(string psAC_MENU_RUID) {
            UserDS oDS = new UserDS();
            return oDS.isGranted_menu(psAC_MENU_RUID);
        } //End public static Boolean isValidMenu(string psAC_MENU_RUID)
    
    } //End public class CredentialInfo
} //End namespace APPBASE.Helper
