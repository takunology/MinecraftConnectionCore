using System;
using System.Net;
using System.Threading.Tasks;
using MinecraftConnectionCore;

namespace SampleApp
{
    class Program
    {
        private static IPAddress Address = IPAddress.Parse("127.0.0.1");
        private static ushort Port = 25575;
        private static string Pass = "minecraft";
        private static MinecraftCommands command = new MinecraftCommands(Address, Port, Pass);

        static void Main(string[] args)
        {
            command.SendCommand("/time set 0");
        }
    }
}
