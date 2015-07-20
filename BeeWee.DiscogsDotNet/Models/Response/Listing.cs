namespace BeeWee.DiscogsDotNet.Models
{
    public class Listing : DiscogsResource
    {
        public string status { get; set; }
        public Price price { get; set; }
        public bool allow_offers { get; set; }
        public string sleeve_condition { get; set; }
        public int id { get; set; }
        public string condition { get; set; }
        public string posted { get; set; }
        public string ships_from { get; set; }
        public string uri { get; set; }
        public string comments { get; set; }
        public Seller seller { get; set; }
        public Release release { get; set; }
        public string resource_url { get; set; }
        public bool audio { get; set; }
    }
}