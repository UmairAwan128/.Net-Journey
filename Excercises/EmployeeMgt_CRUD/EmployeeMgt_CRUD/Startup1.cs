using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeMgt_CRUD
{
    public class Startup1
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) //this configure our applications request processing pipline
        {
            //if the environment of application is development then run the code inside if(){__} , we defined this env variable
            //in launchsettings.json inside "profiles" as "IIS Express": {"environmentVariables": {"ASPNETCORE_ENVIRONMENT": "Development"}
            //the profile "IISExpress" will be used when we run our project from VisualStudio so process name will be iisexpress
            //we also have another profile named "EmployeeMgt_CRUD" which is used when we run our program using DotNetCore CLI so localhost:5000
            //and in this as running project from CLI so outOfProcess hosting will be used and process name will be "dotnet"
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                //await context.Response.WriteAsync("Hello World!");
                //to get the name of the process which is currently hosting our application
                //if our app is in inProcess hosting then it should be iisexpress as our app is in localhost and in iisexpress software
                //but it will be "w3wp" when our app will be hosted on IIS orignal.
                // in EmployeeMgt_CRUD.csproj  file we define using a tag about our app either it will be using inProcess or outOfProcess hosting
                //if we remove the tag it will be outOfProcess hosting i.e it is byDefault
                await context.Response.WriteAsync(
                    System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                //if we run this app using dotNetCoreCLI(works on LInux,MAC,Windows) named "developer CMD for VS2017" the process name will be dotnet.exe 
                //in that case hosting will be outOfProcess hosting and in that we have two server inspite of one as in InProcessHosting
                //so first server is Kestral(crossPlatformServer) and other can be any like IIS. Kestral comes with dotnet core
                //first it faces all request from user either generate response or pass it to the second server
                //like IIS so in this way DotNetCore apps can use any server which makes cross platform 

                // in EmployeeMgt_CRUD.csproj  file we define using a tag about our app either it will be using inProcess or outOfProcess hosting
                //if we write there outOfProcess and run project from VisualStudio it will show "dotnet" so the process name will be dotnet.exe
                //as we know outOfProcess should be handled by Kesteral but as running from VisualStudio so in this case IIS is facing all req first 
                //and passes them to Kesteral then Kesteral process sends back to IIS and IIS sends response to User here we call IIS a reverse proxy server

                //inProcessHosting is faster then outOfProcess hosting as in outOFProcess hosting
                //we have two server and proxing request b/w them take additional time then in
                //inProcessHosting where we have only one server.   
            });
        }
    }
}
