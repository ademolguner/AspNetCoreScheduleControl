using ScheduleControl.Core.Entities;

namespace ScheduleControl.Entities.Dtos.Mail
{
    public class SmtpConfigDto : IDto
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool UseSsl { get; set; }
    }
}