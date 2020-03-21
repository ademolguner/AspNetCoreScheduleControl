using ScheduleControl.Core.Entities;

namespace ScheduleControl.Entities.Dtos.Database
{
    public class DatabaseOptionDto : IDto
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string BackupPath { get; set; }
        public string RestorePath { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IntegratedSecurity { get; set; }
    }
}