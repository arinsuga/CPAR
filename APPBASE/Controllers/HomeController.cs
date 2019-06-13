using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Filters;
using APPBASE.Svcbiz;

namespace APPBASE.Controllers
{
    [MyActionFilterAttribute]
    public class HomeController : Controller
    {
        //Dataset services
        private CPARDS oDS_cpar = new CPARDS();
        private CPARChatnotifyDS oDS_cparchatnotif = new CPARChatnotifyDS();
        //Access Controll
        private string sUSR_RUID = "";
        private string sROLE_RUID = "";
        private string sUSRRES_RUID = "";
        //CPAR_YEAR
        private int? nCPAR_MAXYEAR = null;

        //Prepare Process
        private void prepareProcess() {
            sUSR_RUID = hlpConfig.SessionInfo.getAppUsrRUID();
            sROLE_RUID = hlpConfig.SessionInfo.getAppRoleRUID();
            sUSRRES_RUID = hlpConfig.SessionInfo.getAppUsrRES_RUID();
            if (nCPAR_MAXYEAR == null) { nCPAR_MAXYEAR = oDS_cpar.getMax_CPARYEAR(); }
            ViewBag.YEARLIST = oDS_cpar.getDatalist_YEARLIST();
            ViewBag.CPAR_MAXYEAR = nCPAR_MAXYEAR;

            if (sROLE_RUID == "") {
                oQRY = oDS_cpar.getDatalist_notif();
                oQRY_cpartype = oDS_cpar.getDatalist_YEARALL(nCPAR_MAXYEAR);
            } //End if (sROLE_RUID == "")
            
            if (sROLE_RUID == valFLAG.FLAG_ROLE_SYSADMIN) {
                oQRY = oDS_cpar.getDatalist_notif();
                oQRY_cpartype = oDS_cpar.getDatalist_YEARALL(nCPAR_MAXYEAR);
            } //End if (sROLE_RUID == valFLAG.FLAG_ROLE_SYSADMIN)
            
            if (sROLE_RUID == valFLAG.FLAG_ROLE_CPAR_ADMIN) {
                oQRY = oDS_cpar.getDatalist_notif();
                oQRY_cpartype = oDS_cpar.getDatalist_YEARALL(nCPAR_MAXYEAR);
            } //End if (sROLE_RUID == valFLAG.FLAG_ROLE_CPAR_ADMIN)
            
            if (sROLE_RUID == valFLAG.FLAG_ROLE_CPAR_PIC) {
                oQRY = oDS_cpar.getDatalist_notif(sUSRRES_RUID);
                oQRY_cpartype = oDS_cpar.getDatalist_YEARALL(nCPAR_MAXYEAR, sUSRRES_RUID);
            } //End if (sROLE_RUID == valFLAG.FLAG_ROLE_CPAR_PIC)
            
            if (sROLE_RUID == valFLAG.FLAG_ROLE_PJXADMIN) {
                oQRY = oDS_cpar.getDatalist_notif(sUSRRES_RUID);
                oQRY_cpartype = oDS_cpar.getDatalist_YEARALL(nCPAR_MAXYEAR, sUSRRES_RUID);
            } //End if (sROLE_RUID == valFLAG.FLAG_ROLE_PJXADMIN)
        } //End private void prepareProcess()

        //CPAR Notification
        private List<CPARNOTIFVM> oQRY = null;
        private void calcCPAR_STSANDSTEP() {
            //CPAR_STS
            int? nOPEN = 0;
            int? nCLOSED = 0;
            int? nCANCELED = 0;
            //CPAR_STEP
            int? nPRECREATE = 0;
            int? nCREATED = 0;
            int? nRESPONDED = 0;
            int? nVERIFIED = 0;
            int? nVERIFIED2 = 0;
            foreach (var item in oQRY)
            {
                if (item.CPAR_STS == valFLAG.FLAG_CPAR_STS_OPEN)
                {
                    //CPAR_STEP
                    nPRECREATE = nPRECREATE + item.PRECREATE;
                    nCREATED = nCREATED + item.CREATED;
                    nRESPONDED = nRESPONDED + item.RESPONDED;
                    nVERIFIED = nVERIFIED + item.VERIFIED;
                    //CPAR_STS
                    nOPEN = nOPEN + (item.PRECREATE + item.CREATED + item.RESPONDED + item.VERIFIED);
                } //End if (item.CPAR_STS == valFLAG.FLAG_CPAR_STS_OPEN)
                if (item.CPAR_STS == valFLAG.FLAG_CPAR_STS_CLOSED)
                {
                    nCLOSED = nCLOSED + (item.PRECREATE + item.CREATED + item.RESPONDED + item.VERIFIED);
                    nVERIFIED2 = nVERIFIED2 + item.VERIFIED;
                }
                if (item.CPAR_STS == valFLAG.FLAG_CPAR_STS_CANCELED) { nCANCELED = nCANCELED + (item.PRECREATE + item.CREATED + item.RESPONDED + item.VERIFIED); }
            } //End foreach (var item in oQRY)
            //CPAR_STS
            ViewBag.OPEN = nOPEN;
            ViewBag.CLOSED = nCLOSED;
            ViewBag.CANCELED = nCANCELED;
            //CPAR_STEP
            ViewBag.PRECREATE = nPRECREATE;
            ViewBag.CREATED = nCREATED;
            ViewBag.RESPONDED = nRESPONDED;
            ViewBag.VERIFIED = nVERIFIED;
            ViewBag.VERIFIED2 = nVERIFIED2;
        } //End private void calcCPAR_STSANDSTEP()
        //CPAR Chat Notification
        private List<CPARNOTIF_CPARCHATVM> oQRY_cparchat = null;
        private void calcCPAR_CHAT(string id = null) {
            if (id == "all-cpar-chat-notif") { oQRY_cparchat = oDS_cparchatnotif.getDatalist_notif(sUSR_RUID); }
            else { oQRY_cparchat = oDS_cparchatnotif.getDatalist_notif(sUSR_RUID, "3"); }
            ViewBag.ModelCPARChat = oQRY_cparchat;
            int? nCPARChat = 0;
            foreach (var item in oQRY_cparchat)
            {
                nCPARChat = nCPARChat + item.COUNT_NOTIF;
            } //End foreach (var item in oQRY_cparchat)
            ViewBag.CPARChat = nCPARChat;
        } //End private void calcCPAR_CHAT()

        //CPAR Type
        private List<CPARYEARALLVM> oQRY_cpartype = null;
        private void calcCPAR_TYPE()
        {
            int? nIA = 0;
            int? nTM = 0;
            int? nPP = 0;
            int? nPI = 0;
            int? nCC = 0;
            int? nLL = 0;
            foreach (var item in oQRY_cpartype)
            {
                nIA = nIA + item.CPAR_IA;
                nTM = nTM + item.CPAR_TM;
                nPP = nPP + item.CPAR_PP;
                nPI = nPI + item.CPAR_PI;
                nCC = nCC + item.CPAR_CC;
                nLL = nLL + item.CPAR_LL;
            } //End foreach (var item in oQRY_cpartype)

            ViewBag.nIA = nIA;
            ViewBag.nTM = nTM;
            ViewBag.nPP = nPP;
            ViewBag.nPI = nPI;
            ViewBag.nCC = nCC;
            ViewBag.nLL = nLL;

        } //End private void calcCPAR_TYPE()
        public ActionResult Index(string id = null)
        {
            //Prepare
            prepareProcess();

            if (sUSR_RUID != "") {
                //Calculate CPAR Status and Step
                calcCPAR_STSANDSTEP();
                //Calculate CPAR Chat
                calcCPAR_CHAT();
                //Calculate CPAR Type
                calcCPAR_TYPE();
            } //End if (sUSR_RUID != "")
            
            return View();
        }
        [HttpPost]
        public ActionResult Index()
        {
            nCPAR_MAXYEAR = Convert.ToInt16(Request["CPAR_YEAR"].ToString());

            //Prepare
            prepareProcess();

            if (sUSR_RUID != "")
            {
                //Calculate CPAR Status and Step
                calcCPAR_STSANDSTEP();
                //Calculate CPAR Chat
                calcCPAR_CHAT();
                //Calculate CPAR Type
                calcCPAR_TYPE();
            } //End if (sUSR_RUID != "")

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aplikasi CPAR";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Arin Suga.";

            return View();
        }
    }
}
