using Newtonsoft.Json;

namespace ivnet.club.services.api.Models
{
    public class Fixture
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        [JsonProperty(PropertyName = "opponent")]
        public string Opponent { get; set; }

        [JsonProperty(PropertyName = "homeOrAway")]
        public string HomeOrAway { get; set; }

        [JsonProperty(PropertyName = "kit")]
        public string Kit { get; set; }

        [JsonProperty(PropertyName = "trips")]
        public string Trips { get; set; }
    }
}