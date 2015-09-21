using System;
using System.Linq;
using System.Threading;

namespace BluffinMuffin.Logger.DBAccess
{
    public class Command
    {

        private const string GENERAL = "GENERAL";
        private const string LOBBY = "LOBBY";
        private const string GAME = "GAME";


        private readonly string m_Name;
        private readonly Server m_Server;
        private readonly Client m_Client;
        private readonly string m_Details;
        private readonly bool m_IsFromServer;
        private readonly string m_Type;
        private readonly Game m_Game;
        private readonly DateTime m_ExecutionTime;

        private Command(string name, Server server, Client client, string details, bool isFromServer, string type, Game game = null)
        {
            m_Name = name;
            m_Server = server;
            m_Client = client;
            m_Details = details;
            m_IsFromServer = isFromServer;
            m_Type = type;
            m_Game = game;
            m_ExecutionTime = DateTime.Now;;
        }

        private static void RegisterCommand(string name, Server srv, Client cli, string detail, bool isFromServer, string type, Game g = null)
        {
            Database.CommandsToLog.Add(new Command(name, srv, cli, detail, isFromServer, type, g));
        }

        internal void ExecuteRegistering()
        {
            using (var context = Database.GetContext())
            {
                var client = context.AllClients.Single(x => x.Id == m_Client.Id);
                var server = context.AllServers.Single(x => x.Id == m_Server.Id);
                var game = m_Game == null ? null : context.AllGames.Single(x => x.Id == m_Game.Id);
                var c = new CommandEntity()
                {
                    Name = m_Name,
                    Detail = m_Details,
                    IsFromServer = m_IsFromServer,
                    Type = m_Type,
                    Server = server,
                    Client = client,
                    ExecutionTime = m_ExecutionTime,
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
