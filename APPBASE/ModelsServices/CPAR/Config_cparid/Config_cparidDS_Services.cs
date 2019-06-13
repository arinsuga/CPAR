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
    public class Config_cparidDS
    {
        //Constructor
        public Config_cparidDS() { } //End public Config_cparidDS
        public List<Config_cparid_ListVM> getDatalist()
        {
            List<Config_cparid_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Config_cparids
                           select new Config_cparid_ListVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPARID_COUNTER = tb.CPARID_COUNTER,
                               CPARID_YEAR = tb.CPARID_YEAR,
                               CPARID_MONTH = tb.CPARID_MONTH,
                               CPARID_LAST = tb.CPARID_LAST,
                               CPARID_IA = tb.CPARID_IA,
                               CPARID_TM = tb.CPARID_TM,
                               CPARID_PP = tb.CPARID_PP,
                               CPARID_PI = tb.CPARID_PI,
                               CPARID_CC = tb.CPARID_CC,
                               CPARID_LL = tb.CPARID_LL
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Config_cparid_ListVM> getDatalist()
        public Config_cparid_DetailVM getData()
        {
            Config_cparid_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Config_cparids
                           select new Config_cparid_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPARID_COUNTER = tb.CPARID_COUNTER,
                               CPARID_YEAR = tb.CPARID_YEAR,
                               CPARID_MONTH = tb.CPARID_MONTH,
                               CPARID_LAST = tb.CPARID_LAST,
                               CPARID_IA = tb.CPARID_IA,
                               CPARID_TM = tb.CPARID_TM,
                               CPARID_PP = tb.CPARID_PP,
                               CPARID_PI = tb.CPARID_PI,
                               CPARID_CC = tb.CPARID_CC,
                               CPARID_LL = tb.CPARID_LL
                           };
                oReturn = oQRY.First();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Config_cparid_DetailVM getData(string id = null)
        public Config_cparid_DetailVM getData(int? id, int? id2)
        {
            Config_cparid_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Config_cparids
                           where tb.CPARID_YEAR == id && tb.CPARID_MONTH == id2
                           select new Config_cparid_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPARID_COUNTER = tb.CPARID_COUNTER,
                               CPARID_YEAR = tb.CPARID_YEAR,
                               CPARID_MONTH = tb.CPARID_MONTH,
                               CPARID_LAST = tb.CPARID_LAST,
                               CPARID_IA = tb.CPARID_IA,
                               CPARID_TM = tb.CPARID_TM,
                               CPARID_PP = tb.CPARID_PP,
                               CPARID_PI = tb.CPARID_PI,
                               CPARID_CC = tb.CPARID_CC,
                               CPARID_LL = tb.CPARID_LL
                           };
                oReturn = oQRY.FirstOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Config_cparid_DetailVM getData(string id = null)
    } //End public class Config_cparidDS
} //End namespace APPBASE.Models

