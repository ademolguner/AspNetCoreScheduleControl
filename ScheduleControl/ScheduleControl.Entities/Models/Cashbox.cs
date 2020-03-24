using ScheduleControl.Core.Entities;

namespace ScheduleControl.Entities.Models
{
    public class Cashbox : IEntity
    {
        public int CashboxId { get; set; }
        public int CashTypeId { get; set; }
        public decimal TotalQuantity { get; set; }
    }
}