using System;
using System.Collections.Generic;
using System.Text;
using ScheduleControl.Core.DataAccess;
using ScheduleControl.Entities.Models;

namespace ScheduleControl.DataAccess.Abstract
{
    public interface ICurrencyDal : IEntityRepository<Currency>
    {
    }
}
