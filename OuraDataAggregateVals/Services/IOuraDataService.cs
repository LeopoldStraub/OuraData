using OuraDataAggregateVals.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OuraDataAggregateVals.Services
{
    public interface IOuraDataService
    {
        public Task<SleepData> FetchDailyDataAsync();
    }
}
