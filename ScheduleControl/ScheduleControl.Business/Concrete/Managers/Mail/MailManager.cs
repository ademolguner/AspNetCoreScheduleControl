using Microsoft.Extensions.Options;
using ScheduleControl.Business.Abstract;
using ScheduleControl.Business.Abstract.Mail;
using ScheduleControl.Entities.Dtos.Mail;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

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

        public async Task SendUserRegisterMailAsync(int userId)
        {
            using var client = CreateSmtpClient();
            var userInfo = _userService.GetByUserId(userId);

            MailMessageDto mailMessageDto = new MailMessageDto
            {
                Body = "Kayıt işleminizi tamamlamak için  " 
                     + "<a href='https://aktiflinkadresi/Account/UserRegisterCheck?reqUrl=*" 
                     + userInfo.UserGuid.ToString() + "'>linke</a> tıklayınız.",
                To = userInfo.Email,
                Subject = "Kullanıcı Register Islemi Kontrol",
                From = _smtpConfigDto.User
            };
            MailMessage mailMessage = mailMessageDto.GetMailMessage();
            mailMessage.IsBodyHtml = true;
            await client.SendMailAsync(mailMessage);
        }

        private SmtpClient CreateSmtpClient()
        {
            SmtpClient smtp = new SmtpClient(_smtpConfigDto.Host, _smtpConfigDto.Port);
            smtp.Credentials = new NetworkCredential(_smtpConfigDto.User, _smtpConfigDto.Password);
            smtp.EnableSsl = _smtpConfigDto.UseSsl;
            return smtp;
        }



        public async Task SendMailAsync(MailMessageDto mailMessageDto)
        {
            MailMessage mailMessage = mailMessageDto.GetMailMessage();
            mailMessage.From = new MailAddress(_smtpConfigDto.User);

            using var client = CreateSmtpClient();
            await client.SendMailAsync(mailMessage);
        }
    }
}