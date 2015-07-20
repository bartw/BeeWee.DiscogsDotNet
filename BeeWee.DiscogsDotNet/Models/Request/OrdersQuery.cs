using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Models
{
    public class OrdersQuery
    {
        public OrderStatusEnumeration? Status { get; set; }
        public OrderSortEnumeration? Sort { get; set; }
        public SortOrderEnumeration? SortOrder { get; set; }
    }
}
