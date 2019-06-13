using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APPBASE.Models;
using APPBASE.Helpers;
using APPBASE.Filters;
using APPBASE.Svcapp;
using AutoMapper;

namespace APPBASE.Controllers
{
    public partial class UserController : Controller
    {
        private EmployeeDS oDSEmployee = new EmployeeDS();

        // GET: /User/_Create_showData/5
        public ActionResult _Create_showData(string id = null)
        {
            //return View(Employee_jobattrVM.getData(id));
            return View(oDSEmployee.getData_jobattr(id));

        }
        // GET: /User/_Role_showDatalist/5
        public ActionResult _Rolemenu_showDatalist(string id = null)
        {
            var oData = oDS.getDatalist_Rolemenu(id, hlpConfig.ConstantaInfo.MDLE_RUID, hlpConfig.SessionInfo.getAppUsrRUID());
            return View(oData);
        }
    } //End public partial class UserController : Controller
} //End namespace APPBASE.Controllers