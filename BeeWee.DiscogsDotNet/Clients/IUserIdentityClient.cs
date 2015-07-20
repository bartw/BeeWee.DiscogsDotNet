using BeeWee.DiscogsDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Clients
{
    public interface IUserIdentityClient
    {
        Task<Identity> GetIdentityAsync();
        Task<Profile> GetProfileAsync(string username);
    }
}
