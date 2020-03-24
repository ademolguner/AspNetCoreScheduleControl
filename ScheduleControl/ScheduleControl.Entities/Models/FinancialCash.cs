using ScheduleControl.Core.Entities;
using System;

namespace ScheduleControl.Entities.Models
{
    public class FinancialCash : IEntity
    {
        public FinancialCash()
        {
            this.LastUpdatedDate = DateTime.Now;
        }
        public int FinancialCashId { get; set; }
        public int CurrencyId { get; set; }
        public decimal CashCurrncy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}