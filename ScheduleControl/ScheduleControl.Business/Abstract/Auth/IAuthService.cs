using ScheduleControl.Entities.Dtos.Account;
using ScheduleControl.Entities.Models;

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