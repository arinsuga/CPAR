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
    public partial class CPARComplainController : CPARController
    {
        public CPARComplainController()
        {
            CPAR_TYPE = valFLAG.FLAG_CPAR_TYPE_CC;
            ViewBag.Subtitle = "Customer Complain";
        } //End public CPARComplainController()
    } //End public partial class CPARComplainController : CPARController
} //End namespace APPBASE.Controllers

