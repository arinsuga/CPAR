using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APPBASE.Models;

namespace APPBASE.Helpers
{
    public class hlpMenuDropDown
    {
        #region 01 - Initialize Area
            //Constanta Menu Data
            public const string MENU_MAIN_CLASS = "[[::MENU_MAIN_CLASS::]]";
            public const string MENU_CONTENT = "[[::MENU_CONTENT::]]";
            public const string MENU_ID = "[[::MENU_ID::]]";
            public const string MENU_LINK = "[[::MENU_LINK::]]";
            public const string MENU_CAPTION = "[[::MENU_CAPTION::]]";
            public const string MENU_GROUP_ITEMS = "[[::MENU_GROUP_ITEMS::]]";
            //Constanta Menu Class
            public const string MENU_UL_GRP_CLASS = "[[::MENU_UL_GRP_CLASS::]]";
            public const string MENU_LI_GRP_CLASS = "[[::MENU_LI_GRP_CLASS::]]";
            public const string MENU_LI_ITM_CLASS = "[[::MENU_LI_ITM_CLASS::]]";
            public const string MENU_HREF_GRP_CLASS = "[[::MENU_HREF_GRP_CLASS::]]";
            public const string MENU_HREF_ITM_CLASS = "[[::MENU_HREF_ITM_CLASS::]]";
            //Constanta Menu Prepend & Append
            public const string MENU_HREF_GRP_PREPEND = "[[::MENU_HREF_GRP_PREPEND::]]";
            public const string MENU_HREF_GRP_APPEND = "[[::MENU_HREF_GRP_APPEND::]]";
        #endregion
        #region 02 - Public Area
        //Overload 1
        public static string DisplayMenu(string psUlGROUPClass, string psLiGROUPClass, string psLiITEMClass,
                                            string psHrefGROUPClass, string psHrefITEMClass, string psMenuGroupRUID)
        {
            string vReturn = "";
            string vsErrMsg = "";

            string vsUsrRUID = hlpConfig.SessionInfo.getAppUsrRUID(); // HttpContext.Current.Session["AppUsrRUID"].ToString(); //"RUID00105"
            string vsAppMdleRUID = hlpConfig.SessionInfo.getAppMdleRUID(); // HttpContext.Current.Session["AppMdleRUID"].ToString(); //"HRIS"
            //string vsUsrRUID = "RUID90000"; // HttpContext.Current.Session["AppUsrRUID"].ToString(); //"RUID00105"
            //string vsAppMdleRUID = "CCS"; // HttpContext.Current.Session["AppMdleRUID"].ToString(); //"HRIS"

            //Variable render menu
            string vsMenu = "";
            //vsMenu = "<ul>" + MENU_CONTENT + "</ul>";
            vsMenu = MENU_CONTENT;
            string vsMenuContent = "";
            string vsMNU_ISVISIBLE = "";

            //Variable render menu group
            string vsMenuGroup = "";
            string vsMenuGroupID = "";
            string vsMenuGroupRUID = "";
            string vsMenuGroupLink = "";
            string vsMenuGroupCaption = "";
            string vsMenuGroupItems = "";
            string vsMenuGroupULClass = psUlGROUPClass;
            string vsMenuGroupLIClass = psLiGROUPClass;
            string vsMenuGroupHREFClass = psHrefGROUPClass;

            //Variable render menu item
            string vsMenuItem = "";
            string vsMenuItemParentRUID = "";
            string vsMenuItemID = "";
            string vsMenuItemLink = "";
            string vsMenuItemCaption = "";
            string vsMenuItemLIClass = psLiITEMClass;
            string vsMenuItemHREFClass = psHrefITEMClass;

            try
            {
                using (var db = new DBMAINContext()) {
                    //var qryGRP = from tb in db.Usermenu_infos select tb;
                    var qryGRP = from tb in db.Usermenu_infos select tb;
                    var qryITM = from tb in db.Usermenu_infos select tb;

                    qryGRP = qryGRP.Where(fld => fld.MNU_TYPE == "GRP" && fld.USR_RUID == vsUsrRUID && fld.MDLE_RUID == vsAppMdleRUID);
                    qryITM = qryITM.Where(fld => fld.MNU_TYPE == "ITM" && fld.USR_RUID == vsUsrRUID && fld.MDLE_RUID == vsAppMdleRUID);
                    if ((psMenuGroupRUID != "") && (psMenuGroupRUID != null))
                    {
                        qryGRP = qryGRP.Where(fld => fld.MNU_RUID == psMenuGroupRUID);
                        qryITM = qryITM.Where(fld => fld.MNU_PARENT_RUID == psMenuGroupRUID);
                    } //End if ((psMenuGroupRUID != "") && (psMenuGroupRUID != null))

                    
                    var TBLDataGRP = qryGRP.OrderBy(fld => fld.RSEQNO).ToList();
                    var TBLDataITM = qryITM.OrderBy(fld => fld.RSEQNO).ToList();

                    foreach (var itemGRP in TBLDataGRP)
                    {
                        vsMenuGroup = "";
                        vsMenuGroupID = itemGRP.MNU_ID;
                        vsMenuGroupRUID = itemGRP.MNU_RUID;
                        vsMenuGroupLink = itemGRP.MNU_LINK_ID;
                        vsMenuGroupCaption = itemGRP.MNU_CAPTION;
                        vsMenuGroupItems = "";
                        vsMNU_ISVISIBLE = itemGRP.MNU_ISVISIBLE;

                        vsMenuItem = "";
                        foreach (var itemITM in TBLDataITM)
                        {
                            vsMNU_ISVISIBLE = itemITM.MNU_ISVISIBLE;
                            if (vsMNU_ISVISIBLE == hlpGeneral.FlagInfo.getFlagValid())
                            {
                                vsMenuItemParentRUID = itemITM.MNU_PARENT_RUID;
                                if (vsMenuGroupRUID == vsMenuItemParentRUID)
                                {
                                    vsMenuItemID = itemITM.MNU_ID;
                                    vsMenuItemLink = itemITM.MNU_LINK_ID;
                                    vsMenuItemCaption = itemITM.MNU_CAPTION;

                                    vsMenuItem = vsMenuItem + setMenuItem(vsMenuItemID, vsMenuItemLink,
                                                                            vsMenuItemCaption, vsMenuItemLIClass,
                                                                            vsMenuItemHREFClass);
                                } //End if (vsMenuGroupRUID == vsMenuItemParentRUID)
                            } //End if (vsMNU_ISVISIBLE = hlpGeneral.FlagInfo.getFlagValid())
                        } //End foreach (var item in TBLDataITM)
                        vsMenuGroupItems = vsMenuItem;
                        if ((vsMenuGroupItems == "") || (vsMenuGroupItems == null))
                        {
                            vsMenuGroup = setMenuItem(vsMenuGroupID, vsMenuGroupLink,
                                                        vsMenuGroupCaption, vsMenuGroupLIClass,
                                                        vsMenuGroupHREFClass);
                        }
                        else
                        {
                            vsMenuGroup = setMenuGroup(vsMenuGroupID, vsMenuGroupLink,
                                                        vsMenuGroupCaption, vsMenuGroupItems,
                                                        vsMenuGroupULClass, vsMenuGroupLIClass, vsMenuGroupHREFClass);
                        } //End if
                        vsMenuContent = vsMenuContent + vsMenuGroup;
                    } //End foreach (var item in TBLDataGRP)
                    vsMenu = vsMenu.Replace(MENU_CONTENT, vsMenuContent);
                } //End using (var db = new DBMAINContext())
            } //End try
            catch (System.Exception e) { vsErrMsg = e.Message; } //End catch
            finally { } //End finally

            vReturn = vsMenu;
            return vReturn;
        } //End function DisplayMenuByUserID

        //Overload 2
        public static string DisplayMenu(string psUlGROUPClass, string psLiGROUPClass, string psLiITEMClass,
                                         string psHrefGROUPClass, string psHrefITEMClass, string psMenuGroupRUID,
                                         string psHrefGROUPPrepend, string psHrefGROUPAppend)
        {
            string vReturn = "";
            string vsErrMsg = "";

            string vsUsrRUID = hlpConfig.SessionInfo.getAppUsrRUID(); // HttpContext.Current.Session["AppUsrRUID"].ToString(); //"RUID00105"
            string vsAppMdleRUID = hlpConfig.SessionInfo.getAppMdleRUID(); // HttpContext.Current.Session["AppMdleRUID"].ToString(); //"HRIS"
            //string vsUsrRUID = "RUID90000"; // HttpContext.Current.Session["AppUsrRUID"].ToString(); //"RUID00105"
            //string vsAppMdleRUID = "CCS"; // HttpContext.Current.Session["AppMdleRUID"].ToString(); //"HRIS"

            //Variable render menu
            string vsMenu = "";
            //vsMenu = "<ul>" + MENU_CONTENT + "</ul>";
            vsMenu = MENU_CONTENT;
            string vsMenuContent = "";
            string vsMNU_ISVISIBLE = "";

            //Variable render menu group
            string vsMenuGroup = "";
            string vsMenuGroupID = "";
            string vsMenuGroupRUID = "";
            string vsMenuGroupLink = "";
            string vsMenuGroupCaption = "";
            string vsMenuGroupItems = "";
            string vsMenuGroupULClass = psUlGROUPClass;
            string vsMenuGroupLIClass = psLiGROUPClass;
            string vsMenuGroupHREFClass = psHrefGROUPClass;
            string vsHrefGROUPPrepend = psHrefGROUPPrepend;
            string vsHrefGROUPAppend = psHrefGROUPAppend;


            //Variable render menu item
            string vsMenuItem = "";
            string vsMenuItemParentRUID = "";
            string vsMenuItemID = "";
            string vsMenuItemLink = "";
            string vsMenuItemCaption = "";
            string vsMenuItemLIClass = psLiITEMClass;
            string vsMenuItemHREFClass = psHrefITEMClass;

            try
            {
                using (var db = new DBMAINContext())
                {
                    //var qryGRP = from tb in db.Usermenu_infos select tb;
                    var qryGRP = from tb in db.Usermenu_infos select tb;
                    var qryITM = from tb in db.Usermenu_infos select tb;

                    qryGRP = qryGRP.Where(fld => fld.MNU_TYPE == "GRP" && fld.USR_RUID == vsUsrRUID && fld.MDLE_RUID == vsAppMdleRUID);
                    qryITM = qryITM.Where(fld => fld.MNU_TYPE == "ITM" && fld.USR_RUID == vsUsrRUID && fld.MDLE_RUID == vsAppMdleRUID);
                    if ((psMenuGroupRUID != "") && (psMenuGroupRUID != null))
                    {
                        qryGRP = qryGRP.Where(fld => fld.MNU_RUID == psMenuGroupRUID);
                        qryITM = qryITM.Where(fld => fld.MNU_PARENT_RUID == psMenuGroupRUID);
                    } //End if ((psMenuGroupRUID != "") && (psMenuGroupRUID != null))


                    var TBLDataGRP = qryGRP.OrderBy(fld => fld.RSEQNO).ToList();
                    var TBLDataITM = qryITM.OrderBy(fld => fld.MNU_RSEQNO).ToList();

                    foreach (var itemGRP in TBLDataGRP)
                    {
                        vsMenuGroup = "";
                        vsMenuGroupID = itemGRP.MNU_ID;
                        vsMenuGroupRUID = itemGRP.MNU_RUID;
                        vsMenuGroupLink = itemGRP.MNU_LINK_ID;
                        vsMenuGroupCaption = itemGRP.MNU_CAPTION;
                        vsMenuGroupItems = "";
                        vsMNU_ISVISIBLE = itemGRP.MNU_ISVISIBLE;

                        vsMenuItem = "";
                        foreach (var itemITM in TBLDataITM)
                        {
                            vsMNU_ISVISIBLE = itemITM.MNU_ISVISIBLE;
                            if (vsMNU_ISVISIBLE == hlpGeneral.FlagInfo.getFlagValid())
                            {
                                vsMenuItemParentRUID = itemITM.MNU_PARENT_RUID;
                                if (vsMenuGroupRUID == vsMenuItemParentRUID)
                                {
                                    vsMenuItemID = itemITM.MNU_ID;
                                    vsMenuItemLink = itemITM.MNU_LINK_ID;
                                    vsMenuItemCaption = itemITM.MNU_CAPTION;

                                    vsMenuItem = vsMenuItem + setMenuItem(vsMenuItemID, vsMenuItemLink,
                                                                            vsMenuItemCaption, vsMenuItemLIClass,
                                                                            vsMenuItemHREFClass);
                                } //End if (vsMenuGroupRUID == vsMenuItemParentRUID)
                            } //End if (vsMNU_ISVISIBLE = hlpGeneral.FlagInfo.getFlagValid())
                        } //End foreach (var item in TBLDataITM)
                        vsMenuGroupItems = vsMenuItem;
                        if ((vsMenuGroupItems == "") || (vsMenuGroupItems == null))
                        {
                            vsMenuGroup = setMenuItem(vsMenuGroupID, vsMenuGroupLink,
                                                        vsMenuGroupCaption, vsMenuGroupLIClass,
                                                        vsMenuGroupHREFClass);
                        }
                        else
                        {
                            vsMenuGroup = setMenuGroup(vsMenuGroupID, vsMenuGroupLink,
                                                        vsMenuGroupCaption, vsMenuGroupItems,
                                                        vsMenuGroupULClass, vsMenuGroupLIClass, vsMenuGroupHREFClass,
                                                        vsHrefGROUPPrepend, vsHrefGROUPAppend);
                        } //End if
                        vsMenuContent = vsMenuContent + vsMenuGroup;
                    } //End foreach (var item in TBLDataGRP)
                    vsMenu = vsMenu.Replace(MENU_CONTENT, vsMenuContent);
                    vsMenu = vsMenu.Replace(MENU_HREF_GRP_PREPEND, vsHrefGROUPPrepend);
                    vsMenu = vsMenu.Replace(MENU_HREF_GRP_APPEND, vsHrefGROUPAppend);
                } //End using (var db = new DBMAINContext())
            } //End try
            catch (System.Exception e) { vsErrMsg = e.Message; } //End catch
            finally { } //End finally

            vReturn = vsMenu;
            return vReturn;
        } //End function DisplayMenuByUserID
        #endregion
        #region 03 - Private Area
        //1 - Menu Main Class
        private static string setMenuMainClass(string psUlMainClass)
        {
            string vReturn = "";

            if ((psUlMainClass != "") && (psUlMainClass != null))
            {
                vReturn = " class=\"" + psUlMainClass + "\" ";
            } //End if


            return vReturn;
        } //End function setMenuMainClass
        //2 - Menu Group - Overload 1
        private static string setMenuGroup(string psMenuID, string psMenuLink,
                                           string psMenuCaption, string psMenuGroupItems,
                                           string psULGroupClass, string psLIGroupClass, string psHREFGroupClass)
        {
            string vReturn = "";
            string vsErrMsg = "";
            string vsMenuGroupTemplate = getTemplateMenuGroup();
            string vsTemp = vsMenuGroupTemplate;
            string vsULGroupClass = " class = \"" + psULGroupClass + "\" ";
            string vsLIGroupClass = " class = \"" + psLIGroupClass + "\" ";
            string vsHREFGroupClass = " class = \"" + psHREFGroupClass + "\" ";

            string vsMenuLink = "";
            try
            {
                vsTemp = vsTemp.Replace(MENU_ID, psMenuID);
                if ((psMenuLink != "") && (psMenuLink != null))
                {

                    vsMenuLink = VirtualPathUtility.ToAbsolute("~/" + psMenuLink);
                    vsTemp = vsTemp.Replace(MENU_LINK, vsMenuLink);
                }
                else
                {
                    vsTemp = vsTemp.Replace(MENU_LINK, "#");
                } //End if
                vsTemp = vsTemp.Replace(MENU_CAPTION, psMenuCaption);
                vsTemp = vsTemp.Replace(MENU_GROUP_ITEMS, psMenuGroupItems);

                if ((psMenuGroupItems != "") && (psMenuGroupItems != null))
                {
                    if ((psULGroupClass != "") && (psULGroupClass != null))
                    {
                        vsTemp = vsTemp.Replace(MENU_UL_GRP_CLASS, vsULGroupClass);
                    }
                    else
                    {
                        vsTemp = vsTemp.Replace(MENU_UL_GRP_CLASS, "");
                    }//End if
                    if ((psLIGroupClass != "") && (psLIGroupClass != null))
                    {
                        vsTemp = vsTemp.Replace(MENU_LI_GRP_CLASS, vsLIGroupClass);
                    }
                    else
                    {
                        vsTemp = vsTemp.Replace(MENU_LI_GRP_CLASS, "");
                    }//End if
                    if ((psHREFGroupClass != "") && (psHREFGroupClass != null))
                    {
                        vsTemp = vsTemp.Replace(MENU_HREF_GRP_CLASS, vsHREFGroupClass);
                    }
                    else
                    {
                        vsTemp = vsTemp.Replace(MENU_HREF_GRP_CLASS, "");
                    }//End if
                }
                else
                {
                    vsTemp = vsTemp.Replace(MENU_UL_GRP_CLASS, "");
                    vsTemp = vsTemp.Replace(MENU_LI_GRP_CLASS, "");
                    vsTemp = vsTemp.Replace(MENU_HREF_GRP_CLASS, "");
                } //End if

            } //End try
            catch (System.Exception e) { vsErrMsg = e.Message; } //End catch
            finally { } //End finally
            vReturn = vsTemp;

            return vReturn;
        } //End function setMenuGroup
        //2 - Menu Group - Overload 2
        private static string setMenuGroup(string psMenuID, string psMenuLink,
                                           string psMenuCaption, string psMenuGroupItems,
                                           string psULGroupClass, string psLIGroupClass, string psHREFGroupClass,
                                           string psHrefGROUPPrepend, string psHrefGROUPAppend)
        {
            string vReturn = "";
            string vsErrMsg = "";
            string vsMenuGroupTemplate = getTemplateMenuGroup();
            string vsTemp = vsMenuGroupTemplate;
            string vsULGroupClass = " class = \"" + psULGroupClass + "\" ";
            string vsLIGroupClass = " class = \"" + psLIGroupClass + "\" ";
            string vsHREFGroupClass = " class = \"" + psHREFGroupClass + "\" ";
            string vsHrefGROUPPrepend = psHrefGROUPPrepend;
            string vsHrefGROUPAppend = psHrefGROUPAppend;

            string vsMenuLink = "";
            try
            {
                vsTemp = vsTemp.Replace(MENU_ID, psMenuID);
                if ((psMenuLink != "") && (psMenuLink != null))
                {

                    vsMenuLink = VirtualPathUtility.ToAbsolute("~/" + psMenuLink);
                    vsTemp = vsTemp.Replace(MENU_LINK, vsMenuLink);
                }
                else
                {
                    vsTemp = vsTemp.Replace(MENU_LINK, "#");
                } //End if
                vsTemp = vsTemp.Replace(MENU_CAPTION, psMenuCaption);
                vsTemp = vsTemp.Replace(MENU_GROUP_ITEMS, psMenuGroupItems);

                if ((psMenuGroupItems != "") && (psMenuGroupItems != null))
                {
                    if ((psULGroupClass != "") && (psULGroupClass != null))
                    {
                        vsTemp = vsTemp.Replace(MENU_UL_GRP_CLASS, vsULGroupClass);
                    }
                    else
                    {
                        vsTemp = vsTemp.Replace(MENU_UL_GRP_CLASS, "");
                    }//End if
                    if ((psLIGroupClass != "") && (psLIGroupClass != null))
                    {
                        vsTemp = vsTemp.Replace(MENU_LI_GRP_CLASS, vsLIGroupClass);
                    }
                    else
                    {
                        vsTemp = vsTemp.Replace(MENU_LI_GRP_CLASS, "");
                    }//End if
                    if ((psHREFGroupClass != "") && (psHREFGroupClass != null))
                    {
                        vsTemp = vsTemp.Replace(MENU_HREF_GRP_CLASS, vsHREFGroupClass);
                    }
                    else
                    {
                        vsTemp = vsTemp.Replace(MENU_HREF_GRP_CLASS, "");
                    }//End if
                }
                else
                {
                    vsTemp = vsTemp.Replace(MENU_UL_GRP_CLASS, "");
                    vsTemp = vsTemp.Replace(MENU_LI_GRP_CLASS, "");
                    vsTemp = vsTemp.Replace(MENU_HREF_GRP_CLASS, "");
                } //End if
            } //End try
            catch (System.Exception e) { vsErrMsg = e.Message; } //End catch
            finally { } //End finally
            vReturn = vsTemp;

            return vReturn;
        } //End function setMenuGroup
        private static string getTemplateMenuGroup()
        {
            string vReturn = "";
            string vsErrMsg = "";

            try
            {
                vReturn = vReturn + "<li " + MENU_LI_GRP_CLASS + " >" + "<a id=\"" + MENU_ID + "\" " + MENU_HREF_GRP_CLASS + " href=\"" + MENU_LINK + "\">";
                vReturn = vReturn + MENU_HREF_GRP_PREPEND + MENU_CAPTION + MENU_HREF_GRP_APPEND;
                vReturn = vReturn + "</a>";
                vReturn = vReturn + "<ul" + MENU_UL_GRP_CLASS + ">";
                vReturn = vReturn + MENU_GROUP_ITEMS;
                vReturn = vReturn + "</ul>";
                vReturn = vReturn + "</li>";
            } //End try
            catch (System.Exception e) { vsErrMsg = e.Message; } //End catch
            finally { } //End finally

            return vReturn;
        } //End function getTemplateMenuGroup
        //3 - Menu Item
        private static string setMenuItem(string psMenuID, string psMenuLink,
                                          string psMenuCaption, string psLIItemClass,
                                                                                                                                                                                                                            string psHREFItemClass)
        {
            string vReturn = "";
            string vsErrMsg = "";
            string vsMenuItemTemplate = getTemplateMenuItem();
            string vsTemp = vsMenuItemTemplate;
            string vsLIItemClass = " class = \"" + psLIItemClass + "\" ";
            string vsHREFItemClass = " class = \"" + psHREFItemClass + "\" ";
            string vsMenuLink = "";

            try
            {
                vsTemp = vsTemp.Replace(MENU_ID, psMenuID);

                if ((psMenuLink != "") && (psMenuLink != null))
                {

                    vsMenuLink = VirtualPathUtility.ToAbsolute("~/" + psMenuLink);
                    vsTemp = vsTemp.Replace(MENU_LINK, vsMenuLink);
                }
                else
                {
                    vsTemp = vsTemp.Replace(MENU_LINK, "#");
                } //End if

                vsTemp = vsTemp.Replace(MENU_CAPTION, psMenuCaption);

                if ((psLIItemClass != "") && (psLIItemClass != null))
                {
                    vsTemp = vsTemp.Replace(MENU_LI_ITM_CLASS, vsLIItemClass);
                }
                else
                {
                    vsTemp = vsTemp.Replace(MENU_LI_ITM_CLASS, "");
                } //End if

                if ((psHREFItemClass != "") && (psHREFItemClass != null))
                {
                    vsTemp = vsTemp.Replace(MENU_HREF_ITM_CLASS, vsHREFItemClass);
                }
                else
                {
                    vsTemp = vsTemp.Replace(MENU_HREF_ITM_CLASS, "");
                }//End if


            } //End try
            catch (System.Exception e) { vsErrMsg = e.Message; } //End catch
            finally { } //End finally

            vReturn = vsTemp;
            return vReturn;
        } //End function setMenuGroup
        private static string getTemplateMenuItem()
        {
            string vReturn = "";
            string vsErrMsg = "";

            try
            {
                vReturn = vReturn + "<li" + MENU_LI_ITM_CLASS + ">";
                vReturn = vReturn + "<a id=\"" + MENU_ID + "\"" + MENU_HREF_ITM_CLASS + " href=\"" + MENU_LINK + "\" >";
                vReturn = vReturn + MENU_CAPTION;
                vReturn = vReturn + "</a>";
                vReturn = vReturn + "</li>";
            } //End try
            catch (System.Exception e) { vsErrMsg = e.Message; } //End catch
            finally { } //End finally

            return vReturn;
        } //End function getTemplateMenuItem
        #endregion
    } //End public class hlpMenuDropDown
} //End namespace APPBASE.Helpers