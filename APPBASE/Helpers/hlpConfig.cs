using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data;
using System.Data.Entity;
using APPBASE.Helpers;

namespace APPBASE.Helpers
{
    public class hlpConfig
    {
        public class SessionInfo {
            public static void setDefSession() {

                //User Login Information
                HttpContext.Current.Session["AppUsrID"] = ""; //modif this line for testing = SYSTEM
                HttpContext.Current.Session["AppUsrRUID"] = ""; //modif this line for testing = RUID001
                HttpContext.Current.Session["AppMdleRUID"] = ""; //modif this line for testing = ASMIT / HRIS
                HttpContext.Current.Session["AppRoleRUID"] = ""; //modif this line for testing = ADMIN/ANONYMOUS

                //Resource Information
                HttpContext.Current.Session["AppUsrRES_RUID"] = ""; //modif this line for testing = Base on User Login
                HttpContext.Current.Session["AppUsrRES_NM"] = ""; //modif this line for testing = Base on User Login
                HttpContext.Current.Session["AppUsrDEPT_RUID"] = ""; //modif this line for testing = Base on User Login
                HttpContext.Current.Session["AppUsrDEPT_NM"] = ""; //modif this line for testing = Base on User Login
                HttpContext.Current.Session["AppUsrJOBTTL_RUID"] = ""; //modif this line for testing = Base on User Login
                HttpContext.Current.Session["AppUsrJOBTTL_NM"] = ""; //modif this line for testing = Base on User Login
                HttpContext.Current.Session["AppUsrIMG_SRC"] = "";
                
                HttpContext.Current.Session["AppProgID"] = "";
                HttpContext.Current.Session["AppIsLoggedIn"] = hlpGeneral.FlagInfo.getFlagNotValid();
                HttpContext.Current.Session["AppDefDateFormatShort"] = ConstantaInfo.FMT_DTSHT;
                HttpContext.Current.Session["AppDefDateFormatLong"] = ConstantaInfo.FMT_DTLONG;
                HttpContext.Current.Session["AppDef1000Separator"] = ConstantaInfo.SGN_1000SEP;
                HttpContext.Current.Session["AppDefDecimalSign"] = ConstantaInfo.SGN_DECSEP;
                HttpContext.Current.Session["AppDefDecimalDigit"] = ConstantaInfo.FMT_DECNUM;
                HttpContext.Current.Session["AppDefCurrencySign"] = ConstantaInfo.SGN_CURR;
                HttpContext.Current.Session["AppDefLanguage"] = ConstantaInfo.LNG_DEFF;
                //Input Mask
                HttpContext.Current.Session["AppDefDateInputMaskShort"] = ConstantaInfo.IMSK_DTSHT;
            } //End public static void setDefSession
            //Set Credential
            public static void setAppUsrID(string psValue) { HttpContext.Current.Session["AppUsrID"] = psValue; }
            public static void setAppUsrRUID(string psValue) { HttpContext.Current.Session["AppUsrRUID"] = psValue; }
            public static void setAppRoleRUID(string psValue) { HttpContext.Current.Session["AppRoleRUID"] = psValue; }
            //Set Resource Information
            public static void setAppUsrRES_RUID(string psValue) { HttpContext.Current.Session["AppUsrRES_RUID"] = psValue; }
            public static void setAppUsrRES_NM(string psValue) { HttpContext.Current.Session["AppUsrRES_NM"] = psValue; }
            public static void setAppUsrDEPT_RUID(string psValue) { HttpContext.Current.Session["AppUsrDEPT_RUID"] = psValue; }
            public static void setAppUsrDEPT_NM(string psValue) { HttpContext.Current.Session["AppUsrDEPT_NM"] = psValue; }
            public static void setAppUsrJOBTTL_RUID(string psValue) { HttpContext.Current.Session["AppUsrJOBTTL_RUID"] = psValue; }
            public static void setAppUsrJOBTTL_NM(string psValue) { HttpContext.Current.Session["AppUsrJOBTTL_NM"] = psValue; }
            public static void setAppUsrIMG_SRC(string psValue) { HttpContext.Current.Session["AppUsrIMG_SRC"] = psValue; }

            
            public static void setAppMdleRUID(string psValue) { HttpContext.Current.Session["AppMdleRUID"] = psValue; }
            public static void setAppProgID(string psValue) { HttpContext.Current.Session["AppProgID"] = psValue; }
            public static void setAppIsLoggedIn(string psValue) { HttpContext.Current.Session["AppIsLoggedIn"] = psValue; }

            //Get Credential
            public static string getAppUsrID() { return HttpContext.Current.Session["AppUsrID"].ToString(); }
            public static string getAppUsrRUID() { return HttpContext.Current.Session["AppUsrRUID"].ToString(); }
            public static string getAppRoleRUID() { return HttpContext.Current.Session["AppRoleRUID"].ToString(); }
            //Get Resource Information
            public static string getAppUsrRES_RUID() {
                string vReturn = "";
                if (HttpContext.Current.Session["AppUsrRES_RUID"] != null) { vReturn = HttpContext.Current.Session["AppUsrRES_RUID"].ToString(); }
                return vReturn;
            }
            public static string getAppUsrRES_NM() {
                string vReturn = "";
                if (HttpContext.Current.Session["AppUsrRES_NM"] != null) { vReturn = HttpContext.Current.Session["AppUsrRES_NM"].ToString(); }
                return vReturn;
            }
            public static string getAppUsrDEPT_RUID() {
                string vReturn = "";
                if (HttpContext.Current.Session["AppUsrDEPT_RUID"] != null) { vReturn = HttpContext.Current.Session["AppUsrDEPT_RUID"].ToString(); }
                return vReturn;
            }
            public static string getAppUsrDEPT_NM() {
                string vReturn = "";
                if (HttpContext.Current.Session["AppUsrDEPT_NM"] != null) { vReturn = HttpContext.Current.Session["AppUsrDEPT_NM"].ToString(); }
                return vReturn;
            }
            public static string getAppUsrJOBTTL_RUID() {
                string vReturn = "";
                if (HttpContext.Current.Session["AppUsrJOBTTL_RUID"] != null) { vReturn = HttpContext.Current.Session["AppUsrJOBTTL_RUID"].ToString(); }
                return vReturn;
            }
            public static string getAppUsrJOBTTL_NM() {
                string vReturn = "";
                if (HttpContext.Current.Session["AppUsrJOBTTL_NM"] != null) { vReturn = HttpContext.Current.Session["AppUsrJOBTTL_NM"].ToString(); }
                return vReturn;
            }
            public static string getAppUsrIMG_SRC()
            {
                string vReturn = "";
                if (HttpContext.Current.Session["AppUsrIMG_SRC"] != null) { vReturn = HttpContext.Current.Session["AppUsrIMG_SRC"].ToString(); }
                return vReturn;
            }

            public static string getAppMdleRUID() { return HttpContext.Current.Session["AppMdleRUID"].ToString(); }
            public static string getAppProgID() { return HttpContext.Current.Session["AppProgID"].ToString(); }
            public static string getAppIsLoggedIn() { return HttpContext.Current.Session["AppIsLoggedIn"].ToString(); }
        } //End public class SessionInfo
        public class ConstantaInfo {
            //Formats
            public const string FMT_DTSHT = "dd/MM/yyyy";
            public const string FMT_DTSHT_JS = "dd/mm/yy";
            public const string FMT_DTLONG = "dd/MM/yyyy hh:mm:ss";
            public const string FMT_DTLONG_JS = "dd/MM/yy hh:mm:ss";
            public const string FMT_DECNUM = "2";
            //Input mask
            public const string IMSK_DTSHT = "99/99/9999";
            //Sign and Symbols
            public const string SGN_1000SEP = ",";
            public const string SGN_DECSEP = ".";
            public const string SGN_CURR = "Rp.";
            //Codes
            public const string LNG_DEFF = "ID";
            //BaseURL
            //public const string BASE_URL = 
            //Application Module
            public const string MDLE_RUID = "CPAR"; //modif this line for testing = CCS/HCIS/HRIS

        } //End public class ConstantaInfo
    } //End public class hlpConfig
} //End namespace APPBASE.Helper
