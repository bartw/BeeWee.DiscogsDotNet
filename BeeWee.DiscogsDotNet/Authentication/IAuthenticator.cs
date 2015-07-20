using System.Net.Http;

namespace BeeWee.DiscogsDotNet.Authentication
{
    public interface IAuthenticator
    {
        void Authenticate(HttpRequestMessage request);
    }
}
