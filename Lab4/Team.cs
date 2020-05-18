using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Lab4
{
    public class Team
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string school { get; set; }
        public string mascot { get; set; }
        public string color { get; set; }

        [JsonIgnore]
        public List<Coach> CoachNavigation { get; set; } = new List<Coach>();
    }
}

