using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SOROS.Entities;  //in this project added the reference of the SOROS.Entities Project to use their classes   

namespace SOROS.Data.Code
{
    
  //<!--Here in Connection String in DataSource where we write name of SQLServer of our computer but here we don, t want to use SQL Server and
  //we are going to use the Local DB of the VisualStudio that comes with it so connecting that and it will create DB for us its benifit is when we will
  //deploy this application we don, t need to install SQL server on the Client/User PC just we just include some drivers in the setup of our Application or its setup
  //so this application will be running to all PC without requiring the SQL Server-->
  //<!--After you have done codefirstApproch(i.e created classes, context class and adding connection string) Now Select Tools from Menu bar then move to NuGetPackageManager  ==>select PackageManagerConsole
  //now in this console first make sure that Default project:_________   is set to the Database project i.e in which Entity framework is installed so here that project is SOROS.Data
  //now in the console enter these commands one by one first enter    Enable-Migration   -->
    public class SOROSContext : DbContext
    {
        public SOROSContext() : base("name=SOROSLocalDBConString")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
    }
}
