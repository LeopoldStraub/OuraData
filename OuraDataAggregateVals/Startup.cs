using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OuraDataAggregateVals;
using OuraDataAggregateVals.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Data.Tables;
using OuraDataAggregateVals.Models;

[assembly: FunctionsStartup(typeof(Startup))]
namespace OuraDataAggregateVals
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            TableServiceClient tableServiceClient = new TableServiceClient(Environment.GetEnvironmentVariable("storageConn"));

            builder.Services.AddSingleton<TableServiceClient>(tableServiceClient);

            builder.Services.AddSingleton<ITableService<SleepData>,TableSleepService>();
            builder.Services.AddSingleton<IOuraDataService, OuraDataService>();
        }
    }
}
