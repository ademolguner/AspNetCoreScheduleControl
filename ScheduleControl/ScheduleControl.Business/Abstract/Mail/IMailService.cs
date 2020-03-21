using ScheduleControl.Entities.Dtos.Mail;
using System.Threading.Tasks;

namespace ScheduleControl.Business.Abstract.Mail
{
    public interface IMailService
    {
        Task SendMailAsync(MailMessageDto mailMessageDto);

        Task SendUserRegisterMailAsync(int userId);
    }
}