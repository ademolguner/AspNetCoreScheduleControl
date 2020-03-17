using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using ScheduleControl.BackgroundJob.Schedules;

namespace ScheduleControl.BackgroundJob.Managers
{
    public static class DelayedJobManager
    {

         
        [Obsolete]
        public static void CreatedDailyReport()
        {
             Hangfire.BackgroundJob.Schedule<DataBaseBackupScheduleJob>
                  (
                   job => job.Run(JobCancellationToken.Null), 
                   TimeSpan.FromSeconds(10)
                   );
        }
    }
}
