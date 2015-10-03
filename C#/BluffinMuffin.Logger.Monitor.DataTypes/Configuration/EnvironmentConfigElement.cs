using System.Configuration;

namespace BluffinMuffin.Logger.Monitor.DataTypes.Configuration
{
    public class EnvironmentConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string) this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get { return (string) this["url"]; }
            set { this["url"] = value; }
        }

        [ConfigurationProperty("user", IsRequired = true)]
        public string User
        {
            get { return (string)this["user"]; }
            set { this["user"] = value; }
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }

        [ConfigurationProperty("database", IsRequired = true)]
        public string Database
        {
            get { return (string)this["database"]; }
            set { this["database"] = value; }
        }
    }
}
