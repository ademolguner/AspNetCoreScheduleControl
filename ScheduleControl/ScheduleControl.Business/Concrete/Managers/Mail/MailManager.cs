using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ScheduleControl.Business.Abstract;
using ScheduleControl.Business.Abstract.Mail;
using ScheduleControl.Entities.Dtos.Mail;

namespace ScheduleControl.Business.Concrete.Managers.Mail
{
    public class MailManager : IMailService
    {
        private readonly SmtpConfigDto _smtpConfigDto;
        private readonly IUserService _userService;

        public MailManager(IOptions<SmtpConfigDto> options, IUserService userService)
        {
            _smtpConfigDto = options.Value;
            _userService = userService;
        }

        public async Task SendMailAsync(MailMessageDto mailMessageDto)
        { 
                MailMessage mailMessage = mailMessageDto.GetMailMessage();
                mailMessage.From = new MailAddress(_smtpConfigDto.User);

                using var client = CreateSmtpClient();
                await client.SendMailAsync(mailMessage);
        }

        public async Task SendUserRegisterMailAsync()//MailMessageDto mailMessageDto
        {
            using var client = CreateSmtpClient();
            var userList = _userService.GetUnRegisterUsers();
            foreach (var userItem in userList)
            {
                MailMessageDto mailMessageDto = new MailMessageDto
                {
                    Body = "Kayıt işleminizi tamamlamak için  "+ "<a href='https://localhost:44395/Account/UserRegisterCheck?reqUrl=*" + userItem.UserGuid.ToString() + "'>linke</a> tıklayınız.",
                    To = userItem.Email,
                    Subject = "Kullanıcı Register Islemi Kontrol",
                    From= _smtpConfigDto.User
                };
                MailMessage mailMessage = mailMessageDto.GetMailMessage();
                mailMessage.IsBodyHtml = true;
                //mailMessage.From = new MailAddress(_smtpConfigDto.User);
                // burada register mailleri kişi kişi gönderilecek
                // HttpContext.Current.Request.RawUrl
                await client.SendMailAsync(mailMessage);
            } 
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
