using Hangfire;
using ScheduleControl.BackgroundJob.Managers;
using System;

namespace ScheduleControl.BackgroundJob.Schedules
{
    public static class ContinuationJobs
    {
        /// <summary>
        /// Birbiri ile ilişkili işlerin olduğu zaman çalışan job. Job tetiklenmesi için başka bir job bitmesi gerekiyor
        /// </summary>
        /// <param name="id">İlişkili job id değeri</param>
        [Obsolete]
        [AutomaticRetry(Attempts = 7)]
        public static void GetMyFinancialCashUpdate(string id)
        {
            Hangfire.BackgroundJob.ContinueJobWith<FinancialCashScheduleJobManager>(
                           parentId: id,
                           job => job.Process());
        } 
        // farklı işler yapan metotları burada tanımlayabiliriz. tabi  ContinuationJobs  türünde çalışan
    }
}


