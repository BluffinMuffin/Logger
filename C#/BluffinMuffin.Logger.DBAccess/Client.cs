using System;
using System.Linq;
using static System.String;

namespace BluffinMuffin.Logger.DBAccess
{
    public class Client
    {
        internal int Id { get; private set; }

        public string ClientIdentification { get; internal set; }
        public string Hostname { get; }
        public string DisplayName { get; internal set; }
        public Version ImplementedProtocol { get; internal set; }

        public Client(string hostname)
        {
            Hostname = hostname;
        }

        public void RegisterClient()
        {
            if (Id > 0)
                return;

            using (var context = Database.GetContext())
            {
                var c = new ClientEntity { ClientStartedAt = DateTime.Now, Hostname = Hostname};
                context.AllClients.Add(c);
                context.SaveChanges();
                Id = c.Id;
            }
        }

        public void SetAdditionalInformation(string clientIdentification, Version implementedProtocol)
        {
            if (Id == 0 || !IsNullOrEmpty(ClientIdentification) || ImplementedProtocol != null)
                return;
            ClientIdentification = clientIdentification;
            ImplementedProtocol = implementedProtocol;

            using (var context = Database.GetContext())
            {
                var c = context.AllClients.Single(x => x.Id == Id);
                c.ImplementedProtocol = ImplementedProtocol.ToString(3);
                c.ClientIdentification = ClientIdentification;
                context.SaveChanges();
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
