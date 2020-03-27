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
            /*  RemoveIfExists yöntemini çağırarak var olan yinelenen bir işi kaldırabilirsiniz. 
                Böyle tekrar eden bir iş olmadığında bir istisna oluşturmaz */
            RecurringJob.RemoveIfExists(nameof(DataBaseBackupScheduleJobManager));
            RecurringJob.AddOrUpdate<DataBaseBackupScheduleJobManager>(nameof(DataBaseBackupScheduleJobManager),
                job => job.Process(),"59 23 * * *", TimeZoneInfo.Local);
        } 
    }
}


