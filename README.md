# MinecraftConnectionCore - preview

<div>
<img src="./logo.png" width="350" hspace="0" vspace="10">
</div>

![](https://img.shields.io/badge/Minecraft%20Version-1.16.3-brightgreen)

日本語版は [こちら](https://github.com/takunology/MinecraftConnectionCore/blob/main/README%20_JP.md)

It is based on [CoreRCON](https://github.com/ScottKaye/CoreRCON) and extended for minecraft. This library can be used without being aware of asynchronous processing. It also provides basic minecraft commands, so that you can easily execute commands without knowing them.

# How to Use it?
## 1. Launch a Minecraft server
To run the program, you need to set up the RCON connection. Change the settings of `server.properties` in the directory of your minecraft server as follows The password and port number can be anything you want. (Please use Minecraft server version 1.13 or higher.)

This example, the port number is `25575` and the password is 'minecraft'.

```
rcon.port=25575
rcon.password=minecraft
enable-rcon=true
```

Save the configuration and start the server. Start Minecraft (the client) as well, and log in to the server. </br>


## 2. Create a project and install the package
This package is available for `.NET Standard 2.0` and higher. Here is a sample code using `.NET Core (console application)` as an example.

Search for `MinecraftConnectionCore` in NuGet Package Manager and Install it, or use the following command in the Package Manager Console

```
Install-Package MinecraftConnectionCore -Version 1.0.0-beta1
```

Details : https://www.nuget.org/packages/MinecraftConnectionCore/1.0.0-beta1

First, Create an instance based on the parameters for connecting to the RCON of the minecraft server.Use the values set in Section 1 for the parameters. Also, if you want to use the minecraft server locally, set the IP address to `127.0.0.1`. 

Next, use the methods of the generated instance.The methods available in this library are as follows.

- DisplayMessage(object Text);
- DisplayTitle(object Text);
- GiveEffect(string PlayerName, string EffectID, int Time);
- GiveItem(string PlayerName, string ItemID, int Count);
- ItemClear(string PlayerName, string ItemID, int Count);
- SendCommand(string Command);
- SetBlock(int x, int y, int z, string BlockItemID);
- Summon(int x, int y, int z, string EntityID);

For example, a program to set the time to 0 could be written like this. 

```cs
using System.Net;
using MinecraftConnectionCore;

namespace ExampleApp
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
```

If you want to place a block, use the `SetBlock()` method. The coordinates to be placed can be specified, so if you want to place the blocks consecutively, use the `for` statement. This program creates a plane (floor) made of 10 x 10 stone blocks.

```cs
static void Main(string[] args)
{
    // Player's coordinates
    int x = 256;
    int y = 64; 
    int z = 128;

    for (int i = 0; i < 10; i++) 
    {
        for (int j = 0; j < 10; j++) 
        {
            Command.SetBlock(x + i, y, z + j, "minecraft:stone");
        }
    }
}
```

Try to run various commands!
