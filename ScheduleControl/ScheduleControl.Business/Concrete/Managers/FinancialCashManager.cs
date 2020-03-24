using ScheduleControl.Business.Abstract;
using ScheduleControl.DataAccess.Abstract;
using ScheduleControl.Entities.Models;

namespace ScheduleControl.Business.Concrete.Managers
{
    public class FinancialCashManager : IFinancialCashService
    {
        private readonly IFinancialCashDal _financialCashDal;

        public FinancialCashManager(IFinancialCashDal financialCashDal)
        {
            _financialCashDal = financialCashDal;
        }

        public FinancialCash GetByCurrencyId(int currencyId)
        {
            return _financialCashDal.Get(c => c.CurrencyId == currencyId);
        }

        public void Insert(FinancialCash financialCash)
        {
            _financialCashDal.Add(financialCash);
        }

        public void Update(FinancialCash financialCash)
        {
            _financialCashDal.Update(financialCash);
        }
    }
}