using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Models
{
    public class CollectionFields : DiscogsResource
    {
        public List<Field> fields { get; set; }
    }
}
