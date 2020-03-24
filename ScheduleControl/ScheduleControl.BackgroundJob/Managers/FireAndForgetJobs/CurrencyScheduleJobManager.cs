using ScheduleControl.Business.Abstract;
using System.Threading.Tasks;

namespace ScheduleControl.BackgroundJob.Managers.FireAndForgetJobs
{
    public class CurrencyScheduleJobManager
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyScheduleJobManager(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        //public async Task Run(IJobCancellationToken token)
        //{
        //    token.ThrowIfCancellationRequested();
        //    await Process();
        //}

        public async Task Process()
        {
            var lists = await _currencyService.GetCurrencyApiCall();
            foreach (var itemCurrency in lists)
            {
                var currencyItemData = _currencyService.GetCurrencyCode(itemCurrency.Code);
                if (currencyItemData != null)
                {
                    itemCurrency.CurrencyId = currencyItemData.CurrencyId;
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