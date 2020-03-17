using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;
using ScheduleControl.BackgroundJob.Schedules;

namespace ScheduleControl.BackgroundJob.Managers
{
    public static class RecurringJobManager
    {

        [Obsolete]
        public static void CheckCurrencyDataRefresh()
        {
            RecurringJob.RemoveIfExists(nameof(CurrencyScheduleJob));
            RecurringJob.AddOrUpdate<CurrencyScheduleJob>(nameof(CurrencyScheduleJob),
                job => job.Run(JobCancellationToken.Null),
                Cron.Daily(6), TimeZoneInfo.Local);
        }

    }
}
