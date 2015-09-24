using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BluffinMuffin.Logger.Monitor.DataTypes;

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
        }
    }
}
