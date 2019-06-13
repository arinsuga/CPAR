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
using APPBASE.Helpers;
using APPBASE.Models;
using APPBASE.Svcbiz;

namespace APPBASE.Models
{
    public partial class CPAR
    {
        public void setFIELD() {

            this.CPAR_STEP = valFLAG.FLAG_CPAR_STEP_CREATED;

            if (this.DTA_STS == valFLAG.FLAG_CRUDOPT_CREATE)
            {
                if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC) {
                    this.CPAR_STEP = valFLAG.FLAG_CPAR_STEP_PRECREATE;
                } //End if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_CC)
            } //End if (this.DTA_STS == valFLAG.FLAG_CRUDOPT_CREATE)

            if (this.DTA_STS == valFLAG.FLAG_CRUDOPT_CREATE)
            {
                this.setCPAR_ID();
            } //End if (this.DTA_STS == valFLAG.FLAG_CRUDOPT_CREATE)
        } //End public void setFIELD()
        public void setFIELD_responsedate(CPAR_DetailVM poViewModel)
        {
            if (poViewModel.CPAR_DT != null)
            {
                int nAdd = 7;
                this.CPAR_RSPNLMT_DT = poViewModel.CPAR_DT.Value.AddDays(nAdd);
            } //End if (poViewModel.CPAR_DT != null)

        } //End public void setFIELD_response()
        public void setFIELD_verifydate(CPAR_DetailVM poViewModel)
        {
            if (poViewModel.CPAR_DT != null)
            {
                int nAdd = 7*22;

                //Internal Audit
                if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA)
                {
                    //1 months - 2 weeks
                    if (poViewModel.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MAJOR) nAdd = 7*2;
                    //3 months - 2 weeks
                    if (poViewModel.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MINOR) nAdd = 7*10;
                } //End if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA)
                //Produk tidak sesuai (3 months - 2 weeks)
                if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) nAdd = 7 * 10;


                this.CPAR_VERLMT_DT = poViewModel.CPAR_DT.Value.AddDays(nAdd);
            } //End if (poViewModel.CPAR_DT != null)

        } //End public void setFIELD_response()

        public void setFIELD_finishdate(CPAR_DetailVM poViewModel)
        {
            if (poViewModel.CPAR_DT != null) {
                int nAdd = 6;

                //Internal Audit
                if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA) {
                    if (poViewModel.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MAJOR) nAdd = 1;
                    if (poViewModel.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MINOR) nAdd = 3;
                } //End if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA)
                //Produk tidak sesuai
                if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) nAdd = 3;
                
                this.CPAR_FINISH_DT = poViewModel.CPAR_DT.Value.AddMonths(nAdd);
            } //End if (poViewModel.CPAR_DT != null)

        } //End public void setFIELD_response()
        public void setFIELD_response(CPAR_VerifyVM poViewModel)
        {
            //this.CPAR_TRGT_DT = poViewModel.CPAR_TRGT_DT;
            //this.CPAR_FINISH_DT = poViewModel.CPAR_FINISH_DT;
            this.CPAR_STEP = valFLAG.FLAG_CPAR_STEP_RESPONDED;
            this.CPAR_RESOLUTION1 = poViewModel.CPAR_RESOLUTION1;
            this.CPAR_RESOLUTION2 = poViewModel.CPAR_RESOLUTION2;
            this.CPAR_RESOLUTION3 = poViewModel.CPAR_RESOLUTION3;
        } //End public void setFIELD_response()
        public void setFIELD_verify(CPAR_VerifyVM poViewModel)
        {
            this.CPAR_STEP = valFLAG.FLAG_CPAR_STEP_VERIFIED;
            this.VFKS1_DT = poViewModel.VFKS1_DT;
            this.VFKS1_DESC = poViewModel.VFKS1_DESC;
            this.VFKS1_PIC = poViewModel.VFKS1_PIC;

            this.VFKS2_DT = poViewModel.VFKS2_DT;
            this.VFKS2_DESC = poViewModel.VFKS2_DESC;
            this.VFKS2_PIC = poViewModel.VFKS2_PIC;
            
            this.VFKS3_DT = poViewModel.VFKS3_DT;
            this.VFKS3_DESC = poViewModel.VFKS3_DESC;
            this.VFKS3_PIC = poViewModel.VFKS3_PIC;
            
            this.VFKS4_DT = poViewModel.VFKS4_DT;
            this.VFKS4_DESC = poViewModel.VFKS4_DESC;
            this.VFKS4_PIC = poViewModel.VFKS4_PIC;
            
            this.VFKS5_DT = poViewModel.VFKS5_DT;
            this.VFKS5_DESC = poViewModel.VFKS5_DESC;
            this.VFKS5_PIC = poViewModel.VFKS5_PIC;
        } //End public void setFIELD_verify()
        public void setFIELD_close()
        {
            this.CPAR_STS = valFLAG.FLAG_CPAR_STS_CLOSED;
        } //End public void setFIELD_close()
        public void setFIELD_cancel()
        {
            this.CPAR_STS = valFLAG.FLAG_CPAR_STS_CANCELED;
        } //End public void setFIELD_cancel()


        public void setFIELD_finishdate()
        {
            if (this.CPAR_DT != null)
            {
                int nAdd = 6;

                //Internal Audit
                if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA)
                {
                    if (this.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MAJOR) nAdd = 1;
                    if (this.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MINOR) nAdd = 3;
                } //End if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA)
                //Produk tidak sesuai
                if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) nAdd = 3;

                this.CPAR_FINISH_DT = this.CPAR_DT.Value.AddMonths(nAdd);
            } //End if (poViewModel.CPAR_DT != null)

        } //End public void setFIELD_finishdate()
        public void setFIELD_responsedate()
        {
            if (this.CPAR_DT != null)
            {
                int nAdd = 7;
                this.CPAR_RSPNLMT_DT = this.CPAR_DT.Value.AddDays(nAdd);
            } //End if (poViewModel.CPAR_DT != null)

        } //End public void setFIELD_responsedate()
        public void setFIELD_verifydate()
        {
            if (this.CPAR_DT != null)
            {
                int nAddmonths = 6;
                int nSubstract = (7 * 2) * -1;

                //Internal Audit
                if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA)
                {
                    //1 months - 2 weeks
                    if (this.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MAJOR) nAddmonths = 1;
                    //3 months - 2 weeks
                    if (this.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MINOR) nAddmonths = 3;
                } //End if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA)
                //Produk tidak sesuai (3 months - 2 weeks)
                if (this.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) nAddmonths = 3;


                this.CPAR_VERLMT_DT = this.CPAR_DT.Value.AddMonths(nAddmonths);
                this.CPAR_VERLMT_DT = this.CPAR_VERLMT_DT.Value.AddDays(nSubstract);
            } //End if (poViewModel.CPAR_DT != null)

        } //End public void setFIELD_verifydate()

        public string getBADGECOLOR_finishdate(CPAR_ListVM poViewModel)
        {
            string vReturn = "badge bg-green";
            int nWeek = 7; //7 days
            int nWeekMultiply = 6; //1/3/6
            
            int nPeriod = 0;
            int nLivePeriod = 0;

            int nGreen = 0;
            int nYellow = 0;
            int nRed = 0;
            DateTime dDatestart = poViewModel.CPAR_DT.Value;
            DateTime dDateend = DateTime.Now;


            if (poViewModel.CPAR_DT != null)
            {
                //Internal Audit
                if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA)
                {
                    if (poViewModel.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MAJOR) { nWeekMultiply = 1; } //End if (poViewModel.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MAJOR)
                    if (poViewModel.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MINOR) { nWeekMultiply = 3; } //End if (poViewModel.CLASS_RUID == valFLAG.FLAG_CPAR_CLASS_MINOR)
                } //End if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_IA)
                //Produk tidak sesuai
                if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP) { nWeekMultiply = 3; } //End if (poViewModel.CPAR_TYPE == valFLAG.FLAG_CPAR_TYPE_PP)

                //Period
                nLivePeriod = (dDateend - dDatestart).Days;
                nPeriod = nWeek * nWeekMultiply;
                //Green
                nGreen = nPeriod * 1;
                //Yellow
                nYellow = nPeriod * 2;
                //Red
                nRed = nPeriod * 3;

                //Set color Green
                if ((nLivePeriod >= 0) && (nLivePeriod <= nGreen)) vReturn = "badge bg-green";
                //Set color Yellow
                if ((nLivePeriod >= nGreen) && (nLivePeriod <= nYellow)) vReturn = "badge bg-yellow";
                //Set color Red
                //if ((nLivePeriod >= nYellow) && (nLivePeriod <= nRed)) vReturn = "badge bg-red";
                if (nLivePeriod > nYellow) vReturn = "badge bg-red";
            } //End if (poViewModel.CPAR_DT != null)

            return vReturn;
        } //End public string getBADGECOLOR_finishdate(CPAR_ListVM poViewModel)

    } //End public partial class CPAR
} //End namespace APPBASE.Models