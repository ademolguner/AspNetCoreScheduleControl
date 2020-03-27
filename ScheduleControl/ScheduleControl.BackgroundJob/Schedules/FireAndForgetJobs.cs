using ScheduleControl.BackgroundJob.Managers.FireAndForgetJobs;
using ScheduleControl.Entities.Dtos.Mail;
using System;

namespace ScheduleControl.BackgroundJob.Schedules
{
    /// <summary>
    /// Bir kere ve hemen çalışan background job tipidir. 
    /// </summary>
    public static class FireAndForgetJobs
    {
        [Obsolete]
        public static void GetCurrencyJob()
        {
            var jobId = Hangfire.BackgroundJob.Enqueue<CurrencyScheduleJobManager>(
                        job => job.Process()
                        );
            ContinuationJobs.GetMyFinancialCashUpdate(jobId);
        }




        [Obsolete]
        public static void SendMailJob(MailMessageDto mailMessageDto)
        {
            Hangfire.BackgroundJob.Enqueue<EmailSendingScheduleJobManager>
                (
                 job => job.Process(mailMessageDto)
                 );
        }

    }
}