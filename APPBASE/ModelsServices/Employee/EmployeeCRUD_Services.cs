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
using APPBASE.Svcapp;
using APPBASE.Svcbiz;
using AutoMapper;

namespace APPBASE.Models
{
    public class EmployeeCRUD
    {
        public string RUID { get; set; }
        public string IMG_SRC { get; set; }

        //Constructor
        public EmployeeCRUD() { RUID = ""; IMG_SRC = ""; } //End public EmployeeCRUD()
        public void Create(Employee_DetailVM poViewModel, HttpPostedFileBase poFileimage)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    #region Employee
                        Employee oModel = new Employee();
                        //Map Form Data
                        Mapper.CreateMap<Employee_DetailVM, Employee>();
                        oModel = Mapper.Map<Employee_DetailVM, Employee>(poViewModel);
                        //Set Field Header
                        oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                        //Set DTA_STS
                        oModel.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.CREATE);
                        //Set RES_TYPE
                        oModel.setRES_TYPE();
                        //Set BP_STS
                        oModel.setActivate();

                        //Set Image file name
                        if (poFileimage != null) {
                            oModel.IMG_SRC = Utility_FileUploadDownload.setImage(oModel.RUID);
                            Utility_FileUploadDownload.saveImage_Employee(poFileimage, oModel.IMG_SRC);
                        } //End if (poFileimage != null)

                        //Process CRUD
                        db.Employees.Add(oModel);
                        db.SaveChanges();
                    #endregion

                    #region Employee_Address
                        Employee_address oModel_addressKTP = new Employee_address();
                        //Set Field Header
                        oModel_addressKTP.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                        //Set DTA_STS
                        oModel_addressKTP.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.CREATE);
                        //Set Address KTP
                        oModel_addressKTP.DTA_STS = oModel.DTA_STS;
                        //oModel_addressKTP.BP_STS = poViewModel.
                        oModel_addressKTP.RES_RUID = oModel.RUID;
                        oModel_addressKTP.CNTRY_RUID = poViewModel.CNTRY_RUID_IC;
                        oModel_addressKTP.CITY_RUID = poViewModel.CITY_RUID_IC;
                        oModel_addressKTP.ZIP = poViewModel.ZIP_IC;
                        oModel_addressKTP.ADDR_TYP = oModel.setAddressIC();
                        oModel_addressKTP.ADDR1 = poViewModel.ADDR1_IC;
                        oModel_addressKTP.ADDR2 = poViewModel.ADDR2_IC;
                        oModel_addressKTP.ADDR3 = poViewModel.ADDR3_IC;
                        //oModel_addressKTP.ADDR4 = poViewModel.
                        //oModel_addressKTP.ADDR5 = poViewModel.

                        //Set Address DOMISILI
                        Employee_address oModel_addressDOM = new Employee_address();
                        //Set Field Header
                        oModel_addressDOM.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                        //Set DTA_STS
                        oModel_addressDOM.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.CREATE);
                        oModel_addressDOM.DTA_STS = oModel.DTA_STS;
                        //oModel_addressDOM.BP_STS = poViewModel.
                        oModel_addressDOM.RES_RUID = oModel.RUID;
                        oModel_addressDOM.CNTRY_RUID = poViewModel.CNTRY_RUID_DMCL;
                        oModel_addressDOM.CITY_RUID = poViewModel.CITY_RUID_DMCL;
                        oModel_addressDOM.ZIP = poViewModel.ZIP_DMCL;
                        oModel_addressDOM.ADDR_TYP = oModel.setAddressDMCL();
                        oModel_addressDOM.ADDR1 = poViewModel.ADDR1_DMCL;
                        oModel_addressDOM.ADDR2 = poViewModel.ADDR2_DMCL;
                        oModel_addressDOM.ADDR3 = poViewModel.ADDR3_DMCL;
                        //oModel_addressDOM.ADDR4 = poViewModel.
                        //oModel_addressDOM.ADDR5 = poViewModel.

                        //Process CRUD
                        db.Employee_addresss.Add(oModel_addressKTP);
                        db.Employee_addresss.Add(oModel_addressDOM);
                        db.SaveChanges();
                    #endregion

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create
        public void Update(Employee_DetailVM poViewModel, HttpPostedFileBase poFileimage)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    #region Employee
                        Employee oModel = db.Employees.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                        //Map Form Data
                        Mapper.CreateMap<Employee_DetailVM, Employee>();
                        oModel = Mapper.Map<Employee_DetailVM, Employee>(poViewModel);
                        //Set Field Header
                        oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                        //Set DTA_STS
                        oModel.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.UPDATE);
                        //Set RES_TYPE
                        oModel.setRES_TYPE();

                        //Set Image file name
                        if (poFileimage != null)
                        {
                            oModel.IMG_SRC = Utility_FileUploadDownload.setImage(oModel.RUID);
                            Utility_FileUploadDownload.saveImage_Employee(poFileimage, oModel.IMG_SRC);
                        } //End if (poFileimage != null)

                        //Process CRUD
                        db.Entry(oModel).State = EntityState.Modified;
                        db.SaveChanges();
                    #endregion

                    #region Employee_address
                        //Delete old address
                        var oModel_address = db.Employee_addresss.Where(fld => fld.RES_RUID == poViewModel.RUID);
                        foreach (Employee_address item in oModel_address) { db.Employee_addresss.Remove(item); } //End foreach

                        //Set Address DOMISILI
                        Employee_address oModel_addressKTP = new Employee_address();
                        //Set Field Header
                        oModel_addressKTP.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                        //Set DTA_STS
                        oModel_addressKTP.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.CREATE);
                        //Set Address KTP
                        oModel_addressKTP.DTA_STS = oModel.DTA_STS;
                        //oModel_addressKTP.BP_STS = poViewModel.
                        oModel_addressKTP.RES_RUID = oModel.RUID;
                        oModel_addressKTP.CNTRY_RUID = poViewModel.CNTRY_RUID_IC;
                        oModel_addressKTP.CITY_RUID = poViewModel.CITY_RUID_IC;
                        oModel_addressKTP.ZIP = poViewModel.ZIP_IC;
                        oModel_addressKTP.ADDR_TYP = oModel.setAddressIC();
                        oModel_addressKTP.ADDR1 = poViewModel.ADDR1_IC;
                        oModel_addressKTP.ADDR2 = poViewModel.ADDR2_IC;
                        oModel_addressKTP.ADDR3 = poViewModel.ADDR3_IC;
                        //oModel_addressKTP.ADDR4 = poViewModel.
                        //oModel_addressKTP.ADDR5 = poViewModel.

                        //Set Address DOMISILI
                        Employee_address oModel_addressDOM = new Employee_address();
                        //Set Field Header
                        oModel_addressDOM.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                        //Set DTA_STS
                        oModel_addressDOM.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.CREATE);
                        oModel_addressDOM.DTA_STS = oModel.DTA_STS;
                        //oModel_addressDOM.BP_STS = poViewModel.
                        oModel_addressDOM.RES_RUID = oModel.RUID;
                        oModel_addressDOM.CNTRY_RUID = poViewModel.CNTRY_RUID_DMCL;
                        oModel_addressDOM.CITY_RUID = poViewModel.CITY_RUID_DMCL;
                        oModel_addressDOM.ZIP = poViewModel.ZIP_DMCL;
                        oModel_addressDOM.ADDR_TYP = oModel.setAddressDMCL();
                        oModel_addressDOM.ADDR1 = poViewModel.ADDR1_DMCL;
                        oModel_addressDOM.ADDR2 = poViewModel.ADDR2_DMCL;
                        oModel_addressDOM.ADDR3 = poViewModel.ADDR3_DMCL;
                        //oModel_addressDOM.ADDR4 = poViewModel.
                        //oModel_addressDOM.ADDR5 = poViewModel.

                        //Process CRUD
                        db.Employee_addresss.Add(oModel_addressKTP);
                        db.Employee_addresss.Add(oModel_addressDOM);
                        db.SaveChanges();
                    #endregion

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

                    #region Employee
                        Employee oModel = db.Employees.Find(id);
                        db.Employees.Remove(oModel);
                    #endregion

                    #region Employee_address
                        //Delete old address
                        var oModel_address = db.Employee_addresss.Where(fld => fld.RES_RUID == id);
                        foreach (Employee_address item in oModel_address) { db.Employee_addresss.Remove(item); } //End foreach
                    #endregion
                    db.SaveChanges();

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Delete
        public void Career(Employee_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    //Get Current Data by RUID
                    Employee oModel = db.Employees.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set DTA_STS
                    oModel.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.UPDATE);
                    //Set Job info
                    oModel.RES_STS = poViewModel.RES_STS;
                    oModel.DEPT_RUID = poViewModel.DEPT_RUID;
                    oModel.JOB_TITLE_RUID = poViewModel.JOB_TITLE_RUID;
                    oModel.JOIN_DT = poViewModel.JOIN_DT;
                    oModel.JAMSOSTEK_NO = poViewModel.JAMSOSTEK_NO;

                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Update
        public void UpdateQuit(Employee_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    #region Employee
                    Employee oModel = db.Employees.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    Mapper.CreateMap<Employee_DetailVM, Employee>();
                    oModel = Mapper.Map<Employee_DetailVM, Employee>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set DTA_STS
                    oModel.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.UPDATE);
                    //Set RES_TYPE
                    oModel.setRES_TYPE();
                    //Set BP_STS
                    oModel.BP_STS = APPBASE.Svcbiz.valFLAG.FLAG_EMP_BPSTS_QUIT;

                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                    #endregion

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Update
    } //End public class EmployeeCRUD
} //End namespace APPBASE.Models

