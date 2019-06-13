using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPBASE.Svcbiz
{
    public class valFLAG : Svcapp.valFLAG
    {
        //Employee BP_STS Active/Inactive
        public const string FLAG_EMPBPSTS_ACTIVE = "LOV_HRS_EMP_EXISTS_ACTIVE";
        public const string FLAG_EMPBPSTS_INACTIVE = "LOV_HRS_EMP_EXISTS_QUIT";

        //Employee RES_STS Active/Inactive
        public const string FLAG_EMPSTS_PROB = "LOV_HRS_EMPSTS_PROB";
        public const string FLAG_EMPSTS_CONT = "LOV_HRS_EMPSTS_CONT";
        public const string FLAG_EMPSTS_PRMT = "LOV_HRS_EMPSTS_PRMT";
        public const string FLAG_EMPSTS_INSP = "LOV_HRS_EMPSTS_INSP";
        public const string FLAG_EMPSTS_OUTSRC = "LOV_HRS_EMPSTS_OUTSRC";

        //Action to Employee
        public const string FLAG_EMPACT_CAREER = "HRIS_EMP_CARRER";
        public const string FLAG_EMPACT_QUIT = "HRIS_EMP_QUIT";

        //RES_TYPE
        public const string FLAG_EMP_RESTYPE = "EMP";

        //Employee BP_STS (Status Active / Berhenti)
        public const string FLAG_EMP_BPSTS_ACTIVE = "LOV_HRS_EMP_EXISTS_ACTIVE";
        public const string FLAG_EMP_BPSTS_QUIT = "LOV_HRS_EMP_EXISTS_QUIT";

        //ADDR_TYP
        public const string FLAG_EMP_ADDRTYPE_IC = "IC";
        public const string FLAG_EMP_ADDRTYPE_DMCL = "DMCL";

        //CPAR_STS
        public const string FLAG_CPAR_STS_OPEN = "OPEN";
        public const string FLAG_CPAR_STS_CLOSED = "CLOSED";
        public const string FLAG_CPAR_STS_CANCELED = "CANCELED";

        //CPAR_TYPE
        public const string FLAG_CPAR_TYPE_IA = "IA";
        public const string FLAG_CPAR_TYPE_TM = "TM";
        public const string FLAG_CPAR_TYPE_PP = "PP";
        public const string FLAG_CPAR_TYPE_PI = "PI";
        public const string FLAG_CPAR_TYPE_CC = "CC";
        public const string FLAG_CPAR_TYPE_LL = "LL";
        //CPAR_STEP
        public const string FLAG_CPAR_STEP_PRECREATE = "PRECREATE";
        public const string FLAG_CPAR_STEP_CREATED = "CREATED";
        public const string FLAG_CPAR_STEP_RESPONDED = "RESPONDED";
        public const string FLAG_CPAR_STEP_VERIFIED = "VERIFIED";

        //CPAR_STEP
        public const string FLAG_CPAR_STEP_PRECREATE_NM = "Lengkapi CPAR dari CC Oleh QA";
        public const string FLAG_CPAR_STEP_CREATED_NM = "Belum ditanggapi oleh Auditee";
        public const string FLAG_CPAR_STEP_RESPONDED_NM = "Belum diVerifikasi oleh Auditor/QA";
        public const string FLAG_CPAR_STEP_VERIFIED_NM = "Sudah diVerifikasi status Open";
        public const string FLAG_CPAR_STEP_VERIFIED_NM2 = "Sudah diVerifikasi status Closed";

        //CPAR_STEP
        public const string FLAG_CPAR_CLASS_MAJOR = "MJ";
        public const string FLAG_CPAR_CLASS_MINOR = "MN";
        public const string FLAG_CPAR_CLASS_OPORTUNITY = "OI";

        //COMPLAIN_STS
        public const string FLAG_COMPLAIN_STS_OPEN = "OPEN";
        public const string FLAG_COMPLAIN_STS_CLOSED = "CLOSED";
        public const string FLAG_COMPLAIN_STS_CANCELED = "CANCELED";
        //COMPLAIN_TYPE
        public const string FLAG_COMPLAIN_TYPE_DEFECT = "DEFECT";
        public const string FLAG_COMPLAIN_TYPE_SERVICE = "SERVICE";
        public const string FLAG_COMPLAIN_TYPE_COMMUNICATION = "COMMUNICATION";
        public const string FLAG_COMPLAIN_TYPE_SUGGEST = "SUGGEST";
        public const string FLAG_COMPLAIN_TYPE_QUESTION = "QUESTION";
        public const string FLAG_COMPLAIN_TYPE_MISUNDERSTAND = "MISUNDERSTAND";
        public const string FLAG_COMPLAIN_TYPE_MISUSE = "MISUSE";

        //ROLE_RUID
        public const string FLAG_ROLE_SYSADMIN = "SYSADMIN";
        public const string FLAG_ROLE_CPAR_ADMIN = "CPAR_ADMIN";
        public const string FLAG_ROLE_CPAR_PIC = "CPAR_PIC";
        public const string FLAG_ROLE_PJXADMIN = "CPAR_PJXADMIN";
        public const string FLAG_ROLE_CPAR_MEMBER = "CPAR_MEMBER";

        //NOTIF_CPAR
        public const string FLAG_NOTIF_CPAR_AUDITEE = "AUDITEE";
        public const string FLAG_NOTIF_CPAR_AUDITEE_DEPT = "AUDITEE_DEPT";
        public const string FLAG_NOTIF_CPAR_AUDITOR = "AUDITOR";


    } //End public class valFLAG
} //End namespace APPBASE.Svcbiz