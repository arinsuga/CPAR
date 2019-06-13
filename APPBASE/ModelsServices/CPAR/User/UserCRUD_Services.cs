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
    public partial class UserCRUD
    {
        public string RUID { get; set; }

        public void CreateCPAR(User_DetailCPARVM poViewModel, HttpPostedFileBase poFileimage)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    #region User Area
                        User oModel = new User();
                        //Map Form Data
                        //Mapper.CreateMap<User_DetailCPARVM, User>();
                        //oModel = Mapper.Map<User_DetailCPARVM, User>(poViewModel);
                        //Set Field Header
                        oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                        //Set DTA_STS
                        oModel.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.CREATE);
                        //Set BP_STS (Active)
                        oModel.setActivate();
                        //Set model from Viewmodel
                        oModel.USR_ID = poViewModel.USR_ID;
                        oModel.USR_NM1 = poViewModel.USR_NM1;
                        //Encrypt password
                        oModel.USR_PSWD = hlpObf.randomEncrypt(poViewModel.USR_PSWD);
                    #endregion

                    #region Employee Area
                        Employee oModelEmployee = new Employee();
                        //Set Field Header
                        oModelEmployee.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                        //Set DTA_STS
                        oModelEmployee.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.CREATE);
                        //Set RES_TYPE
                        oModelEmployee.setRES_TYPE();
                        //Set BP_STS
                        oModelEmployee.setActivate();
                        //Set model from Viewmodel
                        oModelEmployee.RES_NM1 = poViewModel.USR_NM1;
                        oModelEmployee.DEPT_RUID = poViewModel.DEPT_RUID;
                        //Set Image file name
                        if (poFileimage != null)
                        {
                            oModelEmployee.IMG_SRC = Utility_FileUploadDownload.setImage(oModelEmployee.RUID);
                            Utility_FileUploadDownload.saveImage_Employee(poFileimage, oModelEmployee.IMG_SRC);
                        } //End if (poFileimage != null)
                    #endregion

                    //Set RES_RUID in User Table
                    oModel.RES_RUID = oModelEmployee.RUID;
                    //Process CRUD
                    db.Users.Add(oModel);
                    db.Employees.Add(oModelEmployee);
                    //Save to Database
                    db.SaveChanges();
                    this.RUID = oModel.RUID;
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void CreateCPAR(User_DetailCPARVM poViewModel, HttpPostedFileBase poFileimage)
        public void UpdateCPAR(User_DetailCPARVM poViewModel, HttpPostedFileBase poFileimage)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    #region User Area
                        User oModel = db.Users.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                        //Set Field Header
                        oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                        //Set DTA_STS
                        oModel.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.UPDATE);
                        //Set BP_STS (Active)
                        oModel.setActivate();
                        //Set model from Viewmodel
                        oModel.USR_NM1 = poViewModel.USR_NM1;
                        oModel.USR_PSWD = hlpObf.randomEncrypt(poViewModel.USR_PSWD);
                    #endregion

                    #region Employee Area
                        Employee oModelEmployee = db.Employees.AsNoTracking().SingleOrDefault(fld => fld.RUID == oModel.RES_RUID);
                        //Set Field Header
                        oModelEmployee.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                        //Set DTA_STS
                        oModelEmployee.DTA_STS = oModel.setDTA_STS(hlpFlags_CRUDOption.UPDATE);
                        //Set RES_TYPE
                        oModelEmployee.setRES_TYPE();
                        //Set model from Viewmodel
                        oModelEmployee.RES_NM1 = poViewModel.USR_NM1;
                        oModelEmployee.DEPT_RUID = poViewModel.DEPT_RUID;

                        //Set Image file name
                        if (poFileimage != null)
                        {
                            oModelEmployee.IMG_SRC = Utility_FileUploadDownload.setImage(oModelEmployee.RUID);
                            Utility_FileUploadDownload.saveImage_Employee(poFileimage, oModelEmployee.IMG_SRC);
                        } //End if (poFileimage != null)

                    #endregion

                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.Entry(oModelEmployee).State = EntityState.Modified;
                    //Save to Database
                    db.SaveChanges();
                    this.RUID = oModel.RUID;
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void UpdateCPAR(User_DetailCPARVM poViewModel, HttpPostedFileBase poFileimage)
        public void DeleteCPAR(string id)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    //User Area
                    User oModel = db.Users.Find(id);
                    db.Users.Remove(oModel);
                    //Employee Area
                    Employee oModelEmployee = db.Employees.Find(oModel.RES_RUID);
                    db.Employees.Remove(oModelEmployee);
                    //Save to Database
                    db.SaveChanges();
                    //Delete Photo
                    Utility_FileUploadDownload.deleteImage_Employee(oModel.RES_RUID);
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void DeleteCPAR(string id)
        public void ActivateCPAR(string id)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    User oModel = db.Users.AsNoTracking().SingleOrDefault(fld => fld.RUID == id);
                    oModel.setActivate();
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void ActivateCPAR(string id)
        public void DeactivateCPAR(string id)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    User oModel = db.Users.AsNoTracking().SingleOrDefault(fld => fld.RUID == id);
                    oModel.setDeactivate();
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Process CRUD
                    db.Entry(oModel).State = EntityState.Modified;
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void DeactivateCPAR(string id)

        public void Create_UsermenuCPAR(Userrole_DetailCPARVM poViewModel, string psMDLE_RUID)
        {
            string vsMsgErr = "";
            //TODO: This code is the same with Create_Usermenu. Refactor this function to call that function by mapping vm Userrole_DetailCPARVM to Userrole_DetailVM
            try
            {
                using (var db = new DBMAINContext())
                {
                    ////Map Form Data
                    //List<Userrolemenu_ListVM> oUserrolemenu_ListVM = poViewModel.Userrolemenu_ListVM;
                    //Mapper.CreateMap < List<Userrolemenu_ListVM>, List<Usermenu>>();
                    Mapper.CreateMap<Userrolemenu_ListVM, Usermenu>();
                    List<Usermenu> oModel = Mapper.Map<List<Userrolemenu_ListVM>, List<Usermenu>>(poViewModel.Userrolemenu_ListVM);
                    var oCurrentModel = db.Usermenus.Where(fld => fld.MDLE_RUID == psMDLE_RUID &&
                                        fld.USR_RUID == poViewModel.RUID);
                    //Delete old usermenu
                    foreach (Usermenu item in oCurrentModel) { db.Usermenus.Remove(item); } //End foreach
                    //Add New usermenu
                    foreach (Usermenu item in oModel) {
                        item.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                        item.MDLE_RUID = psMDLE_RUID;
                        item.USR_RUID = poViewModel.RUID;
                        item.IS_GRANTED = hlpGeneral.FlagInfo.getFlagValid();
                        db.Usermenus.Add(item);
                    } //End foreach
                    //Update User (field ROLE_RUID)
                    User oModelUser = db.Users.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Set Field Header
                    oModelUser.setFIELD_HEADER(hlpFlags_CRUDOption.UPDATE);
                    //Set ROLE_RUID
                    oModelUser.ROLE_RUID = poViewModel.ROLE_RUID;
                    //Process CRUD
                    db.Entry(oModelUser).State = EntityState.Modified;
                    
                    //Save Database
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create_UsermenuCPAR(User_DetailCPARVM poViewModel, string psMDLE_RUID)
    } //End public partial class UserCRUD
} //End namespace APPBASE.Models