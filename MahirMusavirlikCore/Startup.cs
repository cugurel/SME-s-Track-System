using MahirMusavirlikCore.Identity;
using MahirMusavirlikCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace MahirMusavirlikCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWkhtmltopdf("wkhtmltopdf");
            services.AddDbContext<ApplicationContext>(
                //options => options.UseSqlServer("server = 77.245.159.23\\MSSQLSERVER2019; database = mahirmusavir; user id=mahirmusavirmm; password=Xdjy64_1;")
                options => options.UseSqlServer("server = LAPTOP-6RP07O6C; database = mahirmusavir; integrated security=true;")
                );
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {

                //options.Password.RequireDigit = true;
                //options.Password.RequireLowercase = false;
                //options.Password.RequireUppercase = false;

                //options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);


            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/Login";
                options.LogoutPath = "/Login/Logout";
            });

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            

            services.AddRazorPages();
            services.AddMvc(options => options.EnableEndpointRouting = false).AddControllersAsServices();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }


            app.UseStaticFiles();

            app.UseRouting();
            app.UseStatusCodePages();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                    endpoints.MapControllerRoute(name: "default",
                    pattern: "{Controller=Login}/{Action=Login}/{Id?}/{Sender?}");
            });
        }
    }
}
