using Newtonsoft.Json;

namespace ivnet.club.services.api.Models
{
    public class RinkBooking
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "weekId")]
        public int WeekId { get; set; }

        [JsonProperty(PropertyName = "dayId")]
        public int DayId { get; set; }

        [JsonProperty(PropertyName = "timeId")]
        public int TimeId { get; set; }

        [JsonProperty(PropertyName = "displayWeek")]
        public string DisplayWeek { get; set; }

        [JsonProperty(PropertyName = "day")]
        public string Day { get; set; }

        [JsonProperty(PropertyName = "time")]
        public string Time { get; set; }

        [JsonProperty(PropertyName = "bookedBy")]
        public string BookedBy { get; set; }

    }
}