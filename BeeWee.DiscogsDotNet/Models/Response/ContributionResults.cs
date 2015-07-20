using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Models
{
    public class ContributionResults : DiscogsResource
    {
        public List<Contribution> contributions { get; set; }
        public Pagination pagination { get; set; }
    }
}
