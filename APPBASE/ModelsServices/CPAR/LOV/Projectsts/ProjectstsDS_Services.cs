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
    public class ProjectstsDS
    {
        //Constructor
        public ProjectstsDS() { } //End public ProjectstsDS
        public List<Projectsts_ListVM> getDatalist()
        {
            List<Projectsts_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Projectsts_infos
                           select new Projectsts_ListVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM
                           };
                vReturn = oQRY.OrderBy(fld=>fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Projectsts_ListVM> getDatalist()
        public List<Projectsts_ComboboxVM> getDatalist_combobox()
        {
            List<Projectsts_ComboboxVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Projectsts_infos
                           select new Projectsts_ComboboxVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               LOV_NM = tb.LOV_NM
                           };
                vReturn = oQRY.OrderBy(fld => fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<Projectsts_ListVM> getDatalist_lookup()

        public Projectsts_DetailVM getData(string id = null)
        {
            Projectsts_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.Projectsts_infos
                           where tb.RUID == id
                           select new Projectsts_DetailVM
                           {
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               LOV_ID = tb.LOV_ID,
                               LOV_NM = tb.LOV_NM
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public Projectsts_DetailVM getData(string id = null)
    } //End public class ProjectstsDS
} //End namespace APPBASE.Models

