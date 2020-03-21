using ScheduleControl.BackgroundJob.Managers;
using System;

namespace ScheduleControl.BackgroundJob.Schedules
{
    public static class ContinuationJobs
    {
        /// <summary>
        /// Birbiri ile ilişkili işlerin olduğu zaman çalışan job. Job tetiklenmesi için başka bir job bitmesi gerekiyor
        /// BackgroundJob.ContinueWith(jobId,() => Console.WriteLine("Continuation!"));
        /// </summary>
        /// <param name="id"></param>
        [Obsolete]
        public static void GetMyFinancialCashUpdate(string id)
        {
            Hangfire.BackgroundJob.ContinueJobWith<FinancialCashScheduleJobManager>(
                           parentId: id,
                           job => job.Process());
        }

        //Hangfire.BackgroundJob.Schedule<DataBaseBackupScheduleJobManager>
        //         (
        //          job => job.Run(JobCancellationToken.Null),
        //          TimeSpan.FromDays(1)
        //          );

        //CurrencyScheduleJobManager

        //Cron.MinuteInterval(2), TimeZoneInfo.Local);

        //[Obsolete]
        //public static void CheckCurrencyDataRefresh()
        //{
        //}
    }
}