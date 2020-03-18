using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScheduleControl.BackgroundJob;
using ScheduleControl.BackgroundJob.Abstract;
using ScheduleControl.BackgroundJob.Managers;
using ScheduleControl.BackgroundJob.Schedules;
using ScheduleControl.Business.Abstract;
using ScheduleControl.Business.Abstract.Mail;
using ScheduleControl.Business.Concrete.Managers;
using ScheduleControl.Business.Concrete.Managers.Mail;
using ScheduleControl.DataAccess.Abstract;
using ScheduleControl.DataAccess.Concrete.EntityFramework;
using ScheduleControl.DataAccess.Concrete.EntityFramework.Context;
using ScheduleControl.Entities.Dtos.Mail;

namespace ScheduleControl.WebUI
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
            
            var connectionString = Configuration["ConnectionStrings:ScheduleProjectDb"];
            services.AddDbContext<ScheduleProjectDbContext>(option => option.UseSqlServer(connectionString));

            //services.AddHangfire(_ => _.UseSqlServerStorage(Configuration["ConnectionStrings:ScheduleProjectDb"]));
            services.AddHangfire(config =>
            {
                var option = new SqlServerStorageOptions
                {
                    PrepareSchemaIfNecessary = false,
                    QueuePollInterval = TimeSpan.FromMinutes(5)
                };
                config.UseSqlServerStorage(connectionString, option);
            });




            // dependency
            services.AddScoped<ICurrencyService, CurrencyManager>();
            services.AddScoped<ICurrencyDal, EfCurrencyDal>();
            services.AddScoped<IMailService, MailManager>();

            // configuration options
            services.Configure<SmtpConfigDto>(Configuration.GetSection("SmtpConfig"));



            // Schedule servisi



            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            //app.UseHangfireDashboard();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] {new HangfireDashboardAuthorizationFilter()}
            });
            //app.UseHangfireServer();
            app.UseHangfireServer(new BackgroundJobServerOptions
            {
                WorkerCount = 1
            });

             



            app.UseRouting(); 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute{Attempts = 0});

            // ilk basta tanımlayabiliriz.
            BackgroundJob.Schedules.RecurringJobs.CheckCurrencyDataRefresh();

        }
    }
}
