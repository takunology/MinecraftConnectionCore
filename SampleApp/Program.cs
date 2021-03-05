using System;
using System.Net;
using MinecraftConnectionCore;

namespace SampleApp
{
    class Program
    {
        private static IPAddress Address = IPAddress.Parse("127.0.0.1");
        private static ushort Port = 25575;
        private static string Pass = "minecraft";
        private static MinecraftCommands Command = new MinecraftCommands(Address, Port, Pass);

        static void Main(string[] args)
        {
            Command.SendCommand("/time set 0");
            
        }
    }
}
