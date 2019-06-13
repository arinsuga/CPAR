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
            //Access Control
            public DbSet<User> Users { get; set; }
            public DbSet<User_info> User_infos { get; set; }
            public DbSet<Usermenu> Usermenus { get; set; }
            public DbSet<Usermenu_info> Usermenu_infos { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<Role_info> Role_infos { get; set; }
            public DbSet<Rolemenu> Rolemenus { get; set; }
            public DbSet<Rolemenu_info> Rolemenu_infos { get; set; }
            //Employee
            public DbSet<EmployeeHasnousr_info> EmployeeHasnousr_infos { get; set; }
        } //End public class DBMAINContext : DbContext
    #endregion
} //End namespace APPBASE.Models