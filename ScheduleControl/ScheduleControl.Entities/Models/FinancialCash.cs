using ScheduleControl.Core.Entities;

namespace ScheduleControl.Entities.Models
{
    public class FinancialCash : IEntity
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public decimal CashCurrncy { get; set; }
    }
}