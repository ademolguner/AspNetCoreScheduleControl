using ScheduleControl.Business.Abstract;
using ScheduleControl.DataAccess.Abstract;
using ScheduleControl.Entities.Models;

namespace ScheduleControl.Business.Concrete.Managers
{
    public class CashTypeManager : ICashTypeService
    {
        private readonly ICashTypeDal _cashTypeDal;

        public CashTypeManager(ICashTypeDal cashTypeDal)
        {
            _cashTypeDal = cashTypeDal;
        }

        public CashType GetById(int id)
        {
            return _cashTypeDal.Get(x => x.CashTypeId == id);
        }
    }
}