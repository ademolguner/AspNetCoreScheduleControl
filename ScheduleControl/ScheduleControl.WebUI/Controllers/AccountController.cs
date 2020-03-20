using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScheduleControl.BackgroundJob.Schedules;
using ScheduleControl.Business.Abstract.Auth;
using ScheduleControl.Entities.Dtos.Account;
using ScheduleControl.WebUI.ViewModels;

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
            return View();
        }

        [HttpPost("Register")]
        //[Obsolete]
        public IActionResult Register(AuthViewModel authViewModel)
        {
            // kullanıcı kaydet ve hangfire tetikle
            var user = _authService.Register(authViewModel.UserForRegisterDto);
            DelayedJobs.SendMailRegisterJobs();


            return RedirectToAction("Index", "Home");
        }



        [HttpGet("Login")]
        public PartialViewResult Login()
        {
            return PartialView("Login");
        }

        [HttpPost("Login")]
        public JsonResult Login(AuthViewModel authViewModel)
        {
            ModelState.AddModelError("error", "Hata");
            ViewBag.error = TempData["error"];
            return new JsonResult(ModelState);
        }


        //[HttpGet("UserRegisterCheck")]
        public IActionResult UserRegisterCheck(string reqUrl)
        {
            if (string.IsNullOrEmpty(reqUrl))
                return RedirectToAction("Error","Home");
            _authService.UserActivatedRegister(reqUrl);
            return RedirectToAction("Index","Home");
        }


    }
}