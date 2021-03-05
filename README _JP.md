# MinecraftConnectionCore - preview

<div>
<img src="./logo.png" width="350" hspace="0" vspace="10">
</div>

![](https://img.shields.io/badge/Minecraft%20Version-1.16.3-brightgreen)

このライブラリは [CoreRCON](https://github.com/ScottKaye/CoreRCON) をベースに Minecraft 用に拡張したものです。非同期処理を意識せずに使用することができ、プログラミングを始めたばかりの方や Minecraft のコマンドを知らない方におすすめです。

# 使い方
## 1. Minecraft サーバの起動
プログラムを実行する前に、まずは RCON の接続設定が必要です。Minecraft Server の保存されているディレクトリ内に `server.properties` があるので、これを次のように書きかえてください。

```
rcon.port=25575
rcon.password=minecraft
enable-rcon=true
```

ここではポート番号を `25575`, パスワードを `minecraft` としています。編集できたら上書き保存して、サーバを起動してください。クライアント側の Minecraft も起動してください。

## 2. プロジェクト作成とパッケージインストール
このパッケージは `.NET Standard 2.0` 以上で使用できます。ここでは `.NET Core (コンソールアプリケーション)` を用いた作成方法について説明します。

NuGet パッケージマネージャにて `MinecraftConnectionCore` をインストールするか、パッケージマネージャーコンソールにて次のコマンドを使用してください。

```
Install-Package MinecraftConnectionCore -Version 1.0.0-beta1
```

詳細：https://www.nuget.org/packages/MinecraftConnectionCore/1.0.0-beta1

まずは 1 で設定した値をもとに、インスタンスを生成します。もし、ローカル環境で動かしている場合は IP アドレスを `127.0.0.1` とします。

次に、生成したインスタンスのメソッドを使用して、Minecraft にコマンドを送信します。このライブラリで使用できるメソッドは次の通りです。

- `DisplayMessage (object Text)`
- `DisplayTitle (object Text)`
- `GiveEffect (string PlayerName, string EffectID, int Time)`
- `GiveItem (string PlayerName, string ItemID, int Count)`
- `ItemClear (string PlayerName, string ItemID, int Count)`
- `SendCommand (string Command)`
- `SetBlock (int x, int y, int z, string BlockItemID)`
- `Summon (int x, int y, int z, string EntityID)`

例えば、時間を 0 に設定するコマンドを実行したいときは次のようなプログラムを書きます。

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
        private static MinecraftCommands command = new MinecraftCommands(Address, Port, Pass);

        static void Main(string[] args)
        {
            command.SendCommand("/time set 0");
        }
    }
}
```

任意の座標にブロックを設置する場合は `SetBlock()` メソッドを使用します。連続した座標にブロックを配置していくときは `for` ステートメントの変数を使って、座標をインクリメントしていきます。次のプログラムは 10 × 10 の石ブロックで床（平面）を作成します。

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
            command.SetBlock(x + i, y, z + j, "minecraft:stone");
        }
    }
}
```

様々なコマンドを実行して、C# によるマインクラフトプログラミングを楽しんでください！
