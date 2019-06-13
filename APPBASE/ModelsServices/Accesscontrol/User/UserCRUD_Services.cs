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
    public partial class UserCRUD
    {
        //Constructor
        public UserCRUD() { } //End public UserCRUD()
        public void Create(User_DetailVM poViewModel) {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    User oModel = new User();
                    //Map Form Data
                    Mapper.CreateMap<User_DetailVM, User>();
                    oModel = Mapper.Map<User_DetailVM, User>(poViewModel);
                    //Set Field Header
                    oModel.setFIELD_HEADER(hlpFlags_CRUDOption.CREATE);
                    //Encrypt password
                    oModel.USR_PSWD = hlpObf.randomEncrypt(oModel.USR_PSWD);
                    //Process CRUD
                    db.Users.Add(oModel);
                    db.SaveChanges();
                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Create
        public void Update(User_DetailVM poViewModel)
        {
            string vsMsgErr = "";
            try
            {
                using (var db = new DBMAINContext())
                {
                    User oModel = db.Users.AsNoTracking().SingleOrDefault(fld => fld.RUID == poViewModel.RUID);
                    //Map Form Data
                    Mapper.CreateMap<User_DetailVM, User>();
                    oModel = Mapper.Map<User_DetailVM, User>(poViewModel);
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
                    User oModel = db.Users.Find(id);
                    db.Users.Remove(oModel);
                    db.SaveChanges();

                } //End using
            } //End try
            catch (Exception e) { vsMsgErr = e.Message; } //End catch
        } //End public void Delete
        public void Activate(string id)
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
        } //End public void Activate
        public void Deactivate(string id)
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
        } //End public void Deactivate

        public void Create_Usermenu(Userrole_DetailVM poViewModel, string psMDLE_RUID)
        {
            string vsMsgErr = "";

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
        } //End public void Create
    } //End public partial class UserCRUD
} //End namespace APPBASE.Models