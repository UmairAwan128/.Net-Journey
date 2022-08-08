using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMgt_CRUD.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//first see startUp6.cs for pre topics

namespace EmployeeMgt_CRUD
{
    //MVC is a design pattern that is used to implement user interface layer of our application.
    //To addd MVC to our application we have two steps
    //1. add Required MVC Service to dependency injection container. we did this in configureServices().
    //2. add MVC middleware to our request processing pipeline we did it in Configure() as that method configures request processing pipeline.
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the dependency injection container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //First read the comments for below lines like AddMVC and AddSingleton() then read its related comments
            //Here we want to configure and User MSSQL server with EFCore we do this in configureServices() and has some steps to follow
            ////1. Register Application specific DBContext class i.e here AppDbContext.cs with DependencyInjection system so we don,t need to create
            ////   its object i.e AppDbContext when need ed and to use any of its functionality anywhere in the project we just need inject AppDBContext
            ////   and the instance created in here will be used there i.e in all over application. so we do it in this way
            //   services.AddDbContextPool<AppDbContext>()         // we also have .AddDbContext() but we should prefer using .AddDbContextPool() 
            ////   as it provides pooling/singleton i.e whenever instance of DbContext is requested from anywhere in our project instead of creating a brand new instance
            ////   ASP.NET core checks if there is an instance available in the DBContext pool if yes then that instance is returned new is not created
            ///    also .AddDbContextPool() method is new and better in comparison of performance with .AddDbContext() 
            ////2. We have to specify Database provider that we want to use as we want MSSQL server and additionally we want 
            ///    to passs here connectionString  as parameter so to connect to a database so we instead of hardocding we can define
            ///    it either in a file and use it here we defined it in appSettings.json file and accessed it here using GetConnectionString() passed name of ConnectionString as parameter 
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));


            ////To add the all the required MVC service to dependency Injection container 
            ////all we need to do is use IServiceCollection and call addMvc() or addMvcCore() on it.
            //  services.AddMvc();        //adds all the required MVC services and additionally it calls AddMvcCore() method also so no need to call both
            ////services.AddMvcCore(); //only adds the core MVC services e.g it does not add JsonFormaterService that we want to
            ////handle a response of JsonResult from Controller i.e currently Index() of HomeController is returning Json as 
            ////response so if we use AddMvc() it handles and show Json but AddMvcCore() doesNot handle Json and show Error/DeveloperExceptionPage 
            ////if we are in Development mode/environment.
            services.AddMvc().AddXmlSerializerFormatters(); //if user requires data/response in xml format. User tell the format required
                                                            //in request header by passing key value pair "Accept : application/xml" so to convert response to xml format we first
                                                            //added service .AddXmlSerializerFormatters() and second the action/method that allows returning data in various format
                                                            //should return ObjectResult so we created such a method Details_ContentNego() in HomeController. 


            ////As we know ConfigureServices() configures services required for our application or here we add services that we use in our application like we Added MVC above
            ////We created interface "IEmployeeRepository" which is our created service and we want to use it in our application so we should add/configue it here in the same way as below
            ////used here Singleton() means use single instance throughout appication lifeTime i.e create new instance for new user/request and use it for its subsequentrequest don,t create new 
            //    services.AddSingleton<IEmployeeRepository,MockEmployeeRepository>();
            ////above line means if someone like "HomeController" request for "IEmployeeRepository" instance to acess its members like GetEmployee(id) we want ASP.NET core
            ////to do is create an instance of a class which implments this interface (as for interface we cannot create obj) SO that class will also have that method  with functionality which we want
            ////so we are telling that class here in secondParameter i.e the class which implements the interface is "MockEmployeeRepository" so create and use its object in application. 
            ////so using above line we told DotNetCore to create "MockEmployeeRepository" class
            ////object when anywhere in application someone wants to access any member of "IEmployeeRepository" so  DotNetCore create obj of
            ////of "MockEmployeeRepository" then inject that object to where it was reqired or called from or replace code with like obj.memberName so members get accessible
            ////there without creating obj of the class even.

            ////benifits of using Dependency Injection or this appreach:
            ////if tomorrow we want to use another class with new implementation inspite of "MockEmployeeRepository" we will just change it right here i.e
            ////the second parameter will be changed and if we don,t used dependencyInjection i.e like in HomeController Constructor
            ////if we directly created object of "MockEmployeeRepository" class there to access members we will be changing "MockEmployeeRepository" with 
            ////"newName" everywhere we created the class obj so in this way we say that dependencyInjection makes our code loosely couple i.e easy to change/unit testing.
            ////e.g so we just changed one word and now our app is using SQL/DB implementation for IEmployeeRepository inspite of in-mem storage now Database is used in this Application. 
             services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            //we should use here AddScoped() inspite of AddSingleton()  as we want the object of IEmployeeRepository to be available through entire scope of httpRequest 
            //and for another HttpReq we want new object to be created as multi users so multi objects so we will have two objects in memory for two different requests  

            //we also have one more mthods for doing same thing
            //services.AddTransient<>();
            
            //to check differnece b/w all these three we take an example i.e we have injected IEmployeeRepository to the
            //HomeController and we have also injected IEmployeeRepository to create.cshtml view as we wanted to display "TotalEmployeesCount"
            //on create.cshtml and third thing we did is commented the   RedirectToAction("detailsView"....)  in create() post action. as we wanted
            //to see the count of Employees after the form is submitted i.e after createEmployeeForm submits we will have +1 employee so if we use
            //1. services.AddSingleton<>()    =>  in this case When we open Create view from browser request comes to HomeController so there
            //   an Instance of IEmployeeRepository will be created/injected using the constructor and after the create()[get]  action
            //   return the create.cshtml view and the view also has dependency on IEmployeeRepository so as we are using Singleton so
            //   this view will not create a new IEmployeeRepository instance instead it will use the instance that is created in HomeController so
            //   same instance will be injected to the create.cshtml so in this case we have only one instance in all our Application and it will
            //   be created when application get first HTTP request for that instance and later in all over our application for any of request for IEmployeeRepository
            //   from either controller/View this instance will be used. so when after filling form create button is pressed the request comes create() post action
            //   and it will save that Employee using the old and only IEmployeeRepository instance and return again the create.cshtml view which also uses the same and IEmployeeRepository
            //   instance now as new Employee added so we will see "TotalEmployeesCount=4" i.e +1 and if we again click create button TotalEmployeesCount will be 5,6,7 and soon.

            //2. services.AddScoped<>()    =>  in this case We have same instance within the scope of the given httpRequest
            //   but new instance accross different httpRequests so when we open Create view from browser it is get request to create() action
            //   so an Insance of IEmployeeRepository will be created and create.cshtml is returned which also uses the same of IEmployeeRepository instance. 
            //   when after filling form we press create button which is post request so request comes to create() post action and as this is a differt http request
            //   so this time new IEmployeeRepository instance will be created and this saves the employee and return the View and this time
            //   the create.cshtml view will use this IEmployeeRepository instance and show the "TotalEmployeesCount=4"  and if we again and again
            //   click "create" button after filling the form we will see the "TotalEmployeesCount=4" it will never increase as each post request
            //   is a seperate request so for each new post request new IEmployeeRepository instance is created and that new Employee will be added to this new
            //   IEmployeeRepository instance so as each IEmployeeRepository instance has three employees so after adding the new 1 we always get 4 not any more.
            //   so for same http request(either get/post) same IEmployeeRepository instance will be used in both the Controller and View or in scope/body of action() as Action is returning View so view will use same instance.
            //   and for another request new IEmployeeRepository instance will be created and used in both the Controller and View.

            //2. services.AddTransient<>()    =>  in this case every time new instance is created whenever we need instance
            //   weather HTTP request is in the scope or accroess differnt httpRequests so here in this case the instance of IEmployeeRepository
            //   created in Controller will not be used in View so for either get or post req in controller each time new IEmployeeRepository
            //   and in view new IEmployeeRepository will be created and used so as new created each time so when we submit the create form
            //   the TotalEmployeesCount will be 3 always either we click it any no of time as for each post request new instance is created first in 
            //   controller and then another new instance is created in View. so in this case new Employee will never be shown on the list/index page.

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request processing pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else {
                //we should show friendly error pages to users inspite of developerExceptionPage so for all the environments except the "development" show error page
                ////we can use these middlewares to handle errors like 404 url error invalid page accessed or route does not match any view
                // app.UseStatusCodePages(); //this middleware will just show simple text message 404 not found we can,t even change that so its not used.                    
                // app.UseStatusCodePagesWithRedirects("/Error/{0}"); //using this we can specify url where we want to go or page we want to show if there is nonSuccess statusCode. 
                ////so url means go to controller named "Error" and here action name is decided on runtime i.e it is a placeholder that will be
                //// replaced with nonSuccess status code i.e if error code is 404 url will be Error/404 means access action named 404 from Error Controller.
                ////but for short code in Error controller we used attribute routing and declared only one action "HttpStatusCodeHandler" that will handle all these various errors
                ////as in URL "/Error/{0}" second thing here is "actionName" e.g 404 but in Controller using attribute routing we used "actionName" as parameter to action "HttpStatusCodeHandler(statusCode)"
                ////and as we know we can use attribute routing to create a route of any pattern we want but it should be unique.
                ////so the value of statusCode/actionName will be stored in parameter name "{statusCode}" and then used by Action HttpStatusCodeHandler(statusCode). 

                //How this Line Gets 404 StatusCode? 
                //the working of this is same as UseDevelopmentExceptionPage() i.e we introduce it in start of our request processing pipeline 
                //so when a request comes for url or route this request goes one by one to each middleaware reaches the MVC middleware
                //and if that url is valid it shows that page if invalid url it generates a 404 status and then from that place pipeline
                //reverses and this line/middleware "UseStatusCodePagesWithRedirects()" will execute and gets that error statusCode i.e 404
                //and executes the Url or generate a new request to "Error/404" in other words our url is like changed as its a request so this
                //will go through the request processing pipeline and MVC middleware will entertain this request and show the error page.

                //In addition to this we also this method both have same functionality and execution pattern but this is mostly used. 
                app.UseStatusCodePagesWithReExecute("/Error/{0}");

                //UseStatusCodePagesWithReExecute() is prefererd using over UseStatusCodePagesWithRedirects() as the method
                //UseStatusCodePagesWithRedirects() does two things that people don,t like e.g it swaps the users entered invalid url
                //with the errorPage url that is currently showing and secondly after showing this error page it sends back the errorCode status 200
                //inspite of 404. Why 200 is returned? as we know in the request processing piplne url changes to errorPage and that page is 
                //found so status code gets 200.
                //Why use UseStatusCodePagesWithReExecute()? because first it does not redirects i.e it does not swaps the users entered invalid url
                //with the errorPage url that is currently showing and secondly it returns status code 404 inspite of 200.
                //why 404? in reality the here also as Error page found 200 is passed to middleware "UseStatusCodePagesWithReExecute()"
                //but this middleware changes the status code 200 to its orignal status code which should be 404. and that is returned

            }
            app.UseStaticFiles();

            // added here MVC middleware to our request processing pipeline. we added this after UseStaticFiles() middleware
            //for better performance of our application e.g if req is for image file and the seq is same as current UseStaticFiles()
            //middleware will handle that request and short circuit the remaining pipeline so MVC middleware will not run
            //but if MVC middleware was before the static file middleware each time even request is for image file request will
            //first come to MVC middleware then Static File middleware so we used UseStaticFiles() middleware before MVC middleware.
            //  app.UseMvcWithDefaultRoute(); //UseMvcDefaultRoute() means if u navigate to the defination of this method 
            //you will see that this method has a default route named 'default' with value '{controller=Home}/{action=Index}/{id?}'
            //that means this middleware will look for index() method inside a HomeController whenever in url after "localhost:3424/"
            //nothing is passed as parameter i.e no name of Controller and action passed in URL if in URL we pass another controller/action
            //and we don,t have that Controller and action this middleware will pass the request to next middleware if any if not 404 error will occur.
            //if it found Index() for HomeController it shortcircuit the pipeline so remaing middlewares will not get request
            //and pipeline reverses from here.

            //as we know UseMvcWithDefaultRoute() uses a default route but if we don,t want to use that default route but our own use
            // this does not have default route so if we write this we need to define a route for our app as well so defined 
            // controller=Home means default value of controller is "Home" so if user don,t specify controller use HomeController
            // id is optional parameter here as ? so if a action e.g Home->detailsView(id) requires Id parameter and we don,t
            //pass it in URL the Action will be executed and the line where we use "id" paramter value e.g getting employee
            //an exception will occur on that line and shown on browser.
            app.UseMvc(routes =>
            {
                //routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");

                //We should use tagHelper for creating links in application because we don,t need to change them 
                // if we change route of our application for details see index.cshtml in Home folder. e.g lets say we 
                //have completed our project and we got new requirement from client that it wants that all apllication
                //url should start with companyName then controller then action so made this route 
                routes.MapRoute("default", "companyName/{controller=Home}/{action=Index}/{id?}");
            });
            //In MVC we have two kinds of routing convention and attribute roting the above one is called convention routing 
            //and for attribute routing we again use app.UseMvc() but we don,t pass  or route/parameter to it. but in such
            //case we define route for each of the action in its respective Controller file using the "Route()" attribute we 
            //use it start/top/start of the action or controllerClass so here we write only UseMvc() and in Controller files we used Route attribte. 
            //    app.UseMvc();
        }
    }
}
