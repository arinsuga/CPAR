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
//using APPBASE.Svcapp;
using APPBASE.Svcbiz;
using AutoMapper;


namespace APPBASE.Controllers
{
    public partial class CPARReviewController : CPARController
    {
        public CPARReviewController()
        {
            CPAR_TYPE = valFLAG.FLAG_CPAR_TYPE_TM;
            ViewBag.Subtitle = "Tinjauan Manajemen";
        } //End public CPARReviewController()
    } //End public partial class CPARReviewController : Controller
} //End namespace APPBASE.Controllers

