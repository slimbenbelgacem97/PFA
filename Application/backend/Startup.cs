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
using backend.Autoecole.Api.Configurations;
using Microsoft.OpenApi.Models;

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
                {
                    options.Password.RequiredLength = 8;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
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
                    ValidAudience = "https://localhost:5001",
                    ValidIssuer = "https://localhost:5001",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Secret))
                };
            });

            services.AddMvc(option => option.EnableEndpointRouting = false)

                    .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<ModelContextV2>(options =>
                options.UseSqlite(Configuration.GetConnectionString("Default")));
                services.AddSwaggerGen(swagger =>
                {
                    //This is to generate the Default UI of Swagger Documentation  
                    swagger.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Autoécole API",
                        Description = ""
                    });
                    // To Enable authorization using Swagger (JWT)  
                    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
                    });
                    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    }
                                },
                            new string[] {}
                        }
                    });
                });
            }

            services.AddTransient<IServiceAgent, SrevicesAgent>();
            services.AddTransient<IServiceSeance, ServiceSeance>();
            services.AddTransient<IServiceCandidat,ServiceCandidat>();
            services.AddTransient<IServiceAuthentification, ServiceAuthentification>();
            services.AddTransient<IServiceVehicule, ServiceVehicule>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ModelContextV2 dbContext)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                }); 
            }

            

            app.UseCors("VueCorsPolicy");

            dbContext.Database.EnsureCreated();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc(
                routes =>
                 {
                     routes.MapRoute(
                         name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}"
                     );
                 }
            );
           
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