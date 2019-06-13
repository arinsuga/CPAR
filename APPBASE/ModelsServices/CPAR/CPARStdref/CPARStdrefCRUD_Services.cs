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
    public class CPARStdrefCRUD
    {
        public CPARStdref oModel;

        //Constructor
        public CPARStdrefCRUD() { } //End public CPARStdrefCRUD()
        public void Create(CPARStdref_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPARStdref oModel = new CPARStdref();
                    //Map Form Data
                    Mapper.CreateMap<CPARStdref_DetailVM, CPARStdref>();
                    oModel = Mapper.Map<CPARStdref_DetailVM, CPARStdref>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Process CRUD
                    db.CPARStdrefs.Add(oModel);
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create
        public void Update(CPARStdref_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPARStdref oModel = db.CPARStdrefs.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    Mapper.CreateMap<CPARStdref_DetailVM, CPARStdref>();
                    oModel = Mapper.Map<CPARStdref_DetailVM, CPARStdref>(poViewModel);
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
                    CPARStdref oModel = db.CPARStdrefs.Find(id);
                    db.CPARStdrefs.Remove(oModel);
                    db.SaveChanges();

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Delete


        public void Create_prepare(CPARStdref_DetailVM poViewModel)
        {
            string vsMsgErr = "";

            try
            {
                using (var db = new DBMAINContext())
                {
                    CPARStdref oModel = new CPARStdref();
                    //Map Form Data
                    Mapper.CreateMap<CPARStdref_DetailVM, CPARStdref>();
                    oModel = Mapper.Map<CPARStdref_DetailVM, CPARStdref>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_CREATE;
                    this.oModel = oModel;
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch

        } //End public void Create_prepare(CPARStdref_DetailVM poViewModel)
    } //End public class CPARStdrefCRUD
} //End namespace APPBASE.Models

