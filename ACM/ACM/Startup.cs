using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACM.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ACM.Services;

namespace ACM
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services
                .AddIdentity<ACMUser, IdentityRole>()
                .AddEntityFrameworkStores<ACMDbContext>()
                .AddDefaultTokenProviders();

            services
                .Configure<IdentityOptions>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 1;
                }
                );
               
            services.AddDbContext<ACMDbContext>(options =>
                options.UseSqlServer(
                    MagicStrings.DBConnectionString));

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ICodeService, CodeService>();
            services.AddTransient<IIPService, IPService>();
            services.AddTransient<IHomeownerService, HomeownerSevice>();
            services.AddTransient<IBillService, BillService>();
            services.AddTransient<IApartmentServise, ApartmentService>();
            services.AddTransient<ISpendingService, SpendingService>();
            services.AddTransient<IMeetingsService, MeetingsService>();
            services.AddTransient<ISummaryService, SummaryService>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ACMDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                if (!roleManager.RoleExistsAsync(MagicStrings.AdminString).Result)
                {
                    roleManager.CreateAsync(new IdentityRole(MagicStrings.AdminString)).Wait();
                }
            }

            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
