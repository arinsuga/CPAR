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
    public class CPARCRUD
    {
        public string RUID { get; set; }
        public string CPAR_TYPE { get; set; }
        public CPAR oModel = new CPAR();

        public Config_cparidCRUD oCRUDConfig_cparid;
        private CPARStdrefCRUD oCRUD_Stdref;

        //private Config_cparidDS oDSConfig_cparid;
        private EmployeeDS oDSEmployee;
        private CPARStdrefDS oDSCPARStdref;
        private CPARDS oDSCPAR = new CPARDS();

        //Constructor 1
        public CPARCRUD() { } //End public CPARCRUD()
        public void setCPAR_TYPE(string psCPAR_TYPE)
        {
            this.CPAR_TYPE = psCPAR_TYPE;
            oCRUDConfig_cparid = new Config_cparidCRUD();
            //oDSConfig_cparid = new Config_cparidDS();
            oDSEmployee = new EmployeeDS();
        } //End public void setCPAR_TYPE(string psCPAR_TYPE)
        public void Create(CPAR_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPAR oModel = new CPAR();
                    //Map Form Data
                    Mapper.CreateMap<CPAR_DetailVM, CPAR>();
                    oModel = Mapper.Map<CPAR_DetailVM, CPAR>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_CREATE;
                    //Set CPAR_STS
                    oModel.CPAR_STS = valFLAG.FLAG_CPAR_STS_OPEN;
                    //Set CPAR_TYPE
                    oModel.CPAR_TYPE = this.CPAR_TYPE;
                    //Get Config_cparid
                    //oModel.oVMConfig_cparid = oDSConfig_cparid.getData();
                    //Set FIELD
                    oModel.setFIELD();
                    //Set DEPT_RUID Auditor and Auditee
                    if (oModel.AUDITOR_RUID != null)
                    {
                        oModel.AUDITORDEPT_RUID = oDSEmployee.getData_deptruid(oModel.AUDITOR_RUID);
                    } //End if (AUDITOR_RUID != null)
                    if (oModel.AUDITEE_RUID != null)
                    {
                        oModel.AUDITEEDEPT_RUID = oDSEmployee.getData_deptruid(oModel.AUDITEE_RUID);
                    } //End if (AUDITEE_RUID != null)

                    //Set Config CPAR_ID
                    if (oModel.isNEW_CONFIG)
                    {
                        oCRUDConfig_cparid.Create_prepare(oModel.oVMConfig_cparid);
                        db.Config_cparids.Add(oCRUDConfig_cparid.oModel);
                    } //End if (oModel.isNEW_CONFIG)
                    if (!oModel.isNEW_CONFIG)
                    {
                        oCRUDConfig_cparid.Update_prepare(oModel.oVMConfig_cparid);
                        db.Entry(oCRUDConfig_cparid.oModel).State = EntityState.Modified;
                    } //End if (!oModel.isNEW_CONFIG)

                    //Set CPAR_FINISG_DT base on CPAR_DT
                    //oModel.setFIELD_finishdate(poViewModel);
                    oModel.setFIELD_finishdate();
                    //Set CPAR_RSPNLMT_DT base on CPAR_DT
                    //oModel.setFIELD_responsedate(poViewModel);
                    oModel.setFIELD_responsedate();
                    //Set CPAR_VERLMT_DT base on CPAR_DT
                    //oModel.setFIELD_verifydate(poViewModel);
                    oModel.setFIELD_verifydate();

                    //Process CRUD
                    db.CPARs.Add(oModel);


                    //Set CPAR_stdref
                    oCRUD_Stdref = new CPARStdrefCRUD();
                    if (poViewModel.STDREF_LIST != null)
                    {
                        foreach (var item in poViewModel.STDREF_LIST)
                        {
                            CPARStdref_DetailVM oItem = new CPARStdref_DetailVM();
                            //Map Form Data
                            Mapper.CreateMap<CPARStdref_ListVM, CPARStdref_DetailVM>();
                            oItem = Mapper.Map<CPARStdref_ListVM, CPARStdref_DetailVM>(item);
                            oItem.CPAR_RUID = oModel.RUID;
                            oCRUD_Stdref.Create_prepare(oItem);

                            db.CPARStdrefs.Add(oCRUD_Stdref.oModel);
                        } //End foreach (var item in poViewModel.STDREF_LIST)
                    } //End if (poViewModel.STDREF_LIST != null)

                    //Process CRUD
                    db.SaveChanges();
                    this.RUID = oModel.RUID;
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create
        public void Update(CPAR_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPAR oModel = db.CPARs.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    poViewModel.CPAR_STS = oModel.CPAR_STS;
                    poViewModel.CPAR_TYPE = oModel.CPAR_TYPE;
                    poViewModel.AUDITORDEPT_RUID = oModel.AUDITORDEPT_RUID;
                    poViewModel.AUDITEEDEPT_RUID = oModel.AUDITEEDEPT_RUID;

                    //Reflect data VM
                    if (oModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC) {
                        poViewModel.AUDITEE_RUID = oModel.AUDITEE_RUID;
                        poViewModel.AUDITEEDEPT_RUID = oModel.AUDITEEDEPT_RUID;
                        poViewModel.CPAR_DT = oModel.CPAR_DT;
                        poViewModel.CPAR_TRGT_DT = oModel.CPAR_TRGT_DT;
                        //poViewModel.CPAR_DESC = oModel.CPAR_DESC;
                        poViewModel.CPAR_RESOLUTION2 = oModel.CPAR_RESOLUTION2;
                        poViewModel.COMPLAIN_RUID = oModel.COMPLAIN_RUID;
                    } //End if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC)

                    //Map Form Data
                    Mapper.CreateMap<CPAR_DetailVM, CPAR>();
                    oModel = Mapper.Map<CPAR_DetailVM, CPAR>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_UPDATE;
                    //Set FIELD
                    oModel.setFIELD();

                    //Set CPAR_FINISG_DT base on CPAR_DT
                    //oModel.setFIELD_finishdate(poViewModel);
                    oModel.setFIELD_finishdate();
                    //Set CPAR_RSPNLMT_DT base on CPAR_DT
                    //oModel.setFIELD_responsedate(poViewModel);
                    oModel.setFIELD_responsedate();
                    //Set CPAR_VERLMT_DT base on CPAR_DT
                    //oModel.setFIELD_verifydate(poViewModel);
                    oModel.setFIELD_verifydate();

                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;

                    //Set CPAR_stdref Delete by CPAR RUID
                    oCRUD_Stdref = new CPARStdrefCRUD();
                    oDSCPARStdref = new CPARStdrefDS();
                    var oQRY = oDSCPARStdref.getDatalist_byCPAR_RUID(oModel.RUID);
                    foreach (var item in oQRY)
                    {
                        CPARStdref oItem = db.CPARStdrefs.Find(item.RUID);
                        db.CPARStdrefs.Remove(oItem);
                    } //End foreach (var item in oQRY)
                    
                    //Set CPAR_stdref Add by STDREF_LIST
                    if (poViewModel.STDREF_LIST != null) {
                        foreach (var item in poViewModel.STDREF_LIST)
                        {
                            //LASTWORK
                            CPARStdref_DetailVM oItem = new CPARStdref_DetailVM();
                            //Map Form Data
                            Mapper.CreateMap<CPARStdref_ListVM, CPARStdref_DetailVM>();
                            oItem = Mapper.Map<CPARStdref_ListVM, CPARStdref_DetailVM>(item);
                            oItem.CPAR_RUID = oModel.RUID;
                            oCRUD_Stdref.Create_prepare(oItem);

                            db.CPARStdrefs.Add(oCRUD_Stdref.oModel);
                        } //End foreach (var item in poViewModel.STDREF_LIST)
                    } //End if (poViewModel.STDREF_LIST != null)

                    //Process CRUD
                    db.SaveChanges();
                    this.RUID = oModel.RUID;
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
                    CPAR oModel = db.CPARs.Find(id);
                    db.CPARs.Remove(oModel);

                    //Set CPAR_stdref Delete by CPAR RUID
                    oDSCPARStdref = new CPARStdrefDS();
                    var oQRY = oDSCPARStdref.getDatalist_byCPAR_RUID(id);
                    foreach (var item in oQRY)
                    {
                        CPARStdref oItem = db.CPARStdrefs.Find(item.RUID);
                        db.CPARStdrefs.Remove(oItem);
                    } //End foreach (var item in oQRY)

                    //Process CRUD
                    db.SaveChanges();

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Delete

        public void Create_prepare()
        {
            string vsMsgErr = "";
            try
            {
                CPAR oModel = new CPAR();
                //Manual Mapper
                oModel = this.oModel;

                //Set Field Header
                oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                //Set DTA_STS
                oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_CREATE;
                //Set CPAR_STS
                oModel.CPAR_STS = valFLAG.FLAG_CPAR_STS_OPEN;
                //Set CPAR_TYPE
                oModel.CPAR_TYPE = this.CPAR_TYPE;
                //Set CPAR_DT
                oModel.CPAR_DT = this.oModel.CPAR_DT;
                //Get Config_cparid
                //oModel.oVMConfig_cparid = oDSConfig_cparid.getData();
                //Set FIELD
                oModel.setFIELD();
                
                //Set Config CPAR_ID
                //oCRUDConfig_cparid.Update_prepare(oModel.oVMConfig_cparid);
                if (oModel.isNEW_CONFIG)
                {
                    oCRUDConfig_cparid.Create_prepare(oModel.oVMConfig_cparid);
                } //End if (oModel.isNEW_CONFIG)
                if (!oModel.isNEW_CONFIG)
                {
                    oCRUDConfig_cparid.Update_prepare(oModel.oVMConfig_cparid);
                } //End if (!oModel.isNEW_CONFIG)

                
                this.oModel = oModel;
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create_prepare()

        public void Response(CPAR_VerifyVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPAR oModel = db.CPARs.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    //Mapper.CreateMap<CPAR_DetailVM, CPAR>();
                    //oModel = Mapper.Map<CPAR_DetailVM, CPAR>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_UPDATE;
                    //Set FIELD
                    oModel.setFIELD_response(poViewModel);
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                    this.RUID = oModel.RUID;
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Response(CPAR_VerifyVM poViewModel)
        public void Verify(CPAR_VerifyVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPAR oModel = db.CPARs.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    //Mapper.CreateMap<CPAR_DetailVM, CPAR>();
                    //oModel = Mapper.Map<CPAR_DetailVM, CPAR>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set DTA_STS
                    oModel.DTA_STS = valFLAG.FLAG_CRUDOPT_UPDATE;
                    //Set FIELD
                    oModel.setFIELD_verify(poViewModel);
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                    this.RUID = oModel.RUID;
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Verify(CPAR_VerifyVM poViewModel)
        public void Close(CPAR_VerifyVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPAR oModel = db.CPARs.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
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
        } //End public void Close(CPAR_VerifyVM poViewModel)
        public void Cancel(CPAR_VerifyVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    CPAR oModel = db.CPARs.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
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
        } //End public void Cancel(CPAR_VerifyVM poViewModel)

        //PATCH morefeature#1
        public void patch_morefeature1(CPAR_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    var oData = oDSCPAR.getDatalist();
                    foreach (var item in oData)
                    {
                        CPAR oModel = db.CPARs.AsNoTracking().SingleOrDefault(fld => fld.RUID == item.RUID);
                        //Set CPAR_FINISG_DT base on CPAR_DT
                        if (oModel.CPAR_FINISH_DT == null) {
                            oModel.setFIELD_finishdate();
                        } //End if (oModel.CPAR_FINISH_DT == null)
                        
                        //Set CPAR_RSPNLMT_DT base on CPAR_DT
                        oModel.setFIELD_responsedate();
                        //Set CPAR_VERLMT_DT base on CPAR_DT
                        oModel.setFIELD_verifydate();
                        //Process CRUD
                        db.Entry(oModel).State = EntityState.Modified;
                        //Process CRUD
                        db.SaveChanges();
                    } //End foreach (var item in oData)
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void patch_morefeature1(CPAR_DetailVM poViewModel)
        //PATCH Patchhotfix2
        public void patch_hotfix2()
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {

                    var oData = oDSCPAR.getDatalist_Patchhotfix2();
                    foreach (var item in oData)
                    {
                        CPAR oModel = db.CPARs.AsNoTracking().SingleOrDefault(fld => fld.RUID == item.RUID);
                        //Set CPAR_VERLMT_DT base on CPAR_DT
                        oModel.setFIELD_verifydate();
                        //Process CRUD
                        db.Entry(oModel).State = EntityState.Modified;
                        //Process CRUD
                        db.SaveChanges();
                    } //End foreach (var item in oData)
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void patch_hotfix2()
        //PATCH Patchhotfix3
        public void patch_hotfix3()
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    var oData = oDSCPAR.getDatalist_Patchhotfix3();
                    foreach (var item in oData)
                    {
                        CPAR oModel = db.CPARs.AsNoTracking().SingleOrDefault(fld => fld.RUID == item.RUID);
                        //Set CPAR_VERLMT_DT base on CPAR_DT
                        oModel.setFIELD_verifydate();
                        //Process CRUD
                        db.Entry(oModel).State = EntityState.Modified;
                        //Process CRUD
                        db.SaveChanges();
                    } //End foreach (var item in oData)
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void patch_hotfix3()
    } //End public class CPARCRUD
} //End namespace APPBASE.Models

