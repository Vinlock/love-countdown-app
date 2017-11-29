using System;
using Newtonsoft.Json;


namespace FormsTest
{
    public class Date
    {
        [JsonProperty("year")]
        public int year { get; set; }

        [JsonProperty("month")]
        public int month { get; set; }

        [JsonProperty("day")]
        public int day { get; set; }

        [JsonProperty("hour")]
        public int hour { get; set; }

        [JsonProperty("minute")]
        public int minute { get; set; }

        [JsonProperty("second")]
        public int second { get; set; }
    }
}
