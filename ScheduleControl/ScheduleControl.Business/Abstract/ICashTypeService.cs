using ScheduleControl.Entities.Models;
using System.Collections.Generic;

namespace ScheduleControl.Business.Abstract
{
    public interface ICashTypeService
    {
        List<CashType> GetAll();
        CashType GetById(int id);
    }
}