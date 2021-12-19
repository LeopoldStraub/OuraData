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

namespace OuraDataAggregateVals
{
    public static class OuraDataHttpTrigger
    {
        private const string BASE_URI = "https://api.ouraring.com/v1";

        [FunctionName("OuraDataHttpTrigger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("OuraDataHttpTrigger processed a request.");

            string startEnd = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            log.LogInformation(startEnd);

            string requestUri = BuildRequestUri("sleep", startEnd, startEnd);

            HttpClient http = new HttpClient();

            //put bearer token into keyvault.
            http.DefaultRequestHeaders.Add("Authorization", " Bearer UVW3OSVCANW4K4PVAUP7JY3P22GAOLJG");

            var response = await http.GetAsync(requestUri);

            SleepData sleepData = JsonConvert.DeserializeObject<SleepData>(await response.Content.ReadAsStringAsync());

            log.LogInformation(sleepData.Sleep[0].ScoreRem.ToString());

            return new OkObjectResult("");
        }

        private static string BuildRequestUri(string category, string start, string end)
        {
            return $"{BASE_URI}/{category}?start={start}&end={end}";
        }
    }
}