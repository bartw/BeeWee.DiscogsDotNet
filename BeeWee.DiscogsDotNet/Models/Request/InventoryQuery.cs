using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Models
{
    public class InventoryQuery
    {
        public string Username { get; set; }
        public string Status { get; set; }
        public InventorySortEnumeration? Sort { get; set; }
        public SortOrderEnumeration? SortOrder { get; set; }
    }
}
