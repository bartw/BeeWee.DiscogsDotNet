using System.Collections.Generic;

namespace BeeWee.DiscogsDotNet.Models
{
    public class Order : DiscogsResource
    {
        public string status { get; set; }
        public Fee fee { get; set; }
        public string created { get; set; }
        public List<Item> items { get; set; }
        public Shipping shipping { get; set; }
        public string shipping_address { get; set; }
        public string additional_instructions { get; set; }
        public Seller seller { get; set; }
        public string last_activity { get; set; }
        public Buyer buyer { get; set; }
        public Total total { get; set; }
        public string id { get; set; }
        public string resource_url { get; set; }
        public string messages_url { get; set; }
        public string uri { get; set; }
        public List<string> next_status { get; set; }
    }
}