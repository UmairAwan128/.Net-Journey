using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt_CRUD.Models
{
    //In ASP .NET Core MVC models and controllers can also be in any other folder but we are folloing this convention
    //EmployeeModel is a collection of two classes one is for Data i.e Employee.cs and other is for ManagingData i.e MockEmployeeRepository.cs
    //we additionally added a third member i.e interface into this family for ease for mantaining/changing Employee and using DependencyInjection.

    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Name cannot exceed from 50 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="Invalid Email Format")]
        [Display(Name="Office Email")]  //we changed the name of this property to "OfficeEmail so it will be displayed everywhere e.g in error msg,lableName
        //but we will be using Email in  our project
        public string Email { get; set; }

        // [Required]  we don,t need to write here [required] Dept is enum type and enum's carry int values and int are bydefault required
        //but if we want to make it optional use "Dept?" as nullable type.
        //we want to make this field to show required error if user don,t select any value from dropdown or select invalid option which is first option like "Select option"
        //but if we write [Required] its useless so solution is make it first optional then use [required] so make the Dept type nullable and used [Required]
        [Required]
        public Dept? Department { get; set; }

        //make sure you see  abourMigrations.txt file first 
        //we added this new field after migrations i.e after creating table in DB so we will create new migration for this 
        // so we first "Add-Migration AddPhotoPathColumn" then update-database
        public string PhotoPath { get; set; }

    }
}
