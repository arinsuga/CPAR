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
    public partial class Complain
    {
        public void setFIELD(string psCRUDOption)
        {
            this.IS_CPAR = valFLAG.FLAG_NO;
            if (this.COMPLAIN_TYPE == valFLAG.FLAG_COMPLAIN_TYPE_DEFECT) { this.IS_CPAR = valFLAG.FLAG_YES; }
            if (this.COMPLAIN_TYPE == valFLAG.FLAG_COMPLAIN_TYPE_SERVICE) { this.IS_CPAR = valFLAG.FLAG_YES; }
            if (this.COMPLAIN_TYPE == valFLAG.FLAG_COMPLAIN_TYPE_COMMUNICATION) { this.IS_CPAR = valFLAG.FLAG_YES; }
            if (psCRUDOption == valFLAG.FLAG_CRUDOPT_CREATE) { this.COMPLAIN_STS = valFLAG.FLAG_COMPLAIN_STS_OPEN; }

        } //End public void setFIELD()
        public void setFIELD_close()
        {
            this.COMPLAIN_STS = valFLAG.FLAG_COMPLAIN_STS_CLOSED;
        } //End public void setFIELD_close()
        public void setFIELD_cancel()
        {
            this.COMPLAIN_STS = valFLAG.FLAG_COMPLAIN_STS_CANCELED;
        } //End public void setFIELD_cancel()
    } //End public partial class Complain
} //End namespace APPBASE.Models