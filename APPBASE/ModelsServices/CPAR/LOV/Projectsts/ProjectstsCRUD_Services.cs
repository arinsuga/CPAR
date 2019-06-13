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
    public class ProjectstsCRUD
    {
        //Constructor
        public ProjectstsCRUD() { } //End public ProjectstsCRUD()
        public void Create(Projectsts_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    Projectsts oModel = new Projectsts();
                    //Map Form Data
                    Mapper.CreateMap<Projectsts_DetailVM, Projectsts>();
                    oModel = Mapper.Map<Projectsts_DetailVM, Projectsts>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_CREATE;
                    //Process CRUD
                    db.Projectstss.Add(oModel);
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create
        public void Update(Projectsts_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    Projectsts oModel = db.Projectstss.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    Mapper.CreateMap<Projectsts_DetailVM, Projectsts>();
                    oModel = Mapper.Map<Projectsts_DetailVM, Projectsts>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_UPDATE;
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
                    Projectsts oModel = db.Projectstss.Find(id);
                    db.Projectstss.Remove(oModel);
                    db.SaveChanges();

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Delete
    } //End public class ProjectstsCRUD
} //End namespace APPBASE.Models

