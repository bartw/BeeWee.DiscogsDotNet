using BeeWee.DiscogsDotNet.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BeeWee.DiscogsDotNet.Authentication
{
    public class OAuthAuthenticator : IAuthenticator
    {
        private Token _consumerToken;

        public Token OAuthToken { get; set; }
        public string OAuthVerifier { get; set; }     

        public OAuthAuthenticator(Token consumerToken)
            : this(consumerToken, null)
        {
        }

        public OAuthAuthenticator(Token consumerToken, Token oauthToken)
            : this(consumerToken, oauthToken, null)
        {
        }

        public OAuthAuthenticator(Token consumerToken, Token oauthToken, string oauthVerifier)
        {
            if (consumerToken == null || string.IsNullOrEmpty(consumerToken.Key) || string.IsNullOrEmpty(consumerToken.Secret))
            {
                throw new ArgumentException("Consumer token or on of its properties can't be null or empty");
            }

            _consumerToken = consumerToken;
            OAuthToken = oauthToken;
            OAuthVerifier = oauthVerifier;
        }

        public void Authenticate(HttpRequestMessage request)
        {
            request.Headers.Authorization = AuthenticationHeaderValue.Parse(GetAuthorizationHeader(_consumerToken, OAuthToken, OAuthVerifier));
        }

        private static string GetAuthorizationHeader(Token consumerToken, Token token, string verifier)
        {
            var builder = new StringBuilder();

            builder.Append("OAuth ");
            builder.Append(GetConsumerKey(consumerToken));
            builder.Append(GetNonce());
            builder.Append(GetToken(token));
            builder.Append(GetSignature(consumerToken, token));
            builder.Append("oauth_signature_method=\"PLAINTEXT\",");
            builder.Append(GetTimeStamp());
            builder.Append(GetVerifier(verifier));
            builder.Append("oauth_version=\"1.0\"");

            return builder.ToString();
        }

        private static string GetConsumerKey(Token consumerToken)
        {
            string consumerKey = null;
            if (consumerToken != null)
            {
                consumerKey = consumerToken.Key;
            }

            return string.Format("oauth_consumer_key=\"{0}\",", consumerToken.Key);
        }

        private static string GetNonce()
        {
            return string.Format("oauth_nonce=\"{0}\",", Convert.ToBase64String(new UTF8Encoding().GetBytes(DateTime.Now.Ticks.ToString())));
        }

        private static string GetToken(Token token)
        {
            if (token != null && !string.IsNullOrEmpty(token.Key))
            {
                return string.Format("oauth_token=\"{0}\",", token.Key);
            }

            return "";
        }

        private static string GetSignature(Token consumerToken, Token token)
        {
            string consumerSecret = null;
            if (consumerToken != null)
            {
                consumerSecret = consumerToken.Secret;
            }

            string tokenSecret = null;
            if (token != null)
            {
                tokenSecret = token.Secret;
            }

            return string.Format("oauth_signature=\"{0}&{1}\",", consumerSecret ?? "", tokenSecret ?? "");
        }

        private static string GetTimeStamp()
        {
            return string.Format("oauth_timestamp=\"{0}\",", Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds).ToString());
        }

        private static string GetVerifier(string verifier)
        {
            if (!string.IsNullOrEmpty(verifier))
            {
                return string.Format("oauth_verifier=\"{0}\",", verifier);
            }

            return "";
        }
    }
}
