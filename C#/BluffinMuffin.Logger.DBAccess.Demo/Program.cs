using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BluffinMuffin.Logger.DBAccess.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.InitDatabase("turnsol.arvixe.com","BluffinMuffin_Logger_Test","1ti3gre2","BluffinMuffin_Logs_Test");

            var server = new Server("BluffinMuffin.Logger.DBAccess.Demo", new Version(3, 0, 0));
            server.RegisterServer();

            var client = new Client("BluffinMuffin.Logger.DBAccess.Demo", new Version(3, 0, 0),"127.0.0.1");
            client.RegisterClient();
            client.Identify("SpongeBob");

        }
    }
}
