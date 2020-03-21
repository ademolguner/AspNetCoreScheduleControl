using ScheduleControl.Core.Entities;

namespace ScheduleControl.Entities.Dtos.Cashbox
{
    public class CashboxInputDto : IDto
    {
        public int CaseTypeId { get; set; }
        public decimal TotalQuantity { get; set; }
    }
}