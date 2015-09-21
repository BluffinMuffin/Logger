using System;

namespace BluffinMuffin.Logger.DBAccess
{
    public class Server
    {
        private bool m_Registered;

        public string ServerIdentification { get; }
        public Version ImplementedProtocol { get; }

        public Server(string serverIdentification, Version implementedProtocol)
        {
            ServerIdentification = serverIdentification;
            ImplementedProtocol = implementedProtocol;
        }

        public void RegisterServer()
        {
            if (m_Registered)
                return;

            using (var context = Database.GetContext())
            {
                context.AllServers.Add(new ServerEntity {ImplementedProtocol = ImplementedProtocol.ToString(3), ServerIdentification = ServerIdentification, ServerStartedAt = DateTime.Now});
                context.SaveChanges();
            }
            m_Registered = true;
        }
    }
}
