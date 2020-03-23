using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleControl.WebUI.ViewModels
{
    public class CashboxInputViewModel
    {
        public  List<SelectListItem> CashTypeItemList { get; set; }
        public decimal TotalQuantity { get; set; }
    }
}
