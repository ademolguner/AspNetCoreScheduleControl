using ScheduleControl.Core.Entities;

namespace ScheduleControl.Entities.Models
{
    public class Cashbox : IEntity
    {
        public int Id { get; set; }
        public int CaseTypeId { get; set; }
        public decimal TotalQuantity { get; set; }
    }
}