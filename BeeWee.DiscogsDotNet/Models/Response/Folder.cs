namespace BeeWee.DiscogsDotNet.Models
{
    public class Folder : DiscogsResource
    {
        public int id { get; set; }
        public int count { get; set; }
        public string name { get; set; }
        public string resource_url { get; set; }
    }
}