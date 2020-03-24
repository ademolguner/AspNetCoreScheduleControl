using ScheduleControl.Business.Abstract;
using ScheduleControl.DataAccess.Abstract;
using ScheduleControl.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Xml;

namespace ScheduleControl.Business.Concrete.Managers
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly ICurrencyDal _currencyDal;

        public CurrencyManager(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal;
        }

        public List<Currency> GetCurrencies()
        {
            return _currencyDal.GetList();
        }

        public Currency GetCurrency(int id)
        {
            return _currencyDal.Get(x => x.CurrencyId == id);
        }

        public Currency GetCurrencyCode(string code)
        {
            try
            {
                var data = _currencyDal.Get(c => c.Code == code);
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Add(Currency currency)
        {
            _currencyDal.Add(currency);
        }

        public void Update(Currency currency)
        {
            _currencyDal.Update(currency);
        }

        public async Task<List<Currency>> GetCurrencyApiCall()
        {
            List<Currency> currencies = new List<Currency>();
            XmlTextReader rdr = new XmlTextReader(" http://www.tcmb.gov.tr/kurlar/today.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(rdr);

            foreach (DataRow itemRow in ds.Tables[1].Rows)
            {
                currencies.Add(new Currency
                {
                    Name = itemRow.ItemArray[1].ToString(),
                    Code = itemRow.ItemArray[2].ToString(),
                    ForexBuying = string.IsNullOrEmpty(itemRow.ItemArray[3].ToString()) != true ? Convert.ToDecimal(itemRow.ItemArray[3]) : 0,
                    ForexSelling = string.IsNullOrEmpty(itemRow.ItemArray[4].ToString()) != true ? Convert.ToDecimal(itemRow.ItemArray[4]) : 0,
                    BanknoteBuying = string.IsNullOrEmpty(itemRow.ItemArray[5].ToString()) != true ? Convert.ToDecimal(itemRow.ItemArray[5]) : 0,
                    BanknoteSelling = string.IsNullOrEmpty(itemRow.ItemArray[6].ToString()) != true ? Convert.ToDecimal(itemRow.ItemArray[6]) : 0,
                    LastUpdateTime = DateTime.Now
                });
            }
            return await Task.FromResult(currencies);
        }

        public decimal MoneyCompareCurrency(decimal modey, int currencyId)
        {
            var selectedCurrency = GetCurrency(currencyId);
            return selectedCurrency.BanknoteSelling!=0?modey / selectedCurrency.BanknoteSelling:0;
        }
    }
}