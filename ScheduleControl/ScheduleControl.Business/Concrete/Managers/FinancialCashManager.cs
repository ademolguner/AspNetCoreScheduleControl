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

        public void Insert(FinancialCash financialCash)
        {
            _financialCashDal.Add(financialCash);
        }
    }
}