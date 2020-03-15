using ScheduleControl.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using ScheduleControl.Core.DataAccess.EntityFramework;
using ScheduleControl.DataAccess.Concrete.EntityFramework.Context;
using ScheduleControl.Entities.Models;

namespace ScheduleControl.DataAccess.Concrete.EntityFramework
{
    public class EfCurrencyDal : EfEntityRepositoryBase<Currency, ScheduleProjectDbContext>, ICurrencyDal
    {
    }
}
