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
using AutoMapper;

namespace APPBASE.Models
{
    public class CPARChatCRUD
    {
        public string RUID { get; set; }

        //Constructor
        public CPARChatCRUD() { } //End public CPARChatCRUD()
        public void Create(CPARChat_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            string sSENDER_ROLERUID = hlpConfig.SessionInfo.getAppRoleRUID();
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPARChat oModel = new CPARChat();
                    //Map Form Data
                    Mapper.CreateMap<CPARChat_DetailVM, CPARChat>();
                    oModel = Mapper.Map<CPARChat_DetailVM, CPARChat>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_CREATE;
                    //Set field
                    oModel.CPAR_RUID = poViewModel.CPAR_RUID;
                    oModel.USR_RUID = oModel.ADTRL_USR;
                    oModel.CHAT_DESC_FMT = oModel.CHAT_DESC_PLAIN;
                    //Add model to save
                    db.CPARChats.Add(oModel);

                    CPARChatnotifyCRUD oCRUD_notify = new CPARChatnotifyCRUD();
                    //Send Notification to AUDITEE
                    if (sSENDER_ROLERUID == valFLAG.FLAG_ROLE_CPAR_ADMIN) {
                        CPARDS oDS_CPAR = new CPARDS();
                        var oQRY_cpar = oDS_CPAR.getData(oModel.CPAR_RUID);
                        CPARChatnotify_DetailVM oVM_notify = new CPARChatnotify_DetailVM();
                        oVM_notify.CPARCHAT_RUID = oModel.RUID;
                        oVM_notify.USR_RUID = oQRY_cpar.AUDITEE_USRRUID;  //oQRY_cpar.AUDITEE_RUID;
                        oCRUD_notify.Create_prepare(oVM_notify);
                        CPARChatnotify oModel_notify = oCRUD_notify.oModel;
                        //Add model to save
                        db.CPARChatnotifys.Add(oModel_notify);
                    } //End if (sSENDER_ROLERUID != valFLAG.FLAG_ROLE_CPAR_ADMIN)

                    //Send Notification to CPAR_ADMIN
                    if (sSENDER_ROLERUID != valFLAG.FLAG_ROLE_CPAR_ADMIN) {
                        UserDS oDS_user = new UserDS();
                        var oQRY_user = oDS_user.getDatalist(valFLAG.FLAG_ROLE_CPAR_ADMIN);
                        foreach (var item in oQRY_user)
                        {
                            CPARChatnotify_DetailVM oVM_notifyX = new CPARChatnotify_DetailVM();
                            oVM_notifyX.CPARCHAT_RUID = oModel.RUID;
                            oVM_notifyX.USR_RUID = item.RUID;
                            oCRUD_notify.Create_prepare(oVM_notifyX);
                            CPARChatnotify oModel_notifyX = oCRUD_notify.oModel;
                            //Add model to save
                            db.CPARChatnotifys.Add(oModel_notifyX);
                        } //End foreach (var item in oQRY_user)
                    } //End if (sSENDER_ROLERUID == valFLAG.FLAG_ROLE_CPAR_ADMIN)

                    
                    //Process CRUD
                    db.SaveChanges();
                    this.RUID = oModel.RUID;
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create
        public void Update(CPARChat_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPARChat oModel = db.CPARChats.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    Mapper.CreateMap<CPARChat_DetailVM, CPARChat>();
                    oModel = Mapper.Map<CPARChat_DetailVM, CPARChat>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Update
        public void Delete(string id)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPARChat oModel = db.CPARChats.Find(id);
                    db.CPARChats.Remove(oModel);
                    db.SaveChanges();

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Delete
    } //End public class CPARChatCRUD
} //End namespace APPBASE.Models

