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
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class CPAR
    {
        public Boolean isNEW_CONFIG;
        public string sYEAR = "";
        public string sMONTH = "";
        public int nYEAR = 0;
        public int nMONTH = 0;
        public int nCOUNTER = 0;
        public Config_cparid_DetailVM oVMConfig_cparid;
        private Config_cparidDS oDSConfig_cparid;

        public void setCPAR_ID() {
            oDSConfig_cparid = new Config_cparidDS();
            string sID = "";
            string sID1 = "";
            string sID2 = "";
            string sID3 = "";
            string sID4 = "";
            

            //DateTime dDatetime = DateTime.Now;
             DateTime? dDatetime = null;
             if (this.CPAR_DT != null) dDatetime = this.CPAR_DT.Value;
             else dDatetime = DateTime.Now;
            

            //string sYEARMONTH = "";
            //string sYEARMONTH_cfg = "";

            this.nYEAR = dDatetime.Value.Year;
            this.nMONTH = dDatetime.Value.Month;
            this.sYEAR = dDatetime.Value.Year.ToString();
            this.sMONTH = dDatetime.Value.Month.ToString("D2");

            //Get Config_cparid
            this.oVMConfig_cparid = oDSConfig_cparid.getData(nYEAR, nMONTH);
            //sYEARMONTH = sYEAR + sMONTH;
            //sYEARMONTH_cfg = ((int)oVMConfig_cparid.CPARID_YEAR).ToString() + ((int)oVMConfig_cparid.CPARID_MONTH).ToString("D2");

            if (this.oVMConfig_cparid == null)
            //if (sYEARMONTH != sYEARMONTH_cfg)
            {
                isNEW_CONFIG = true;
                this.nCOUNTER = 1;
                this.oVMConfig_cparid = new Config_cparid_DetailVM();
            }
            else {
                this.nCOUNTER = (int)oVMConfig_cparid.CPARID_COUNTER + 1;
            } //End if (sYEARMONTH != sYEARMONTH_cfg)

            sID1 = this.nCOUNTER.ToString("D3");
            sID2 = getMontToRomawi(this.nMONTH);
            sID3 = sYEAR;
            sID4 = this.CPAR_TYPE;

            //if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA) { sID4 = oVMConfig_cparid.CPARID_IA; }
            //if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_TM) { sID4 = oVMConfig_cparid.CPARID_TM; }
            //if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) { sID4 = oVMConfig_cparid.CPARID_PP; }
            //if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PI) { sID4 = oVMConfig_cparid.CPARID_PI; }
            //if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC) { sID4 = oVMConfig_cparid.CPARID_CC; }
            //if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_LL) { sID4 = oVMConfig_cparid.CPARID_LL; }

            sID = sID1 + "/" + sID2 + "/" + sID3 + "/" + sID4;
            this.CPAR_ID = sID;
            //Update Config CPARID
            oVMConfig_cparid.CPARID_COUNTER = nCOUNTER;
            oVMConfig_cparid.CPARID_YEAR = nYEAR;
            oVMConfig_cparid.CPARID_MONTH = nMONTH;
            oVMConfig_cparid.CPARID_LAST = sID;
        } //End public void setCPAR_ID()
        private string getMontToRomawi(int pnMonth) {
            string vReturn = "";
            if (pnMonth == 1) { vReturn = "I"; }
            if (pnMonth == 2) { vReturn = "II"; }
            if (pnMonth == 3) { vReturn = "III"; }
            if (pnMonth == 4) { vReturn = "IV"; }
            if (pnMonth == 5) { vReturn = "V"; }
            if (pnMonth == 6) { vReturn = "VI"; }
            if (pnMonth == 7) { vReturn = "VII"; }
            if (pnMonth == 8) { vReturn = "VIII"; }
            if (pnMonth == 9) { vReturn = "IX"; }
            if (pnMonth == 10) { vReturn = "X"; }
            if (pnMonth == 11) { vReturn = "XI"; }
            if (pnMonth == 12) { vReturn = "XII"; }
            return vReturn;
        } //End private string getMontToRomawi(int pnMonth)
    } //End public partial class CPAR
} //End namespace APPBASE.Models