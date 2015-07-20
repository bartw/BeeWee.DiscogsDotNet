using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Models
{
    public class Label : DiscogsResource
    {
        public string profile { get; set; }
        public string releases_url { get; set; }
        public string name { get; set; }
        public string contact_info { get; set; }
        public string uri { get; set; }
        public List<string> urls { get; set; }
        public List<Image> images { get; set; }
        public string resource_url { get; set; }
        public int id { get; set; }
        public string data_quality { get; set; }
    }
}
