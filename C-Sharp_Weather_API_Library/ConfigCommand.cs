using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Weather_API_Library
{
    internal class ConfigCommand : CommandBase
    {
        public void runCommand(string command)
        {
            if (command.Equals("get_config"))
            {
                ConfigJson configJson = ConfigManager.GetConfig();
                Console.WriteLine("生データ：" + ConfigManager.GetRawJson());
            }
        }
    }
}
