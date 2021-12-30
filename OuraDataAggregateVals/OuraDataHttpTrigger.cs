using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using OuraDataAggregateVals.Models;
using Azure.Data.Tables;
using OuraDataAggregateVals.Services;
using System.Collections.Generic;

namespace OuraDataAggregateVals
{
    public  class OuraDataHttpTrigger
    {
        private const string BASE_URI = "https://api.ouraring.com/v1";
        private const string DATE_FORMAT = "yyyy-MM-dd";

        private ITableService<SleepData> sleepTableService;
        private IOuraDataService ouraDataService;

        public OuraDataHttpTrigger(ITableService<SleepData> tableService, IOuraDataService dataService)
        {
            ouraDataService = dataService;
            sleepTableService = tableService;
        }

        [FunctionName("SaveDataFromStartToDay")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "savedata")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("SaveDataFromStartToDay processed a request.");

            string start = req.Query["start"];
            if(start is null)
            {
                return new BadRequestResult();
            }

            DateTime startDate = DateTime.Now;

            try
            {
                startDate = DateTime.ParseExact(start, DATE_FORMAT, System.Globalization.CultureInfo.CurrentCulture);

            }catch(FormatException fe)
            {
                log.LogError($"Formatting of startDate failed. Given string: {start}");
            }

            DateTime endDate = DateTime.Today.AddDays(-1);

            foreach(DateTime day in EachDay(startDate, endDate))
            {
                SleepData sleepData = await ouraDataService.FetchDataAsync(day.ToString(DATE_FORMAT));
                if(!(sleepData is null))
                {
                    bool success = sleepTableService.AddEntity(sleepData);
                    if (!success)
                        log.LogWarning($"SleepData could not be saved. Date: {sleepData.Sleep[0].SummaryDate.ToString()}");
                }
                
            }

            

            return new OkObjectResult("");
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }


    }
}