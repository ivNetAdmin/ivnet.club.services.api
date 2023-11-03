using Newtonsoft.Json;

namespace ivnet.club.services.api.Models
{
    public class Member
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
      
        [JsonProperty(PropertyName = "userName")]
        public string Username { get; set; }
      
        [JsonProperty(PropertyName = "pw")]
        public string Password { get; set; }
       
        [JsonProperty(PropertyName = "clubCode")]
        public string ClubCode { get; set; }

        [JsonProperty(PropertyName = "clubName")]
        public string ClubName { get; set; }

        [JsonProperty(PropertyName = "fullname")]
        public string Fullname { get; set; }
        
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "telephone")]
        public string Telephone { get; set; }
       
        [JsonProperty(PropertyName = "dietary")]
        public string Dietary { get; set; }
        
        [JsonProperty(PropertyName = "medical")]
        public string Medical { get; set; }
    }
}