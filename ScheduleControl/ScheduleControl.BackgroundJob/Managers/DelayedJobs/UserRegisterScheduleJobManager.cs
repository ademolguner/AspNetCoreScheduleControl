using ScheduleControl.Business.Abstract.Mail;
using System;
using System.Threading.Tasks;

namespace ScheduleControl.BackgroundJob.Managers.DelayedJobs
{
    public class UserRegisterScheduleJobManager
    {
        private readonly IMailService _mailService;

        public UserRegisterScheduleJobManager(IMailService mailService)
        {
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        public async Task Process(int userId)
        {
            await _mailService.SendUserRegisterMailAsync(userId);
        }
    }
}