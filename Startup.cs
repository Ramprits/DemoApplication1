using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DemoApplication1.Data;
using DemoApplication1.Models;
using DemoApplication1.Services;
using Newtonsoft.Json.Serialization;

namespace DemoApplication1
{
     public class Startup
     {
          public Startup(IHostingEnvironment env)
          {
               var builder = new ConfigurationBuilder()
                   .SetBasePath(env.ContentRootPath)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

               if (env.IsDevelopment())
               {
                    // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                    builder.AddUserSecrets();
               }

               builder.AddEnvironmentVariables();
               Configuration = builder.Build();
          }

          public Startup(IConfigurationRoot configuration)
          {
               this.Configuration = configuration;

          }
          public IConfigurationRoot Configuration { get; }

          // This method gets called by the runtime. Use this method to add services to the container.
          public void ConfigureServices(IServiceCollection services)
          {
               // Add framework services.
               services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

               services.AddIdentity<ApplicationUser, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>()
                   .AddDefaultTokenProviders();

               services.AddMvc();
               //    .AddJsonOptions(o =>
               //    {
               //         if (o.SerializerSettings.ContractResolver != null)
               //         {
               //              var castResolver = o.SerializerSettings.ContractResolver
               //                                  as DefaultContractResolver;
               //              castResolver.NamingStrategy = null;
               //         }

               //    });

               // Add application services.
               services.AddTransient<ICityInfoRepository, CityInfo>();
               services.AddTransient<IEmailSender, AuthMessageSender>();
               services.AddTransient<ISmsSender, AuthMessageSender>();
          }

          // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
          public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
          {
               loggerFactory.AddConsole(Configuration.GetSection("Logging"));
               loggerFactory.AddDebug();
               app.UseStatusCodePages();
               if (env.IsDevelopment())
               {
                    app.UseDeveloperExceptionPage();
                    app.UseDatabaseErrorPage();
                    app.UseBrowserLink();
               }
               else
               {
                    app.UseExceptionHandler("/Home/Error");
               }
               app.UseStaticFiles();

               app.UseIdentity();

               // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
                AutoMapper.Mapper.Initialize(config =>{
                    config.CreateMap<Entities.City,Models.CityWithOutPointsOfInterest>();
                });
               app.UseMvc(routes =>
               {
                    routes.MapRoute(
                     name: "default",
                     template: "{controller=Home}/{action=Index}/{id?}");
               });
          }
     }
}
