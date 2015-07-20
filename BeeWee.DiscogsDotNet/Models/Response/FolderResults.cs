using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Models
{
    public class FolderResults : DiscogsResource
    {
        public List<Folder> folders { get; set; }
    }
}
