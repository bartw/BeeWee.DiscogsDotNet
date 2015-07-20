using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Models
{
    public class CollectionRelease
    {
        public int instance_id { get; set; }
        public int rating { get; set; }
        public Release basic_information { get; set; }
        public int id { get; set; }
    }
}
