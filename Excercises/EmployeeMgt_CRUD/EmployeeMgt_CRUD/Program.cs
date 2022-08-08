using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EmployeeMgt_CRUD
{
    //An ASP.NET core initially starts as a console application so main() is entry point  
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            //CreateDefaultBuilder(args) => setUp the webhost the default settings 
            //UseStartup<Startup>() configure startup class
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>(); 
    }
}
