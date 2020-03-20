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
        public static void DatabaseBackupOperation()
        {
            Hangfire.BackgroundJob.Schedule<DataBaseBackupScheduleJobManager>
                 (
                  job => job.Run(JobCancellationToken.Null),
                  TimeSpan.FromSeconds(10)
                  );
        }
    }
}
