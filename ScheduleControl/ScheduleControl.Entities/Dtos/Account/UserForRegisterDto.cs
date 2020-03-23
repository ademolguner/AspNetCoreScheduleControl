using System.ComponentModel.DataAnnotations;

namespace ScheduleControl.Entities.Dtos.Account
{
    public class UserForRegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}