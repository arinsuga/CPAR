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
    public partial class CPARImproveController : CPARController
    {
        public CPARImproveController()
        {
            CPAR_TYPE = valFLAG.FLAG_CPAR_TYPE_PI;
            ViewBag.Subtitle = "Program Improvement";
        } //End public CPARImproveController()
    } //End public partial class CPARImproveController : Controller
} //End namespace APPBASE.Controllers

