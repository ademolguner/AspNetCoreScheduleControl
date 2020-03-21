using ScheduleControl.Business.Abstract.Auth;
using ScheduleControl.Business.Abstract.Mail;
using System;
using System.Threading.Tasks;

namespace ScheduleControl.BackgroundJob.Managers.DelayedJobs
{
    public class UserRegisterScheduleJobManager
    {
        private readonly IAuthService _authService;
        private readonly IMailService _mailService;

        public UserRegisterScheduleJobManager(IAuthService authService, IMailService mailService)
        {
            _authService = authService;
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        public async Task Process(int userId)
        {
            await _mailService.SendUserRegisterMailAsync(userId);
        }
    }
}