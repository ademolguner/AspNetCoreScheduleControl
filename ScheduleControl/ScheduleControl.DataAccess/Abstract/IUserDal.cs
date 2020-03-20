using ScheduleControl.Core.DataAccess;
using ScheduleControl.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleControl.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
