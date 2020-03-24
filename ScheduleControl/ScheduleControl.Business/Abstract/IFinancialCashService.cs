using ScheduleControl.Entities.Models;

namespace ScheduleControl.Business.Abstract
{
    public interface IFinancialCashService
    {
        FinancialCash GetByCurrencyId(int currencyId);
        void Insert(FinancialCash financialCash);
        void Update(FinancialCash financialCash);
    }
}