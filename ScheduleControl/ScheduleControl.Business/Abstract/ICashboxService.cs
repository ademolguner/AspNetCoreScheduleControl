using ScheduleControl.Entities.Models; 

namespace ScheduleControl.Business.Abstract
{
    public interface ICashboxService
    {
        void Insert(Cashbox cashbox);
        decimal GetIncomeTotal();
        decimal GetExpenseTotal();
        decimal GetCashTotal();
    }
}