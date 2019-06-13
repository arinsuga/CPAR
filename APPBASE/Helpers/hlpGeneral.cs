using System;
using System.Collections.Generic;
using System.Web;
using System.IO;

namespace APPBASE.Helpers
{
    public class hlpGeneral
    {
        #region 01 - Class Flag Info
        public class FlagInfo
        {
            public static string getFlagValid()
            {
                return "Y";
            }
            public static string getFlagNotValid()
            {
                return "N";
            }

            public static string getNumSuccess()
            {
                return "0";
            }
            public static string getNumFailed()
            {
                return "1";
            }
            public static string getNumErrApp()
            {
                return "1";
            }
            public static string getNumErrSys()
            {
                return "2";
            }

        }
        public class LKPInfo
        {
            //LOV Component
            public static string getLKPComponentCtgryHWIT()
            {
                return "HARDWARE_IT";
            }
            public static string getLKPComponentCtgrySW()
            {
                return "SOFTWARE";
            }
            //public static string getLKPComponentCtgryHWITDesc()
            //{
            //    return Helper.hlpXML.hlpLanguage.getLangByID("LKP_HARDWARE_IT");
            //}
            //public static string getLKPComponentCtgrySWDesc()
            //{
            //    return Helper.hlpXML.hlpLanguage.getLangByID("LKP_SOFTWARE");
            //}
        }
        public class TypeInfo
        {


            public static string getTypeResourceEMP()
            {
                return "EMP";
            }
            public static string getTypeResourceSUP()
            {
                return "SUP";
            }
            public static string getTypeResourceCLN()
            {
                return "CLN";
            }
        }
        public class HistInfo
        {
            //Type
            public static string getHistTypeActNew()
            {
                return "NEW";
            }
            public static string getHistTypeActUpd()
            {
                return "UPD";
            }
            public static string getHistTypeActDel()
            {
                return "DEL";
            }

            //Description 1
            //public static string getHistTypeDesc1ActNew()
            //{
            //    return hlpXML.hlpLanguage.getLangByID("HIST_ACT_DESC1_NEW");
            //}
            //public static string getHistTypeDesc1ActUpd()
            //{
            //    return hlpXML.hlpLanguage.getLangByID("HIST_ACT_DESC1_UPD");
            //}
            //public static string getHistTypeDesc1ActDel()
            //{
            //    return hlpXML.hlpLanguage.getLangByID("HIST_ACT_DESC1_DEL");
            //}

        }
        public class StatusInfo
        {
            //Status Data
            public static string getDTA_STS_NEW()
            {
                return "NEW";
            }
            public static string getDTA_STS_UPD()
            {
                return "UPD";
            }
            public static string getDTA_STS_DEL()
            {
                return "DEL";
            }

            //Permanent - Status Bussines process (Kepegawaian)
            public static string getBP_STS_EMP_FIX()
            {
                return "EMPFIX";
            }
            //Contract - Status Bussines process (Kepegawaian)
            public static string getBP_STS_EMP_CON()
            {
                return "EMPCON";
            }
            //Probation - Status Bussines process (Kepegawaian)
            public static string getBP_STS_EMP_PRO()
            {
                return "EMPPRO";
            }
            //Freelance - Status Bussines process (Kepegawaian)
            public static string getBP_STS_EMP_FRL()
            {
                return "EMPFRL";
            }
        }
        public class TagInfo
        {
            public static string getTagVldtnTag1() { return "::::TAG1::::"; }
            public static string getTagVldtnTag2() { return "::::TAG2::::"; }
            public static string getTagVldtnTag3() { return "::::TAG3::::"; }
            public static string getTagVldtnTag4() { return "::::TAG4::::"; }
            public static string getTagVldtnTag5() { return "::::TAG5::::"; }
        }
        public class AppModuleInfo
        {
            //Section Module ID
            public static string setMdleDefault() { return "CCS"; } //modif this line for Module ID
            //End Section Module ID
        }
        public class LovBizActEmpInfo
        {
            public static string getEmpNew() { return "LOV_HRS_EMP_BIZACT_NEW"; }
            public static string getEmpPromotion() { return "LOV_HRS_EMP_BIZACT_PROMOTION"; }
            public static string getEmpDemotion() { return "LOV_HRS_EMP_BIZACT_DEMOTION"; }
            public static string getEmpQuit() { return "LOV_HRS_EMP_BIZACT_QUIT"; }
            public static string getEmpRevisionUser() { return "LOV_HRS_EMP_BIZACT_REV_USR"; }
            public static string getEmpRevisionAdmin() { return "LOV_HRS_EMP_BIZACT_REV_ADM"; }
        }
        public class LovExistStsEmpInfo
        {
            public static string getEmpActiveFlag() { return "LOV_HRS_EMP_EXISTS_ACTIVE"; }
            public static string getEmpLeaveFlag() { return "LOV_HRS_EMP_EXISTS_LEAVE"; }
            public static string getEmpQuitFlag() { return "LOV_HRS_EMP_EXISTS_QUIT"; }
        }
        public class LovEmpStsInfo
        {
            public static string getEmpProb() { return "LOV_HRS_EMPSTS_PROB"; }
            public static string getEmpCont() { return "LOV_HRS_EMPSTS_CONT"; }
            public static string getEmpPrmt() { return "LOV_HRS_EMPSTS_PRMT"; }
            public static string getEmpEndProb() { return "LOV_HRS_EMPSTS_ENDPROB"; }
            public static string getEmpEndCont() { return "LOV_HRS_EMPSTS_ENDCONT"; }
            public static string getEmpPension() { return "LOV_HRS_EMPSTS_PENSION"; }
            public static string getEmpFired() { return "LOV_HRS_EMPSTS_FIRED"; }
            public static string getEmpResign() { return "LOV_HRS_EMPSTS_RESIGN"; }
        }
        public class SEARCH_METHOD
        {
            public static string getSM_RUID() { return "RUID"; } //End function getSM_RUID
            public static string getSM_MAIN_RUID() { return "MAIN_RUID"; } //End function getSM_MAIN_RUID
            public static string getSM_ID() { return "ID"; } //End function getSM_ID
            public static string getSM_DISPKEY() { return "DISP_KEY"; } //End function getSM_DISPKEY
            public static string getSM_DEPT() { return "DEPT"; } //End function getSM_DEPT
            public static string getSM_RESRUID() { return "RES_RUID"; } //End function getSM_RESRUID
            public static string getSM_RESNM() { return "RES_NM"; } //End function getSM_RESNM
        } //End public class SEARCH_METHOD
        public class DATA_MODEL_TYPE
        {
            public static string getSTRDataModelARR() { return "ARR"; } //End function getDataModelARR
            public static string getSTRDataModelTBL() { return "TBL"; } //End function getDataModelTBL
            public static string getSTRDataModelDTS() { return "DTS"; } //End function getDataModelDTS
            public static string getSTRDataModelLST() { return "LST"; } //End function getDataModelDTS

            public static int getNUMDataModelARR() { return 1; } //End function getDataModelARR
            public static int getNUMDataModelTBL() { return 2; } //End function getDataModelTBL
            public static int getNUMDataModelDTS() { return 3; } //End function getDataModelDTS
            public static int getNUMDataModelLST() { return 4; } //End function getDataModelDTS
        }
        #endregion

        #region 02 - Class Web
        public class ClientSystemInfo
        {

            #region 01 - Get Area

            public static string getClientIPAddress()
            {
                string vReturn = "";
                HttpContext voContext = HttpContext.Current;
                string vsHTTP_X_FORWARDED_FOR = voContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                string vsREMOTE_ADDR = voContext.Request.ServerVariables["REMOTE_ADDR"];

                if (!string.IsNullOrEmpty(vsHTTP_X_FORWARDED_FOR))
                    vReturn = vsHTTP_X_FORWARDED_FOR;
                else
                    vReturn = vsREMOTE_ADDR;

                return vReturn;
            }
            public static string getClientComputerName()
            {
                string vReturn = "";

                //HttpContext voContext = HttpContext.Current;

                //string vsHTTP_X_FORWARDED_FOR = voContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                //string vsREMOTE_ADDR = voContext.Request.ServerVariables["REMOTE_ADDR"];

                //if (!string.IsNullOrEmpty(vsHTTP_X_FORWARDED_FOR))
                //    vReturn = System.Net.Dns.GetHostByAddress(vsHTTP_X_FORWARDED_FOR).HostName;
                //else
                //    vReturn = System.Net.Dns.GetHostByAddress(vsREMOTE_ADDR).HostName;

                return vReturn.ToUpper();
            }
            public static string getLoggedInUserID()
            {
                string vReturn = HttpContext.Current.Session["AppUsrID"].ToString();
                return vReturn;
            }
            public static string getAppProgID()
            {
                string vReturn = HttpContext.Current.Session["AppProgID"].ToString();
                return vReturn;
            }
            public static DateTime getAppDateTime()
            {
                DateTime vReturn = DateTime.Now;
                return vReturn;
            }

            #endregion

            #region 02 - Set Area

            public static void setLoggedInUserID(string psUserID)
            {
                HttpContext.Current.Session["AppUsrID"] = psUserID;
                HttpContext.Current.Session["AppIsLoggedIn"] = FlagInfo.getFlagValid();
            }
            public static void setAppProgID(string psProgID)
            {
                HttpContext.Current.Session["AppProgID"] = psProgID;
            }

            #endregion

        }
        public class AppUploadInfo
        {

            //Root
            public static string getPathPhoto()
            {
                string vReturn = "";
                //System.Web.UI.Page voPage = HttpContext.Current.Handler as System.Web.UI.Page;
                //vReturn = voPage.ResolveUrl("~/App_DataUpload/Photo/");
                vReturn = "~/App_DataUpload/Photo/";
                return vReturn;
            }
            public static string getDefaultPhoto()
            {
                string vReturn = "";
                //System.Web.UI.Page voPage = HttpContext.Current.Handler as System.Web.UI.Page;
                //vReturn = voPage.ResolveUrl("~/App_DataUpload/Photo/PhotoNA.jpg");
                vReturn = "~/App_DataUpload/Photo/PhotoNA.jpg";
                return vReturn;
            }
            public static string getPhoto(string psRUID)
            {
                string vsErrMsg = "";
                string vReturn = "";
                string vsFileName = "";
                string vsRUIDFileName = "";
                string vsDefFileName = "";

                try
                {
                    //Check if RUID is empty then get default image
                    if (psRUID != "")
                        vsFileName = psRUID + ".jpg";
                    else
                        vsFileName = "EmpPhotoNA.jpg";

                    vsRUIDFileName = "~/App_DataUpload/Photo/" + vsFileName;
                    vsDefFileName = "~/App_DataUpload/Photo/EmpPhotoNA.jpg";

                    //System.Web.UI.Page voPage = HttpContext.Current.Handler as System.Web.UI.Page;
                    //vsRUIDFileName = VirtualPathUtility.ToAbsolute("~/App_DataUpload/Photo/" + vsFileName);
                    //vsDefFileName = VirtualPathUtility.ToAbsolute("~/App_DataUpload/Photo/EmpPhotoNA.jpg");
                    //vsRUIDFileName = voPage.ResolveUrl("~/App_DataUpload/APP_HR/EmpPhoto/" + vsFileName);
                    //vsDefFileName = voPage.ResolveUrl("~/App_DataUpload/APP_HR/EmpPhoto/EmpPhotoNA.jpg");

                    //Check if image file exist

                    if (File.Exists(HttpContext.Current.Server.MapPath(vsRUIDFileName)))
                        vReturn = vsRUIDFileName;
                    else
                        vReturn = vsDefFileName;
                }
                catch (System.Exception e) { vsErrMsg = e.Message; }
                finally { }



                return vReturn;
            }

            //HR
            public static string getPathEmpPhotoHR()
            {
                string vReturn = "";
                //System.Web.UI.Page voPage = HttpContext.Current.Handler as System.Web.UI.Page;
                //vReturn = voPage.ResolveUrl("~/App_DataUpload/APP_HR/EmpPhoto/");
                vReturn = "~/App_DataUpload/APP_HR/EmpPhoto/";
                return vReturn;
            }
            public static string getDefaultEmpPhotoHR()
            {
                string vReturn = "";
                //System.Web.UI.Page voPage = HttpContext.Current.Handler as System.Web.UI.Page;
                //vReturn = voPage.ResolveUrl("~/App_DataUpload/DATA_HR/EmpPhoto/EmpPhotoNA.jpg");
                vReturn = "~/App_DataUpload/DATA_HR/EmpPhoto/EmpPhotoNA.jpg";
                return vReturn;
            }
            public static string getEmpPhotoHR(string psRUID)
            {
                string vsErrMsg = "";
                string vReturn = "";
                string vsFileName = "";
                string vsRUIDFileName = "";
                string vsDefFileName = "";

                try
                {
                    //Check if RUID is empty then get default image
                    if (psRUID != "")
                        vsFileName = psRUID + ".jpg";
                    else
                        vsFileName = "EmpPhotoNA.jpg";

                    vsRUIDFileName = "~/App_DataUpload/APP_HR/EmpPhoto/" + vsFileName;
                    vsDefFileName = "~/App_DataUpload/APP_HR/EmpPhoto/EmpPhotoNA.jpg";

                    //System.Web.UI.Page voPage = HttpContext.Current.Handler as System.Web.UI.Page;
                    //vsRUIDFileName = VirtualPathUtility.ToAbsolute("~/App_DataUpload/APP_HR/EmpPhoto/" + vsFileName);
                    //vsDefFileName = VirtualPathUtility.ToAbsolute("~/App_DataUpload/APP_HR/EmpPhoto/EmpPhotoNA.jpg");
                    //vsRUIDFileName = voPage.ResolveUrl("~/App_DataUpload/APP_HR/EmpPhoto/" + vsFileName);
                    //vsDefFileName = voPage.ResolveUrl("~/App_DataUpload/APP_HR/EmpPhoto/EmpPhotoNA.jpg");

                    //Check if image file exist

                    if (File.Exists(HttpContext.Current.Server.MapPath(vsRUIDFileName)))
                        vReturn = vsRUIDFileName;
                    else
                        vReturn = vsDefFileName;
                }
                catch (System.Exception e) { vsErrMsg = e.Message; }
                finally { }



                return vReturn;
            }

            //ASM
            public static string getDefaultEmpPhotoASM()
            {
                string vReturn = "";
                //System.Web.UI.Page voPage = HttpContext.Current.Handler as System.Web.UI.Page;
                //vReturn = voPage.ResolveUrl("~/App_DataUpload/APP_ASM/EmpPhoto/EmpPhotoNA.jpg");
                vReturn = "~/App_DataUpload/APP_ASM/EmpPhoto/EmpPhotoNA.jpg";
                return vReturn;
            }
        }
        #endregion

        #region 03 Class LKP Default Value
        public class LKPDefaultValue
        {
            #region 01 - Get Area
            public static string getLocalCountryID() { return "ID"; }
            public static string getLocalCountryNm() { return "Indonesia"; }
            #endregion
        }
        #endregion

        #region 04 Class Pagination
        public class Pagination
        {
            public static Boolean isMOD(int pnTROW, int pnRPP)
            {
                Boolean vReturn = false;
                int vnMOD = pnTROW % pnRPP;
                if (vnMOD > 0)
                    vReturn = true;
                return vReturn;
            } //End function isMOD
            public static int getPCOUNT(int pnTROW, int pnRPP)
            {
                int vReturn = 0;
                string vsErrMsg = "";
                int vnMOD = 0;
                int vnTROW = 0;
                int vnPCOUNT = 0;

                try
                {
                    if (pnTROW < pnRPP)
                    {
                        vnPCOUNT = 1;
                    }
                    else
                    {
                        vnMOD = pnTROW % pnRPP;
                        vnTROW = pnTROW - vnMOD;
                        vnPCOUNT = vnTROW / pnRPP;
                        if (vnMOD > 0)
                            vnPCOUNT = vnPCOUNT + 1;
                    } //End if
                } //End try
                catch (System.Exception e) { vsErrMsg = e.Message; } //End catch
                finally { } //End Catch

                vReturn = vnPCOUNT;
                return vReturn;
            } //End function getPCOUNT
            public static int getRSTART(int pnTROW, int pnRPP, int pnPCURR)
            {
                int vReturn = 0;
                string vsErrMsg = "";
                int vnMOD = 0;
                int vnTROW = 0;
                int vnPCOUNT = 0;
                int vnRSTART = 0;
                int vnREND = 0;
                try
                {
                    vnMOD = pnTROW % pnRPP;
                    vnTROW = pnTROW - vnMOD;

                    if (pnRPP > 0)
                    {
                        vnPCOUNT = getPCOUNT(pnTROW, pnRPP);

                        if (pnPCURR < vnPCOUNT)
                        {
                            vnREND = pnRPP * pnPCURR;
                            vnRSTART = (vnREND - pnRPP) + 1;
                        }
                        else
                        {
                            if (vnMOD > 0)
                            {
                                vnRSTART = vnTROW + 1;
                                vnREND = pnTROW;
                            } //End if
                        } //End if
                    } //End if

                } //End try
                catch (System.Exception e) { vsErrMsg = e.Message; } //End catch
                finally { } //End finally
                vReturn = vnRSTART;
                return vReturn;
            } //End function getREND
            public static int getREND(int pnTROW, int pnRPP, int PCURR)
            {
                int vReturn = 0;
                string vsErrMsg = "";
                try { } //End try
                catch (System.Exception e) { vsErrMsg = e.Message; } //End catch
                finally { } //End finally
                return vReturn;
            } //End function getREND
        } //End class Pagination
        #endregion

        #region 05 Class LOV
        public class LOV_ATTRIBUTE
        {
            public static string DESCTYPE_NM = "NM";
            public static string DESCTYPE_SYM = "SYM";
            public static string DESCTYPE_VALNUM = "VALNUM";
            public static string DESCTYPE_VALSTR = "VALSTR";
        } //End class LOV_ATTRIBUTE
        #endregion
    } //End public class hlpGeneral
} //End namespace APPBASE.Helper
