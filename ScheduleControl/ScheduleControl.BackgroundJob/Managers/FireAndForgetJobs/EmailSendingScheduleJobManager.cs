using ScheduleControl.Business.Abstract.Mail;
using ScheduleControl.Entities.Dtos.Mail;
using System;
using System.Threading.Tasks;

namespace ScheduleControl.BackgroundJob.Managers.FireAndForgetJobs
{
    public class EmailSendingScheduleJobManager
    {
        private readonly IMailService _mailService;

        public EmailSendingScheduleJobManager(IMailService mailService)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        public async Task Process(MailMessageDto mailMessageDto)
        {
            await _mailService.SendMailAsync(mailMessageDto);
        }
    }
}