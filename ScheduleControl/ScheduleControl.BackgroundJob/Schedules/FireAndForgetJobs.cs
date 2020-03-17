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
    public static class FireAndForgetJobs
    {
        
        [Obsolete]
        public static void SendMailJobs()
        {
            Hangfire.BackgroundJob.Enqueue<EmailSendingScheduleJobManager>
            (
                job => job.Run(JobCancellationToken.Null)
            );
        }
    }
}
