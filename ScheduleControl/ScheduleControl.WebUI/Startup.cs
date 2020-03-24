using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScheduleControl.BackgroundJob;
using ScheduleControl.Business.Abstract;
using ScheduleControl.Business.Abstract.Auth;
using ScheduleControl.Business.Abstract.DatabaseOperation;
using ScheduleControl.Business.Abstract.Mail;
using ScheduleControl.Business.Concrete.Managers;
using ScheduleControl.Business.Concrete.Managers.Auth;
using ScheduleControl.Business.Concrete.Managers.DatabaseOperation;
using ScheduleControl.Business.Concrete.Managers.Mail;
using ScheduleControl.DataAccess.Abstract;
using ScheduleControl.DataAccess.Concrete.EntityFramework;
using ScheduleControl.DataAccess.Concrete.EntityFramework.Context;
using ScheduleControl.Entities.Dtos.Database;
using ScheduleControl.Entities.Dtos.Mail;
using System;

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
            var connectionString = Configuration["ConnectionStrings:ProjectDev"];
            var hangfireConnectionString = Configuration["ConnectionStrings:HangfireDev"];
            services.AddDbContext<ScheduleProjectDbContext>(option => option.UseSqlServer(connectionString));

            services.AddHangfire(config =>
            {
                var option = new SqlServerStorageOptions
                {
                    PrepareSchemaIfNecessary = true,
                    QueuePollInterval = TimeSpan.FromMinutes(5)
                };
                config.UseSqlServerStorage(hangfireConnectionString, option);
                //.UseSqlServerStorage("db_connection", new SqlServerStorageOptions
                // {
                //     CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                //     SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                //     QueuePollInterval = TimeSpan.Zero,
                //     UseRecommendedIsolationLevel = true,
                //     UsePageLocksOnDequeue = true,
                //     DisableGlobalLocks = true
                // });
            });

            // dependency
            services.AddScoped<ICurrencyService, CurrencyManager>();
            services.AddScoped<ICurrencyDal, EfCurrencyDal>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserDal>();

            services.AddScoped<ICashboxService, CashboxManager>();
            services.AddScoped<ICashboxDal, EfCashboxDal>();

            services.AddScoped<ICashTypeService, CashTypeManager>();
            services.AddScoped<ICashTypeDal, EfCashTypeDal>();


            services.AddScoped<IFinancialCashService, FinancialCashManager>();
            services.AddScoped<IFinancialCashDal, EfFinancialCashDal>();

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IMailService, MailManager>();
            services.AddScoped<IDatabaseOptionService, DatabaseOptionManager>();

            // configuration options
            services.Configure<SmtpConfigDto>(Configuration.GetSection("SmtpConfig"));
            services.Configure<DatabaseOptionDto>(Configuration.GetSection("DatabaseOption"));

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
                Authorization = new[] { new HangfireDashboardAuthorizationFilter() }
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

            GlobalJobFilters.Filters.Add(new AutomaticRetryAttribute { Attempts = 0 });

            // ilk basta tanımlayabiliriz.
            BackgroundJob.Schedules.RecurringJobs.DatabaseBackupOperation();
        }
    }
}