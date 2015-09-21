using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace BluffinMuffin.Logger.DBAccess
{
    public static class Database
    {
        private static string m_ConnectionString;

        internal static BlockingCollection<Command> CommandsToLog { get; } = new BlockingCollection<Command>();

        public static void InitDatabase(string hostname, string username, string password, string database)
        {
            if (!IsNullOrEmpty(m_ConnectionString))
                return;

            //Build an SQL connection string
            var sqlString = new SqlConnectionStringBuilder()
            {
                DataSource = hostname,
                InitialCatalog = database,
                UserID = username,
                Password = password,
                ApplicationName = "EntityFramework",
                MultipleActiveResultSets = true,
                PersistSecurityInfo = true
            };

            //Build an entity framework connection string
            var entityString = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                Metadata = "res://*/BluffinMuffinLogs.csdl|res://*/BluffinMuffinLogs.ssdl|res://*/BluffinMuffinLogs.msl",
                ProviderConnectionString = sqlString.ToString()
            };

            m_ConnectionString = entityString.ToString();
            Task.Factory.StartNew(LogCommands);
        }

        private static void LogCommands()
        {
            foreach (Command c in CommandsToLog.GetConsumingEnumerable())
                c.ExecuteRegistering();
        }

        internal static BluffinMuffinLogsEntities GetContext()
        {
            if(m_ConnectionString == null)
                throw new Exception("Call BluffinMuffin.Logger.DBAccess.Database.InitDatabase() before using the database.");
            return new BluffinMuffinLogsEntities(m_ConnectionString);
        }
    }
}
