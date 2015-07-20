using System.Collections.Generic;

namespace BeeWee.DiscogsDotNet.Models
{
    public class Submissions : DiscogsResource
    {
        public List<Artist> artists { get; set; }
        public List<Label> labels { get; set; }
        public List<Release> releases { get; set; }
    }
}