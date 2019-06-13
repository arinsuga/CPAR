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
            //City
            public DbSet<City> Citys { get; set; }
            //Country
            public DbSet<Country> Countrys { get; set; }
            //Marital Status
            public DbSet<Maritalsts> Maritalstss { get; set; }
            //Sex
            public DbSet<Sex> Sexs { get; set; }
            //Religion
            public DbSet<Religion> Religions { get; set; }
            //Job title
            public DbSet<Jobttl> Jobttls { get; set; }
            //Employee Status
            public DbSet<Employeests> Employeestss { get; set; }
            //Department
            public DbSet<Department> Departments { get; set; }
            public DbSet<Department_info> Department_infos { get; set; }
            //Employee
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Employee_address> Employee_addresss { get; set; }
            public DbSet<Employee_info> Employee_infos { get; set; }
            public DbSet<EmployeeWithaddress_info> EmployeeWithaddress_infos { get; set; }
            //Employee active
            public DbSet<Employeeactive_info> Employeeactive_infos { get; set; }
        } //End public class DBMAINContext : DbContext
    #endregion
} //End namespace APPBASE.Models