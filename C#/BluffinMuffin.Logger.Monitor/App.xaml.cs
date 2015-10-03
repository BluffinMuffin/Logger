using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BluffinMuffin.Logger.Monitor.DataTypes;
using BluffinMuffin.Logger.DBAccess;
using BluffinMuffin.Logger.Monitor.DataTypes.Configuration;

namespace BluffinMuffin.Logger.Monitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        internal static Dictionary<string, EnvironmentConfigElement> Environments;
        public App()
        {
            // Grab the Environments listed in the App.config and add them to our list.
            var connectionManagerDataSection = ConfigurationManager.GetSection(BluffinMuffinDataSection.SECTION_NAME) as BluffinMuffinDataSection;
            if (connectionManagerDataSection != null)
                Environments = connectionManagerDataSection.Environments.OfType<EnvironmentConfigElement>().ToDictionary(x => x.Name, x => x);
        }
        internal static EnvironmentConfigElement Environment { get; private set; }

        internal static void InitEnvironment(EnvironmentConfigElement environment)
        {
            Environment = environment;
            Database.InitDatabase(environment.Url, environment.User, environment.Password, environment.Database);
        }
    }
}
