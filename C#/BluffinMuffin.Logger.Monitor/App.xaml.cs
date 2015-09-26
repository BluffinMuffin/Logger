using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BluffinMuffin.Logger.Monitor.DataTypes;
using BluffinMuffin.Logger.DBAccess;

namespace BluffinMuffin.Logger.Monitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        internal static BluffinEnvironment Environment { get; private set; }

        internal static void InitEnvironment(BluffinEnvironment environment)
        {
            Environment = environment;
            Database.InitDatabase("turnsol.arvixe.com", "BluffinMuffin_Logger_Test", "1ti3gre2", "BluffinMuffin_Logs_Test");
        }
    }
}
