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
    public class CPARChatnotifyDS
    {
        //Constructor
        public CPARChatnotifyDS() { } //End public CPARChatnotifyDS
        public List<CPARChatnotify_ListVM> getDatalist()
        {
            List<CPARChatnotify_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARChatnotify_infos
                           select new CPARChatnotify_ListVM
                           {
                               ADTRL_DT = tb.ADTRL_DT,
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPARCHAT_RUID = tb.CPARCHAT_RUID,
                               USR_RUID = tb.USR_RUID,
                               USR_USRID = tb.USR_USRID,
                               USR_USRNM = tb.USR_USRNM,
                               USR_ROLERUID = tb.USR_ROLERUID,
                               USR_ROLENM = tb.USR_ROLENM,
                               USR_RESNM = tb.USR_RESNM,
                               USR_DEPTNM = tb.USR_DEPTNM,
                               USR_JOBTTLNM = tb.USR_JOBTTLNM,
                               USR_IMG = tb.USR_IMG,
                               CPARCHAT_CPARRUID = tb.CPARCHAT_CPARRUID,
                               CPARCHAT_CPARID = tb.CPARCHAT_CPARID,
                               CPARCHAT_CPARDT = tb.CPARCHAT_CPARDT,
                               CPARCHAT_USRRUID = tb.CPARCHAT_USRRUID,
                               CPARCHAT_USRID = tb.CPARCHAT_USRID,
                               CPARCHAT_USRNM = tb.CPARCHAT_USRNM,
                               CPARCHAT_ROLERUID = tb.CPARCHAT_ROLERUID,
                               CPARCHAT_ROLENM = tb.CPARCHAT_ROLENM,
                               CPARCHAT_RESNM = tb.CPARCHAT_RESNM,
                               CPARCHAT_DEPTNM = tb.CPARCHAT_DEPTNM,
                               CPARCHAT_JOBTTLNM = tb.CPARCHAT_JOBTTLNM,
                               CPARCHAT_IMG = tb.CPARCHAT_IMG,
                               CPARCHAT_DESCPLAIN = tb.CPARCHAT_DESCPLAIN,
                               CPARCHAT_DESCFMT = tb.CPARCHAT_DESCFMT
                           };
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPARChatnotify_ListVM> getDatalist()
        public List<CPARNOTIF_CPARCHATVM> getDatalist_notif(string id = null, string sLimit = null)
        {
            List<CPARNOTIF_CPARCHATVM> vReturn;
            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARNOTIF_CPARCHAT_infos
                           select new CPARNOTIF_CPARCHATVM
                           {
                               //RSEQNO = tb.RSEQNO,
                               //RUID = tb.RUID,
                               CPAR_RUID = tb.CPAR_RUID,
                               CPAR_ID = tb.CPAR_ID,
                               //CPAR_DT = tb.CPAR_DT,
                               USR_RUID = tb.USR_RUID,
                               USR_ID = tb.USR_ID,
                               USR_NM = tb.USR_NM,
                               USR_RESNM = tb.USR_RESNM,
                               COUNT_NOTIF = tb.COUNT_NOTIF
                           };
                if (id != null)
                {
                    if (id != "") { oQRY = oQRY.Where(fld => fld.USR_RUID == id); }
                    //if (psNOTIF_TO == valFLAG.FLAG_NOTIF_CPAR_AUDITEE_DEPT) { oQRY = oQRY.Where(fld => fld.AUDITEEDEPT_RUID == psNOTIF_TORUID); }
                    //if (psNOTIF_TO == valFLAG.FLAG_NOTIF_CPAR_AUDITOR) { oQRY = oQRY.Where(fld => fld.AUDITOR_RUID == psNOTIF_TORUID); }
                } //End if (id != null)
                if (sLimit != null) { if (sLimit != "") { oQRY = oQRY.Take(Convert.ToInt32(sLimit)); } }
                vReturn = oQRY.ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPARNOTIFVM> getDatalist_notif(string id = null)
        public List<CPARChatnotify_ListVM> getDatalist_fordelte(string id = null)
        {
            List<CPARChatnotify_ListVM> vReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARChatnotify_infos
                           select new CPARChatnotify_ListVM
                           {
                               RUID = tb.RUID,
                               USR_RUID = tb.USR_RUID
                           };
                vReturn = oQRY.Where(fld=>fld.USR_RUID==id).ToList();
            } //End using (var = new DbContext())
            return vReturn;
        } //End public List<CPARChatnotify_ListVM> getDatalist_fordelte(string id = null)

        public CPARChatnotify_DetailVM getData(string id = null)
        {
            CPARChatnotify_DetailVM oReturn;


            using (var db = new DBMAINContext())
            {
                var oQRY = from tb in db.CPARChatnotify_infos
                           where tb.RUID == id
                           select new CPARChatnotify_DetailVM
                           {
                               ADTRL_DT = tb.ADTRL_DT,
                               RSEQNO = tb.RSEQNO,
                               RUID = tb.RUID,
                               DTA_STS = tb.DTA_STS,
                               CPARCHAT_RUID = tb.CPARCHAT_RUID,
                               USR_RUID = tb.USR_RUID,
                               USR_USRID = tb.USR_USRID,
                               USR_USRNM = tb.USR_USRNM,
                               USR_ROLERUID = tb.USR_ROLERUID,
                               USR_ROLENM = tb.USR_ROLENM,
                               USR_RESNM = tb.USR_RESNM,
                               USR_DEPTNM = tb.USR_DEPTNM,
                               USR_JOBTTLNM = tb.USR_JOBTTLNM,
                               USR_IMG = tb.USR_IMG,
                               CPARCHAT_CPARRUID = tb.CPARCHAT_CPARRUID,
                               CPARCHAT_CPARID = tb.CPARCHAT_CPARID,
                               CPARCHAT_CPARDT = tb.CPARCHAT_CPARDT,
                               CPARCHAT_USRRUID = tb.CPARCHAT_USRRUID,
                               CPARCHAT_USRID = tb.CPARCHAT_USRID,
                               CPARCHAT_USRNM = tb.CPARCHAT_USRNM,
                               CPARCHAT_ROLERUID = tb.CPARCHAT_ROLERUID,
                               CPARCHAT_ROLENM = tb.CPARCHAT_ROLENM,
                               CPARCHAT_RESNM = tb.CPARCHAT_RESNM,
                               CPARCHAT_DEPTNM = tb.CPARCHAT_DEPTNM,
                               CPARCHAT_JOBTTLNM = tb.CPARCHAT_JOBTTLNM,
                               CPARCHAT_IMG = tb.CPARCHAT_IMG,
                               CPARCHAT_DESCPLAIN = tb.CPARCHAT_DESCPLAIN,
                               CPARCHAT_DESCFMT = tb.CPARCHAT_DESCFMT
                           };
                oReturn = oQRY.SingleOrDefault();
            } //End using (var = new DbContext())
            return oReturn;
        } //End public CPARChatnotify_DetailVM getData(string id = null)

    } //End public class CPARChatnotifyDS
} //End namespace APPBASE.Models
