using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleControl.BackgroundJob.Managers
{
    public static class ContinuationJobManager
    {

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
