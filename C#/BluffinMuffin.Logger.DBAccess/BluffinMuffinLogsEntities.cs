namespace BluffinMuffin.Logger.DBAccess
{
    public partial class BluffinMuffinLogsEntities
    {
        public BluffinMuffinLogsEntities(string connString) : base(connString)
        {
            AllClients = Set<ClientEntity>();
            AllCommands = Set<CommandEntity>();
            AllBlindTypes = Set<BlindTypeEntity>();
            AllGameSubTypes = Set<GameSubTypeEntity>();
            AllGameTypes = Set<GameTypeEntity>();
            AllLimitTypes = Set<LimitTypeEntity>();
            AllLobbyTypes = Set<LobbyTypeEntity>();
            AllGames = Set<GameEntity>();
            AllServers = Set<ServerEntity>();
            AllTableParams = Set<TableParamEntity>();
        }
    }
}
