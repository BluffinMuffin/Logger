using System;
using System.Linq;

namespace BluffinMuffin.Logger.DBAccess
{
    public class Command
    {
        private const string GENERAL = "GENERAL";
        private const string LOBBY = "LOBBY";
        private const string GAME = "GAME";

        internal int Id { get; private set; }

        private static void RegisterCommand(string name, Server srv, Client cli, string detail, bool isFromServer, string type, Game g = null)
        {
            using (var context = Database.GetContext())
            {
                var client = context.AllClients.Single(x => x.Id == cli.Id);
                var server = context.AllServers.Single(x => x.Id == srv.Id);
                var game = g == null ? null : context.AllGames.Single(x => x.Id == g.Id);
                var c = new CommandEntity()
                {
                    Name = name,
                    Detail = detail,
                    IsFromServer = isFromServer,
                    Type = type,
                    Server = server,
                    Client = client,
                    ExecutionTime = DateTime.Now,
                    Game = game
                };
                context.AllCommands.Add(c);
                context.SaveChanges();
            }
        }

        public static void RegisterGeneralCommandFromServer(string name, Server srv, Client cli, string detail)
        {
            RegisterCommand(name, srv, cli, detail, true, GENERAL);
        }

        public static void RegisterGeneralCommandFromClient(string name, Server srv, Client cli, string detail)
        {
            RegisterCommand(name, srv, cli, detail, false, GENERAL);
        }

        public static void RegisterLobbyCommandFromServer(string name, Server srv, Client cli, string detail)
        {
            RegisterCommand(name, srv, cli, detail, true, LOBBY);
        }

        public static void RegisterLobbyCommandFromClient(string name, Server srv, Client cli, string detail)
        {
            RegisterCommand(name, srv, cli, detail, false, LOBBY);
        }

        public static void RegisterGameCommandFromServer(string name, Game game, Client cli, string detail)
        {
            RegisterCommand(name, game.Table.Server, cli, detail, true, GAME, game);
        }

        public static void RegisterGameCommandFromClient(string name, Game game, Client cli, string detail)
        {
            RegisterCommand(name, game.Table.Server, cli, detail, false, GAME, game);
        }
    }
}
