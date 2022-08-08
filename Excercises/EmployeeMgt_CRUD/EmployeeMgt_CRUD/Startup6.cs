using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

//In an application we have these 3 development environments.
//Development (Used while development phase we have non minified JS,CSS files and we here use developerExceptionPage to fix exceptions/errors)
//Stagging (used after development phase completes it is used to find any development related issue here we use minified JS,CSS files and show user friendly error if any found inpite of developerExceptionPage )
//Production (used for day to day business activities or when app launched here we use minified JS,CSS files and show user friendly error if any found inpite of developerExceptionPage as that can be used by hacker to hack app)

namespace EmployeeMgt_CRUD
{
    //MVC is a design pattern that is used to implement user interface layer of our application.

    //first see startUp5.cs
    public class Startup6
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) 
        {
            //Environment Variables (these are declared in launchSettings.json in "profiles") we want to access value of this env variable
            // i.e "ASPNETCORE_ENVIRONMENT": "Development"  so IHostingEnvironment is used to access its value as "env.EnvironmentName"
            //or call methods like if IsDevelopment() return true if "ASPNETCORE_ENVIRONMENT" value is "Development"  
            //if the environment of application is development then run the code inside
            if (env.IsDevelopment()) //we also have IsProduction(),IsStaging()
            //if (env.IsEnvironment("UAT")) //if we have coustom environment of our own name e.g UAT(User acceptence testing) pass its name as parameter
            {
                app.UseDeveloperExceptionPage();

            }

           
            
            //if this is the only middleware here all the requests will be handled by it also it has not any condition and it just returns a msg as response
            //so any url like "http://localhost:49371/","http://localhost:49371/asd","http://localhost:49371/as/asd/ada",
            // even url for file "http://localhost:49371/home.jpg"  can be handled by this middleware.
            app.Run(async (context) =>
            {
                //Environment Variables (these are declared in launchSettings.json in "profiles") we want to access value of this env variable
                // i.e "ASPNETCORE_ENVIRONMENT": "Development"  so IHostingEnvironment is used to access its value as "env.EnvironmentName"
                //we can also create environment in Operating System by controlPannel->search environemtn var and select "edit env variable"
                //then add new as per your req and access it here in the same way as we access this.if we have same env variable in both
                //operatingSystem and launchSettings.json the env variable in the value of launchSettings.json  will be shown.

                await context.Response.WriteAsync("Hosting Environment : "+env.EnvironmentName);

                //if we don,t have the "ASPNETCORE_ENVIRONMENT": "Development" in both launchSettings.json and OperatingSystem its default
                //value "Production" will be shown for security reasons because if its "development" then developerExceptionPage will be shown to
                //user and user can be hacker and hack into our application also in "development" environment nonMinified CSS and JS
                //files are loaded which effects the performance.
            });

            }
    }
}
