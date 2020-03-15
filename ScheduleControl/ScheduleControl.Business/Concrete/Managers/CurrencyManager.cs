using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ScheduleControl.Business.Abstract;
using ScheduleControl.DataAccess.Abstract;
using ScheduleControl.Entities.Models;

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
            return _currencyDal.Get(x => x.Id == id);
        }

        public Currency GetCurrencyCode(string code)
        {
            return _currencyDal.Get(c => c.Code == code);
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
                currencies.Add( new Currency
                {
                    Name = itemRow.ItemArray[1].ToString(),
                    Code = itemRow.ItemArray[2].ToString(),
                    ForexBuying = Convert.ToDecimal(itemRow.ItemArray[3]),
                    ForexSelling = Convert.ToDecimal(itemRow.ItemArray[4]),
                    BanknoteBuying = Convert.ToDecimal(itemRow.ItemArray[5]),
                    BanknoteSelling = Convert.ToDecimal(itemRow.ItemArray[6]),
                    LastUpdateTime = DateTime.Now
                });
            }
            return await Task.FromResult(currencies); 
        }


    }
}
