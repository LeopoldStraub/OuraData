﻿using OuraDataAggregateVals.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Data.Tables;
using Newtonsoft.Json;

namespace OuraDataAggregateVals.Services
{
    public class TableSleepService : ITableService<SleepData>
    {
        TableClient tableClient;

        public TableSleepService(TableServiceClient tableServiceClient)
        {
            tableClient = tableServiceClient.GetTableClient("Sleep");
        }


        public bool AddEntity(SleepData entity)
        {
            string partitionKey = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            string rowKey = Guid.NewGuid().ToString();

            try
            {
                var tableResponse = tableClient.AddEntity<TableEntity>(new TableEntity(partitionKey, rowKey) {
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