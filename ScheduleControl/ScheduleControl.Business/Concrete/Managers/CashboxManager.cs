using ScheduleControl.Business.Abstract;
using ScheduleControl.DataAccess.Abstract;
using ScheduleControl.Entities.Models;
using System.Linq;

namespace ScheduleControl.Business.Concrete.Managers
{
    public class CashboxManager : ICashboxService
    {
        private readonly ICashboxDal _cashboxDal;

        public CashboxManager(ICashboxDal cashboxDal)   //public ICashboxDal CashboxDal => cashboxDal;
        {
            _cashboxDal = cashboxDal;
        }

        public decimal GetIncomeTotal()
        {
            return _cashboxDal.GetList(c => c.CashTypeId == 1).Sum(q=> q.TotalQuantity);
        }

        public decimal GetExpenseTotal()
        {
            return _cashboxDal.GetList(c => c.CashTypeId == 2).Sum(q => q.TotalQuantity);
        }

        public void Insert(Cashbox cashbox)
        {
            _cashboxDal.Add(cashbox);
        }

        public decimal GetCashTotal()
        {
            var total = GetIncomeTotal() - GetExpenseTotal();
            return total <= 0 ? 0 : total;
        }
    }
}