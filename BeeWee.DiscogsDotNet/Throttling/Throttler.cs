using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Throttling
{
    public class Throttler : IThrottler
    {
        private SemaphoreSlim _pool;
        private readonly TimeSpan _resetSpan;
        private Queue<DateTime> _releaseTimes;
        private object _queueLock;

        public Throttler(int concurrentRequests, TimeSpan resetSpan)
        {
            _pool = new SemaphoreSlim(concurrentRequests);
            _resetSpan = resetSpan;
            _releaseTimes = new Queue<DateTime>(concurrentRequests);
            _queueLock = new object();
            for (int i = 0; i < concurrentRequests; i++)
            {
                _releaseTimes.Enqueue(DateTime.MinValue);
            }
        }

        public async Task WaitAsync()
        {
            await _pool.WaitAsync();

            DateTime oldest;
            lock (_queueLock)
            {
                oldest = _releaseTimes.Dequeue();
            }

            DateTime now = DateTime.UtcNow;
            DateTime windowReset = oldest.Add(_resetSpan);
            if (windowReset > now)
            {
                int sleepMilliseconds = Math.Max((int)(windowReset.Subtract(now).Ticks / TimeSpan.TicksPerMillisecond), 1); // sleep at least 1ms to be sure next window has started
                await Task.Delay(TimeSpan.FromMilliseconds(sleepMilliseconds));
            }
        }

        public void Release()
        {
            lock (_queueLock)
            {
                _releaseTimes.Enqueue(DateTime.UtcNow);
            }
            _pool.Release();
        }

        public void Dispose()
        {
            _pool.Dispose();
        }
    }
}
