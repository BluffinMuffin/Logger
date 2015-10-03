using System.Configuration;

namespace BluffinMuffin.Logger.Monitor.DataTypes.Configuration
{
    public class EnvironmentsConfigCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new EnvironmentConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((EnvironmentConfigElement) element).Name;
        }
    }
}
