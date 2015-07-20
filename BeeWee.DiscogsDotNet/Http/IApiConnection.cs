using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Http
{
    public interface IApiConnection : IDisposable
    {
        Task<string> Get(Uri uri);
        Task<T> Get<T>(Uri uri);
        Task<string> Post(Uri uri, object data);
        Task<T> Post<T>(Uri uri, object data);
        Task<T> Put<T>(Uri uri, object data);
        Task Delete(Uri uri, object data);
    }
}
