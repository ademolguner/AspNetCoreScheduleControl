using Hangfire;
using ScheduleControl.BackgroundJob.Abstract;
using ScheduleControl.Business.Abstract.Auth;
using ScheduleControl.Business.Abstract.Mail;
using ScheduleControl.Entities.Dtos.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleControl.BackgroundJob.Managers
{
    public class UserRegisterScheduleJobManager : ISchedulerJob
    {
        private readonly IAuthService _authService;
        private readonly IMailService _mailService;
        public UserRegisterScheduleJobManager(IAuthService authService, IMailService mailService)
        {
            _authService = authService;
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }
        
        

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await Process();
        }

        public async Task Process()
        {
            await _mailService.SendUserRegisterMailAsync();
        }
    }
}
