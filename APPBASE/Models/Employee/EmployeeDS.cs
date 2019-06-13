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
    [Table("VWMST01EMPLOYEE_INFO")]
    public class Employee_info
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string BP_STS_ID { get; set; }
        public string BP_STS_NM { get; set; }
        public string DEPT_RUID { get; set; }
        public string DEPT_ID { get; set; }
        public string DEPT_NM { get; set; }
        public string BRNCH_RUID { get; set; }
        public string BRNCH_ID { get; set; }
        [Display(Name = lblFIELD.BRNCH_NM)]
        public string BRNCH_NM { get; set; }
        public string CMPNY_RUID { get; set; }
        public string JOB_TITLE_RUID { get; set; }
        public string JOB_TITLE_ID { get; set; }
        [Display(Name = lblFIELD.JOB_TITLE_NM)]
        public string JOB_TITLE_NM { get; set; }
        public string RELIGION_RUID { get; set; }
        public string RELIGION_ID { get; set; }
        public string RELIGION_NM { get; set; }
        public string RES_TYPE { get; set; }
        public string RES_ID { get; set; } //NIK
        [Display(Name = lblFIELD.RES_NM)]
        public string RES_NM1 { get; set; }
        public string RES_NM2 { get; set; }
        public string RES_NM3 { get; set; }
        public string RES_XID1 { get; set; } //NO ABSEN
        public string RES_XID2 { get; set; }
        public string RES_XID3 { get; set; }
        public string RES_XID4 { get; set; }
        public string RES_XID5 { get; set; }
        public string RES_XNM1 { get; set; }
        public string RES_XNM2 { get; set; }
        public string RES_XNM3 { get; set; }
        public string RES_XNM4 { get; set; }
        public string RES_XNM5 { get; set; }
        [Display(Name = lblFIELD.SEX)]
        public string SEX { get; set; }
        public string SEX_ID { get; set; }
        public string SEX_NM { get; set; }
        [Display(Name = lblFIELD.MRTL_STS)]
        public string MRTL_STS { get; set; }
        public string MRTL_STS_ID { get; set; }
        public string MRTL_STS_NM { get; set; }
        [Display(Name = lblFIELD.POB)]
        public string POB { get; set; }
        [Display(Name = lblFIELD.DOB)]
        public DateTime? DOB { get; set; }
        [Display(Name = lblFIELD.JOIN_DT)]
        [DisplayFormat(DataFormatString = "{0:" + hlpConfig.ConstantaInfo.FMT_DTSHT + "}")]
        public DateTime? JOIN_DT { get; set; }
        public string NPWP { get; set; }
        public string JAMSOSTEK_NO { get; set; }
        public string PHN_HMO1 { get; set; }
        public string PHN_HMO2 { get; set; }
        public string PHN_HMO3 { get; set; }
        public string PHN_HMO4 { get; set; }
        public string PHN_HMO5 { get; set; }
        public string PHN_MBL1 { get; set; }
        public string PHN_MBL2 { get; set; }
        public string PHN_MBL3 { get; set; }
        public string PHN_MBL4 { get; set; }
        public string PHN_MBL5 { get; set; }
        public string PHN_OFF1 { get; set; }
        public string PHN_OFF2 { get; set; }
        public string PHN_OFF3 { get; set; }
        public string PHN_OFF4 { get; set; }
        public string PHN_OFF5 { get; set; }
        public string FAX1 { get; set; }
        public string FAX2 { get; set; }
        public string FAX3 { get; set; }
        public string FAX4 { get; set; }
        public string FAX5 { get; set; }
        public string MAIL1 { get; set; }
        public string MAIL2 { get; set; }
        public string MAIL3 { get; set; }
        public string MAIL4 { get; set; }
        public string MAIL5 { get; set; }
        public string WEBSITE1 { get; set; }
        public string WEBSITE2 { get; set; }
        public string WEBSITE3 { get; set; }
        public string WEBSITE4 { get; set; }
        public string WEBSITE5 { get; set; }
        public string CP1_NM { get; set; }
        public string CP1_PHN_HMO { get; set; }
        public string CP1_PHN_MBL { get; set; }
        public string CP1_MAIL { get; set; }
        public string CP1_WEBSITE { get; set; }
        public string CP2_NM { get; set; }
        public string CP2_PHN_HMO { get; set; }
        public string CP2_PHN_MBL { get; set; }
        public string CP2_MAIL { get; set; }
        public string CP2_WEBSITE { get; set; }
        public string RMK { get; set; }
        public string NOTES { get; set; }
        public string ADD_RMK1 { get; set; }
        public string ADD_RMK2 { get; set; }
        public string ADD_RMK3 { get; set; }
        public string ADD_RMK4 { get; set; }
        public string ADD_RMK5 { get; set; }
        public string ADD_FLD1 { get; set; }
        public string ADD_FLD2 { get; set; }
        public string ADD_FLD3 { get; set; }
        public string ADD_FLD4 { get; set; }
        public string ADD_FLD5 { get; set; }
        public string BIZ_ACT { get; set; }
        public string BIZ_ACT_ID { get; set; }
        public string BIZ_ACT_NM { get; set; }
        public string RES_STS { get; set; }
        public string RES_STS_ID { get; set; }
        public string RES_STS_NM { get; set; }
        public DateTime? RES_STS_STARTDT { get; set; }
        public DateTime? RES_STS_ENDDT { get; set; }
        public string IMG_SRC { get; set; }
    } //End public class Employee_info
    [Table("VWMST01EMPLOYEE_ADDR_INFO")]
    public class EmployeeWithaddress_info
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string BP_STS_ID { get; set; }
        public string BP_STS_NM { get; set; }
        public string DEPT_RUID { get; set; }
        public string DEPT_ID { get; set; }
        public string DEPT_NM { get; set; }
        public string BRNCH_RUID { get; set; }
        public string BRNCH_ID { get; set; }
        [Display(Name = lblFIELD.BRNCH_NM)]
        public string BRNCH_NM { get; set; }
        public string CMPNY_RUID { get; set; }
        public string JOB_TITLE_RUID { get; set; }
        public string JOB_TITLE_ID { get; set; }
        [Display(Name = lblFIELD.JOB_TITLE_NM)]
        public string JOB_TITLE_NM { get; set; }
        public string RELIGION_RUID { get; set; }
        public string RELIGION_ID { get; set; }
        public string RELIGION_NM { get; set; }
        public string RES_TYPE { get; set; }
        public string RES_ID { get; set; } //NIK
        [Display(Name = lblFIELD.RES_NM)]
        public string RES_NM1 { get; set; }
        public string RES_NM2 { get; set; }
        public string RES_NM3 { get; set; }
        public string RES_XID1 { get; set; } //NO ABSEN
        public string RES_XID2 { get; set; }
        public string RES_XID3 { get; set; }
        public string RES_XID4 { get; set; }
        public string RES_XID5 { get; set; }
        public string RES_XNM1 { get; set; }
        public string RES_XNM2 { get; set; }
        public string RES_XNM3 { get; set; }
        public string RES_XNM4 { get; set; }
        public string RES_XNM5 { get; set; }
        [Display(Name = lblFIELD.SEX)]
        public string SEX { get; set; }
        public string SEX_ID { get; set; }
        public string SEX_NM { get; set; }
        [Display(Name = lblFIELD.MRTL_STS)]
        public string MRTL_STS { get; set; }
        public string MRTL_STS_ID { get; set; }
        public string MRTL_STS_NM { get; set; }
        [Display(Name = lblFIELD.POB)]
        public string POB { get; set; }
        [Display(Name = lblFIELD.DOB)]
        public DateTime? DOB { get; set; }
        [Display(Name = lblFIELD.JOIN_DT)]
        [DisplayFormat(DataFormatString = "{0:" + hlpConfig.ConstantaInfo.FMT_DTSHT + "}")]
        public DateTime? JOIN_DT { get; set; }
        public string NPWP { get; set; }
        public string JAMSOSTEK_NO { get; set; }
        public string PHN_HMO1 { get; set; }
        public string PHN_HMO2 { get; set; }
        public string PHN_HMO3 { get; set; }
        public string PHN_HMO4 { get; set; }
        public string PHN_HMO5 { get; set; }
        public string PHN_MBL1 { get; set; }
        public string PHN_MBL2 { get; set; }
        public string PHN_MBL3 { get; set; }
        public string PHN_MBL4 { get; set; }
        public string PHN_MBL5 { get; set; }
        public string PHN_OFF1 { get; set; }
        public string PHN_OFF2 { get; set; }
        public string PHN_OFF3 { get; set; }
        public string PHN_OFF4 { get; set; }
        public string PHN_OFF5 { get; set; }
        public string FAX1 { get; set; }
        public string FAX2 { get; set; }
        public string FAX3 { get; set; }
        public string FAX4 { get; set; }
        public string FAX5 { get; set; }
        public string MAIL1 { get; set; }
        public string MAIL2 { get; set; }
        public string MAIL3 { get; set; }
        public string MAIL4 { get; set; }
        public string MAIL5 { get; set; }
        public string WEBSITE1 { get; set; }
        public string WEBSITE2 { get; set; }
        public string WEBSITE3 { get; set; }
        public string WEBSITE4 { get; set; }
        public string WEBSITE5 { get; set; }
        public string CP1_NM { get; set; }
        public string CP1_PHN_HMO { get; set; }
        public string CP1_PHN_MBL { get; set; }
        public string CP1_MAIL { get; set; }
        public string CP1_WEBSITE { get; set; }
        public string CP2_NM { get; set; }
        public string CP2_PHN_HMO { get; set; }
        public string CP2_PHN_MBL { get; set; }
        public string CP2_MAIL { get; set; }
        public string CP2_WEBSITE { get; set; }
        public string RMK { get; set; }
        public string NOTES { get; set; }
        public string ADD_RMK1 { get; set; }
        public string ADD_RMK2 { get; set; }
        public string ADD_RMK3 { get; set; }
        public string ADD_RMK4 { get; set; }
        public string ADD_RMK5 { get; set; }
        public string ADD_FLD1 { get; set; }
        public string ADD_FLD2 { get; set; }
        public string ADD_FLD3 { get; set; }
        public string ADD_FLD4 { get; set; }
        public string ADD_FLD5 { get; set; }
        public string BIZ_ACT { get; set; }
        public string BIZ_ACT_ID { get; set; }
        public string BIZ_ACT_NM { get; set; }
        public string RES_STS { get; set; }
        public string RES_STS_ID { get; set; }
        public string RES_STS_NM { get; set; }
        public DateTime? RES_STS_STARTDT { get; set; }
        public DateTime? RES_STS_ENDDT { get; set; }
        public string IMG_SRC { get; set; }
        //Address KTP
        public string CNTRY_RUID_IC { get; set; }
        public string CNTRY_ID_IC { get; set; }
        public string CNTRY_NM_IC { get; set; }
        public string CITY_RUID_IC { get; set; }
        public string CITY_ID_IC { get; set; }
        public string CITY_NM_IC { get; set; }
        public string CITY_OTHNAME_IC { get; set; }
        public string ZIP_IC { get; set; }
        public string ADDR1_IC { get; set; }
        public string ADDR2_IC { get; set; }
        public string ADDR3_IC { get; set; }
        public string ADDR4_IC { get; set; }
        public string ADDR5_IC { get; set; }
        //Address Domisili
        public string CNTRY_RUID_DMCL { get; set; }
        public string CNTRY_ID_DMCL { get; set; }
        public string CNTRY_NM_DMCL { get; set; }
        public string CITY_RUID_DMCL { get; set; }
        public string CITY_ID_DMCL { get; set; }
        public string CITY_NM_DMCL { get; set; }
        public string CITY_OTHNAME_DMCL { get; set; }
        public string ZIP_DMCL { get; set; }
        public string ADDR1_DMCL { get; set; }
        public string ADDR2_DMCL { get; set; }
        public string ADDR3_DMCL { get; set; }
        public string ADDR4_DMCL { get; set; }
        public string ADDR5_DMCL { get; set; }
    } //End public class EmployeeWithaddress_info
    [Table("VWMST01EMPLOYEEACTIVE_INFO")]
    public class Employeeactive_info
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string BP_STS_ID { get; set; }
        public string BP_STS_NM { get; set; }
        public string DEPT_RUID { get; set; }
        public string DEPT_ID { get; set; }
        public string DEPT_NM { get; set; }
        public string BRNCH_RUID { get; set; }
        public string BRNCH_ID { get; set; }
        [Display(Name = lblFIELD.BRNCH_NM)]
        public string BRNCH_NM { get; set; }
        public string CMPNY_RUID { get; set; }
        public string JOB_TITLE_RUID { get; set; }
        public string JOB_TITLE_ID { get; set; }
        [Display(Name = lblFIELD.JOB_TITLE_NM)]
        public string JOB_TITLE_NM { get; set; }
        public string RELIGION_RUID { get; set; }
        public string RELIGION_ID { get; set; }
        public string RELIGION_NM { get; set; }
        public string RES_TYPE { get; set; }
        public string RES_ID { get; set; } //NIK
        [Display(Name = lblFIELD.RES_NM)]
        public string RES_NM1 { get; set; }
        public string RES_NM2 { get; set; }
        public string RES_NM3 { get; set; }
        public string RES_XID1 { get; set; } //NO ABSEN
        public string RES_XID2 { get; set; }
        public string RES_XID3 { get; set; }
        public string RES_XID4 { get; set; }
        public string RES_XID5 { get; set; }
        public string RES_XNM1 { get; set; }
        public string RES_XNM2 { get; set; }
        public string RES_XNM3 { get; set; }
        public string RES_XNM4 { get; set; }
        public string RES_XNM5 { get; set; }
        [Display(Name = lblFIELD.SEX)]
        public string SEX { get; set; }
        public string SEX_ID { get; set; }
        public string SEX_NM { get; set; }
        [Display(Name = lblFIELD.MRTL_STS)]
        public string MRTL_STS { get; set; }
        public string MRTL_STS_ID { get; set; }
        public string MRTL_STS_NM { get; set; }
        [Display(Name = lblFIELD.POB)]
        public string POB { get; set; }
        [Display(Name = lblFIELD.DOB)]
        public DateTime? DOB { get; set; }
        [Display(Name = lblFIELD.JOIN_DT)]
        [DisplayFormat(DataFormatString = "{0:" + hlpConfig.ConstantaInfo.FMT_DTSHT + "}")]
        public DateTime? JOIN_DT { get; set; }
        public string NPWP { get; set; }
        public string JAMSOSTEK_NO { get; set; }
        public string PHN_HMO1 { get; set; }
        public string PHN_HMO2 { get; set; }
        public string PHN_HMO3 { get; set; }
        public string PHN_HMO4 { get; set; }
        public string PHN_HMO5 { get; set; }
        public string PHN_MBL1 { get; set; }
        public string PHN_MBL2 { get; set; }
        public string PHN_MBL3 { get; set; }
        public string PHN_MBL4 { get; set; }
        public string PHN_MBL5 { get; set; }
        public string PHN_OFF1 { get; set; }
        public string PHN_OFF2 { get; set; }
        public string PHN_OFF3 { get; set; }
        public string PHN_OFF4 { get; set; }
        public string PHN_OFF5 { get; set; }
        public string FAX1 { get; set; }
        public string FAX2 { get; set; }
        public string FAX3 { get; set; }
        public string FAX4 { get; set; }
        public string FAX5 { get; set; }
        public string MAIL1 { get; set; }
        public string MAIL2 { get; set; }
        public string MAIL3 { get; set; }
        public string MAIL4 { get; set; }
        public string MAIL5 { get; set; }
        public string WEBSITE1 { get; set; }
        public string WEBSITE2 { get; set; }
        public string WEBSITE3 { get; set; }
        public string WEBSITE4 { get; set; }
        public string WEBSITE5 { get; set; }
        public string CP1_NM { get; set; }
        public string CP1_PHN_HMO { get; set; }
        public string CP1_PHN_MBL { get; set; }
        public string CP1_MAIL { get; set; }
        public string CP1_WEBSITE { get; set; }
        public string CP2_NM { get; set; }
        public string CP2_PHN_HMO { get; set; }
        public string CP2_PHN_MBL { get; set; }
        public string CP2_MAIL { get; set; }
        public string CP2_WEBSITE { get; set; }
        public string RMK { get; set; }
        public string NOTES { get; set; }
        public string ADD_RMK1 { get; set; }
        public string ADD_RMK2 { get; set; }
        public string ADD_RMK3 { get; set; }
        public string ADD_RMK4 { get; set; }
        public string ADD_RMK5 { get; set; }
        public string ADD_FLD1 { get; set; }
        public string ADD_FLD2 { get; set; }
        public string ADD_FLD3 { get; set; }
        public string ADD_FLD4 { get; set; }
        public string ADD_FLD5 { get; set; }
        public string BIZ_ACT { get; set; }
        public string BIZ_ACT_ID { get; set; }
        public string BIZ_ACT_NM { get; set; }
        public string RES_STS { get; set; }
        public string RES_STS_ID { get; set; }
        public string RES_STS_NM { get; set; }
        public DateTime? RES_STS_STARTDT { get; set; }
        public DateTime? RES_STS_ENDDT { get; set; }
        public string IMG_SRC { get; set; }
    } //End public class Employeeactive_info
    [Table("VWMSL01EMPLOYEE_HASNOUSR_INFO")]
    public class EmployeeHasnousr_info
    {
        public string ADTRL_WKS { get; set; }
        public string ADTRL_IP { get; set; }
        public string ADTRL_USR { get; set; }
        public string ADTRL_PRG { get; set; }
        public DateTime? ADTRL_DT { get; set; }
        public int? RSEQNO { get; set; }
        [Key]
        public string RUID { get; set; }
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string DEPT_RUID { get; set; }
        public string DEPT_ID { get; set; }
        public string DEPT_NM { get; set; }
        public string BRNCH_RUID { get; set; }
        public string BRNCH_ID { get; set; }
        [Display(Name = lblFIELD.DEPT_NM)]
        public string BRNCH_NM { get; set; }
        public string CMPNY_RUID { get; set; }
        public string JOB_TITLE_RUID { get; set; }
        public string JOB_TITLE_ID { get; set; }
        [Display(Name = lblFIELD.JOB_TITLE_NM)]
        public string JOB_TITLE_NM { get; set; }
        public string RELIGION_RUID { get; set; }
        public string RES_TYPE { get; set; }
        public string RES_ID { get; set; }
        [Display(Name = lblFIELD.RES_NM)]
        public string RES_NM1 { get; set; }
        public string RES_NM2 { get; set; }
        public string RES_NM3 { get; set; }
        public string RES_XID1 { get; set; }
        public string RES_XID2 { get; set; }
        public string RES_XID3 { get; set; }
        public string RES_XID4 { get; set; }
        public string RES_XID5 { get; set; }
        public string RES_XNM1 { get; set; }
        public string RES_XNM2 { get; set; }
        public string RES_XNM3 { get; set; }
        public string RES_XNM4 { get; set; }
        public string RES_XNM5 { get; set; }
        [Display(Name = lblFIELD.SEX)]
        public string SEX { get; set; }
        [Display(Name = lblFIELD.MRTL_STS)]
        public string MRTL_STS { get; set; }
        [Display(Name = lblFIELD.POB)]
        public string POB { get; set; }
        [Display(Name = lblFIELD.DOB)]
        public DateTime? DOB { get; set; }
        [Display(Name = lblFIELD.JOIN_DT)]
        [DisplayFormat(DataFormatString = "{0:" + hlpConfig.ConstantaInfo.FMT_DTSHT + "}")]
        public DateTime? JOIN_DT { get; set; }
        public string NPWP { get; set; }
        public string JAMSOSTEK_NO { get; set; }
        public string PHN_HMO1 { get; set; }
        public string PHN_HMO2 { get; set; }
        public string PHN_HMO3 { get; set; }
        public string PHN_HMO4 { get; set; }
        public string PHN_HMO5 { get; set; }
        public string PHN_MBL1 { get; set; }
        public string PHN_MBL2 { get; set; }
        public string PHN_MBL3 { get; set; }
        public string PHN_MBL4 { get; set; }
        public string PHN_MBL5 { get; set; }
        public string PHN_OFF1 { get; set; }
        public string PHN_OFF2 { get; set; }
        public string PHN_OFF3 { get; set; }
        public string PHN_OFF4 { get; set; }
        public string PHN_OFF5 { get; set; }
        public string FAX1 { get; set; }
        public string FAX2 { get; set; }
        public string FAX3 { get; set; }
        public string FAX4 { get; set; }
        public string FAX5 { get; set; }
        public string MAIL1 { get; set; }
        public string MAIL2 { get; set; }
        public string MAIL3 { get; set; }
        public string MAIL4 { get; set; }
        public string MAIL5 { get; set; }
        public string WEBSITE1 { get; set; }
        public string WEBSITE2 { get; set; }
        public string WEBSITE3 { get; set; }
        public string WEBSITE4 { get; set; }
        public string WEBSITE5 { get; set; }
        public string CP1_NM { get; set; }
        public string CP1_PHN_HMO { get; set; }
        public string CP1_PHN_MBL { get; set; }
        public string CP1_MAIL { get; set; }
        public string CP1_WEBSITE { get; set; }
        public string CP2_NM { get; set; }
        public string CP2_PHN_HMO { get; set; }
        public string CP2_PHN_MBL { get; set; }
        public string CP2_MAIL { get; set; }
        public string CP2_WEBSITE { get; set; }
        public string RMK { get; set; }
        public string NOTES { get; set; }
        public string ADD_RMK1 { get; set; }
        public string ADD_RMK2 { get; set; }
        public string ADD_RMK3 { get; set; }
        public string ADD_RMK4 { get; set; }
        public string ADD_RMK5 { get; set; }
        public string ADD_FLD1 { get; set; }
        public string ADD_FLD2 { get; set; }
        public string ADD_FLD3 { get; set; }
        public string ADD_FLD4 { get; set; }
        public string ADD_FLD5 { get; set; }
        public string BIZ_ACT { get; set; }
        public string RES_STS { get; set; }
        public DateTime? RES_STS_STARTDT { get; set; }
        public DateTime? RES_STS_ENDDT { get; set; }
        public string IMG_SRC { get; set; }
    } //End public class EmployeeHasnousr_info
} //End namespace APPBASE.Models
