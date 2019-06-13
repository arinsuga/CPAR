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
    public class CPARChatDS
    {
        //Constructor
        public CPARChatDS() { } //End public CPARChatDS
        public List<CPARChat_ListVM> getDatalist()
        {
            List<CPARChat_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARChat_infos
                           select new CPARChat_ListVM
                           {
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPAR_RUID = tb.CPAR_RUID,
                               CPAR_ID = tb.CPAR_ID,
                               CPAR_DT = tb.CPAR_DT,
                               CPAR_DESC = tb.CPAR_DESC,
                               USR_RUID = tb.USR_RUID,
                               USR_ID = tb.USR_ID,
                               USR_NM1 = tb.USR_NM1,
                               ROLE_RUID = tb.ROLE_RUID,
                               ROLE_ID = tb.ROLE_ID,
                               ROLE_NM = tb.ROLE_NM,
                               RES_RUID = tb.RES_RUID,
                               RES_ID = tb.RES_ID,
                               RES_NM1 = tb.RES_NM1,
                               IMG_SRC = tb.IMG_SRC,
                               CHAT_DESC_PLAIN = tb.CHAT_DESC_PLAIN,
                               CHAT_DESC_FMT = tb.CHAT_DESC_FMT
                           };
                vReturn = oQRY.OrderByDescending(fld=>fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPARChat_ListVM> getDatalist()
        public List<CPARChat_ListVM> getDatalist_details(string id = null)
        {
            List<CPARChat_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARChat_infos
                           where tb.CPAR_RUID == id
                           select new CPARChat_ListVM
                           {
                               ADTRL_DT = tb.ADTRL_DT,
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               USR_RUID = tb.USR_RUID,
                               USR_ID = tb.USR_ID,
                               USR_NM1 = tb.USR_NM1,
                               ROLE_RUID = tb.ROLE_RUID,
                               ROLE_ID = tb.ROLE_ID,
                               ROLE_NM = tb.ROLE_NM,
                               RES_RUID = tb.RES_RUID,
                               RES_ID = tb.RES_ID,
                               RES_NM1 = tb.RES_NM1,
                               IMG_SRC = tb.IMG_SRC,
                               CHAT_DESC_PLAIN = tb.CHAT_DESC_PLAIN,
                               CHAT_DESC_FMT = tb.CHAT_DESC_FMT
                           };
                vReturn = oQRY.OrderByDescending(fld => fld.RSEQNO).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPARChat_ListVM> getDatalist()

        public CPARChat_DetailVM getData(string id = null)
        {
            CPARChat_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARChat_infos
                           where tb.RUID == id
                           select new CPARChat_DetailVM
                           {
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public CPARChat_DetailVM getData(string id = null)
        public CPARChat_DetailVM getData_details(string id = null)
        {
            CPARChat_DetailVM oReturn = new CPARChat_DetailVM();
            oReturn.CPARCHAT = getDatalist_details(id);
            return oReturn;
        } //End public CPARChat_DetailVM getData(string id = null)

        public int getData_countbyCPAR(string id = null)
        {
            int vReturn = 0;
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARChat_infos
                           where tb.CPAR_RUID == id
                           select new { RSEQNO = tb.RSEQNO };
                vReturn = oQRY.ToList().Count;
            } //End using (var = new DbContext())
            return vReturn;
        } //End public int getData_countbyCPAR(string id = null)
    } //End public class CPARChatDS
} //End namespace APPBASE.Models

