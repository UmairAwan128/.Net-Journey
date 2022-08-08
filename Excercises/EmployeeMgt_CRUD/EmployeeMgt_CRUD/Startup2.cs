using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeMgt_CRUD
{
    //first see startUp1.cs
    public class Startup2
    {
        private IConfiguration _config;

        //here we used constructor injector to inject "IConfiguration" service into this class
        //which we use to access configurationInfo like environmentVariable,objects defined in appSetting.json or anyother
        public Startup2(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) //this configure our applications request processing pipline
        {
            //if the environment of application is development then run the code inside if(){__} , we defined this env variable
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Run(async (context) =>
            {
                //in ASP.NET core configuration info can come from various sources these are
                //1.Files(appSetting.json,appSetting.{Environment}.json) 
                //2.User Secrets
                //3.Environment Variables
                //4.ComandLine argument
                // to access these sources we use IConfiguration Service that we injected to 
                //this class in its constructor the process is called constructor injector/dependency injection
                //Remember( if we have same varaible in all 4 the value the value of later one will overwrite 
                //the previous one in same order we wrote 1 to 4) e.g CommandLine will overwrite the 
                // EnvironemtVariables and it will overwrite Files,Usersecrets 


                ////now accessing values so from 
                ////1.Files(appSetting.json,appSetting.{Environment}.json) files i.e appSetting.json so if same name variable is also
                ////in appSetting.{Environment}.json so value of the environment specific file will be showed
                ////i.e same variable is in appSetting.Development.json so value of developement file will be shown.
                // await context.Response.WriteAsync(_config["MyKey"]);
                ////3.Environment Variables (these are declared in launchSettings.json in "profiles") as we 
                ////have same varaible with same name in Files "appSetting.json" also so value of EnvironmentVariable will be shown.   
                 await context.Response.WriteAsync(_config["MyKey"]);
                ////4.ComandLine argument(pass from CLI as typing => dotnet run MyKey="value from Command line")
                //// as again have same varaible with same name as in Files "appSetting.json" and in EnvironmentVariable
                //// so commandline arguement valuef will be shown.   
            });
        }
    }
}
