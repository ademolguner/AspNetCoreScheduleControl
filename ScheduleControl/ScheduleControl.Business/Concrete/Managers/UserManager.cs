using ScheduleControl.Business.Abstract;
using ScheduleControl.DataAccess.Abstract;
using ScheduleControl.Entities.Models;
using System;
using System.Collections.Generic;

namespace ScheduleControl.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public User UserGetByUniqNumber(Guid userUniqNumber)
        {
            return _userDal.Get(u => u.UserGuid == userUniqNumber);
        }

        public List<User> GetUnRegisterUsers()
        {
            return _userDal.GetList(u => u.IsActivatedMailSend == false && u.Status == false);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public User GetByUserId(int userId)
        {
            return _userDal.Get(u => u.UserId == userId);
        }

        public User Logining(string mail, string password)
        {
            return _userDal.Get(u => u.Email == mail && u.Password==password);
        }
    }
}