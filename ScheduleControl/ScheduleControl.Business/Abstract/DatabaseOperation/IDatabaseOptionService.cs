using System.Threading.Tasks;

namespace ScheduleControl.Business.Abstract.DatabaseOperation
{
    public interface IDatabaseOptionService
    {
        Task BackupDatabase();

        Task RestoreDatabase();
    }
}