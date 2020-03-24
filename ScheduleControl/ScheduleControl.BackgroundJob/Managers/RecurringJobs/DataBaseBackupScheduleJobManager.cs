using Hangfire;
using ScheduleControl.Business.Abstract.DatabaseOperation;
using System.Threading.Tasks;

namespace ScheduleControl.BackgroundJob.Managers.RecurringJobs
{
    public class DataBaseBackupScheduleJobManager
    {
        private readonly IDatabaseOptionService _databaseOptionService;

        public DataBaseBackupScheduleJobManager(IDatabaseOptionService databaseOptionService)
        {
            _databaseOptionService = databaseOptionService;
        }
  
        public async Task Process()
        {
            //await _databaseOptionService.RestoreDatabase();
            await _databaseOptionService.BackupDatabase();
        }
    }
}