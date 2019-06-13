using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace APPBASE.Svcapp
{
    public class Utility_FileUploadDownload
    {
        private const string PATH_PHOTOEMP = "~/App_DataUpload/EmpPhoto/";

        public static string setImage(string psFilename) { return psFilename + ".jpg"; } //End public static string setImageName(string psFilename)

        public static string getImage_User(string psFilename = null)
        {
            string sFilepath = "";
            string sFilename = "";
            string sEmpPhotoNA = "EmpPhotoNA.jpg";

            if ((psFilename == null) || (psFilename == ""))
            {

                sFilename = Helpers.hlpConfig.SessionInfo.getAppUsrIMG_SRC();
                if ((sFilename == null) || (sFilename == "")) { sFilename = sEmpPhotoNA; }
            }
            else
            {
                sFilename = psFilename;
            } //End if ((psFilename == null) || (psFilename == ""))

            sFilepath = HttpContext.Current.Request.MapPath("~/App_DataUpload/EmpPhoto/" + sFilename);
            if (!System.IO.File.Exists(sFilepath))
            {
                sFilename = sEmpPhotoNA;
            } //End if (!System.IO.File.Exists(sFilepath))

            return sFilename;
        } //End public static string getEmpPhoto(string psFilename)
        public static string getImage_Employee(string psFilename = null)
        {
            string sFilepath = "";
            string sFilename = "";
            string sEmpPhotoNA = "EmpPhotoNA.jpg";

            if ((psFilename == null) || (psFilename == "")) {

                //sFilename = Helpers.hlpConfig.SessionInfo.getAppUsrIMG_SRC();
                if ((sFilename == null) || (sFilename == "")) { sFilename = sEmpPhotoNA; }
            }
            else {
                sFilename = psFilename;
            } //End if ((psFilename == null) || (psFilename == ""))

            sFilepath = HttpContext.Current.Request.MapPath("~/App_DataUpload/EmpPhoto/" + sFilename);
            if (!System.IO.File.Exists(sFilepath))
            {
                sFilename = sEmpPhotoNA;
            } //End if (!System.IO.File.Exists(sFilepath))

            return sFilename;
        } //End public static string getEmpPhoto(string psFilename)
        public static string getImage_Employeechat(string psFilename = null)
        {
            string sFilename = "";
            if ((psFilename == null) || (psFilename == "")) { sFilename = "EmpPhotoNA.jpg"; }
            else { sFilename = psFilename; }
            return sFilename;
        } //End public static string getEmpPhoto(string psFilename)
        public static void saveImage_Employee(HttpPostedFileBase poFileimage, string psFilename)
        {
            string vsMsgErr = "";
            try {
                if (poFileimage != null)
                {
                    int nSize = poFileimage.ContentLength;
                    string sFiletype = poFileimage.ContentType;
                    var oFile = HttpContext.Current.Server.MapPath(PATH_PHOTOEMP + psFilename);
                    poFileimage.SaveAs(oFile);
                } //End if (poFileimage != null)
            }
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void EmployeePhoto()
        public static void deleteImage_Employee(string psFilename)
        {
            string vsMsgErr = "";
            try
            {
                string sFilename = HttpContext.Current.Server.MapPath(PATH_PHOTOEMP);
                FileInfo oFile1 = new FileInfo(sFilename + psFilename + ".jpg");
                FileInfo oFile2 = new FileInfo(sFilename + psFilename + ".bmp");
                FileInfo oFile3 = new FileInfo(sFilename + psFilename + ".gif");
                if (oFile1.Exists) { oFile1.Delete(); }
                if (oFile2.Exists) { oFile2.Delete(); }
                if (oFile3.Exists) { oFile3.Delete(); }
            }
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void EmployeePhoto()
    } //End public class Utility_FileUploadDownload
} //End namespace APPBASE.Services