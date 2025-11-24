using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Weather_API_Library
{
    class InfoCommand : CommandBase
    {
        public void runCommand(string command)
        {
            if (command.Equals("info"))
            {
                Console.WriteLine("開発者：TokumeiKibou01");
            }
        }
    }
}
