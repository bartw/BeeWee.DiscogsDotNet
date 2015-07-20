using BeeWee.DiscogsDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Helpers
{
    internal static class SearchHelper
    {
        public static string BuildSearchUrl(SearchQuery searchQuery)
        {
            var parameters = GetParameters(searchQuery);
            var url = UrlHelper.BuildUri("https://api.discogs.com//database/search", parameters);

            return url;
        }

        private static Dictionary<string, string> GetParameters(SearchQuery searchQuery)
        {
            var parameters = new Dictionary<string, string>();

            UrlHelper.AddStringParameter(parameters, "q", searchQuery.Query);

            if (searchQuery.Type != null)
            {
                UrlHelper.AddStringParameter(parameters, "type", searchQuery.Type.ToString().ToLower());
            }

            UrlHelper.AddStringParameter(parameters, "title", searchQuery.Title);
            UrlHelper.AddStringParameter(parameters, "release_title", searchQuery.Release_title);
            UrlHelper.AddStringParameter(parameters, "credit", searchQuery.Credit);
            UrlHelper.AddStringParameter(parameters, "artist", searchQuery.Artist);
            UrlHelper.AddStringParameter(parameters, "anv", searchQuery.Anv);
            UrlHelper.AddStringParameter(parameters, "label", searchQuery.Label);
            UrlHelper.AddStringParameter(parameters, "genre", searchQuery.Genre);
            UrlHelper.AddStringParameter(parameters, "style", searchQuery.Style);
            UrlHelper.AddStringParameter(parameters, "country", searchQuery.Country);
            UrlHelper.AddStringParameter(parameters, "format", searchQuery.Format);
            UrlHelper.AddStringParameter(parameters, "catno", searchQuery.Catno);
            UrlHelper.AddStringParameter(parameters, "barcode", searchQuery.Barcode);
            UrlHelper.AddStringParameter(parameters, "track", searchQuery.Track);
            UrlHelper.AddStringParameter(parameters, "submitter", searchQuery.Submitter);
            UrlHelper.AddStringParameter(parameters, "contributor", searchQuery.Contributor);

            return parameters;
        }
    }
}
