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

namespace DotNetCoreFunda
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, ConfigGreeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              IGreeter greeter,
                              ILogger<Startup> logger)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //Following line or method is only called once when application starts
            app.Use(next => 
            {
                //Following line or method is only called once every request comes
                return async context =>
                {
                    logger.LogInformation("Incoming request!");
                    if(context.Request.Path.StartsWithSegments("/customMiddlewarePath"))
                    {
                        await context.Response.WriteAsync("Responded by our custom middleware!");
                        logger.LogInformation("Incoming request handled by our middleware!");
                    }
                    else
                    {
                        /*This will go to next middleware if applcable and execute suitable one.
                          For eg: in case when url doesnt match with "/customMiddlewarePath" next() middleware will be called 
                          i.e. app.Run(); as app.UseWelcomePage's path doesn't matches, which Greets with message from config! */
                        await next(context);
                        logger.LogInformation("Outgoing response!");
                    }
                };
            });

            app.UseWelcomePage(new WelcomePageOptions()
            {
                Path = "/onlyForWelcomePage"
            });

            app.Run(async (context) =>
            {
                var greetings = greeter.GetMessage();
                await context.Response.WriteAsync(greetings);
            });
        }
    }
}
