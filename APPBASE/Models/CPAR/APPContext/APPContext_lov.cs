using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using APPBASE.Helpers;
using APPBASE.Models;

namespace APPBASE.Models
{
    #region Default Context Area
        public partial class DBMAINContext : DbContext
        {
            //Proses Audit
            public DbSet<Audit> Audits { get; set; }
            public DbSet<Audit_info> Audit_infos { get; set; }
            //CPAR Status
            public DbSet<CPARsts> CPARstss { get; set; }
            //Project Status
            public DbSet<Projectsts> Projectstss { get; set; }
            public DbSet<Projectsts_info> Projectsts_infos { get; set; }
            //CPAR TYPE
            public DbSet<CPARType> CPARTypes { get; set; }
            //CPAR SUBTYPE
            public DbSet<Subtype> Subtypes { get; set; }
            //CPAR CLASS
            public DbSet<Classaudit> Classaudits { get; set; }
            //CPAR STANDARD/REFF
            public DbSet<Standardreff> Standardreffs { get; set; }
            public DbSet<Standardreff_info> Standardreff_infos { get; set; }
            //COMPLAIN_TYPE
            public DbSet<Complaintype> Complaintypes { get; set; }
            public DbSet<Complaintype_info> Complaintype_infos { get; set; }
        } //End public class DBMAINContext : DbContext
    #endregion
} //End namespace APPBASE.Models