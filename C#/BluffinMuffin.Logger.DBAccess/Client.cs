using System;
using System.Linq;
using static System.String;

namespace BluffinMuffin.Logger.DBAccess
{
    public class Client
    {
        internal int Id { get; private set; }

        public string ClientIdentification { get; }
        public string Hostname { get; }
        public string DisplayName { get; private set; }
        public Version ImplementedProtocol { get; }

        public Client(string clientIdentification, Version implementedProtocol, string hostname)
        {
            ClientIdentification = clientIdentification;
            ImplementedProtocol = implementedProtocol;
            Hostname = hostname;
        }

        public void RegisterClient()
        {
            if (Id > 0)
                return;

            using (var context = Database.GetContext())
            {
                var c = new ClientEntity { ImplementedProtocol = ImplementedProtocol.ToString(3), ClientIdentification = ClientIdentification, ClientStartedAt = DateTime.Now, Hostname = Hostname};
                context.AllClients.Add(c);
                context.SaveChanges();
                Id = c.Id;
            }
        }

        public void Identify(string displayName)
        {
            if (Id == 0 || !IsNullOrEmpty(DisplayName))
                return;

            using (var context = Database.GetContext())
            {
                var c = context.AllClients.Single(x => x.Id == Id);
                c.DisplayName = DisplayName = displayName;
                context.SaveChanges();
            }
        }
    }
}
