using ScheduleControl.Entities.Dtos.Account;

namespace ScheduleControl.WebUI.ViewModels
{
    public class AuthViewModel
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public UserForRegisterDto UserForRegisterDto { get; set; }
    }
}