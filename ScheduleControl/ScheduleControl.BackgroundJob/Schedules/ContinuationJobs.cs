using System;

namespace ScheduleControl.BackgroundJob.Schedules
{
    public static class ContinuationJobs
    {
        /// <summary>
        /// Bir kere ve hemen çalışan job türüdür.
        /// </summary>
        /// <param name="id"></param>
        [Obsolete]
        public static void ExampleOneSynchronization(string id)
        {
            Hangfire.BackgroundJob.ContinueJobWith(
                           parentId: id, 
                           () => Console.WriteLine("Continuation!"));
        }

        public static void ExampleTwoSynchronization(string id)
        {
            Hangfire.BackgroundJob.ContinueJobWith(
                parentId: id,
                () => Console.WriteLine("Continuation!"));
        }
    }
}
