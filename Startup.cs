﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DotNetCoreFunda.Services;
using DotNetCoreFunda.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Rewrite;

namespace DotNetCoreFunda
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, ConfigGreeter>();
            services.AddDbContext<DNCFundaDbContext>(options=>
            {
                options = options.UseSqlServer(_configuration.GetConnectionString("DNCDb"));
            });
            //services.AddSingleton<IEmployeeData, HardCodedEmployees>();
            services.AddScoped<IEmployeeData, SqlEmpData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              IGreeter greeter,
                              ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRewriter(new RewriteOptions().AddRedirectToHttps());

            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                var greetings = greeter.GetMessage();
                /* If we wont set content type then Not Found is printed without spaces!
                  context.Response.ContentType = "text/plain";
                  await context.Response.WriteAsync($"Not Found");
                */
                await context.Response.WriteAsync($"{greetings} : {env.EnvironmentName}");

            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            //No default set in this mapping.
            //routeBuilder.MapRoute("Default",
            //    "{controller}/{action}/{id?}");
            //Now we will set optional params == Defaults so that there is a default route.
            routeBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");
            routeBuilder.MapRoute("Admin",
                "admin/{controller}/{action}/{id?}");
        }
    }
}
