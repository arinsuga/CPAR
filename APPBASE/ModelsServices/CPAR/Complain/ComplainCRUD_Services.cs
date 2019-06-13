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
    public class ComplainCRUD
    {
        public string RUID { get; set; }

        //Constructor
        public ComplainCRUD() { } //End public ComplainCRUD()
        public void Create(Complain_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    Complain oModel = new Complain();
                    //Map Form Data
                    Mapper.CreateMap<Complain_DetailVM, Complain>();
                    oModel = Mapper.Map<Complain_DetailVM, Complain>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_CREATE;
                    //Set CPAR_STS
                    oModel.COMPLAIN_STS = valFLAG.FLAG_CPAR_STS_OPEN;
                    //Set field
                    oModel.setFIELD(valFLAG.FLAG_CRUDOPT_CREATE);

                    //Set outo create CPAR
                    if (oModel.IS_CPAR == valFLAG.FLAG_YES)
                    {
                        EmployeeDS oDSEmployee = new EmployeeDS();
                        CPARCRUD oCRUD_cpar = new CPARCRUD();
                        oCRUD_cpar.setCPAR_TYPE(valFLAG.FLAG_CPAR_TYPE_CC);
                        //oCRUD_cpar.Create_prepare();

                        oCRUD_cpar.oModel.AUDITOR_RUID = null;
                        oCRUD_cpar.oModel.AUDITORDEPT_RUID = null;
                        oCRUD_cpar.oModel.AUDITEE_RUID = poViewModel.PIC_RUID;
                        oCRUD_cpar.oModel.AUDITEEDEPT_RUID = oDSEmployee.getData_deptruid(oCRUD_cpar.oModel.AUDITEE_RUID);
                        oCRUD_cpar.oModel.CPAR_DT = poViewModel.ISSUED_DT;
                        oCRUD_cpar.oModel.CPAR_TRGT_DT = poViewModel.TARGET_DT;
                        oCRUD_cpar.oModel.CPAR_DESC = poViewModel.DESCRIPTION;
                        oCRUD_cpar.oModel.CPAR_RESOLUTION2 = poViewModel.SOLUTION;
                        oCRUD_cpar.oModel.COMPLAIN_RUID = oModel.RUID;
                        oCRUD_cpar.Create_prepare();

                        //Update model CPAR
                        db.CPARs.Add(oCRUD_cpar.oModel);
                        //Update model config
                        //db.Entry(oCRUD_cpar.oCRUDConfig_cparid.oModel).State = EntityState.Modified;
                        if (oCRUD_cpar.oModel.isNEW_CONFIG)
                        {
                            db.Config_cparids.Add(oCRUD_cpar.oCRUDConfig_cparid.oModel);
                        } //End if (oModel.isNEW_CONFIG)
                        if (!oCRUD_cpar.oModel.isNEW_CONFIG)
                        {
                            db.Entry(oCRUD_cpar.oCRUDConfig_cparid.oModel).State = EntityState.Modified;
                        } //End if (!oModel.isNEW_CONFIG)
                    } //End if (this.IS_CPAR == valFLAG.FLAG_YES)

                    //Update model Complain
                    db.Complains.Add(oModel);
                    //Process CRUD
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create
        public void Update(Complain_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    Complain oModel = db.Complains.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    poViewModel.COMPLAIN_STS = oModel.COMPLAIN_STS;
                    poViewModel.IS_CPAR = oModel.IS_CPAR;
                    //Map Form Data
                    Mapper.CreateMap<Complain_DetailVM, Complain>();
                    oModel = Mapper.Map<Complain_DetailVM, Complain>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_CREATE;
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
                    Complain oModel = db.Complains.Find(id);
                    db.Complains.Remove(oModel);
                    db.SaveChanges();

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Delete

        public void Close(Complain_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    Complain oModel = db.Complains.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    //Mapper.CreateMap<CPAR_DetailVM, CPAR>();
                    //oModel = Mapper.Map<CPAR_DetailVM, CPAR>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_UPDATE;
                    //Set FIELD
                    oModel.setFIELD_close();
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                    this.RUID = oModel.RUID;
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Close(Complain_DetailVM poViewModel)
        public void Cancel(Complain_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    Complain oModel = db.Complains.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    //Mapper.CreateMap<CPAR_DetailVM, CPAR>();
                    //oModel = Mapper.Map<CPAR_DetailVM, CPAR>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_UPDATE;
                    //Set FIELD
                    oModel.setFIELD_cancel();
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                    this.RUID = oModel.RUID;
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Cancel(Complain_DetailVM poViewModel)
    } //End public class ComplainCRUD
} //End namespace APPBASE.Models

