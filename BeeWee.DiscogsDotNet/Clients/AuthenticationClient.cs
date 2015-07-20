using BeeWee.DiscogsDotNet.Http;
using BeeWee.DiscogsDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Clients
{
    public class AuthenticationClient : ApiClient, IAuthenticationClient
    {
        public AuthenticationClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        public async Task<Token> GetRequestTokenAsync()
        {
            var tokenString = await ApiConnection.Post(new Uri("https://api.discogs.com/oauth/request_token"), null);
            var token = ParseToken(tokenString);
            return token;
        }

        public string GetAuthorizeUrl(string tokenKey)
        {
            return string.Format("https://discogs.com/oauth/authorize?oauth_token={0}", tokenKey);
        }

        public async Task<Token> GetAccessTokenAsync()
        {
            var tokenString = await ApiConnection.Post(new Uri("https://api.discogs.com/oauth/access_token"), null);
            var token = ParseToken(tokenString);
            return token;
        }

        private static Token ParseToken(string tokenString)
        {
            if (!string.IsNullOrEmpty(tokenString))
            {
                var tokenValues = GetDelimitedValues(tokenString, '&', '=');

                if (tokenValues.ContainsKey("oauth_token") && !string.IsNullOrEmpty(tokenValues["oauth_token"]) &&
                    tokenValues.ContainsKey("oauth_token_secret") && !string.IsNullOrEmpty(tokenValues["oauth_token_secret"]))
                {
                    return new Token(tokenValues["oauth_token"], tokenValues["oauth_token_secret"]);
                }
            }

            return null;
        }

        private static Dictionary<string, string> GetDelimitedValues(string candidateString, char pairDelimeter, char valueDelimiter)
        {
            var nameValueStrings = candidateString.Split(new char[] { pairDelimeter }, StringSplitOptions.RemoveEmptyEntries);
            var splitPairs = nameValueStrings.Select(item => item.Split(new char[] { valueDelimiter }, StringSplitOptions.RemoveEmptyEntries));
            var keyValuePairs = splitPairs.Select(x => new KeyValuePair<string, string>(x[0], x.Length > 1 ? x[1] : string.Empty));

            return keyValuePairs.ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
