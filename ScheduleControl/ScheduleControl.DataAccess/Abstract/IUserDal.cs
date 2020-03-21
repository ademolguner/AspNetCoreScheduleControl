using ScheduleControl.Core.DataAccess;
using ScheduleControl.Entities.Models;

namespace ScheduleControl.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}