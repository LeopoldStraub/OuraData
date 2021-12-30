using OuraDataAggregateVals.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Data.Tables;
using Newtonsoft.Json;

namespace OuraDataAggregateVals.Services
{
    public class TableSleepService : ITableService<SleepData>
    {
        private const string DATE_FORMAT = "yyyy-MM-dd";

        TableClient tableClient;

        public TableSleepService(TableServiceClient tableServiceClient)
        {
            tableClient = tableServiceClient.GetTableClient("Sleep");
        }


        public bool AddEntity(SleepData entity)
        {
            string key = entity.Sleep[0].SummaryDate.ToString(DATE_FORMAT);

            try
            {
                var tableResponse = tableClient.AddEntity<TableEntity>(new TableEntity(key, key) {
                { "sleepdata", JsonConvert.SerializeObject(entity.Sleep[0])}
            });

                return (tableResponse.Status == 200 || tableResponse.Status == 204);

            }
            catch (IndexOutOfRangeException e)
            {
                //log the exception
                return false;
            }
        }
    }
}
