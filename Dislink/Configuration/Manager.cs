using BrokeProtocol.API;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Dislink.Configuration
{
    public class Manager : IScript
    {
        private static readonly string BasePath = Path.Combine("Plugins", "Dislink");
        private static readonly string WPath = Path.Combine(BasePath, "Whitelist.json");
        private static readonly string SPath = Path.Combine(BasePath, "Settings.json");

        public Manager()
        {
            EnsureConfigurationFiles();
        }

        public static void EnsureConfigurationFiles()
        {
            if (!Directory.Exists(BasePath))
                Directory.CreateDirectory(BasePath);

            if (!File.Exists(SPath))
            {
                var Settings = new Settings
                {
                    Whitelist = true,
                    GlobalMessage = "You cannot send links on this server.",
                    LocalMessage = "You cannot send links on this server."
                };

                File.WriteAllText(SPath, JsonConvert.SerializeObject(Settings, Formatting.Indented)); ;
            }

            if (!File.Exists(WPath))
            {
                var Whitelist = new WData
                {
                    Players = new List<string> { "Example1", "Example2" }
                };

                File.WriteAllText(WPath, JsonConvert.SerializeObject(Whitelist, Formatting.Indented));
            }
        }
    }

    public class Settings
    {
        public bool Whitelist { get; set; }
        public string GlobalMessage { get; set; }
        public string LocalMessage { get; set; }
    }

    public class WData
    {
        public List<string> Players { get; set; }
    }
}
