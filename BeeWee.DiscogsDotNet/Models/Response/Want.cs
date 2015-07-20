namespace BeeWee.DiscogsDotNet.Models
{
    public class Want : DiscogsResource
    {
        public int rating { get; set; }
        public Release basic_information { get; set; }
        public string resource_url { get; set; }
        public int id { get; set; }
        public string notes { get; set; }
    }
}