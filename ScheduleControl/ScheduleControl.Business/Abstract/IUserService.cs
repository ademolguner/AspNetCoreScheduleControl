using ScheduleControl.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleControl.Business.Abstract
{
   public interface IUserService
    {
        void Add(User user);
        void Update(User user);
        User GetByMail(string email);
        User UserGetByUniqNumber(Guid userUniqNumber); 
        List<User> GetUnRegisterUsers();
    }
}
