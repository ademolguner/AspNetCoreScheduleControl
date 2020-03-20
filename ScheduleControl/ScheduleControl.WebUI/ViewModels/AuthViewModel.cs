using ScheduleControl.Entities.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleControl.WebUI.ViewModels
{
    public class AuthViewModel
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public UserForRegisterDto UserForRegisterDto { get; set; }
    }
}
