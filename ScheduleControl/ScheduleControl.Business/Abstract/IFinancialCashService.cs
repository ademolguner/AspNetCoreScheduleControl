using ScheduleControl.Entities.Models;

namespace ScheduleControl.Business.Abstract
{
    public interface IFinancialCashService
    {
        void Insert(FinancialCash financialCash);
    }
}