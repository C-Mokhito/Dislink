using BrokeProtocol.API;
using BrokeProtocol.Entities;
using Dislink.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Dislink.Functions
{
    public class Local : PlayerEvents
    {
        private static readonly Regex URL = new Regex(@"(?i)\b((h(?:tt|xx)p[s]?|ftp):\/\/|\bwww[.]|(?:[a-z0-9-]+\s?(?:[.()]|\bdot\b)\s?)+[a-z]{2,})(\/\S*)?", RegexOptions.Compiled);

        private static readonly string BasePath = Path.Combine("Plugins", "Dislink");

        private static readonly string SPath = Path.Combine(BasePath, "Settings.json");

        private static readonly string WPath = Path.Combine(BasePath, "Whitelist.json");

        private static Dislink.Configuration.Settings Settings;

        private static WData Whitelist;

        static Local()
        {
            if (File.Exists(SPath))
            {
                Settings = JsonConvert.DeserializeObject<Dislink.Configuration.Settings>(File.ReadAllText(SPath));
            }
            else
            {
                Settings = new Dislink.Configuration.Settings();
            }
            if (File.Exists(WPath))
            {
                Whitelist = JsonConvert.DeserializeObject<WData>(File.ReadAllText(WPath));
            }
            else
            {
                Whitelist = new WData { Players = new List<string>() };
            }
        }

        [Execution(ExecutionMode.PreEvent)]
        public override bool ChatLocal(ShPlayer p, string message)
        {
            if (URL.IsMatch(message))
            {
                if (Settings.Whitelist)
                {
                    if (Whitelist.Players.Contains(p.username))
                    {
                        return true;
                    }

                    p.svPlayer.SendGameMessage(Settings.LocalMessage);
                    return false;
                }

                p.svPlayer.SendGameMessage(Settings.LocalMessage);
                return false;
            }
            return true;
        }
    }
}
