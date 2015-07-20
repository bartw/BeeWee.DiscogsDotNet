using BeeWee.DiscogsDotNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Clients
{
    public class UserWantlistClient : ApiClient, IUserWantlistClient
    {
        public UserWantlistClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }
    }
}
