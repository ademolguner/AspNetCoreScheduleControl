using ScheduleControl.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleControl.Business.Abstract
{
   public  interface ICurrencyService
    {
        List<Currency> GetCurrencies();
        Currency GetCurrency(int id);
        Currency GetCurrencyCode(string code);
        void Add(Currency currency);
        void Update(Currency currency);

        Task<List<Currency>> GetCurrencyApiCall();
        
    }
}
