using ScheduleControl.Core.DataAccess.EntityFramework;
using ScheduleControl.DataAccess.Abstract;
using ScheduleControl.DataAccess.Concrete.EntityFramework.Context;
using ScheduleControl.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleControl.DataAccess.Concrete.EntityFramework
{
   public class EfUserDal : EfEntityRepositoryBase<User, ScheduleProjectDbContext>, IUserDal
    {
    }
}
