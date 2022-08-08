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

namespace EmployeeMgt_CRUD
{
    //first see startUp3.cs
    public class Startup4
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ////to set a default file that will be open when Site starts i.e for url http://localhost:49371/ we add file with name default.html/index.hml in wwwroot folder
            //app.UseDefaultFiles(); //and this will set the url to the default file path as http://localhost:49371/default.html but this will not be shhown in browser
            //                       //also this doesnot serve the file but only set the url so to serve file use app.UseStaticFiles(); after this so
            //                       //solution is we should use app.UseDefaultFiles(); before the app.UseStaticFiles(); to show our default file when site startsup.
            ////to access static files from browser e.g html,image,css,js file with url first they should be in wwwroot folder
            //app.UseStaticFiles(); //and second use this middleware we access such files as
            //                      //"http://localhost:49371/images/scene1.jpg" or http://localhost:49371/foo.html
            //app.UseFileServer();  //inspite of using both app.UseDefaultFiles(),app.UseStaticFiles() use only this it will do same work 
            ////additionally it has directoryBrowser middleware also i.e used to show all files inside a specfic folder in specific format in browser.

            ////If we want to show any other file as default inspite of index.html or default.html we should do this
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions(); 
            //defaultFilesOptions.DefaultFileNames.Clear();//clear or remove the default file name i.e default/index.html from memory
            //defaultFilesOptions.DefaultFileNames.Add("foo.html"); //and add the name of file
            //app.UseDefaultFiles(defaultFilesOptions); //pass this as parameter so now on site startsup foo.html will be shown as default file
            ////to access static files from browser e.g html,image,css,js file with url first they should be in wwwroot folder
            //app.UseStaticFiles();
            //if we want to use here app.UseFileServer() with default file as foo.html so we will create fileServerOptions object and do same process
            FileServerOptions fileServerOptions = new FileServerOptions();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            app.UseFileServer(fileServerOptions);


            //so keypoint to remember is for adding middleware to our application we use extension methods that starts with 
            //of "use___()" and to coustomize these we have respective "___Options" object e.g fileServerOptions. 

            //if this is the only middleware here all the requests will be handled by it also it has not any condition and it just returns a msg as response
            //so any url like "http://localhost:49371/","http://localhost:49371/asd","http://localhost:49371/as/asd/ada",
            // even url for file "http://localhost:49371/home.jpg"  can be handled by this middleware.
            app.Run(async (context) =>
            {
                //app.Run() is called a TerminalMiddleware i.e when request comes here it will generate response and will not
                //call the next middlewares so we should use this at the end.

                //using the "HttpContext" i.e "context" we can get access to both incomming http request and outgoing http response  
                //using the Response and Request properties
                await context.Response.WriteAsync("Hello world");
            });

        }
    }
}
