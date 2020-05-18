using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Lab4
{
    public class Season
    {
        [JsonIgnore]
        public int id { get; set; }
        public string school { get; set; }

    }

    public class Coach
    {
        [JsonIgnore]
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        [JsonIgnore]
        public List<Season> seasons { get; set; }
        [JsonIgnore]
        public virtual Team TeamNavigation { get; set; }
    }
}
