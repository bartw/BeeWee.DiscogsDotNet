using BeeWee.DiscogsDotNet.Clients;
using BeeWee.DiscogsDotNet.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet
{
    public interface IDiscogsClient : IDisposable
    {
        IApiConnection ApiConnection { get; }
        IAuthenticationClient Authentication { get; }
        IDatabaseClient Database { get; }
        IImagesClient Images { get; }
        IMarketplaceClient Marketplace { get; }
        IUserIdentityClient UserIdentity { get; }
        IUserCollectionClient UserCollection { get; }
        IUserWantlistClient UserWantlist { get; }
    }
}
