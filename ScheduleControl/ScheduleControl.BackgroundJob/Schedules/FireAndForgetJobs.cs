using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading;
using Hangfire;
using Newtonsoft.Json;
using ScheduleControl.BackgroundJob.Managers;
using ScheduleControl.BackgroundJob.Schedules;

namespace ScheduleControl.BackgroundJob.Schedules
{
    /// <summary>
    /// Bir keree ve hemen çalışan background job tipidir.
    /// </summary>
    public static class FireAndForgetJobs
    {
        [Obsolete]
        public static void CheckCurrencyDataRefresh()
        {
            RecurringJob.RemoveIfExists(nameof(CurrencyScheduleJobManager));
            RecurringJob.AddOrUpdate<CurrencyScheduleJobManager>(nameof(CurrencyScheduleJobManager),
                job => job.Run(JobCancellationToken.Null),
                Cron.Daily(6), TimeZoneInfo.Local);
            //Cron.MinuteInterval(2), TimeZoneInfo.Local);
        }
        
    }
}
