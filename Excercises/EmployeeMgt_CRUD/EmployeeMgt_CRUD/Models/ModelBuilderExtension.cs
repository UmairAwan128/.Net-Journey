using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt_CRUD.Models
{
    //we wanted to Seed data to our Employee table with some initial data or sample employee records when table is created we added 
    //below code in OnModelCreating() in the AppDbContext class but for clean code.
    // we moved the code for creating objects or records here and defined an extension method seed() to the
    // ModelBuilder class so as we know now we can use call this seed() on ModelBuilder class.

    //both the class and method should be static for creating an ext method
    public static class ModelBuilderExtension
    {
        // as we added this code after creating Employee table so to add this record to Employee table open PackageManagerCOnsole and run "Add-Migration SeedEmployeeData" then Update-Database
        public static void Seed(this ModelBuilder modelBuilder) { //the first parameter should be name of class in which we are adding this extension method
            //if we want to update this record just change the values keeping the Id same and again run the migration commands Add-Migration and Update-Database
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Mary",
                    Department = Dept.IT,
                    Email = "Mary@asd.com"
                },
                new Employee
                {
                    Id = 2,
                    Name = "gart",
                    Department = Dept.HR,
                    Email = "art@asd.com"
                 }
            );

        }
    }
}
