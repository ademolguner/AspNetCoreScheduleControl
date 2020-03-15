using System;
using System.Collections.Generic;
using System.Text;
using Hangfire;
using ScheduleControl.BackgroundJob.Schedules;

namespace ScheduleControl.BackgroundJob
{
   public static class HangfireJobScheduler
    {
        [Obsolete]
        public static void ScheduleRecurringJob()
        {
            RecurringJob.RemoveIfExists(nameof(EmailSendingScheduleJob));
            RecurringJob.AddOrUpdate<EmailSendingScheduleJob>(nameof(EmailSendingScheduleJob),
                job => job.Run(JobCancellationToken.Null),
                Cron.MinuteInterval(5), TimeZoneInfo.Local);


            RecurringJob.RemoveIfExists(nameof(CurrencyScheduleJob));
            RecurringJob.AddOrUpdate<CurrencyScheduleJob>(nameof(CurrencyScheduleJob),
                job => job.Run(JobCancellationToken.Null),
                //Cron.MinuteInterval(5), TimeZoneInfo.Local);
            Cron.Daily(6), TimeZoneInfo.Local);
        }
    }
}
