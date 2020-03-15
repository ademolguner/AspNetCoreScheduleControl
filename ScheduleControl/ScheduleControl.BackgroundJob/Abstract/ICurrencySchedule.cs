using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleControl.BackgroundJob.Abstract
{
   public interface ICurrencySchedule
   {
       Task RunArTimeOf(DateTime nowDateTime);
   }
}
