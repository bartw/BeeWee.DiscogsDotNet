using BeeWee.DiscogsDotNet.Http;
using BeeWee.DiscogsDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Clients
{
    public class UserIdentityClient : ApiClient, IUserIdentityClient
    {
        public UserIdentityClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        public async Task<Identity> GetIdentityAsync()
        {
            return await ApiConnection.Get<Identity>(new Uri("https://api.discogs.com/oauth/identity"));
        }

        public async Task<Profile> GetProfileAsync(string username)
        {
            var uri = string.Format("https://api.discogs.com/users/{0}", username);
            return await ApiConnection.Get<Profile>(new Uri(uri));
        }
    }
}
