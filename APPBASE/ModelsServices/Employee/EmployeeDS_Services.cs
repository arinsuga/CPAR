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
    public class EmployeeDS
    {
        //Constructor
        public EmployeeDS() { } //End public EmployeeDS

        //Get Datalist - Master area
        public List<Employee_ListVM> getDatalist()
        {
            List<Employee_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Employee_infos
                           select new Employee_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               BP_STS = tb.BP_STS,
                               BP_STS_NM = tb.BP_STS_NM,
                               RES_STS = tb.RES_STS,
                               RES_STS_NM = tb.RES_STS_NM,
                               BIZ_ACT = tb.BIZ_ACT,
                               BIZ_ACT_NM = tb.BIZ_ACT_NM,
                               RES_ID = tb.RES_ID,
                               RES_XID1 = tb.RES_XID1,
                               RES_NM1 = tb.RES_NM1,
                               RES_NM2 = tb.RES_NM2,
                               RES_NM3 = tb.RES_NM3,
                               SEX = tb.SEX,
                               DEPT_RUID = tb.DEPT_RUID,
                               DEPT_NM = tb.DEPT_NM,
                               JOB_TITLE_RUID = tb.JOB_TITLE_RUID,
                               JOB_TITLE_NM = tb.JOB_TITLE_NM,
                               IMG_SRC = tb.IMG_SRC
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Employee_ListVM> getDatalist()
        public List<Employee_ListVM> getDatalist_bystatus(int id)
        {
            List<Employee_ListVM> vReturn;
            string sRES_STS = "";

            if (id == 1) { sRES_STS = valFLAG.FLAG_EMPSTS_PRMT; } //End if (id == 1)
            if (id == 2) { sRES_STS = valFLAG.FLAG_EMPSTS_CONT; } //End if (id == 2)
            if (id == 3) { sRES_STS = valFLAG.FLAG_EMPSTS_PROB; } //End if (id == 3)
            if (id == 4) { sRES_STS = valFLAG.FLAG_EMPSTS_OUTSRC; } //End if (id == 4)
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Employeeactive_infos
                           where tb.RES_STS == sRES_STS
                           select new Employee_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               BP_STS = tb.BP_STS,
                               BP_STS_NM = tb.BP_STS_NM,
                               RES_STS = tb.RES_STS,
                               RES_STS_NM = tb.RES_STS_NM,
                               BIZ_ACT = tb.BIZ_ACT,
                               BIZ_ACT_NM = tb.BIZ_ACT_NM,
                               RES_ID = tb.RES_ID,
                               RES_XID1 = tb.RES_XID1,
                               RES_NM1 = tb.RES_NM1,
                               RES_NM2 = tb.RES_NM2,
                               RES_NM3 = tb.RES_NM3,
                               SEX = tb.SEX,
                               DEPT_RUID = tb.DEPT_RUID,
                               DEPT_NM = tb.DEPT_NM,
                               JOB_TITLE_RUID = tb.JOB_TITLE_RUID,
                               JOB_TITLE_NM = tb.JOB_TITLE_NM,
                               IMG_SRC = tb.IMG_SRC
                           };
                vReturn = oQRY.OrderBy(fld=>fld.RES_NM1).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Employee_ListVM> getDatalist()
        public List<Employee_jobattrVM> getDatalist_jobattr(string psDEPT_RUID = null)
        {
            List<Employee_jobattrVM> oReturn;

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Employee_infos
                           select new Employee_jobattrVM
                           {
                               RUID = tb.RUID,
                               RES_ID = tb.RES_ID,
                               RES_XID1 = tb.RES_XID1,
                               RES_NM1 = tb.RES_NM1,
                               DEPT_RUID = tb.DEPT_RUID,
                               DEPT_ID = tb.DEPT_ID,
                               DEPT_NM = tb.DEPT_NM,
                               BRNCH_RUID = tb.BRNCH_RUID,
                               BRNCH_ID = tb.BRNCH_ID,
                               BRNCH_NM = tb.BRNCH_NM,
                               JOB_TITLE_RUID = tb.JOB_TITLE_RUID,
                               JOB_TITLE_ID = tb.JOB_TITLE_ID,
                               JOB_TITLE_NM = tb.JOB_TITLE_NM
                           };
                //Filter by Departemen
                if ((psDEPT_RUID != null) && (psDEPT_RUID != "")) {
                    oQRY = oQRY.Where(fld => fld.DEPT_RUID == psDEPT_RUID);
                } //End if ((psDEPT_RUID != null) && (psDEPT_RUID != ""))
                oReturn = oQRY.OrderBy(fld => new { fld.DEPT_NM, fld.RES_NM1 }).ToList();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public List<Employee_jobattrVM> getDatalist_jobattr()

        //Get Data
        public Employee_DetailVM getData(string id = null)
        {
            Employee_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.EmployeeWithaddress_infos
                           where tb.RUID == id
                           select new Employee_DetailVM
                           {
                               //Main Key
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               BP_STS = tb.BP_STS, //Active/Quit
                               BP_STS_NM = tb.BP_STS_NM,
                               //Secondary Key
                               RES_ID = tb.RES_ID, //NIK
                               RES_XID1 = tb.RES_XID1, //NO ABSEN
                               RES_STS = tb.RES_STS, //Orientasi/Kontrak/Permanen (Karir)
                               RES_STS_NM = tb.RES_STS_NM,
                               BIZ_ACT = tb.BIZ_ACT, //Cuti/Trainning/DLK/Konsolidasi/Izin/Sakit
                               BIZ_ACT_NM = tb.BIZ_ACT_NM,
                               //Job info
                               DEPT_RUID = tb.DEPT_RUID,
                               DEPT_NM = tb.DEPT_NM,
                               JOB_TITLE_RUID = tb.JOB_TITLE_RUID,
                               JOB_TITLE_NM = tb.JOB_TITLE_NM,
                               JOIN_DT = tb.JOIN_DT,
                               RES_STS_STARTDT = tb.RES_STS_STARTDT,
                               RES_STS_ENDDT = tb.RES_STS_ENDDT,
                               JAMSOSTEK_NO = tb.JAMSOSTEK_NO,
                               //Name
                               RES_NM1 = tb.RES_NM1,
                               RES_NM2 = tb.RES_NM2,
                               RES_NM3 = tb.RES_NM3,
                               //Others
                               RELIGION_RUID = tb.RELIGION_RUID,
                               RELIGION_NM = tb.RELIGION_NM,
                               SEX = tb.SEX,
                               SEX_NM = tb.SEX_NM,
                               MRTL_STS = tb.MRTL_STS,
                               MRTL_STS_NM = tb.MRTL_STS_NM,
                               POB = tb.POB,
                               DOB = tb.DOB,
                               NPWP = tb.NPWP,
                               //Photo
                               IMG_SRC = tb.IMG_SRC,
                               //Contacts
                               PHN_HMO1 = tb.PHN_HMO1,
                               PHN_MBL1 = tb.PHN_MBL1,
                               MAIL1 = tb.MAIL1,
                               //Address KTP
                               CNTRY_RUID_IC = tb.CNTRY_RUID_IC,
                               CNTRY_NM_IC = tb.CNTRY_NM_IC,
                               CITY_RUID_IC = tb.CITY_RUID_IC,
                               CITY_NM_IC = tb.CITY_NM_IC,
                               ZIP_IC = tb.ZIP_IC,
                               ADDR1_IC = tb.ADDR1_IC,
                               ADDR2_IC = tb.ADDR2_IC,
                               ADDR3_IC = tb.ADDR3_IC,
                               //Address Domisili
                               CNTRY_RUID_DMCL = tb.CNTRY_RUID_DMCL,
                               CNTRY_NM_DMCL = tb.CNTRY_NM_DMCL,
                               CITY_RUID_DMCL = tb.CITY_RUID_DMCL,
                               CITY_NM_DMCL = tb.CITY_NM_DMCL,
                               ZIP_DMCL = tb.ZIP_DMCL,
                               ADDR1_DMCL = tb.ADDR1_DMCL,
                               ADDR2_DMCL = tb.ADDR2_DMCL,
                               ADDR3_DMCL = tb.ADDR3_DMCL,
                               //Additional Field
                               RMK = tb.RMK
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Employee_DetailVM getData(string id = null)
        public Employee_jobattrVM getData_jobattr(string id = null)
        {
            Employee_jobattrVM oReturn;

            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Employee_infos
                           where tb.RUID == id
                           select new Employee_jobattrVM
                           {
                               RUID = tb.RUID,
                               RES_ID = tb.RES_ID,
                               RES_XID1 = tb.RES_XID1,
                               RES_NM1 = tb.RES_NM1,
                               DEPT_RUID = tb.DEPT_RUID,
                               DEPT_ID = tb.DEPT_ID,
                               DEPT_NM = tb.DEPT_NM,
                               BRNCH_RUID = tb.BRNCH_RUID,
                               BRNCH_ID = tb.BRNCH_ID,
                               BRNCH_NM = tb.BRNCH_NM,
                               JOB_TITLE_RUID = tb.JOB_TITLE_RUID,
                               JOB_TITLE_ID = tb.JOB_TITLE_ID,
                               JOB_TITLE_NM = tb.JOB_TITLE_NM
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Employee_DetailVM getData_jobattr(string id = null)
        public string getData_deptruid(string id = null)
        {
            string oReturn;

            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Employee_infos
                           where tb.RUID == id
                           select new { DEPT_RUID = tb.DEPT_RUID }).SingleOrDefault();
                oReturn = oQRY.DEPT_RUID;
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Employee_DetailVM getData_jobattr(string id = null)

        //Check Exists
        public Boolean isExists_RES_ID(string id = null)
        {
            Boolean vReturn = false;


            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Employee_infos
                            where tb.RES_ID == id
                            select new { RES_ID = tb.RES_ID }).ToList();

                if (oQRY.Count > 0) { vReturn = true; }


            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isExists_RES_ID(string id = null)
        //Check Exists
        public Boolean isExists_RES_XID1(string id = null)
        {
            Boolean vReturn = false;


            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Employee_infos
                            where tb.RES_XID1 == id
                            select new { RES_XID1 = tb.RES_XID1 }).ToList();

                if (oQRY.Count > 0) { vReturn = true; }


            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isExists_RES_XID1(string id = null)
    } //End public class ProjectDS
} //End namespace APPBASE.Models