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

            //SmtpClient sc = new SmtpClient
            //{
            //    Port = 587,
            //    Host = "smtp.gmail.com",
            //    EnableSsl = true,
            //    Credentials = new NetworkCredential("denemebir@mail.com", "mailsifre")
            //};

            //MailMessage mail = new MailMessage();

            //mail.From = new MailAddress("ademolguner@gmail.com", "Adem Hangfire Mail");

            //mail.To.Add("ademolguner@gmail.com");
            //mail.CC.Add("ademolguner@gmail.com");

            //mail.Subject = "Adem Medium Hangfire Mail";
            //mail.IsBodyHtml = true;
            //mail.Body = "Adem Medium Hangfire Mail E-Posta İçeriği";
            //try
            //{
            //    sc.Send(mail);
            //    await Task.FromResult("Mail Gönderildi");
            //}
            //catch (Exception)
            //{
            //    await Task.FromException(new Exception("Mail Gönderildiği esnada hata oldu"));
            //}
        }
    }
}
