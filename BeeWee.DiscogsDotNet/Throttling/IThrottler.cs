using System;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Throttling
{
    public interface IThrottler : IDisposable
    {
        Task WaitAsync();
        void Release();
    }
}
