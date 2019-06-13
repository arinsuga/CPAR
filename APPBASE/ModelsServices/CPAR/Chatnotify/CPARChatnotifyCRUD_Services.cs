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
    public class CPARChatnotifyCRUD
    {
        public CPARChatnotify oModel = new CPARChatnotify();
        private CPARChatnotifyDS oDS_cparchatnotify = new CPARChatnotifyDS();

        //Constructor
        public CPARChatnotifyCRUD() { } //End public CPARChatnotifyCRUD()
        public void Create(CPARChatnotify_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPARChatnotify oModel = new CPARChatnotify();
                    //Map Form Data
                    Mapper.CreateMap<CPARChatnotify_DetailVM, CPARChatnotify>();
                    oModel = Mapper.Map<CPARChatnotify_DetailVM, CPARChatnotify>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_CREATE;
                    //Process CRUD
                    db.CPARChatnotifys.Add(oModel);
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create
        public void Update(CPARChatnotify_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPARChatnotify oModel = db.CPARChatnotifys.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    Mapper.CreateMap<CPARChatnotify_DetailVM, CPARChatnotify>();
                    oModel = Mapper.Map<CPARChatnotify_DetailVM, CPARChatnotify>(poViewModel);
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
                    CPARChatnotify oModel = db.CPARChatnotifys.Find(id);
                    db.CPARChatnotifys.Remove(oModel);
                    db.SaveChanges();

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Delete
        public void Delete_byUSR_RUID(string id)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    var oQRY = oDS_cparchatnotify.getDatalist_fordelte(id);
                    foreach (var item in oQRY)
                    {
                        CPARChatnotify oModel = db.CPARChatnotifys.Find(item.RUID);
                        db.CPARChatnotifys.Remove(oModel);
                    } //End foreach (var item in oQRY)
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Delete_byUSR_RUID(string id)

        public void Create_prepare(CPARChatnotify_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                CPARChatnotify oModel = new CPARChatnotify();
                //Map Form Data
                Mapper.CreateMap<CPARChatnotify_DetailVM, CPARChatnotify>();
                oModel = Mapper.Map<CPARChatnotify_DetailVM, CPARChatnotify>(poViewModel);
                //Set Field Header
                oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                //Set DTA_STS
                oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_CREATE;
                this.oModel = oModel;
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create
    } //End public class CPARChatnotifyCRUD
} //End namespace APPBASE.Models
