using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScheduleControl.BackgroundJob.Schedules;
using ScheduleControl.Entities.Dtos.Mail;
using ScheduleControl.WebUI.Models;
using System;
using System.Diagnostics;

namespace ScheduleControl.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Obsolete]
        public IActionResult Index()
        {
            //bir takım işlemler ve sponrasında mail tetikleniyor
            //FireAndForgetJobs.SendMailJob(new MailMessageDto {
            //    To = "mailadresiniz@gmail.com",
            //    Subject = "Kullanıcı Register Islemi Kontrol",
            //    From = "appsettingdosyasındanokunanadres@gmail.com",
            //    Body="Icerik"
            //}); 
            return View();
        }
        [HttpGet]
        public IActionResult HangfireAbout()
        {
            // bir takım işlemler ve sponrasında mail tetikleniyor
            //FireAndForgetJobs.CheckCurrencyDataRefresh();
            //DelayedJobs.SendMailJobs();
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}