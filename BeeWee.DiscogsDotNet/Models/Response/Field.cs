using System.Collections.Generic;

namespace BeeWee.DiscogsDotNet.Models
{
    public class Field
    {
        public string name { get; set; }
        public List<string> options { get; set; }
        public int id { get; set; }
        public int position { get; set; }
        public string type { get; set; }
        public bool @public { get; set; }
        public int? lines { get; set; }
    }
}