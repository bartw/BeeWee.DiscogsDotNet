using BeeWee.DiscogsDotNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Clients
{
    public abstract class ApiClient
    {
        protected IApiConnection ApiConnection { get; private set; }

        protected ApiClient(IApiConnection apiConnection)
        {
            ApiConnection = apiConnection;
        }
    }
}
