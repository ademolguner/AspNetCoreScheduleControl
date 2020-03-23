using ScheduleControl.Core.Entities;
using System.Collections.Generic;

namespace ScheduleControl.Entities.Dtos.Cashbox
{
    public class CashboxInputDto : IDto
    {
        public int SelectedCaseTypeId { get; set; }
        public List<int> CashTypeItemList { get; set; }
        public decimal TotalQuantity { get; set; }
    }
}