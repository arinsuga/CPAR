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
    public partial class ExportController : Controller
    {
        [HttpPost]
        public ActionResult LogbookCPAR_XLS(FilterCPAR_DetailVM poViewModel) {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_CPAR_INDEX;

            oVAL_filterCPAR = new FilterCPAR_Validation(poViewModel);
            oVAL_filterCPAR.Validate_Export();

            //Add Error if exists
            for (int i = 0; i < oVAL_filterCPAR.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL_filterCPAR.aValidationMSG[i].VAL_ERRID, oVAL_filterCPAR.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid) {
                this.sFileName = "LOGBOOK_CPAR_";
                this.sSheetName = "Logbook CPAR";
                this.nColcount = 18;
                using (var package = new ExcelPackage())
                {
                    //Get Data
                    CPARCPARStdrefDS oDS = new CPARCPARStdrefDS();
                    var oData = oDS.getDatalist_logbookprint(poViewModel);

                    if (oData == null) { ViewBag.Datanotfound = "Data tidak ditemukan"; }
                    if (oData.Count <= 0) { ViewBag.Datanotfound = "Data tidak ditemukan"; }
                    if (ViewBag.Datanotfound != null) { return View(poViewModel); }

                    package.Workbook.Worksheets.Add(sSheetName);
                    ExcelWorksheet ws = package.Workbook.Worksheets[1];
                    ws.Name = sSheetName; //Setting Sheet's name
                    ws.Cells.Style.Font.Size = nFontSize_Default; //Default font size for whole sheet
                    ws.Cells.Style.Font.Name = sFontName_Default; //Default Font name for whole sheet
                    ws.View.ShowGridLines = false;

                    //Render Header Data
                    //Judul
                    ws.Cells[1, 1].Value = "Logbook CPAR"; //Set Title
                    ws.Cells[1, 1, 1, 10].Merge = true; //Merge columns start and end range
                    ws.Cells[1, 1, 1, 10].Style.Font.Bold = true; //Font should be bold
                    ws.Cells[1, 1, 1, 10].Style.Font.Size = nFontSize_Title;
                    ws.Cells[1, 1, 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left; // Aligmnet is center
                    //Periode
                    string sPeriod = "";
                    if ((poViewModel.CPAR_DT1 != null) && (poViewModel.CPAR_DT2 != null)) {
                        sPeriod = "Periode : ";
                        sPeriod = sPeriod + hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(poViewModel.CPAR_DT1)+" s/d ";
                        sPeriod = sPeriod + hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(poViewModel.CPAR_DT2);
                    } //End if ((poViewModel.CPAR_DT1 != null) && (poViewModel.CPAR_DT2 != null))
                    ws.Cells[2, 1].Value = sPeriod; //Set Title
                    ws.Cells[2, 1, 2, 10].Merge = true; //Merge columns start and end range
                    ws.Cells[2, 1, 2, 10].Style.Font.Bold = false; //Font should be bold
                    ws.Cells[2, 1, 2, 10].Style.Font.Size = nFontSize_Default;
                    ws.Cells[2, 1, 2, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left; // Aligmnet is center


                    //Column Header
                    ws.Cells[3, 1].Value = "NO";
                    ws.Cells[3, 2].Value = "KATEGORI";
                    ws.Cells[3, 3].Value = "NOMOR";
                    ws.Cells[3, 4].Value = "MASALAH";
                    ws.Cells[3, 5].Value = "ANALISA PENYEBAB";
                    ws.Cells[3, 6].Value = "TINDAKAN PERBAIKAN";
                    ws.Cells[3, 7].Value = "SUMBER";
                    ws.Cells[3, 8].Value = "REFERENSI";
                    ws.Cells[3, 9].Value = "AUDITOR";
                    ws.Cells[3, 10].Value = "AUDITEE";
                    ws.Cells[3, 11].Value = "TANGGAL TEMUAN";
                    ws.Cells[3, 12].Value = "TANGGAL PENYELESAIAN";
                    ws.Cells[3, 13].Value = "VERIFIKASI KE-1";
                    ws.Cells[3, 14].Value = "VERIFIKASI KE-2";
                    ws.Cells[3, 15].Value = "VERIFIKASI KE-3";
                    ws.Cells[3, 16].Value = "VERIFIKASI KE-4";
                    ws.Cells[3, 17].Value = "VERIFIKASI KE-5";
                    ws.Cells[3, 18].Value = "STATUS";
                    for (int j = 0; j < nColcount; j++)
                    {
                        ws.Cells[3, j + 1].Style.Border.BorderAround(ExcelBorderStyle.Hair);
                        ws.Cells[3, j + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                        ws.Cells[3, j + 1].Style.Font.Bold = true;

                        ws.Cells[3, j + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        ws.Cells[3, j + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(204, 204, 204));
                    } //End for (int j = 0; j < 13; j++)


                    //Render Content Data
                    string sVerify = "";
                    string sStdref = "";
                    int i = 4;
                    int nNo = 1;
                    Boolean isFirst = true;
                    for (int n = 0; n < oData.Count; n++)
                    {
                        for (int j = 0; j < nColcount; j++)
                        {
                            ws.Cells[i, j + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        } //End for (int j = 0; j < 13; j++)
                        ws.Cells[i, 1].Value = nNo;
                        ws.Cells[i, 2].Value = oData[n].CPAR_SUBTYPE_ID;
                        ws.Cells[i, 3].Value = oData[n].CPAR_ID;
                        ws.Cells[i, 4].Value = oData[n].CPAR_DESC;
                        ws.Cells[i, 5].Value = oData[n].CPAR_RESOLUTION1;
                        ws.Cells[i, 6].Value = oData[n].CPAR_RESOLUTION2;
                        ws.Cells[i, 7].Value = oData[n].CPAR_TYPE_NM;
                        ws.Cells[i, 9].Value = oData[n].AUDITOR_NM;
                        ws.Cells[i, 10].Value = oData[n].AUDITEE_NM;
                        ws.Cells[i, 11].Value = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(oData[n].CPAR_DT);
                        ws.Cells[i, 12].Value = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(oData[n].CPAR_FINISH_DT);
                        ws.Cells[i, 18].Value = oData[n].CPAR_STS_NM;

                        sVerify = "";
                        if (oData[n].VFKS1_DT != null)
                        {
                            sVerify = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(oData[n].VFKS1_DT);
                        } //End if (oData[n].VFKS1_DT != null)
                        if (oData[n].VFKS1_DESC != null)
                        {
                            sVerify = sVerify + "\n" + oData[n].VFKS1_DESC;
                        } //End if (oData[n].VFKS1_DT != null)
                        ws.Cells[i, 13].Value = sVerify;

                        sVerify = "";
                        if (oData[n].VFKS2_DT != null)
                        {
                            sVerify = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(oData[n].VFKS2_DT);
                        } //End if (oData[n].VFKS2_DT != null)
                        if (oData[n].VFKS2_DESC != null)
                        {
                            sVerify = sVerify + "\n" + oData[n].VFKS2_DESC;
                        } //End if if (oData[n].VFKS2_DESC != null)
                        ws.Cells[i, 14].Value = sVerify;

                        sVerify = "";
                        if (oData[n].VFKS3_DT != null)
                        {
                            sVerify = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(oData[n].VFKS3_DT);
                        } //End if (oData[n].VFKS3_DT != null)
                        if (oData[n].VFKS3_DESC != null)
                        {
                            sVerify = sVerify + "\n" + oData[n].VFKS3_DESC;
                        } //End if if (oData[n].VFKS3_DESC != null)
                        ws.Cells[i, 15].Value = sVerify;

                        sVerify = "";
                        if (oData[n].VFKS4_DT != null)
                        {
                            sVerify = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(oData[n].VFKS4_DT);
                        } //End if (oData[n].VFKS4_DT != null)
                        if (oData[n].VFKS4_DESC != null)
                        {
                            sVerify = sVerify + "\n" + oData[n].VFKS4_DESC;
                        } //End if if (oData[n].VFKS4_DESC != null)
                        ws.Cells[i, 16].Value = sVerify;

                        sVerify = "";
                        if (oData[n].VFKS5_DT != null)
                        {
                            sVerify = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(oData[n].VFKS5_DT);
                        } //End if (oData[n].VFKS5_DT != null)
                        if (oData[n].VFKS5_DESC != null)
                        {
                            sVerify = sVerify + "\n" + oData[n].VFKS5_DESC;
                        } //End if if (oData[n].VFKS5_DESC != null)
                        ws.Cells[i, 17].Value = sVerify;

                        sStdref = oData[n].STDREFLOV_ID + " - " + oData[n].STDREFLOV_NM;
                        while (true)
                        {
                            if (n + 1 >= oData.Count) { break; } //End if (n + 1 < oData.Count)
                            if (oData[n].RUID != oData[n + 1].RUID) { break; } //End if (oData[n].RUID != oData[n + 1].RUID)
                            n++;
                            //sStdref = sStdref + "\n\r" + oData[n].STDREFLOV_ID + " - " + oData[n].STDREFLOV_NM;
                            sStdref = sStdref + "\n" + oData[n].STDREFLOV_ID + " - " + oData[n].STDREFLOV_NM;
                        } //End while (true)
                        ws.Cells[i, 8].Value = sStdref;

                        i++;
                        nNo++;
                    } //End for (int n = 0; n < oData.Count; n++)
                    ws.Cells[3, 1, i, nColcount].Style.Border.BorderAround(ExcelBorderStyle.Hair);

                    //Create File
                    var oMemoryStream = package.GetAsByteArray();
                    var ofileName = string.Format(sFileName + "{0:yyyyMMdd-HHmmss}.xlsx", DateTime.UtcNow);
                    return base.File(oMemoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ofileName);
                } //End if (ModelState.IsValid)
            } //End using (var package = new ExcelPackage())

            return View(poViewModel);
        }
        [HttpPost]
        public ActionResult LogbookComplain_XLS(FilterComplain_DetailVM poViewModel)
        {
            ViewBag.AC_MENU_RUID = valMENU.CPAR_LOGBOOK_COMPLAIN_INDEX;

            oVAL_filterComplain = new FilterComplain_Validation(poViewModel);
            oVAL_filterComplain.Validate_Export();

            //Add Error if exists
            for (int i = 0; i < oVAL_filterComplain.aValidationMSG.Count; i++)
            {
                ModelState.AddModelError(oVAL_filterComplain.aValidationMSG[i].VAL_ERRID, oVAL_filterComplain.aValidationMSG[i].VAL_ERRMSG);
            } //End for (int i = 0; i < oVAL.aValidationMSG.Count; i++)

            if (ModelState.IsValid)
            {
                this.sFileName = "LOGBOOK_Complain_";
                this.sSheetName = "Logbook Complain";
                this.nColcount = 16;
                using (var package = new ExcelPackage())
                {
                    //Get Data
                    ComplainDS oDS = new ComplainDS();
                    var oData = oDS.getDatalist_logbookprint(poViewModel);

                    if (oData == null) { ViewBag.Datanotfound = "Data tidak ditemukan"; }
                    if (oData.Count <= 0) { ViewBag.Datanotfound = "Data tidak ditemukan"; }
                    if (ViewBag.Datanotfound != null) { return View(poViewModel); }

                    package.Workbook.Worksheets.Add(sSheetName);
                    ExcelWorksheet ws = package.Workbook.Worksheets[1];
                    ws.Name = sSheetName; //Setting Sheet's name
                    ws.Cells.Style.Font.Size = nFontSize_Default; //Default font size for whole sheet
                    ws.Cells.Style.Font.Name = sFontName_Default; //Default Font name for whole sheet
                    ws.View.ShowGridLines = false;

                    //Render Header Data
                    //Judul
                    ws.Cells[1, 1].Value = "Logbook Complain"; //Set Title
                    ws.Cells[1, 1, 1, 10].Merge = true; //Merge columns start and end range
                    ws.Cells[1, 1, 1, 10].Style.Font.Bold = true; //Font should be bold
                    ws.Cells[1, 1, 1, 10].Style.Font.Size = nFontSize_Title;
                    ws.Cells[1, 1, 1, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left; // Aligmnet is center
                    //Periode
                    string sPeriode = "";
                    if ((poViewModel.Complain_DT1 != null) && (poViewModel.Complain_DT2 != null)) {
                        sPeriode = sPeriode + "Periode ";
                        sPeriode = sPeriode + hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(poViewModel.Complain_DT1) + " s/d ";
                        sPeriode = sPeriode + hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(poViewModel.Complain_DT2);
                    } //End if ((poViewModel.Complain_DT1 != null) && (poViewModel.Complain_DT2 != null))
                    ws.Cells[2, 1].Value = sPeriode;
                    ws.Cells[2, 1, 2, 10].Merge = true; //Merge columns start and end range
                    ws.Cells[2, 1, 2, 10].Style.Font.Bold = false; //Font should be bold
                    ws.Cells[2, 1, 2, 10].Style.Font.Size = nFontSize_Default;
                    ws.Cells[2, 1, 2, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left; // Aligmnet is center

                    //Column Header
                    ws.Cells[3, 1].Value = "NO";
                    ws.Cells[3, 2].Value = "NO. PROYEK";
                    ws.Cells[3, 3].Value = "NAMA PROYEK";
                    ws.Cells[3, 4].Value = "STATUS\nPROYEK";
                    ws.Cells[3, 5].Value = "BLN/THN\nPROYEK SELESAI";
                    ws.Cells[3, 6].Value = "TANGGAL\nCOMPLAIN DITERIMA";
                    ws.Cells[3, 7].Value = "PENERIMA\nCOMPLAIN";
                    ws.Cells[3, 8].Value = "PENCATAT\nCOMPLAIN";
                    ws.Cells[3, 9].Value = "JENIS COMPLAIN";
                    ws.Cells[3, 10].Value = "PENJELASAN COMPLAIN";
                    ws.Cells[3, 11].Value = "PIC\nPENANGANAN\nCOMPLAIN";
                    ws.Cells[3, 12].Value = "TANGGAL\nCOMPLAIN\nDI RESPONSE";
                    ws.Cells[3, 13].Value = "ANALISA PENYEBAB";
                    ws.Cells[3, 14].Value = "KOREKSI\n(Short Term Action)";
                    ws.Cells[3, 15].Value = "TARGET\nSELESAI";
                    ws.Cells[3, 16].Value = "STATUS";

                    for (int j = 0; j < nColcount; j++)
                    {
                        ws.Cells[3, j + 1].Style.Border.BorderAround(ExcelBorderStyle.Hair);
                        ws.Cells[3, j + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Aligmnet is center
                        ws.Cells[3, j + 1].Style.Font.Bold = true;

                        ws.Cells[3, j + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        ws.Cells[3, j + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(204, 204, 204));
                    } //End for (int j = 0; j < 13; j++)


                    //Render Content Data
                    int i = 4;
                    int nNo = 1;
                    for (int n = 0; n < oData.Count; n++)
                    {
                        for (int j = 0; j < nColcount; j++)
                        {
                            ws.Cells[i, j + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Top;
                        } //End for (int j = 0; j < 13; j++)
                        ws.Cells[i, 1].Value = nNo;
                        ws.Cells[i, 2].Value = oData[n].PROJ_ID;
                        ws.Cells[i, 3].Value = oData[n].PROJ_NM;
                        ws.Cells[i, 4].Value = oData[n].PROJ_STS_NM;
                        //ws.Cells[i, 5].Value = oData[n]. //BLN/THN\nPROYEK SELESAI
                        ws.Cells[i, 6].Value = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(oData[n].ISSUED_DT);
                        ws.Cells[i, 7].Value = oData[n].RECIPIENT_NM;
                        //ws.Cells[i, 8].Value = oData[n]. //PENCATAT\nCOMPLAIN
                        ws.Cells[i, 9].Value = oData[n].COMPLAIN_TYPE_NM;
                        ws.Cells[i, 10].Value = oData[n].DESCRIPTION;
                        ws.Cells[i, 11].Value = oData[n].PIC_NM;
                        ws.Cells[i, 12].Value = hlpConvertionAndFormating.ConvertDateToStringDateShortFmt(oData[n].RESPONSE_DT);
                        //ws.Cells[i, 13].Value = oData[n]. //ANALISA PENYEBAB
                        ws.Cells[i, 14].Value = oData[n].SOLUTION;
                        //ws.Cells[i, 15].Value = oData[n]. //TARGET\nSELESAI
                        ws.Cells[i, 16].Value = oData[n].COMPLAIN_STS_NM;


                        i++;
                        nNo++;
                    } //End for (int n = 0; n < oData.Count; n++)
                    ws.Cells[3, 1, i, nColcount].Style.Border.BorderAround(ExcelBorderStyle.Hair);

                    //Create File
                    var oMemoryStream = package.GetAsByteArray();
                    var ofileName = string.Format(sFileName + "{0:yyyyMMdd-HHmmss}.xlsx", DateTime.UtcNow);
                    return base.File(oMemoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ofileName);
                } //End if (ModelState.IsValid)
            } //End using (var package = new ExcelPackage())

            return View(poViewModel);
        }
    } //End public partial class CPARController : Controller
} //End namespace APPBASE.Controllers

