using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading;
using Hangfire;
using Newtonsoft.Json;
using ScheduleControl.BackgroundJob.Schedules;

namespace ScheduleControl.BackgroundJob.Managers
{
  public static  class ScheduleFireAndForgetJobs
    {
        /// <summary>
        /// İş tanımlanır ve hemen ardından bir kereye mahsus tetiklenir.
        /// </summary>
        [Obsolete]
        public static void SendMailJobs()
        {
            RecurringJob.RemoveIfExists(nameof(EmailSendingScheduleJob));
            RecurringJob.AddOrUpdate<EmailSendingScheduleJob>(nameof(EmailSendingScheduleJob),
                job =>  job.Run(JobCancellationToken.Null), //job.SendingAsync(),//
                cronExpression: Cron.MinuteInterval(5),
                timeZone: TimeZoneInfo.Local,
                queue: "adem"//JsonConvert.SerializeObject(mail)
            );
             
        }
    }
}
