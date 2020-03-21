using ScheduleControl.Business.Abstract;
using ScheduleControl.DataAccess.Abstract;
using ScheduleControl.Entities.Models;

namespace ScheduleControl.Business.Concrete.Managers
{
    public class CashboxManager : ICashboxService
    {
        private readonly ICashboxDal _cashboxDal;

        public CashboxManager(ICashboxDal cashboxDal)   //public ICashboxDal CashboxDal => cashboxDal;
        {
            _cashboxDal = cashboxDal;
        }

        public void Insert(Cashbox cashbox)
        {
            _cashboxDal.Add(cashbox);
        }
    }
}