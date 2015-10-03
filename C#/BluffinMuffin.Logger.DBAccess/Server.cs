using System;

namespace BluffinMuffin.Logger.DBAccess
{
    public class Server
    {
        internal int Id { get; private set; }

        public string ServerIdentification { get; }
        public Version ImplementedProtocol { get; }
        public DateTime ServerStartedAt { get; internal set; }

        public Server(string serverIdentification, Version implementedProtocol)
        {
            ServerIdentification = serverIdentification;
            ImplementedProtocol = implementedProtocol;
        }

        public void RegisterServer()
        {
            if (Id > 0)
                return;

            ServerStartedAt = DateTime.Now;

            using (var context = Database.GetContext())
            {
                var s = new ServerEntity
                {
                    ImplementedProtocol = ImplementedProtocol.ToString(3),
                    ServerIdentification = ServerIdentification,
                    ServerStartedAt = ServerStartedAt 
                };
                context.AllServers.Add(s);
                context.SaveChanges();
                Id = s.Id;
            }
        }
    }
}
