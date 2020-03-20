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
        public static void SendMailJobs()
        {
            //Hangfire.BackgroundJob.Enqueue<EmailSendingScheduleJobManager>
            //(
            //    job => job.Run(JobCancellationToken.Null)
            //);
            Hangfire.BackgroundJob.Schedule<EmailSendingScheduleJobManager>
                (
                 job => job.Run(JobCancellationToken.Null),
                 TimeSpan.FromSeconds(10)
                 );
        }
        [Obsolete]
        public static void SendMailRegisterJobs()
        {
            //Hangfire.BackgroundJob.Enqueue<UserRegisterScheduleJobManager>
            //(
            //    job => job.Run(JobCancellationToken.Null)
            //);
            Hangfire.BackgroundJob.Schedule<UserRegisterScheduleJobManager>
                 (
                  job => job.Run(JobCancellationToken.Null),
                  TimeSpan.FromSeconds(10)
                  );
        }
    }
}
