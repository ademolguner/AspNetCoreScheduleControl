using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Logging;
using ScheduleControl.BackgroundJob.Abstract;
using ScheduleControl.Business.Abstract;

namespace ScheduleControl.BackgroundJob.Schedules
{
    public class CurrencyScheduleJob : ICurrencySchedule
    {
        //  api katmanı olusturup call edilecek
        private ILogger<CurrencyScheduleJob> _logger;
        private readonly ICurrencyService _currencyService;

        public CurrencyScheduleJob(ILogger<CurrencyScheduleJob> logger, ICurrencyService currencyService)
        {
            _logger = logger;
            _currencyService = currencyService;
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await RunArTimeOf(DateTime.Now);
        }

        public async Task RunArTimeOf(DateTime nowDateTime)
        {
            var lists = await _currencyService.GetCurrencyApiCall();
            foreach (var itemCurrency in lists)
            {
                var currencyItemData = _currencyService.GetCurrencyCode(itemCurrency.Code);
                if (currencyItemData != null)
                {
                    itemCurrency.Id = currencyItemData.Id;
                    _currencyService.Update(itemCurrency);
                }
                else
                {
                    _currencyService.Add(itemCurrency);

                }
            }
        }

    }
}
