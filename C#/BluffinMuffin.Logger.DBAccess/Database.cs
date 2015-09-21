using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluffinMuffin.Logger.DBAccess
{
    public static class Database
    {
        private static string m_ConnectionString;

        public static void InitDatabase(string hostname, string username, string password, string database)
        {
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
        }

        public static BluffinMuffinLogsEntities GetContext()
        {
            if(m_ConnectionString == null)
                throw new Exception("Call BluffinMuffin.Logger.DBAccess.Database.InitDatabase() before using the database.");
            return new BluffinMuffinLogsEntities(m_ConnectionString);
        }
    }
}
