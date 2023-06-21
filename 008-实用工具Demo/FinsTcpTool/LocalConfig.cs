using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinsTcpTool
{
    public class LocalConfig
    {
        private static LocalConfig _instance;

        public static LocalConfig Instance => _instance ?? (_instance = new LocalConfig());

        private const string _configPath = @".\config.json";

        public string IP { get; set; }

        public ushort Port { get; set; } 


        public void SaveConfig()
        {
            string jsonConfigStr = JsonConvert.SerializeObject(Instance);
            File.WriteAllText(_configPath, jsonConfigStr);
        }

        public bool LoadConfig()
        {
            if (File.Exists(_configPath) == false)
            {
                return false;
            }
            string configJsonStr = File.ReadAllText(_configPath);
            _instance = JsonConvert.DeserializeObject<LocalConfig>(configJsonStr);
            return true;
        }
    }
}
