using Newtonsoft.Json;

namespace ivnet.club.services.api.Models
{
    public class ClubService
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "svg")]
        public string SVG { get; set; }

        [JsonProperty(PropertyName = "route")]
        public string Route { get; set; }
    }
}