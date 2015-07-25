using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeWee.DiscogsDotNet.ConsoleApp
{
    internal enum CommandType
    {
        UNKNOWN,
        CLEAR,
        EXIT,
        MAN,
        AUTHENTICATE,
        IDENTITY,
        PROFILE,
        RELEASE,
        MASTERRELEASE,
        MASTERRELEASEVERSIONS,
        ARTIST,
        ARTISTRELEASES,
        LABEL,
        LABELRELEASES,
        SEARCH,
    }

    internal class Command
    {
        public CommandType Type { get; set; }
        public List<string> Parameters { get; set; }

        public Command()
        {
            Type = CommandType.UNKNOWN;
            Parameters = null;
        }
    }

    internal static class CommandHelper
    {
        internal static Command StringToCommand(string line)
        {
            Command command = new Command();
            if (!string.IsNullOrEmpty(line))
            {
                var parameters = line.Split(' ');
                if (parameters.Length > 0)
                {
                    switch (parameters[0].ToUpper())
                    {
                        case "CLEAR":
                            command.Type = CommandType.CLEAR;
                            break;
                        case "EXIT":
                            command.Type = CommandType.EXIT;
                            break;
                        case "MAN":
                            command.Type = CommandType.MAN;
                            break;
                        case "AUTHENTICATE":
                            command.Type = CommandType.AUTHENTICATE;
                            break;
                        case "IDENTITY":
                            command.Type = CommandType.IDENTITY;
                            break;
                        case "PROFILE":
                            command.Type = CommandType.PROFILE;
                            break;
                        case "RELEASE":
                            command.Type = CommandType.RELEASE;
                            break;
                        case "MASTERRELEASE":
                            command.Type = CommandType.MASTERRELEASE;
                            break;
                        case "MASTERRELEASEVERSIONS":
                            command.Type = CommandType.MASTERRELEASEVERSIONS;
                            break;
                        case "ARTIST":
                            command.Type = CommandType.ARTIST;
                            break;
                        case "ARTISTRELEASES":
                            command.Type = CommandType.ARTISTRELEASES;
                            break;
                        case "LABEL":
                            command.Type = CommandType.LABEL;
                            break;
                        case "LABELRELEASES":
                            command.Type = CommandType.LABELRELEASES;
                            break;
                        case "SEARCH":
                            command.Type = CommandType.SEARCH;
                            break;
                    }
                    command.Parameters = parameters.Skip(1).ToList();
                }
            }
            return command;
        }
    }
}
