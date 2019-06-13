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
    public class SubtypeCRUD
    {
        //Constructor
        public SubtypeCRUD() { } //End public SubtypeCRUD()
        public void Create(Subtype_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    Subtype oModel = new Subtype();
                    //Map Form Data
                    Mapper.CreateMap<Subtype_DetailVM, Subtype>();
                    oModel = Mapper.Map<Subtype_DetailVM, Subtype>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_CREATE;
                    //Process CRUD
                    db.Subtypes.Add(oModel);
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create
        public void Update(Subtype_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                   Subtype oModel = db.Subtypes.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    Mapper.CreateMap<Subtype_DetailVM, Subtype>();
                    oModel = Mapper.Map<Subtype_DetailVM, Subtype>(poViewModel);
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
                    Subtype oModel = db.Subtypes.Find(id);
                    db.Subtypes.Remove(oModel);
                    db.SaveChanges();

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Delete
    } //End public class SubtypeCRUD
} //End namespace APPBASE.Models

