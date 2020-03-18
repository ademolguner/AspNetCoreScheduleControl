using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hangfire;

namespace ScheduleControl.BackgroundJob.Abstract
{
   public  interface ISchedulerJob
   {
       Task Run(IJobCancellationToken token);
       Task Process();
   }
}
