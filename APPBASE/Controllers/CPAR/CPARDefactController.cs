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
    public partial class CPARDefactController : CPARController
    {
        public CPARDefactController()
        {
            CPAR_TYPE = valFLAG.FLAG_CPAR_TYPE_PP;
            ViewBag.Subtitle = "Pengendalian Produk Tidak Sesuai";
        } //End public CPARDefactController()
    } //End public partial class CPARDefactController : Controller
} //End namespace APPBASE.Controllers

