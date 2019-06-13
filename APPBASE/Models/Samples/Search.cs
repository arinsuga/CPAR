using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Objects;
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    #region SEARCH_LABEL
        public class lblSEARCH
        {
            public const string SEARCHBY = "Kriteria Pencarian";
            public const string SEARCHVALUE_DEPT = "Departemen";
            public const string SEARCHVALUE_RES = "Karyawan";
            public const string SEARCHVALUE_DT = "Tanggal";
            public const string SEARCHVALUE_PERIOD = "Periode";
        } //End public class lblSEARCH
    #endregion
    #region SEARCH_CBPeriod
        public class lblSEARCH_CBPeriod {
            //Constants
            public const string PERIOD_ALL_ID = "ALL";
            public const string PERIOD_ALL_VALUE = "Pilih Periode";
            public const string PERIOD_EQUAL_ID = "EQUAL";
            public const string PERIOD_EQUAL_VALUE = "Sesuai tanggal";
            public const string PERIOD_6MTHS_ID = "6MTHS";
            public const string PERIOD_6MTHS_VALUE = "6 bulan kedepan";
            public const string PERIOD_3MTHS_ID = "3MTHS";
            public const string PERIOD_3MTHS_VALUE = "3 bulan kedepan";
            public const string PERIOD_1MTH_ID = "1MTHS";
            public const string PERIOD_1MTH_VALUE = "Sebulan kedepan";
        } //End public class lblSEARCH_CBPeriod
        public class SEARCH_CBPeriod {

            //Properties
            public string SEARCHBY { get; set; }
            public string SEARCHVALUE_DEPT { get; set; }
            public string SEARCHVALUE_EMP { get; set; }
            public string SEARCHVALUE_DT { get; set; }
            public string SEARCHVALUE_PERIOD_SELECTED { get; set; }
            public IEnumerable<SelectListItem> SEARCHVALUE_PERIOD { get; set; }

            //Constructor
            public SEARCH_CBPeriod() {
                //TODO : Must implements Dependencies Injection (for testdriven application)
                //TODO : Cari tau cara ambil current datetime dari server database lewat EF
                //TODOWARNING : BUGS bentrok dengan datepicker format jadi salah
                //SEARCHVALUE_DT = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(DateTime.Now);

                //string sd = DateTime.Now.ToString("dd/MM/yyyy");
                var dataitem = new SelectList(new List<SelectListItem>() {
                    new SelectListItem(){Value = lblSEARCH_CBPeriod.PERIOD_ALL_ID, Text=lblSEARCH_CBPeriod.PERIOD_ALL_VALUE},
                    new SelectListItem(){Value = lblSEARCH_CBPeriod.PERIOD_EQUAL_ID, Text=lblSEARCH_CBPeriod.PERIOD_EQUAL_VALUE},
                    new SelectListItem(){Value = lblSEARCH_CBPeriod.PERIOD_6MTHS_ID, Text=lblSEARCH_CBPeriod.PERIOD_6MTHS_VALUE},
                    new SelectListItem(){Value = lblSEARCH_CBPeriod.PERIOD_3MTHS_ID, Text=lblSEARCH_CBPeriod.PERIOD_3MTHS_VALUE},
                    new SelectListItem(){Value = lblSEARCH_CBPeriod.PERIOD_1MTH_ID, Text=lblSEARCH_CBPeriod.PERIOD_1MTH_VALUE}
                }, "Value", "Text");
                SEARCHVALUE_PERIOD = dataitem;
                SEARCHVALUE_PERIOD_SELECTED = lblSEARCH_CBPeriod.PERIOD_ALL_ID;
            }
        } //End public class SEARCH_CBPeriod
    #endregion
    #region SEARCH_EMP
        public class SEARCH_EMP {
            //Properties
            public string SEARCHBY { get; set; }
            public string SEARCHVALUE_DEPT { get; set; }
            public string SEARCHVALUE_EMP { get; set; }
        } //End public class SEARCH_EMP
    #endregion
    #region SEARCH_CBHIST
        public class SEARCH_CBHIST {
            //Properties
            public string SEARCHBY { get; set; }
            [Required]
            public string SEARCHVALUE_CBTYPE { get; set; }
            [Required]
            public string SEARCHVALUE_EMP { get; set; }
        } //End public class SEARCH_CBHIST
    #endregion
    #region SEARCH_USER
        public class SEARCH_USER
        {
            //Properties
            public string SEARCHBY { get; set; }
            public string SEARCHVALUE_DEPT { get; set; }
            public string SEARCHVALUE_EMP { get; set; }
        } //End public class SEARCH_EMP
    #endregion
    #region SEARCH_PJX
        public class SEARCH_PJX
        {
            //Properties
            public string SEARCHVALUE_BIZUNIT { get; set; }
        } //End public class SEARCH_EMP
    #endregion
    #region SEARCH_COMPLAIN
        public class SEARCH_COMPLAIN
        {
            //Properties
            public string SEARCHVALUE_PJX { get; set; }
            public string SEARCHVALUE_ISSCTGRY { get; set; }
        } //End public class SEARCH_EMP
    #endregion


} //End namespace APPBASE.Models
