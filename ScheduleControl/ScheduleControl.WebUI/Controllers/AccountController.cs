using Microsoft.AspNetCore.Mvc;
using ScheduleControl.BackgroundJob.Schedules;
using ScheduleControl.Business.Abstract.Auth;
using ScheduleControl.Entities.Dtos.Account;
using ScheduleControl.WebUI.ViewModels;
using System;

namespace ScheduleControl.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            var data = new AuthViewModel() { UserForLoginDto = new UserForLoginDto(), UserForRegisterDto = new UserForRegisterDto() };
            return PartialView("_Register",data);
        }

        [HttpPost("Register")]
        [Obsolete]
        public IActionResult Register(AuthViewModel authViewModel)
        {
            var user = _authService.Register(authViewModel.UserForRegisterDto);
            DelayedJobs.SendMailRegisterJobs(user.UserId);
            return RedirectToAction("Index", "Home");
        }




        [HttpGet("Login")]
        public PartialViewResult Login()
        {
            //return PartialView("Login");
            return PartialView("Login", new AuthViewModel());
        }

        [HttpPost("Login")]
        public IActionResult Login(AuthViewModel authViewModel)
        {
            var user = _authService.Login(authViewModel.UserForLoginDto);
            return RedirectToAction("Index", "Home");
        }

        //[HttpGet("UserRegisterCheck")]
        public IActionResult UserRegisterCheck(string reqUrl)
        {
            if (string.IsNullOrEmpty(reqUrl))
                return RedirectToAction("Error", "Home");
            _authService.UserActivatedRegister(reqUrl);
            return RedirectToAction("Index", "Home");
        }
    }
}