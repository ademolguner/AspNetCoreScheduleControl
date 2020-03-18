using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Logging;
using ScheduleControl.BackgroundJob.Abstract;
using ScheduleControl.Business.Abstract.Mail;
using ScheduleControl.Entities.Dtos.Mail;

namespace ScheduleControl.BackgroundJob.Managers
{
    public  class EmailSendingScheduleJobManager : ISchedulerJob
    {
        private readonly IMailService _mailService;
        public EmailSendingScheduleJobManager(IMailService mailService)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }   
        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await Process();
        }

        public async Task Process()
        {
           await _mailService.SendMailAsync(new MailMessageDto
            {
                Body = "Adem Medium Hangfire Mail E-Posta İçeriği",
                To = "ademolguner@gmail.com",
                Subject = "Adem Medium Hangfire Mail",
                From="ademolguner@gmail.com"
            }); 
        }
    }
}
