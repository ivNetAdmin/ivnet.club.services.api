using Newtonsoft.Json;

namespace ivnet.club.services.api.Models
{
    public class ClubRole
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}