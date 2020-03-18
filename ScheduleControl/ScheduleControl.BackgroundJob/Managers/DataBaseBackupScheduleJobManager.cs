using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using ScheduleControl.BackgroundJob.Abstract;

namespace ScheduleControl.BackgroundJob.Managers
{
   public  class DataBaseBackupScheduleJobManager: ISchedulerJob
    {
        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await Process();
        }

        public  Task Process()
        {
            throw new NotImplementedException();
        }
    }
}
