using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using APPBASE.Filters;
using APPBASE.Models;
using APPBASE.Helpers;

namespace APPBASE.Controllers
{
    public partial class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Login(UserloginVM model, string returnUrl)
        {
            if ((ModelState.IsValid) && (hlpCredentialInfo.isValidDBLogin(model.USR_ID, model.USR_PSWD, hlpConfig.ConstantaInfo.MDLE_RUID)))
            {
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Login salah user atau password.");
            return View(model);
        }
        [HttpPost]
        [MyActionFilterAttribute]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    //WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    //WebSecurity.Login(model.UserName, model.Password);
                    //return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    //ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    } //End public partial class AccountController : Controller
} //End namespace APPBASE.Controllers
