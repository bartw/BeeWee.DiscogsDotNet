using BeeWee.DiscogsDotNet.Authentication;
using BeeWee.DiscogsDotNet.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.ConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                Task.Run(async () =>
                {
                    await Run();
                }).Wait();
                Console.ReadKey();
                return Environment.ExitCode;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Trace.TraceError(e.ToString());
                Console.ReadKey();
                return Environment.ExitCode != 0 ? Environment.ExitCode : 100;
            }
        }

        private static async Task Run()
        {
            Console.WriteLine("Welcome to DiscogsCli.");
            Console.WriteLine("Please give the name of your product:");
            var productName = Console.ReadLine();
            Console.WriteLine("Please give the version of your product:");
            var productVersion = Console.ReadLine();
            using (var client = new DiscogsClient(productName, productVersion))
            {
                Command command;
                do
                {
                    Console.WriteLine("Please enter a command. Use man for help.");
                    command = CommandHelper.StringToCommand(Console.ReadLine());
                    await ExecuteCommand(client, command);
                } while (command.Type != CommandType.EXIT);
                Console.WriteLine("Thanks for using DiscogsCli.");
            }
        }

        private static async Task ExecuteCommand(DiscogsClient client, Command command)
        {
            switch (command.Type)
            {
                case CommandType.UNKNOWN:
                    Console.WriteLine("Command unknown, use man for help.");
                    break;
                case CommandType.CLEAR:
                    Console.Clear();
                    break;
                case CommandType.EXIT:
                    break;
                case CommandType.MAN:
                    foreach (CommandType type in Enum.GetValues(typeof(CommandType)))
                    {
                        if (type != CommandType.UNKNOWN)
                        {
                            Console.WriteLine(type.ToString().ToLower());
                        }
                    }
                    break;
                case CommandType.AUTHENTICATE:
                    {
                        Console.WriteLine("Please give your consumer key:");
                        var consumerKey = Console.ReadLine();
                        Console.WriteLine("Please give your consumer secret:");
                        var consumerSecret = Console.ReadLine();
                        var consumerToken = new Token(consumerKey, consumerSecret);
                        client.ApiConnection.Authenticator = new OAuthAuthenticator(consumerToken);
                        var requestToken = await client.Authentication.GetRequestTokenAsync();
                        var uri = client.Authentication.GetAuthorizeUrl(requestToken.Key);
                        Console.WriteLine("Go to this url:");
                        Console.WriteLine(uri);
                        Console.WriteLine("Paste the pin here:");
                        var pin = Console.ReadLine();
                        client.ApiConnection.Authenticator = new OAuthAuthenticator(consumerToken, requestToken, pin);
                        var accessToken = await client.Authentication.GetAccessTokenAsync();
                        client.ApiConnection.Authenticator = new OAuthAuthenticator(consumerToken, accessToken);
                        Console.WriteLine("You are now authenticated");
                    }
                    break;
                case CommandType.IDENTITY:
                    {
                        var identity = await client.UserIdentity.GetIdentityAsync();
                        Console.WriteLine("Identity:");
                        Console.WriteLine(string.Format("Id: {0}", identity.Id));
                        Console.WriteLine(string.Format("Resource url: {0}", identity.ResourceUrl));
                        Console.WriteLine(string.Format("Consumer name: {0}", identity.ConsumerName));
                        Console.WriteLine(string.Format("Username: {0}", identity.Username));
                    }
                    break;
                case CommandType.PROFILE:
                    {
                        Console.WriteLine("Please give the username:");
                        var username = Console.ReadLine();
                        var profile = await client.UserIdentity.GetProfileAsync(username);
                        Console.WriteLine("Profile:");
                        Console.WriteLine(string.Format("id: {0}", profile.id));
                        Console.WriteLine(string.Format("avatar_url: {0}", profile.avatar_url));
                        Console.WriteLine(string.Format("collection_fields_url: {0}", profile.collection_fields_url));
                        Console.WriteLine(string.Format("collection_folders_url: {0}", profile.collection_folders_url));
                        Console.WriteLine(string.Format("email: {0}", profile.email));
                        Console.WriteLine(string.Format("home_page: {0}", profile.home_page));
                        Console.WriteLine(string.Format("inventory_url: {0}", profile.inventory_url));
                        Console.WriteLine(string.Format("location: {0}", profile.location));
                        Console.WriteLine(string.Format("name: {0}", profile.name));
                        Console.WriteLine(string.Format("num_collection: {0}", profile.num_collection));
                        Console.WriteLine(string.Format("num_for_sale: {0}", profile.num_for_sale));
                        Console.WriteLine(string.Format("num_lists: {0}", profile.num_lists));
                        Console.WriteLine(string.Format("num_pending: {0}", profile.num_pending));
                        Console.WriteLine(string.Format("num_wantlist: {0}", profile.num_wantlist));
                        Console.WriteLine(string.Format("profile: {0}", profile.profile));
                        Console.WriteLine(string.Format("rank: {0}", profile.rank));
                        Console.WriteLine(string.Format("rating_avg: {0}", profile.rating_avg));
                        Console.WriteLine(string.Format("registered: {0}", profile.registered));
                        Console.WriteLine(string.Format("releases_contributed: {0}", profile.releases_contributed));
                        Console.WriteLine(string.Format("releases_rated: {0}", profile.releases_rated));
                        Console.WriteLine(string.Format("resource_url: {0}", profile.resource_url));
                        Console.WriteLine(string.Format("uri: {0}", profile.uri));
                        Console.WriteLine(string.Format("username: {0}", profile.username));
                        Console.WriteLine(string.Format("wantlist_url: {0}", profile.wantlist_url));
                    }
                    break;
                case CommandType.RELEASE:
                    {
                        Console.WriteLine("Please give the release id:");
                        var id = Console.ReadLine();
                        var release = await client.Database.GetRelease(id);
                        Console.WriteLine("Release:");
                        Console.WriteLine(string.Format("id: {0}", release.id));
                        Console.WriteLine(string.Format("title: {0}", release.title));
                    }
                    break;
                case CommandType.MASTERRELEASE:
                    {
                        Console.WriteLine("Please give the master id:");
                        var id = Console.ReadLine();
                        var master = await client.Database.GetMasterRelease(id);
                        Console.WriteLine("Master:");
                        Console.WriteLine(string.Format("id: {0}", master.id));
                        Console.WriteLine(string.Format("title: {0}", master.title));
                    }
                    break;
                case CommandType.MASTERRELEASEVERSIONS:
                    break;
                case CommandType.ARTIST:
                    {
                        Console.WriteLine("Please give the artist id:");
                        var id = Console.ReadLine();
                        var artist = await client.Database.GetArtist(id);
                        Console.WriteLine("Artist:");
                        Console.WriteLine(string.Format("id: {0}", artist.id));
                        Console.WriteLine(string.Format("name: {0}", artist.name));
                    }
                    break;
                case CommandType.ARTISTRELEASES:
                    break;
                case CommandType.LABEL:
                    {
                        Console.WriteLine("Please give the label id:");
                        var id = Console.ReadLine();
                        var label = await client.Database.GetLabel(id);
                        Console.WriteLine("Master:");
                        Console.WriteLine(string.Format("id: {0}", label.id));
                        Console.WriteLine(string.Format("name: {0}", label.name));
                    }
                    break;
                case CommandType.LABELRELEASES:
                    break;
                case CommandType.SEARCH:
                    Console.WriteLine("Please give the search query:");
                    var queryString = Console.ReadLine();
                    var query = new SearchQuery();
                    query.Query = queryString;
                    var results = await client.Database.Search(query);
                    Console.WriteLine("Results");
                    foreach (var result in results.results)
                    {
                        Console.WriteLine(string.Format("id: {0}", result.id));
                        Console.WriteLine(string.Format("resource_url: {0}", result.resource_url));
                        Console.WriteLine(string.Format("title: {0}", result.title));
                        Console.WriteLine(string.Format("type: {0}", result.type));
                        Console.WriteLine("------------------------");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
