using Newtonsoft.Json;

namespace BeeWee.DiscogsDotNet.Models
{
    public class Identity : DiscogsResource
    {
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "resource_url")]
        public string ResourceUrl { get; set; }

        [JsonProperty(PropertyName = "consumer_name")]
        public string ConsumerName { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}
