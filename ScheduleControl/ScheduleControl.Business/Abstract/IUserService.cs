using ScheduleControl.Entities.Models;
using System;
using System.Collections.Generic;

namespace ScheduleControl.Business.Abstract
{
    public interface IUserService
    {
        User GetByUserId(int userId);

        void Add(User user);

        void Update(User user);

        User GetByMail(string email);

        User UserGetByUniqNumber(Guid userUniqNumber);

        List<User> GetUnRegisterUsers();

        User Logining(string mail, string password);
    }
}