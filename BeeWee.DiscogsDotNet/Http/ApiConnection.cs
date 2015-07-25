using BeeWee.DiscogsDotNet.Authentication;
using BeeWee.DiscogsDotNet.Models;
using BeeWee.DiscogsDotNet.Throttling;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Http
{
    public class ApiConnection : IApiConnection
    {
        private readonly IThrottler _throttler;
        private readonly ProductHeaderValue _productInformation;

        public IAuthenticator Authenticator { get; set; }

        public ApiConnection(string productName, string productVersion)
        {
            _throttler = new Throttler(20, TimeSpan.FromMinutes(1));
            _productInformation = new ProductHeaderValue(productName, productVersion);
        }

        public async Task<string> Get(Uri uri)
        {
            var request = CreateRequest(HttpMethod.Get, uri);
            var response = await SendThrottledRequestAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<T> Get<T>(Uri uri)
        {
            var request = CreateRequest(HttpMethod.Get, uri);
            var response = await SendThrottledRequestAsync(request);
            var result = await DeserializeResponse<T>(response);
            return result;
        }

        public async Task<string> Post(Uri uri, object data)
        {
            var request = CreateRequest(HttpMethod.Post, uri);
            if (data != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(data));
            }
            var response = await SendThrottledRequestAsync(request);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<T> Post<T>(Uri uri, object data)
        {
            var request = CreateRequest(HttpMethod.Post, uri);
            if (data != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(data));
            }
            var response = await SendThrottledRequestAsync(request);
            var result = await DeserializeResponse<T>(response);
            return result;
        }

        public Task<T> Put<T>(Uri uri, object data)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Uri uri, object data)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (_throttler != null)
            {
                _throttler.Dispose();
            }
        }

        private HttpRequestMessage CreateRequest(HttpMethod method, Uri uri)
        {
            var request = new HttpRequestMessage(method, uri);
            request.Headers.UserAgent.Clear();
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(_productInformation));
            if (Authenticator != null)
            {
                Authenticator.Authenticate(request);
            }
            return request;
        }

        private async Task<HttpResponseMessage> SendThrottledRequestAsync(HttpRequestMessage request)
        {
            if (_throttler != null)
            {
                await _throttler.WaitAsync();
            }

            try
            {
                return await SendRequestAsync(request);
            }
            finally
            {
                if (_throttler != null)
                {
                    _throttler.Release();
                }
            }
        }

        private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request)
        {
            using (var client = new HttpClient())
            {
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    throw new Exception(string.Format("Could not complete request to {0}; server responed with {1};{2};{3}",
                        request.RequestUri, (int)response.StatusCode, response.StatusCode, response.ReasonPhrase));
                }
            }
        }

        private async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);   
        }
    }
}
