using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMgt_CRUD.Models
{
    //Details or topic about EFCore is in the end of this file do check that first
    public class AppDbContext : DbContext
    {
        //We need DbContextOptions object here to do any useful work so we injected it in Constructor,
        //DbContextOptions has things like connectionString,DataBaseProvider used by this Application
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
             
        }

        //we want to Seed data to our Employee table with some initial data or sample employee records when table is created so.
        // if we added this code after creating table so to add this record to Employee table open PackageManagerCOnsole and run "Add-Migration SeedEmployeeData" then Update-Database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //if we want to update this record just change the values keeping the Id same and again run the migration commands Add-Migration and Update-Database
            //we moved the code for creating objects to class ModelBuilderExtension there we defined an extension method seed() to the
            // ModelBuilder class so as we know now we can use call that seed() here and all the employee objects will be created and data will be inserted to Employee table.
            modelBuilder.Seed();            
        }

        //we use this to save and retrieve Employee and do this using LINQ queries which are then translated to the sql Query
        // for the underlying database
        public DbSet<Employee> Employees { get; set; }
    }

    // EFCore is Lightweight,Extensible, OpenSource and is also CrossPlatform i.e works on linux,windows,MacOS e.t.c 
    //EntityFramework core is ORM(Object Relational Mapper) which means it enables developers to work with Business objects(like Employee class/object)
    // and responsiblilty of ORM is to generate the SQL that the undelying Database understands, ORM elinates the need for writting most of code  
    // like code for storing and retrieving data from DB or for mapping database data to/from model classes SO EFCore do all this and save lot of time.
    // So EFCore is b/w application code and Database. It supports both Code and DB first approach but limited support for DBFirst.
    // EFCore Supports many Relational(Table) and NonRelational(Objects) Databases as it uses various plugin libraries or DB providers 
    // and these are all available as Nuget packages. e.g. EFCore supports DataBases like MSSQL,MySQL,SQLite e.t.c all has its related package to install
    // complete list is here along with there package names https://docs.microsoft.com/en-us/ef/core/providers/
    // A database provider, usually sits between EF Core and the database it supports.The database provider contains the 
    // functionality specific to the database it supports e.g SQLServerprovider contains code for SQLServerDB .Functionality
    // that is common to all the databases is in the EF Core component. Functionality that is specific to a database, 
    // for example, Microsoft SQL Server specific functionality is with in the SQLServerprovider package for EF Core. 

    // Single Layered Web Application (all code in single project)
    // MultiLayered Web Application (Code is divide like DataAccess layer for DB, Presentation Layer frontend design,Businees layer has logic)
    /// Our Project is Single Layered and has EFCore already installed as all the projects created with ASP.NetCore 2.1 or above has EFCore already installed
    /// we can check this package by going to SolutionExplorer then "Dependencies->Nuget" expand Microsoft.ASPNETCore.App package which is 
    /// a meta package i.e this package has no content of its own but has list of dependencies/packages installed so here in this list we can check for EFCore package.
    /// But If we want to Install EntityFramework Core in project like DataAcessLayer which is a class laibray project we need to install these three packages
    /// 1. Microsoft.EntityFrameworkCore.SqlServer   (has the functionality specific to MSSQL server and it depends on  Microsoft.EntityFrameworkCore.Relational package) 
    /// 2. Microsoft.EntityFrameworkCore.Relational  (has the functionality specific to all Relational databases(e.g MSSQL,MySql) and it depends on  Microsoft.EntityFrameworkCore package)
    /// 3. Microsoft.EntityFrameworkCore             (has the core functionality that is common to all databases)
    /// So to install we just install Microsoft.EntityFrameworkCore.SqlServer package and remaining two packages will be auto installed
    /// by Nuget as they are its dependencies. but if we first install  Microsoft.EntityFrameworkCore we have to install remaining two on our own.

    /// if we want to use MySQL there are various packages to install MySQL package to check which one is correct use this site
    /// https://docs.microsoft.com/en-us/ef/core/providers/ it has complete list of DBprovider(like MySQL) along with their packageName(Pomelo). 

}
