using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleControl.BackgroundJob.Abstract
{
   public interface IEmailSendingSchedule
   {
       Task SendingAsync(MailMessage mailMessage);
   }
}
