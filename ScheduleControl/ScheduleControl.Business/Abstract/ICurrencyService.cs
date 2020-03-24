using ScheduleControl.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScheduleControl.Business.Abstract
{
    public interface ICurrencyService
    {
        List<Currency> GetCurrencies();

        Currency GetCurrency(int id);

        Currency GetCurrencyCode(string code);

        void Add(Currency currency);

        void Update(Currency currency);

       decimal MoneyCompareCurrency(decimal modey, int currencyId);

        Task<List<Currency>> GetCurrencyApiCall();
    }
}