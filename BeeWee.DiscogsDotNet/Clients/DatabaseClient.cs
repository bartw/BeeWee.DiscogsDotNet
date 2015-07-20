using BeeWee.DiscogsDotNet.Helpers;
using BeeWee.DiscogsDotNet.Http;
using BeeWee.DiscogsDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Clients
{
    public class DatabaseClient : ApiClient, IDatabaseClient
    {
        public DatabaseClient(IApiConnection apiConnection)
            : base(apiConnection)
        {
        }

        public async Task<Release> GetRelease(string id)
        {
            var uri = string.Format("https://api.discogs.com/releases/{0}", id);
            return await ApiConnection.Get<Release>(new Uri(uri));
        }

        public async Task<MasterRelease> GetMasterRelease(string id)
        {
            var uri = string.Format("https://api.discogs.com/masters/{0}", id);
            return await ApiConnection.Get<MasterRelease>(new Uri(uri));
        }

        public async Task<MasterReleaseVersions> GetMasterReleaseVersions(string id)
        {
            var uri = string.Format("https://api.discogs.com/masters/{0}/versions", id);
            return await ApiConnection.Get<MasterReleaseVersions>(new Uri(uri));
        }

        public async Task<Artist> GetArtist(string id)
        {
            var uri = string.Format("https://api.discogs.com/artists/{0}", id);
            return await ApiConnection.Get<Artist>(new Uri(uri));
        }

        public async Task<ArtistReleases> GetArtistReleases(string id)
        {
            var uri = string.Format("https://api.discogs.com/artists/{0}/releases", id);
            return await ApiConnection.Get<ArtistReleases>(new Uri(uri));
        }

        public async Task<Label> GetLabel(string id)
        {
            var uri = string.Format("https://api.discogs.com/labels/{0}", id);
            return await ApiConnection.Get<Label>(new Uri(uri));
        }

        public async Task<LabelReleases> GetLabelReleases(string id)
        {
            var uri = string.Format("https://api.discogs.com/labels/{0}/releases", id);
            return await ApiConnection.Get<LabelReleases>(new Uri(uri));
        }

        public async Task<SearchResults> Search(SearchQuery searchQuery)
        {
            var uri = SearchHelper.BuildSearchUrl(searchQuery);
            return await ApiConnection.Get<SearchResults>(new Uri(uri));
        }
    }
}
