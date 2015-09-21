using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BluffinMuffin.Logger.DBAccess.Enums;

namespace BluffinMuffin.Logger.DBAccess.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.InitDatabase("turnsol.arvixe.com","BluffinMuffin_Logger_Test","1ti3gre2","BluffinMuffin_Logs_Test");

            var server = new Server("BluffinMuffin.Logger.DBAccess.Demo", new Version(3, 0, 0));
            server.RegisterServer();

            var client1 = new Client("BluffinMuffin.Logger.DBAccess.Demo", new Version(3, 0, 0), "127.0.0.1");
            client1.RegisterClient();

            var client2 = new Client("BluffinMuffin.Logger.DBAccess.Demo", new Version(3, 0, 0), "127.0.0.1");
            client2.RegisterClient();
            client2.Identify("SpongeBob");

            var table = new Table("Bikini Bottom", GameSubTypeEnum.TexasHoldem, 2,10,BlindTypeEnum.Blinds, LobbyTypeEnum.QuickMode, LimitTypeEnum.NoLimit, server);
            table.RegisterTable();

        }
    }
}
