using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Models
{
    public class Artist : DiscogsResource
    {
        public string profile { get; set; }
        public string releases_url { get; set; }
        public string name { get; set; }
        public List<string> namevariations { get; set; }
        public string uri { get; set; }
        public List<string> urls { get; set; }
        public List<Image> images { get; set; }
        public string resource_url { get; set; }
        public List<Alias> aliases { get; set; }
        public int id { get; set; }
        public string data_quality { get; set; }
        public string realname { get; set; }
    }
}
