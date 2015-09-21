using System;
using System.Linq;
using BluffinMuffin.Logger.DBAccess.Enums;

namespace BluffinMuffin.Logger.DBAccess
{
    public class Command
    {
        private const string GENERAL = "GENERAL";
        private const string LOBBY = "LOBBY";
        private const string GAME = "GAME";

        internal int Id { get; private set; }

        public string Name { get; }
        public Server Server { get; }
        public Client Client { get; }
        public string Detail { get; }

        public Command(string name, Server server, Client client, string detail)
        {
            Name = name;
            Server = server;
            Client = client;
            Detail = detail;
        }

        private void RegisterCommand(bool isFromServer, string type)
        {
            if (Id > 0)
                return;

            using (var context = Database.GetContext())
            {
                var client = context.AllClients.Single(x => x.Id == Client.Id);
                var server = context.AllServers.Single(x => x.Id == Server.Id);
                var c = new CommandEntity()
                {
                    Name = Name,
                    Detail = Detail,
                    IsFromServer = isFromServer,
                    Type = type,
                    Server = server,
                    Client = client,
                    ExecutionTime = DateTime.Now
                };
                context.AllCommands.Add(c);
                context.SaveChanges();
                Id = c.Id;
            }
        }

        public void RegisterGeneralCommandFromServer()
        {
            RegisterCommand(true, GENERAL);
        }

        public void RegisterGeneralCommandFromClient()
        {
            RegisterCommand(false, GENERAL);
        }

        public void RegisterLobbyCommandFromServer()
        {
            RegisterCommand(true, LOBBY);
        }

        public void RegisterLobbyCommandFromClient()
        {
            RegisterCommand(false, LOBBY);
        }

        public void RegisterGameCommandFromServer()
        {
            RegisterCommand(true, GAME);
        }

        public void RegisterGameCommandFromClient()
        {
            RegisterCommand(false, GAME);
        }
    }
}
