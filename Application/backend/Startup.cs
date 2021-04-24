using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using NLog;
using backend.Models;
using backend.Data;
using backend.Repositries;
using backend.Logging;
// using backend.Models;
// using backend.Repositries;
// using backend.Logging;
namespace backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "\\log.config"));
            Configuration = configuration;

            Environment = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Startup));
            services.AddSpaStaticFiles(configuration: options => { options.RootPath = "wwwroot"; });
             services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
             services.AddSingleton<ILoggerManager, LoggerManager>(); // to exttract to an other class (ServicesExeteiions)
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("VueCorsPolicy", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                    //.AllowCredentials();
                    // .WithOrigins("https://localhost:5001","https://localhost:8081");
                });
            });
            services.AddMvc(option => option.EnableEndpointRouting = false)
                    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<ModelContextV2>(options => options.UseSqlite(Configuration.GetConnectionString("Default")));
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ModelContextV2 dbContext)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors("VueCorsPolicy");

            dbContext.Database.EnsureCreated();
            app.UseAuthentication();
            app.UseMvc(
                routes =>
                 {
                     routes.MapRoute(
                         name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}"
                     );
                 }
            );
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}"
                );
            });
            app.UseDefaultFiles();
            app.UseSpaStaticFiles();
            app.UseSpa(configuration: builder =>
            {
                if (Environment.IsDevelopment())
                {
                    builder.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                }
            });
        }
    }
}