using ScheduleControl.Business.Abstract;
using ScheduleControl.Business.Abstract.Auth;
using ScheduleControl.Entities.Dtos.Account;
using ScheduleControl.Entities.Models;
using System;

namespace ScheduleControl.Business.Concrete.Managers.Auth
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public User Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.Logining(userForLoginDto.Email, userForLoginDto.Password);
            if (userToCheck == null)
            {
                throw new Exception("hata metni");
            }
            return userToCheck;
        }

        public User Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCheck = UserExists(userForRegisterDto.Email);
            if (userToCheck)
            {
                var user = new User
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    Password = userForRegisterDto.Password,
                    Status = false,
                    UserGuid = Guid.NewGuid(),
                    IsActivatedMailSend = false
                };
                _userService.Add(user);
                return user;
            }
            throw new Exception("Bu mail adresi ile kullanıcı kayıtlı  !!!");
        }

        public bool UserActivatedRegister(string userMailUrl)
        {
            Guid userUniqNumber = Guid.Parse(userMailUrl.Split("*")[1]);
            var userInfo = _userService.UserGetByUniqNumber(userUniqNumber);
            if (userInfo != null)
            {
                userInfo.IsActivatedMailSend = true;
                userInfo.Status = true;
                _userService.Update(userInfo);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return false;
            }
            return true;
        }
    }
}