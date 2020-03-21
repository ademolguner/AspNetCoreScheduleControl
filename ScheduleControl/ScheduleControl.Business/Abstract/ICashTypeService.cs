using ScheduleControl.Entities.Models;

namespace ScheduleControl.Business.Abstract
{
    public interface ICashTypeService
    {
        CashType GetById(int id);
    }
}