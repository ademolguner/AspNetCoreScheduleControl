using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;
using ScheduleControl.BackgroundJob.Managers;
using ScheduleControl.BackgroundJob.Schedules;

namespace ScheduleControl.BackgroundJob.Schedules
{
    /// <summary>
    /// Çok kez (tekrarlı işler) ve belirtilmiş CRON süresince çalışır
    /// </summary>
    public static class RecurringJobs
    {
       
        [Obsolete]
        public static void CheckCurrencyDataRefresh()
        {
            RecurringJob.RemoveIfExists(nameof(CurrencyScheduleJobManager));
            RecurringJob.AddOrUpdate<CurrencyScheduleJobManager>(nameof(CurrencyScheduleJobManager),
                job => job.Run(JobCancellationToken.Null),
                // Cron.Daily(6), TimeZoneInfo.Local);
                Cron.MinuteInterval(2), TimeZoneInfo.Local);
        }

    }
}
