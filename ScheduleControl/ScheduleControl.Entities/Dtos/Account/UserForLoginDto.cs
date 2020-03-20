using ScheduleControl.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleControl.Entities.Dtos.Account
{
   public class UserForLoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
