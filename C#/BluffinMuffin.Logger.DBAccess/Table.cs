using System;
using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Logger.DBAccess.Enums;

namespace BluffinMuffin.Logger.DBAccess
{
    public class Table
    {
        internal int Id { get; private set; }

        public string TableName { get; }
        public GameSubTypeEnum GameSubType { get; }
        public GameTypeEnum GameType { get; internal set; }
        public int MinPlayersToStart { get; }
        public int MaxPlayers { get; }
        public string Arguments { get; set; }
        public BlindTypeEnum BlindType { get; }
        public LobbyTypeEnum LobbyType { get; }
        public LimitTypeEnum LimitType { get; }
        public Server Server { get; }
        public DateTime TableStartedAt { get; internal set; }

        public Table(string tableName, GameSubTypeEnum gameSubType, int minPlayersToStart, int maxPlayers, BlindTypeEnum blindType, LobbyTypeEnum lobbyType, LimitTypeEnum limitType, Server server)
        {
            TableName = tableName;
            GameSubType = gameSubType;
            MinPlayersToStart = minPlayersToStart;
            MaxPlayers = maxPlayers;
            BlindType = blindType;
            LobbyType = lobbyType;
            LimitType = limitType;
            Server = server;
        }

        public void RegisterTable()
        {
            if (Id > 0)
                return;

            TableStartedAt = DateTime.Now;

            using (var context = Database.GetContext())
            {
                var gameSubType = context.AllGameSubTypes.Single(x => x.Name == GameSubType.ToString());
                var blindType = context.AllBlindTypes.Single(x => x.Name == BlindType.ToString());
                var lobbyType = context.AllLobbyTypes.Single(x => x.Name == LobbyType.ToString());
                var limitType = context.AllLimitTypes.Single(x => x.Name == LimitType.ToString());
                var server = context.AllServers.Single(x => x.Id == Server.Id);
                var t = new TableParamEntity
                {
                    TableName = TableName,
                    GameSubType = gameSubType,
                    MinPlayerToStart = MinPlayersToStart,
                    MaxPlayer = MaxPlayers,
                    BlindType = blindType,
                    LobbyType = lobbyType,
                    LimitType = limitType,
                    Server = server,
                    Arguments = Arguments,
                    TableStartedAt = TableStartedAt
                };
                context.AllTableParams.Add(t);
                context.SaveChanges();
                Id = t.Id;
            }
        }

        public static IEnumerable<string> AllGameTypes()
        {
            using (var context = Database.GetContext())
            {
                return context.AllGameTypes.Select(x => x.Name).Distinct().AsEnumerable().ToArray();
            }
        }

        public static IEnumerable<string> AllGameSubTypes()
        {
            using (var context = Database.GetContext())
            {
                return context.AllGameSubTypes.Select(x => x.Name).Distinct().AsEnumerable().ToArray();
            }
        }
    }
}
