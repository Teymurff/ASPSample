using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using P310_ASP_Start.DAL;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P310_ASP_Start.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using Microsoft.AspNetCore.Identity.UI.Services;
using P310_ASP_Start.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Org.BouncyCastle.Utilities;

namespace P310_ASP_Start
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession(opts =>
            {
                opts.IdleTimeout = TimeSpan.FromMinutes(30);
                opts.Cookie.IsEssential = true;
            });


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options => {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(100);

                options.SlidingExpiration = true;
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<EliteContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 3;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 7;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            //lifetime of services
            //AddTransient - each time new instance
            //AddScoped - 
            //AddSingleton

            services.AddSingleton<IEmailSender, EmailSender>(e => new EmailSender(
                _configuration["EmailSettings:Host"],
                _configuration.GetValue<int>("EmailSettings:Port"),
                _configuration.GetValue<bool>("EmailSettings:SSL"),
                _configuration["EmailSettings:Username"],
                _configuration["EmailSettings:Password"]
            ));

            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddDbContext<EliteContext>(options =>
            {
                options.UseSqlServer(_configuration["Data:ConnectionStrings:Test"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(router =>
            {
                router.MapRoute(
                 name: "areas",
                 template: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );

                router.MapRoute("default", "{controller=home}/{action=index}/{id?}");
            });


        }


    }
}
