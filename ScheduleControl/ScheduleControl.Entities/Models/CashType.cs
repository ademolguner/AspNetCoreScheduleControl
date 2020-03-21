using ScheduleControl.Core.Entities;

namespace ScheduleControl.Entities.Models
{
    public class CashType : IEntity
    {
        public int CashTypeId { get; set; }
        public string CashTypeName { get; set; }
    }
}