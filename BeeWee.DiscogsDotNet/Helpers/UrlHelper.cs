using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Helpers
{
    public static class UrlHelper
    {
        public static string BuildUri(string url, Dictionary<string, string> parameters)
        {
            var uriBuilder = new StringBuilder();

            uriBuilder.Append(url);

            bool firstParam = true;

            if (parameters != null && parameters.Count > 0)
            {
                foreach (var parameter in parameters)
                {
                    uriBuilder.AppendFormat("{0}{1}={2}", firstParam ? "?" : "&", parameter.Key, parameter.Value);
                    firstParam = false;
                }
            }

            return uriBuilder.ToString();
        }
        public static void AddStringParameter(Dictionary<string, string> parameters, string key, string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                parameters.Add(key, Uri.EscapeUriString(value));
            }
        }
    }
}
