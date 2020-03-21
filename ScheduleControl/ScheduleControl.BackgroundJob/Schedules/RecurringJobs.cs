using Hangfire;
using ScheduleControl.BackgroundJob.Managers.RecurringJobs;
using System;

namespace ScheduleControl.BackgroundJob.Schedules
{
    /// <summary>
    /// Çok kez (tekrarlı işler) ve belirtilmiş CRON süresince çalışır
    /// </summary>
    public static class RecurringJobs
    {
        [Obsolete]
        public static void DatabaseBackupOperation()
        {
            RecurringJob.RemoveIfExists(nameof(DataBaseBackupScheduleJobManager));
            RecurringJob.AddOrUpdate<DataBaseBackupScheduleJobManager>(nameof(DataBaseBackupScheduleJobManager),
                job => job.Process(),   //job => job.Run(JobCancellationToken.Null),
                Cron.Daily(1), TimeZoneInfo.Local);
        }
    }
}