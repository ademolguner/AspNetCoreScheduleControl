using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using ScheduleControl.BackgroundJob.Abstract;
using ScheduleControl.Business.Abstract.DatabaseOperation;

namespace ScheduleControl.BackgroundJob.Managers
{
   public  class DataBaseBackupScheduleJobManager: ISchedulerJob
    {
        private readonly IDatabaseOptionService _databaseOptionService;
        public DataBaseBackupScheduleJobManager(IDatabaseOptionService databaseOptionService)
        {
            _databaseOptionService = databaseOptionService;
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await Process();
        }

        public async Task Process()
        {
            await _databaseOptionService.RestoreDatabase();
            await _databaseOptionService.BackupDatabase();
        }
    }
}
