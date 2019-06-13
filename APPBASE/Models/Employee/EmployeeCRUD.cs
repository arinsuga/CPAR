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
    [Table("MST01RSRC")]
    public partial class Employee : CRUD
    {
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string DEPT_RUID { get; set; }
        public string BRNCH_RUID { get; set; }
        public string CMPNY_RUID { get; set; }
        public string JOB_TITLE_RUID { get; set; }
        public string JOB_TITLE_NM { get; set; }
        public string RELIGION_RUID { get; set; }
        public string RES_TYPE { get; set; }
        public string RES_ID { get; set; }
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
        public string SEX { get; set; }
        public string MRTL_STS { get; set; }
        public string POB { get; set; }
        public DateTime? DOB { get; set; }
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
    } //End public partial class Employee : CRUD
    [Table("MST01RSRC_ADDR")]
    public partial class Employee_address : CRUD
    {
        public string DTA_STS { get; set; }
        public string BP_STS { get; set; }
        public string RES_RUID { get; set; }
        public string CNTRY_RUID { get; set; }
        public string CITY_RUID { get; set; }
        public string ZIP { get; set; }
        public string ADDR_TYP { get; set; }
        public string ADDR1 { get; set; }
        public string ADDR2 { get; set; }
        public string ADDR3 { get; set; }
        public string ADDR4 { get; set; }
        public string ADDR5 { get; set; }
    } //End public partial class Employee_address : CRUD
    [Table("MST01LOV_EMPSTS")]
    public partial class Employeests : CRUD  //TODO: Refactor Empsts to Employeests
    {
        public string DTA_STS { get; set; }
        public int? LOV_SEQ1 { get; set; }
        public int? LOV_SEQ2 { get; set; }
        public string LOV_ID { get; set; }
        public string LOV_NM { get; set; }
    } //End public partial class Employeests : CRUD
} //End namespace APPBASE.Models
