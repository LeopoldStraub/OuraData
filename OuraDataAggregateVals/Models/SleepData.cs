using System;
using System.Collections.Generic;
using System.Text;

namespace OuraDataAggregateVals.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SleepData
    {
        [JsonProperty("sleep")]
        public Sleep[] Sleep { get; set; }
    }

    public partial class Sleep
    {
        [JsonProperty("summary_date")]
        public DateTimeOffset SummaryDate { get; set; }

        [JsonProperty("period_id")]
        public long PeriodId { get; set; }

        [JsonProperty("is_longest")]
        public long IsLongest { get; set; }

        [JsonProperty("timezone")]
        public long Timezone { get; set; }

        [JsonProperty("bedtime_end")]
        public DateTimeOffset BedtimeEnd { get; set; }

        [JsonProperty("bedtime_start")]
        public DateTimeOffset BedtimeStart { get; set; }

        [JsonProperty("breath_average")]
        public double BreathAverage { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("awake")]
        public long Awake { get; set; }

        [JsonProperty("rem")]
        public long Rem { get; set; }

        [JsonProperty("deep")]
        public long Deep { get; set; }

        [JsonProperty("light")]
        public long Light { get; set; }

        [JsonProperty("midpoint_time")]
        public long MidpointTime { get; set; }

        [JsonProperty("efficiency")]
        public long Efficiency { get; set; }

        [JsonProperty("restless")]
        public long Restless { get; set; }

        [JsonProperty("onset_latency")]
        public long OnsetLatency { get; set; }

        [JsonProperty("hr_5min")]
        public long[] Hr5Min { get; set; }

        [JsonProperty("hypnogram_5min")]
        public string Hypnogram5Min { get; set; }

        [JsonProperty("rmssd")]
        public long Rmssd { get; set; }

        [JsonProperty("rmssd_5min")]
        public long[] Rmssd5Min { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("score_alignment")]
        public long ScoreAlignment { get; set; }

        [JsonProperty("score_deep")]
        public long ScoreDeep { get; set; }

        [JsonProperty("score_disturbances")]
        public long ScoreDisturbances { get; set; }

        [JsonProperty("score_efficiency")]
        public long ScoreEfficiency { get; set; }

        [JsonProperty("score_latency")]
        public long ScoreLatency { get; set; }

        [JsonProperty("score_rem")]
        public long ScoreRem { get; set; }

        [JsonProperty("score_total")]
        public long ScoreTotal { get; set; }

        [JsonProperty("temperature_deviation")]
        public double TemperatureDeviation { get; set; }

        [JsonProperty("temperature_trend_deviation")]
        public double TemperatureTrendDeviation { get; set; }

        [JsonProperty("bedtime_start_delta")]
        public long BedtimeStartDelta { get; set; }

        [JsonProperty("bedtime_end_delta")]
        public long BedtimeEndDelta { get; set; }

        [JsonProperty("midpoint_at_delta")]
        public long MidpointAtDelta { get; set; }

        [JsonProperty("temperature_delta")]
        public double TemperatureDelta { get; set; }

        [JsonProperty("hr_lowest")]
        public long HrLowest { get; set; }

        [JsonProperty("hr_average")]
        public double HrAverage { get; set; }
    }
}
