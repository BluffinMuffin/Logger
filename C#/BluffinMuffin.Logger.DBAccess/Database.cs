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
        private static BluffinMuffinLogsEntities m_Db = null;

        internal static BluffinMuffinLogsEntities Entities => m_Db;

        public static void InitDatabase(string hostname, string username, string password, string database)
        {
            //Build an SQL connection string
            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
                DataSource = hostname,
                InitialCatalog = database,
                UserID = username,
                Password = password
            };

            //Build an entity framework connection string
            EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                Metadata = "res://*/LoggingModel.csdl|res://*/LoggingModel.ssdl|res://*/LoggingModel.msl",
                ProviderConnectionString = sqlString.ToString()
            };

            m_Db = new BluffinMuffinLogsEntities(entityString.ToString());
        }

        public static void CheckIfInitialized()
        {
            if(m_Db == null)
                throw new Exception("Call BluffinMuffin.Logger.DBAccess.Database.InitDatabase() before using the database.");
        }
    }
}
