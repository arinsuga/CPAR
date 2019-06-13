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
    public class StandardreffDS
    {
        //Constructor
        public StandardreffDS() { } //End public StandardreffDS()
        public List<Standardreff_ListVM> getDatalist()
        {
            List<Standardreff_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Standardreff_infos
                           select new Standardreff_ListVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Standardreff_ListVM> getDatalist()
        public List<Standardreff_LookupVM> getDatalist_lookup(List<string> id=null)
        {
            List<Standardreff_LookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Standardreff_infos
                           select new Standardreff_LookupVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM
                           };
                if (id != null) {
                    oQRY = oQRY.Where(fld=> id.Contains(fld.RUID));
                } //End if (id != null)


                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Standardreff_LookupVM> getDatalist_lookup()
        public List<Standardreff_LookupVM> getDatalist_lookupNotin(List<string> id = null)
        {
            List<Standardreff_LookupVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Standardreff_infos
                           select new Standardreff_LookupVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM
                           };
                if (id != null)
                {
                    oQRY = oQRY.Where(fld => !id.Contains(fld.RUID));
                } //End if (id != null)


                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Standardreff_LookupVM> getDatalist_lookup()

        public List<Standardreff_LookupVM> getDatalist_lookupadditems(List<string> id = null)
        {
            List<Standardreff_LookupVM> vReturn=new List<Standardreff_LookupVM>();

            if (id != null) {
                using (var db = new DBMAINContext())
                {
                    var oQRY = from tb in db.Standardreff_infos
                               select new Standardreff_LookupVM
                               {
                                   RUID = tb.RUID,
                                   DTA_STS = tb.DTA_STS,
                                   LOV_ID = tb.LOV_ID,
                                   LOV_NM = tb.LOV_NM
                               };
                    oQRY = oQRY.Where(fld => id.Contains(fld.RUID));
                    vReturn = oQRY.ToList();
                } //End using (var = new DbContext())
            } //End if (id != null)
            return vReturn;
        } //End public List<Standardreff_LookupVM> getDatalist_lookup()
        public List<Standardreff_LookupVM> getDatalist_lookupadditemsNotin(List<string> id = null)
        {
            List<Standardreff_LookupVM> vReturn = new List<Standardreff_LookupVM>();

            if (id != null) {
                using (var db = new DBMAINContext())
                {
                    var oQRY = from tb in db.Standardreff_infos
                               select new Standardreff_LookupVM
                               {
                                   RUID = tb.RUID,
                                   DTA_STS = tb.DTA_STS,
                                   LOV_ID = tb.LOV_ID,
                                   LOV_NM = tb.LOV_NM
                               };
                    oQRY = oQRY.Where(fld => !id.Contains(fld.RUID));
                    vReturn = oQRY.ToList();
                } //End using (var = new DbContext())
            } //End if (id != null)
            return vReturn;
        } //End public List<Standardreff_LookupVM> getDatalist_lookup()

        public Standardreff_DetailVM getData(string id = null)
        {
            Standardreff_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Standardreff_infos
                           where tb.RUID == id
                           select new Standardreff_DetailVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM,
                               ISUSEDBY_CPAR = tb.ISUSEDBY_CPAR
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Standardreff_DetailVM getData(string id = null)

        //Check Exists
        public Boolean isExists_LOV_ID(string id = null)
        {
            Boolean vReturn = false;


            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Standardreff_infos
                            where tb.LOV_ID == id
                            select new { LOV_ID = tb.LOV_ID }).ToList();
                if (oQRY.Count > 0) { vReturn = true; }
            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isExists_LOV_ID(string id = null)
        //Check Is Used by CPAR
        public Boolean isUSEDBY_CPAR(string id = null)
        {
            Boolean vReturn = false;

            using (var db = new DBMAINContext())
            {
                var oQRY = (from tb in db.Standardreff_infos
                            where tb.RUID == id
                            select new { ISUSEDBY_CPAR = tb.ISUSEDBY_CPAR }).SingleOrDefault();
                if (oQRY.ISUSEDBY_CPAR == valFLAG.FLAG_YES) { vReturn = true; } //End if (oQRY.ISUSEDBY_CPAR == valFLAG.FLAG_YES)
            } //End using (var = new DbContext())
            return vReturn;
        } //End public Boolean isUSEDBY_CPAR(string id = null)
    } //End public class StandardreffDS
} //End namespace APPBASE.Models

