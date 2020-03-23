using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScheduleControl.BackgroundJob.Schedules;
using ScheduleControl.Business.Abstract;
using ScheduleControl.Entities.Dtos.Cashbox;
using ScheduleControl.Entities.Models;
using ScheduleControl.WebUI.ViewModels;
using System;
using System.Collections.Generic;

namespace ScheduleControl.WebUI.Controllers
{
    public class CashboxController : Controller
    {
        private readonly ICashboxService _cashboxService;
        private readonly ICashTypeService _cashTypeService;

        public CashboxController(ICashboxService cashboxService, ICashTypeService cashTypeService)
        {
            _cashboxService = cashboxService;
            _cashTypeService = cashTypeService;
        }

        public IActionResult Index()
        {
            return View(new CashboxInputViewModel());
        }

        [HttpGet]
        public IActionResult CashInsert()
        {
            var typesData = _cashTypeService.GetAll();
            List<SelectListItem> data = new List<SelectListItem>();
            foreach (var item in typesData)
            {
                data.Add(new SelectListItem { Text = item.CashTypeName, Value = item.CashTypeId.ToString(), Selected = false });
            }
            var model = new CashboxInputViewModel { CashTypeItemList = data, TotalQuantity = 0 };
            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public IActionResult CashInsert(CashboxInputDto cashboxInputDto)
        {
            _cashboxService.Insert(new Cashbox { CaseTypeId = cashboxInputDto.SelectedCaseTypeId, TotalQuantity = cashboxInputDto.TotalQuantity });
            FireAndForgetJobs.GetCurrencyJob();
            return View();
        }
    }
}