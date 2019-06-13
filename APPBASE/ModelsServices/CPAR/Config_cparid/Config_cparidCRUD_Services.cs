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
    public class Config_cparidCRUD
    {
        public Config_cparid oModel;

        //Constructor
        public Config_cparidCRUD() { } //End public Config_cparidCRUD()
        public void Create(Config_cparid_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    Config_cparid oModel = new Config_cparid();
                    //Map Form Data
                    Mapper.CreateMap<Config_cparid_DetailVM, Config_cparid>();
                    oModel = Mapper.Map<Config_cparid_DetailVM, Config_cparid>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Process CRUD
                    db.Config_cparids.Add(oModel);
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create
        public void Update(Config_cparid_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    Config_cparid oModel = db.Config_cparids.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    Mapper.CreateMap<Config_cparid_DetailVM, Config_cparid>();
                    oModel = Mapper.Map<Config_cparid_DetailVM, Config_cparid>(poViewModel);
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
                    Config_cparid oModel = db.Config_cparids.Find(id);
                    db.Config_cparids.Remove(oModel);
                    db.SaveChanges();

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Delete

        public void Create_prepare(Config_cparid_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    Config_cparid oModel = new Config_cparid();
                    //Map Form Data
                    Mapper.CreateMap<Config_cparid_DetailVM, Config_cparid>();
                    oModel = Mapper.Map<Config_cparid_DetailVM, Config_cparid>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    this.oModel = oModel;
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create_prepare(Config_cparid_DetailVM poViewModel)
        public void Update_prepare(Config_cparid_DetailVM poViewModel)
        {
            string vsMsgErr = "";

            try
            {
                using (var db = new DBMAINContext())
                {
                    Config_cparid oModel = db.Config_cparids.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    Mapper.CreateMap<Config_cparid_DetailVM, Config_cparid>();
                    oModel = Mapper.Map<Config_cparid_DetailVM, Config_cparid>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    this.oModel = oModel;
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public Config_cparid Update_prepare(Config_cparid_DetailVM poViewModel)
    } //End public class Config_cparidCRUD
} //End namespace APPBASE.Models

