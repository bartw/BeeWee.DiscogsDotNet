using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Models
{
    public class OrderMessageResult : DiscogsResource
    {
        public Pagination pagination { get; set; }
        public List<Message> messages { get; set; }
    }
}
