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
using FluentValidation;
using FluentValidation.Mvc;
using FluentValidation.Attributes;

namespace APPBASE.Models
{
    [Table("Person")]
    [Validator(typeof(PersonValidator))]
    public class Person
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public DateTime? dob { get; set; }
        public decimal? salary { get; set; }
    } //End public class Person

    public class PersonValidator : AbstractValidator<Person>
    {
        //Constructor
        public PersonValidator()
        {
            RuleFor(x => x.name)
            .NotNull().WithMessage("Nama tidak boleh kosong ya")
            .Length(5, 10).WithMessage("Panjang karakter minimum 5 dan maximum 10");
            RuleFor(x => x.address).NotNull().When(x => x.name != null).WithMessage("Alamat harus diisi jika nama tidak kosong");
        } //End 
    } //End public class PersonValidator : AbstractValidator<Person>



} //End namespace APPBASE.Models