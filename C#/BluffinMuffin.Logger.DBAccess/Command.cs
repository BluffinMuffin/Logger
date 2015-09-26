using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Logger.DBAccess.Enums;

namespace BluffinMuffin.Logger.DBAccess
{
    public class Command
    {

        private const string GENERAL = "GENERAL";
        private const string LOBBY = "LOBBY";
        private const string GAME = "GAME";


        public string Name { get; internal set; }
        public Server Server { get; internal set; }
        public Client Client { get; internal set; }
        public string Details { get; internal set; }
        public bool IsFromServer { get; internal set; }
        public string Type { get; internal set; }
        public Game Game { get; internal set; }
        public DateTime ExecutionTime { get; internal set; }

        private Command(string name, Server server, Client client, string details, bool isFromServer, string type, Game game = null)
        {
            Name = name;
            Server = server;
            Client = client;
            Details = details;
            IsFromServer = isFromServer;
            Type = type;
            Game = game;
            ExecutionTime = DateTime.Now;
        }

        private static void RegisterCommand(string name, Server srv, Client cli, string detail, bool isFromServer, string type, Game g = null)
        {
            Database.CommandsToLog.Add(new Command(name, srv, cli, detail, isFromServer, type, g));
        }

        internal void ExecuteRegistering()
        {
            using (var context = Database.GetContext())
            {
                var client = context.AllClients.Single(x => x.Id == Client.Id);
                var server = context.AllServers.Single(x => x.Id == Server.Id);
                var game = Game == null ? null : context.AllGames.Single(x => x.Id == Game.Id);
                var c = new CommandEntity()
                {
                    Name = Name,
                    Detail = Details,
                    IsFromServer = IsFromServer,
                    Type = Type,
                    Server = server,
                    Client = client,
                    ExecutionTime = ExecutionTime,
                    Game = game
                };
                context.AllCommands.Add(c);
                context.SaveChanges();
            }
        }

        public static IEnumerable<string> AllCommandNames()
        {
            using (var context = Database.GetContext())
            {
                return context.AllCommands.Select(x => x.Name).Distinct().AsEnumerable().ToArray();
            }
        } 

        public static IEnumerable<Command> AllCommands()
        {
            return GetCommands();
        }

        public static IEnumerable<Command> AllCommandsOfDate(DateTime d)
        {
            return GetCommands(x => x.ExecutionTime.Date == d.Date);
        }

        public static IEnumerable<Command> AllCommandsOfName(string n)
        {
            return GetCommands(x => x.Name == n);
        }

        private static IEnumerable<Command> GetCommands(Func<CommandEntity,bool> whereClause = null )
        {
            using (var context = Database.GetContext())
            {
                var xs = whereClause == null ? context.AllCommands.AsEnumerable() : context.AllCommands.Where(whereClause).AsEnumerable();
                foreach (var x in xs)
                {
                    var s = x.Server == null ? null : new Server(x.Server.ServerIdentification, new Version(x.Server.ImplementedProtocol));
                    var t = x.Game?.TableParam;
                    yield return new Command(
                        x.Name,
                        s,
                        x.Client == null ? null :
                        new Client(x.Client.Hostname)
                        {
                            DisplayName = x.Client.DisplayName,
                            ClientIdentification = x.Client.ClientIdentification,
                            ImplementedProtocol = new Version(x.Client.ImplementedProtocol)
                        },
                        x.Detail,
                        x.IsFromServer,
                        x.Type,
                        x.Game == null ? null : new Game(new Table(
                            t.TableName,
                            (GameSubTypeEnum)Enum.Parse(typeof(GameSubTypeEnum), t.GameSubType.Name),
                            t.MinPlayerToStart,
                            t.MaxPlayer,
                            (BlindTypeEnum)Enum.Parse(typeof(BlindTypeEnum), t.BlindType.Name),
                            (LobbyTypeEnum)Enum.Parse(typeof(LobbyTypeEnum), t.LobbyType.Name),
                            (LimitTypeEnum)Enum.Parse(typeof(LimitTypeEnum), t.LimitType.Name),
                            s)))
                    {
                        ExecutionTime = x.ExecutionTime
                    };
                }
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
