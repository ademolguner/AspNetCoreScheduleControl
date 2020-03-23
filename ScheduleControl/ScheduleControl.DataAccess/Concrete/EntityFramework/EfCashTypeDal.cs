using ScheduleControl.Core.DataAccess.EntityFramework;
using ScheduleControl.DataAccess.Abstract;
using ScheduleControl.DataAccess.Concrete.EntityFramework.Context;
using ScheduleControl.Entities.Models;

namespace ScheduleControl.DataAccess.Concrete.EntityFramework
{
    //class EfCaseTypeDal
    public class EfCashTypeDal : EfEntityRepositoryBase<CashType, ScheduleProjectDbContext>, ICashTypeDal
    {
    }
}