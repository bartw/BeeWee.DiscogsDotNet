using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Models
{
    public class MasterReleaseVersions : DiscogsResource
    {
        public Pagination pagination { get; set; }
        public List<Version> versions { get; set; }
    }
}
