using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ScheduleControl.Business.Abstract.Mail;
using ScheduleControl.Entities.Dtos.Mail;

namespace ScheduleControl.Business.Concrete.Managers.Mail
{
    public class MailManager : IMailService
    {
        private readonly SmtpConfigDto _smtpConfigDto;
        public MailManager(IOptions<SmtpConfigDto> options)
        {
            _smtpConfigDto = options.Value;
        }

        public async Task SendMailAsync(MailMessageDto mailMessageDto)
        { 
                MailMessage mailMessage = mailMessageDto.GetMailMessage();
                mailMessage.From = new MailAddress(_smtpConfigDto.User);

                using var client = CreateSmtpClient();
                await client.SendMailAsync(mailMessage);
        }

        private SmtpClient CreateSmtpClient()
        {
            SmtpClient smtp= new SmtpClient(_smtpConfigDto.Host, _smtpConfigDto.Port);
            smtp.Credentials=new NetworkCredential(_smtpConfigDto.User, _smtpConfigDto.Password);
            smtp.EnableSsl = _smtpConfigDto.UseSsl;
            return smtp;
        }
    }
}
