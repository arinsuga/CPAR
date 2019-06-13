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
    public partial class Employee_ListVM
    {
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; } //Active/Inative
        public string BP_STS_NM { get; set; }

        public string RES_STS { get; set; } //Orientasi/Kontrak/Permanen (Karir)
        public string RES_STS_NM { get; set; }
        public string BIZ_ACT { get; set; } //Cuti/Trainning/DLK/Konsolidasi/Izin/Sakit
        public string BIZ_ACT_NM { get; set; }

        public string RES_ID { get; set; } //NIK
        public string RES_XID1 { get; set; } //NO ABSEN
        [Display(Name = lblFIELD.RES_NM)]
        public string RES_NM1 { get; set; }
        public string RES_NM2 { get; set; }
        public string RES_NM3 { get; set; }
        public string SEX { get; set; }

        public string DEPT_RUID { get; set; }
        [Display(Name = lblFIELD.DEPT_NM)]
        public string DEPT_NM { get; set; }
        public string JOB_TITLE_RUID { get; set; }
        public string JOB_TITLE_NM { get; set; }

        public string IMG_SRC { get; set; }
    } //End public partial class Employee_ListVM
    public partial class Employee_DetailVM
    {
        //Main Key
        public int? RSEQNO { get; set; }
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; } //Active/Quit
        public string BP_STS_NM { get; set; }

        //Secondary Key
        public string RES_ID { get; set; } //NIK
        public string RES_XID1 { get; set; } //NO ABSEN
        public string BIZ_ACT { get; set; } //Cuti/Trainning/DLK/Konsolidasi/Izin/Sakit
        public string BIZ_ACT_NM { get; set; }

        //Job info
        public string RES_STS { get; set; } //Status Kepegawaian - Orientasi/Kontrak/Permanen (Karir)
        public string RES_STS_NM { get; set; }
        public string DEPT_RUID { get; set; }
        [Display(Name = lblFIELD.DEPT_NM)]
        public string DEPT_NM { get; set; }
        public string JOB_TITLE_RUID { get; set; }
        public string JOB_TITLE_NM { get; set; }
        [DisplayFormat(DataFormatString = "{0:" + hlpConfig.ConstantaInfo.FMT_DTSHT + "}")]
        public DateTime? JOIN_DT { get; set; }
        [DisplayFormat(DataFormatString = "{0:" + hlpConfig.ConstantaInfo.FMT_DTSHT + "}")]
        public DateTime? RES_STS_STARTDT { get; set; }
        [DisplayFormat(DataFormatString = "{0:" + hlpConfig.ConstantaInfo.FMT_DTSHT + "}")]
        public DateTime? RES_STS_ENDDT { get; set; }
        public string JAMSOSTEK_NO { get; set; }


        //Name
        [Display(Name = lblFIELD.RES_NM)]
        public string RES_NM1 { get; set; }
        public string RES_NM2 { get; set; }
        public string RES_NM3 { get; set; }
        //Others
        public string RELIGION_RUID { get; set; }
        public string RELIGION_NM { get; set; }
        public string SEX { get; set; }
        public string SEX_NM { get; set; }
        public string MRTL_STS { get; set; }
        public string MRTL_STS_NM { get; set; }
        public string POB { get; set; }
        public DateTime? DOB { get; set; }
        public string NPWP { get; set; }
        //Photo
        public string IMG_SRC { get; set; }
        //Contacts
        public string PHN_HMO1 { get; set; }
        public string PHN_MBL1 { get; set; }
        public string MAIL1 { get; set; }
        //Address KTP
        public string CNTRY_RUID_IC { get; set; }
        public string CNTRY_NM_IC { get; set; }
        public string CITY_RUID_IC { get; set; }
        public string CITY_NM_IC { get; set; }
        public string CITY_OTHNAME_IC { get; set; }
        public string ZIP_IC { get; set; }
        public string ADDR1_IC { get; set; }
        public string ADDR2_IC { get; set; }
        public string ADDR3_IC { get; set; }
        //Address Domisili
        public string CNTRY_RUID_DMCL { get; set; }
        public string CNTRY_NM_DMCL { get; set; }
        public string CITY_RUID_DMCL { get; set; }
        public string CITY_NM_DMCL { get; set; }
        public string CITY_OTHNAME_DMCL { get; set; }
        public string ZIP_DMCL { get; set; }
        public string ADDR1_DMCL { get; set; }
        public string ADDR2_DMCL { get; set; }
        public string ADDR3_DMCL { get; set; }

        //Additional Field
        public string RMK { get; set; }
    } //End public partial class Employee_DetailVM
    public partial class Employee_jobattrVM
    {
        public string RUID { get; set; }
        public string RES_ID { get; set; } //NIK
        public string RES_XID1 { get; set; } //NO ABSEN
        [Display(Name = lblFIELD.RES_NM)]
        public string RES_NM1 { get; set; }
        public DateTime? JOIN_DT { get; set; }

        public string DEPT_RUID { get; set; }
        public string DEPT_ID { get; set; }
        [Display(Name = lblFIELD.DEPT_NM)]
        public string DEPT_NM { get; set; }

        public string BRNCH_RUID { get; set; }
        public string BRNCH_ID { get; set; }
        [Display(Name = lblFIELD.BRNCH_NM)]
        public string BRNCH_NM { get; set; }

        public string JOB_TITLE_RUID { get; set; }
        public string JOB_TITLE_ID { get; set; }
        [Display(Name = lblFIELD.JOB_TITLE_NM)]
        public string JOB_TITLE_NM { get; set; }
    } //End public partial class Employee_jobattrVM
} //End namespace APPBASE.Models