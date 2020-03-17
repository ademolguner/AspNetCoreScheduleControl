using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using ScheduleControl.BackgroundJob.Abstract;

namespace ScheduleControl.BackgroundJob.Schedules
{
   public  class DataBaseBackupScheduleJob: ISchedulerJob
    {
        public Task Run(IJobCancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task Process(DateTime? dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
