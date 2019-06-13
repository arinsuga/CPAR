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
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;

namespace APPBASE.Controllers
{
    [MyActionFilterAttribute]
    public partial class ExportController : Controller
    {
        private FilterCPAR_Validation oVAL_filterCPAR;
        private FilterComplain_Validation oVAL_filterComplain;
        private ClassauditDS oDSLOVClass = new ClassauditDS();
        private CPARstsDS oDSLOVCPARsts = new CPARstsDS();

        //Setting Data
        private string sFileName = "";
        private string sSheetName = "";
        private int nColcount = 1;

        //Title Font and Format
        private string sFontName_Title = "Calibri";
        private int nFontSize_Title = 14;
        //Column Header Font and Format
        private string sFontName_Colheader = "Calibri";
        private int nFontSize_Colheader = 11;
        //Content Font and Format
        private string sFontName_Default = "Calibri";
        private int nFontSize_Default = 11;

        public ActionResult Sample_XLS()
        {
            using (var package = new ExcelPackage())
            {
                package.Workbook.Worksheets.Add("Test");
                ExcelWorksheet ws = package.Workbook.Worksheets[1];
                ws.Name = "Test"; //Setting Sheet's name
                ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
                ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet

                //Merging cells and create a center heading for out table
                ws.Cells[1, 1].Value = "Sample DataTable Export"; // Heading Name
                ws.Cells[1, 1, 1, 10].Merge = true; //Merge columns start and end range
                ws.Cells[1, 1, 1, 10].Style.Font.Bold = true; //Font should be bold
                ws.Cells[1, 1, 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center

                for (var i = 1; i < 11; i++)
                {
                    for (var j = 2; j < 45; j++)
                    {
                        var cell = ws.Cells[j, i];

                        //Setting Value in cell
                        cell.Value = i * (j - 1);
                    }
                }

                var chart = ws.Drawings.AddChart("chart1", eChartType.AreaStacked);
                //Set position and size
                chart.SetPosition(0, 630);
                chart.SetSize(800, 600);

                // Add the data series.
                var series = chart.Series.Add(ws.Cells["A2:A46"], ws.Cells["B2:B46"]);

                var memoryStream = package.GetAsByteArray();
                var fileName = string.Format("MyData-{0:yyyy-MM-dd-HH-mm-ss}.xlsx", DateTime.UtcNow);
                return base.File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }
        public ActionResult LogbookCPAR_XLS()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_CPAR_INDEX;
            FilterCPAR_DetailVM oViewModel = new FilterCPAR_DetailVM();
            ViewBag.CLASS_RUID_LOV = oDSLOVClass.getDatalist();
            ViewBag.CPAR_STS_LOV = oDSLOVCPARsts.getDatalist();
            return View(oViewModel);
        }
        public ActionResult LogbookComplain_XLS()
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_COMPLAIN_INDEX;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    } //End public partial class ExportController : Controller
} //End namespace APPBASE.Controllers

