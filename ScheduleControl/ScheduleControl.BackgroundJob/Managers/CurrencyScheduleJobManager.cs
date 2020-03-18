using System;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Logging;
using ScheduleControl.BackgroundJob.Abstract;
using ScheduleControl.Business.Abstract;

namespace ScheduleControl.BackgroundJob.Managers
{
    public  class CurrencyScheduleJobManager : ISchedulerJob
    {
        
        private readonly ICurrencyService _currencyService;

        public CurrencyScheduleJobManager(ICurrencyService currencyService)
        { 
            _currencyService = currencyService;
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await Process();
        }

        public async Task Process()
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
