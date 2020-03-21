using ScheduleControl.BackgroundJob.Managers.DelayedJobs;
using System;

namespace ScheduleControl.BackgroundJob.Schedules
{
    /// <summary>
    /// Oluşturulduktan belirli bir zaman sonra (ayarlanan) sadece tek seferliğine çalışan job türüdür.
    /// var jobId = BackgroundJob.Schedule(() => Console.WriteLine("Delayed!"),TimeSpan.FromDays(7));
    /// </summary>
    public static class DelayedJobs
    {
        [Obsolete]
        public static void SendMailRegisterJobs(int userId)
        {
            Hangfire.BackgroundJob.Schedule<UserRegisterScheduleJobManager>
                 (
                  job => job.Process(userId),
                  TimeSpan.FromMinutes(1)
                  );
        }
    }
}