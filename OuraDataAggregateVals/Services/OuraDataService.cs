using Newtonsoft.Json;
using OuraDataAggregateVals.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OuraDataAggregateVals.Services
{
    public class OuraDataService : IOuraDataService
    {
        private const string BASE_URI = "https://api.ouraring.com/v1";

        public async Task<SleepData> FetchDailyDataAsync()
        {
            string startEnd = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");

            string requestUri = BuildRequestUri("sleep", startEnd, startEnd);
            HttpClient http = new HttpClient();

            //put bearer token into keyvault.
            http.DefaultRequestHeaders.Add("Authorization", $" Bearer {Environment.GetEnvironmentVariable("OURA_TOKEN")}");

            var response = await http.GetAsync(requestUri);
            SleepData sleepData;
            try
            {
                sleepData = JsonConvert.DeserializeObject<SleepData>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception)
            {
                return null;
            }
            
            return sleepData;
        }

        private static string BuildRequestUri(string category, string start, string end)
        {
            return $"{BASE_URI}/{category}?start={start}&end={end}";
        }
    }
}
