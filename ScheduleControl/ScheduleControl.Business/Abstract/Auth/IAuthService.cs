using ScheduleControl.Entities.Dtos.Account;
using ScheduleControl.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleControl.Business.Abstract.Auth
{
   public interface IAuthService
    {
        User Register(UserForRegisterDto userForRegisterDto);

        User Login(UserForLoginDto userForLoginDto);

        bool UserExists(string email);
        bool UserActivatedRegister(string userMailUrl);
    }
}
