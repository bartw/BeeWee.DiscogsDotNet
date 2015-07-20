using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeeWee.DiscogsDotNet.Clients;
using BeeWee.DiscogsDotNet.Http;

namespace BeeWee.DiscogsDotNet
{
    public class DiscogsClient : IDiscogsClient
    {
        public IApiConnection ApiConnection { get; private set; }
        public IAuthenticationClient Authentication { get; private set; }
        public IDatabaseClient Database { get; private set; }
        public IImagesClient Images { get; private set; }
        public IMarketplaceClient Marketplace { get; private set; }
        public IUserCollectionClient UserCollection { get; private set; }
        public IUserIdentityClient UserIdentity { get; private set; }
        public IUserWantlistClient UserWantlist { get; private set; }

        public DiscogsClient(string productName, string productVersion)
            : this(new ApiConnection(productName, productVersion))
        {
        }

        public DiscogsClient(IApiConnection apiConnection)
        {
            ApiConnection = apiConnection;
            Authentication = new AuthenticationClient(ApiConnection);
            Database = new DatabaseClient(ApiConnection);
            Images = new ImagesClient(ApiConnection);
            Marketplace = new MarketplaceClient(ApiConnection);
            UserCollection = new UserCollectionClient(ApiConnection);
            UserIdentity = new UserIdentityClient(ApiConnection);
            UserWantlist = new UserWantlistClient(ApiConnection);
        }

        public void Dispose()
        {
            if (ApiConnection != null)
            {
                ApiConnection.Dispose();
            }
        }
    }
}
