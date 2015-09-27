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
                    var s = FindServer(context, x);
                    yield return new Command(x.Name, s, FindClient(context, x), x.Detail, x.IsFromServer, x.Type, FindGame(context, x, s))
                    {
                        ExecutionTime = x.ExecutionTime
                    };
                }
            }
        }

        private static readonly Dictionary<int, Server> m_Servers = new Dictionary<int, Server>();
        private static Server FindServer(BluffinMuffinLogsEntities context, CommandEntity x)
        {
            if (!m_Servers.ContainsKey(x.ServerId))
            {
                var serv = context.AllServers.Single(y => y.Id == x.ServerId);
                m_Servers.Add(x.ServerId, new Server(serv.ServerIdentification, new Version(serv.ImplementedProtocol)));
            }
            return m_Servers[x.ServerId];
        }

        private static readonly Dictionary<int, Client> m_Clients = new Dictionary<int, Client>();
        private static Client FindClient(BluffinMuffinLogsEntities context, CommandEntity x)
        {
            if (!m_Clients.ContainsKey(x.ClientId))
            {
                var cli = context.AllClients.Single(y => y.Id == x.ClientId);
                m_Clients.Add(x.ClientId, new Client(cli.Hostname)
                {
                    DisplayName = cli.DisplayName,
                    ClientIdentification = cli.ClientIdentification,
                    ImplementedProtocol = cli.ImplementedProtocol == null ? null : new Version(cli.ImplementedProtocol)
                });
            }
            return m_Clients[x.ClientId];
        }

        private static readonly Dictionary<int, Game> m_Games = new Dictionary<int, Game>();
        private static Game FindGame(BluffinMuffinLogsEntities context, CommandEntity x, Server s)
        {
            if (x.GameId == null)
                return null;
            if (!m_Games.ContainsKey(x.GameId.Value))
            {
                var gam = context.AllGames.Single(y => y.Id == x.GameId.Value);
                m_Games.Add(x.GameId.Value, new Game(FindTable(context, gam, s)));
            }
            return m_Games[x.GameId.Value];
        }

        private static readonly Dictionary<int, Table> m_Tables = new Dictionary<int, Table>();
        private static Table FindTable(BluffinMuffinLogsEntities context, GameEntity x, Server s)
        {
            if (!m_Tables.ContainsKey(x.TableParamId))
            {
                var tab = context.AllTableParams.Single(y => y.Id == x.TableParamId);
                m_Tables.Add(x.TableParamId, new Table(
                    tab.TableName,
                    FindGameSubType(context, tab),
                    tab.MinPlayerToStart,
                    tab.MaxPlayer,
                    FindBlind(context, tab),
                    FindLobby(context, tab),
                    FindLimit(context, tab),
                    s));
            }
            return m_Tables[x.TableParamId];
        }

        private static readonly Dictionary<int, BlindTypeEnum> m_Blinds = new Dictionary<int, BlindTypeEnum>();
        private static BlindTypeEnum FindBlind(BluffinMuffinLogsEntities context, TableParamEntity x)
        {
            if (!m_Blinds.ContainsKey(x.BlindTypeId))
            {
                var b = context.AllBlindTypes.Single(y => y.Id == x.BlindTypeId);
                m_Blinds.Add(x.BlindTypeId, (BlindTypeEnum)Enum.Parse(typeof(BlindTypeEnum), b.Name));
            }
            return m_Blinds[x.BlindTypeId];
        }

        private static readonly Dictionary<int, LobbyTypeEnum> m_Lobbys = new Dictionary<int, LobbyTypeEnum>();
        private static LobbyTypeEnum FindLobby(BluffinMuffinLogsEntities context, TableParamEntity x)
        {
            if (!m_Lobbys.ContainsKey(x.LobbyTypeId))
            {
                var l = context.AllLobbyTypes.Single(y => y.Id == x.LobbyTypeId);
                m_Lobbys.Add(x.LobbyTypeId, (LobbyTypeEnum)Enum.Parse(typeof(LobbyTypeEnum), l.Name));
            }
            return m_Lobbys[x.LobbyTypeId];
        }

        private static readonly Dictionary<int, LimitTypeEnum> m_Limits = new Dictionary<int, LimitTypeEnum>();
        private static LimitTypeEnum FindLimit(BluffinMuffinLogsEntities context, TableParamEntity x)
        {
            if (!m_Limits.ContainsKey(x.LimitTypeId))
            {
                var l = context.AllLimitTypes.Single(y => y.Id == x.LimitTypeId);
                m_Limits.Add(x.LimitTypeId, (LimitTypeEnum)Enum.Parse(typeof(LimitTypeEnum), l.Name));
            }
            return m_Limits[x.LimitTypeId];
        }

        private static readonly Dictionary<int, GameSubTypeEnum> m_GameSubType = new Dictionary<int, GameSubTypeEnum>();
        private static GameSubTypeEnum FindGameSubType(BluffinMuffinLogsEntities context, TableParamEntity x)
        {
            if (!m_GameSubType.ContainsKey(x.GameSubTypeId))
            {
                var subtype = context.AllGameSubTypes.Single(y => y.Id == x.GameSubTypeId);
                m_GameSubType.Add(x.GameSubTypeId, (GameSubTypeEnum)Enum.Parse(typeof(GameSubTypeEnum), subtype.Name));
            }
            return m_GameSubType[x.GameSubTypeId];
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
