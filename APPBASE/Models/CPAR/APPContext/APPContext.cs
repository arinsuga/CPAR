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
            //Project
            public DbSet<Project> Projects { get; set; }
            public DbSet<Project_info> Project_infos { get; set; }
            //CPAR
            public DbSet<CPAR> CPARs { get; set; }
            public DbSet<CPAR_info> CPAR_infos { get; set; }
            public DbSet<CPARCPARStdref_info> CPARCPARStdref_infos { get; set; }
            public DbSet<CPARNOTIF_info> CPARNOTIF_infos { get; set; }
            public DbSet<CPARYEARALL_info> CPARYEARALL_infos { get; set; }

            //CPARStdref
            public DbSet<CPARStdref> CPARStdrefs { get; set; }
            public DbSet<CPARStdref_info> CPARStdref_infos { get; set; }

            //Config CPAR_ID
            public DbSet<Config_cparid> Config_cparids { get; set; }
            //CPAR Chat
            public DbSet<CPARChat> CPARChats { get; set; }
            public DbSet<CPARChat_info> CPARChat_infos { get; set; }
            public DbSet<CPARChatnotify> CPARChatnotifys { get; set; }
            public DbSet<CPARChatnotify_info> CPARChatnotify_infos { get; set; }
            public DbSet<CPARNOTIF_CPARCHAT_info> CPARNOTIF_CPARCHAT_infos { get; set; }

            //Complain
            public DbSet<Complain> Complains { get; set; }
            public DbSet<Complain_info> Complain_infos { get; set; }
        } //End public class DBMAINContext : DbContext
    #endregion
} //End namespace APPBASE.Models
