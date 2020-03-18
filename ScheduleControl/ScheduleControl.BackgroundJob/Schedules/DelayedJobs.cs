using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using ScheduleControl.BackgroundJob.Managers;
using ScheduleControl.BackgroundJob.Schedules;

namespace ScheduleControl.BackgroundJob.Schedules
{
    /// <summary>
    /// Oluşturulduktan belirli bir zaman sonra (ayarlanan) sadece tek seferliğine çalışan job türüdür.
    /// </summary>
    public static class DelayedJobs
    {

         
        [Obsolete]
        public static void CreatedDailyReport()
        {
             Hangfire.BackgroundJob.Schedule<DataBaseBackupScheduleJobManager>
                  (
                   job => job.Run(JobCancellationToken.Null), 
                   TimeSpan.FromSeconds(10)
                   );
        }
    }
}
