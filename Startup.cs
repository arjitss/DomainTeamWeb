using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainTeamWebsite.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DomainTeamWebsite
{

    public class Startup
    {        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions dEPO = new DeveloperExceptionPageOptions {
                    SourceCodeLineCount = 10
                };
                app.UseDeveloperExceptionPage(dEPO);
            }

            //app.UseFileServer();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseMvcWithDefaultRoute();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action}/{id?}");
                
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!" + env.EnvironmentName);
                //     //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                //     //await context.Response.WriteAsync(_config["mykey"]);
                // });
            });
            app.Run(async (context) => {
                await context.Response.WriteAsync("Hello World");
            });
        }
    }
}
