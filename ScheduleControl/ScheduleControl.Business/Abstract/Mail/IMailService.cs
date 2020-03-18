using System.Threading.Tasks;
using ScheduleControl.Entities.Dtos;
using ScheduleControl.Entities.Dtos.Mail;

namespace ScheduleControl.Business.Abstract.Mail
{
    public interface IMailService
    {
        Task SendMailAsync(MailMessageDto mailMessageDto);
    }

}
