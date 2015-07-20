using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Models
{
    public class CollectionResults : DiscogsResource
    {
        public Pagination pagination { get; set; }
        public List<CollectionRelease> releases { get; set; }
    }
}
