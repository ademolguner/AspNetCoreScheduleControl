using Hangfire;
using ScheduleControl.Business.Abstract;
using ScheduleControl.Entities.Models;
using System;
using System.Threading.Tasks;

namespace ScheduleControl.BackgroundJob.Managers
{
    public class FinancialCashScheduleJobManager
    {
        private readonly IFinancialCashService _financialCashService;
        private readonly ICurrencyService _currencyService;
        private readonly ICashboxService _cashboxService;

        public FinancialCashScheduleJobManager(IFinancialCashService financialCashService, ICurrencyService currencyService, ICashboxService cashboxService)
        {
            _financialCashService = financialCashService;
            _currencyService = currencyService;
            _cashboxService = cashboxService;
        }
        public void Process()
        {
            var totalCash = _cashboxService.GetCashTotal();
            //if (totalCash == 0) return;
            var allCurrencyLists = _currencyService.GetCurrencies();

            foreach (var itemCurrency in allCurrencyLists)
            {
                var financialItem = _financialCashService.GetByCurrencyId(itemCurrency.CurrencyId);
                var moneyCompareTotal = _currencyService.MoneyCompareCurrency(totalCash, itemCurrency.CurrencyId);
                if (financialItem != null)
                {
                    financialItem.CashCurrncy = moneyCompareTotal;
                    _financialCashService.Update(financialItem);
                }
                else
                {
                    _financialCashService.Insert(new FinancialCash
                    {
                        CashCurrncy = moneyCompareTotal,
                        CurrencyId = itemCurrency.CurrencyId
                    });
                }
            }
        }
    }
}