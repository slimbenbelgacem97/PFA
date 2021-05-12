using System;
using System.IO;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using backend.Logging;
using backend.Autoecole.DataAccess.Data;
using backend.Autoecole.Domain.Services;
using backend.Autoecole.DataAccess.Repositories;
using backend.Autoecole.Domain.Services.IServices;
using backend.Autoecole.Domain.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddScoped<IUnitofWork, UnitofWork>();
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
                   
                });
            });


            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                { options.Password.RequiredLength = 8;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;

                }

            )
               .AddEntityFrameworkStores<ModelContextV2>()
               .AddDefaultTokenProviders();
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                }

            )
                .AddJwtBearer(options =>
                    {
                        options.SaveToken = true;
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidAudience = Configuration["JWT:ValidAudience"],
                            ValidIssuer = Configuration["JWT:ValidIssuer"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value))
                        };
                    }
                );

            services.AddMvc(option => option.EnableEndpointRouting = false)
                    
                    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<ModelContextV2>(options => options.UseSqlite(Configuration.GetConnectionString("Default")));
            }
            services.AddTransient<IServiceAgent, SrevicesAgent>();
           
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
            app.UseAuthentication();
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
            // app.UseSpa(configuration: builder =>
            // {
            //     if (Environment.IsDevelopment())
            //     {
            //         builder.UseProxyToSpaDevelopmentServer("http://localhost:");
            //     }
            // });
        }
    }
}