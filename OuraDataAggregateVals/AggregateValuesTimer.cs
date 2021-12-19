using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using OuraDataAggregateVals.Models;
using OuraDataAggregateVals.Services;

namespace OuraDataAggregateVals
{
    public class AggregateValuesTimer
    {
        private readonly ITableService<SleepData> _tableServiceSleep;
        private readonly IOuraDataService _ouraDataService;

        public AggregateValuesTimer(ITableService<SleepData> tableService, IOuraDataService ouraDataService)
        {
            _tableServiceSleep = tableService;
            _ouraDataService = ouraDataService;
        }

        [FunctionName("GetSleepData")]
        public async Task Run([TimerTrigger("0 12 * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            SleepData sleepData = await _ouraDataService.FetchDailyDataAsync();



            if (sleepData != null)
            {
                log.LogInformation($"SleepData loaded with {sleepData.Sleep.Length} elements");
                bool success = _tableServiceSleep.AddEntity(sleepData);
                log.LogInformation($"Saving of sleepdata was successful: {success}");
            }
            else
            {
                log.LogInformation("SleepData was null.");
            }
        }
    }
}
