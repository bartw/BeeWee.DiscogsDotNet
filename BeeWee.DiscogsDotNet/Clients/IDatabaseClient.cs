using BeeWee.DiscogsDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.Clients
{
    public interface IDatabaseClient
    {
        Task<Release> GetRelease(string id);
        Task<MasterRelease> GetMasterRelease(string id);
        Task<MasterReleaseVersions> GetMasterReleaseVersions(string id);
        Task<Artist> GetArtist(string id);
        Task<ArtistReleases> GetArtistReleases(string id);
        Task<Label> GetLabel(string id);
        Task<LabelReleases> GetLabelReleases(string id);
        Task<SearchResults> Search(SearchQuery searchQuery);
    }
}
