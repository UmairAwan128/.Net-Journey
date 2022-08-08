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
    //first see startUp2.cs
    public class Startup3
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                              ILogger<Startup> logger) // ILogger<Startup> is used to log the msg to the console
        {
            //Middleware is a piece of software that has a very specific purpose and
            //can handle has access to both incoming request and outgoing response. A collection of middleware components
            //creates a request processing pipline all our middlewares are here in configure() 
            //so this method configure the request processing pipline for this application
            //Some important points:
            //- A middleware component may just ignore and simple pass the request to next middleware
            //- or may do some processing and then pass the request to next middleware for further processing
            //- may hanlde the request generate response and short circuit the rest of the pipleine so remaining middlewares will not see that request
            //- may process the outgoing Response
            //- Middleware components are executed in the order in which they are added in the request processing pipline so be carefull with order

            //if the environment of application is development then run the code inside if(){__} , we defined this env variable
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run() is called a TerminalMiddleware i.e when request comes here it will generate response and will not
            //call the next middlewares so shortcircuit. 
            //app.Run(async (context) =>
            //so solution is to use the app.Use() with additional parameter "next" 
            app.Use(async (context, next) =>
            {
                //the msg "MW1: Incoming Request" will be logged when request comes here in this middleware then call the next middleware
                logger.LogInformation("MW1: Incoming Request"); //code before next() executes as request travel middleware to middleware 
                await next();
                //the msg "MW1: OutGoing Response" will be logged when pipline is reversed and response comes back to this middleware
                logger.LogInformation("MW1: OutGoing Response");//code after next() executes as response travel middleware to middleware
            });

            app.Use(async (context,next) =>
            {
                logger.LogInformation("MW2: Incoming Request");
                await next(); //call the next() middleware
                logger.LogInformation("MW2: OutGoing Response");
                
            });

            //if this is the only middleware here all the requests will be handled by it also it has not any condition and it just returns a msg as response
            //so any url like "http://localhost:49371/","http://localhost:49371/asd","http://localhost:49371/as/asd/ada",
            // even url for file "http://localhost:49371/home.jpg"  can be handled by this middleware.
            app.Run(async (context) =>
            {
                //app.Run() is called a TerminalMiddleware i.e when request comes here it will generate response and will not
                //call the next middlewares so we should use this at the end.

                //using the "HttpContext" i.e "context" we can get access to both incomming http request and outgoing http response  
                //using the Response and Request properties
                await context.Response.WriteAsync("Hello from last middleware");
                //pipline reverses it self as this middleware is terminalMiddleware and generate msg/response so now in all pre middleware codes after
                // line await next(); code will run which is msg.
                logger.LogInformation("MW3: Request handled and response generated");
            });

            //output:
            //MW1: Incoming Request
            //MW2: Incoming Request
            //MW1: Request handled and response generated
            //MW2: OutGoing Response
            //MW1: OutGoing Response
        }
    }
}
