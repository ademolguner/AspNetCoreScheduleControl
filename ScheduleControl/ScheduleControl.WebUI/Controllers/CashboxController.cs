using Microsoft.AspNetCore.Mvc;
using ScheduleControl.BackgroundJob.Schedules;
using ScheduleControl.Business.Abstract;
using ScheduleControl.Entities.Dtos.Cashbox;
using ScheduleControl.Entities.Models;
using System;

namespace ScheduleControl.WebUI.Controllers
{
    public class CashboxController : Controller
    {
        private readonly ICashboxService _cashboxService;

        public CashboxController(ICashboxService cashboxService)
        {
            _cashboxService = cashboxService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CashInsert()
        {
            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CashInsert(CashboxInputDto cashboxInputDto)
        {
            _cashboxService.Insert(new Cashbox { CaseTypeId = cashboxInputDto.CaseTypeId, TotalQuantity = cashboxInputDto.TotalQuantity });
            FireAndForgetJobs.GetCurrencyJob();
            return View();
        }
    }
}