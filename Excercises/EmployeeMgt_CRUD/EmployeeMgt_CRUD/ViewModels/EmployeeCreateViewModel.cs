using EmployeeMgt_CRUD.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt_CRUD.ViewModels
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed from 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Office Email")]  //we changed the name of this property to "OfficeEmail so it will be displayed everywhere e.g in error msg,lableName
        //but we will be using Email in  our project
        public string Email { get; set; }

        [Required]
        public Dept? Department { get; set; }

        //we used the type IFormFile inspite of string as it is an interface and has a set of useful properties to work with file
        //like FileName,copyTo() is for move uploaded file to a specific folder e.t.c
        public List<IFormFile> Photos { get; set; } //used list as we want multiple files for single user
    }
}
