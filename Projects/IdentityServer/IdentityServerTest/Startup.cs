using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServerTest
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddInMemoryClients(new List<Client>(Config.Clients))
                .AddInMemoryIdentityResources(new List<IdentityResource>(Config.IdentityResources))
                .AddInMemoryApiResources(new List<ApiResource>(Config.ApiResources))
                .AddInMemoryApiScopes(new List<ApiScope>(Config.ApiScopes))
                .AddTestUsers(new List<TestUser>(Config.Users))
                .AddDeveloperSigningCredential(); // this provides signing material/certificate in Dev Env so to sign token and other content before sending.

            // as we have added QuickStartUI Auhtntication/Authorization Controllers and Views like Login and Consent page so to make IdServer use those we are adding this service.
            services.AddControllersWithViews(); //this adds all the Contrller with there coresponding view to the ServiceCollection so they can be called.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();


            // as we have added QuickStartUI Auhtntication/Authorization Controllers and Views like Login and Consent page so to make IdServer use those we are enabling authorization and adding endpoints for all the controller and a default route so they can be accessiable. 
            //commented this as now we have controllers in our app so configuring them
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            app.UseAuthorization(); 
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());

        }
    }
}
