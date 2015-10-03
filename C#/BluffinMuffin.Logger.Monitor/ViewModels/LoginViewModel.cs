using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BluffinMuffin.Logger.Monitor.DataTypes;
using BluffinMuffin.Logger.Monitor.DataTypes.Configuration;
using BluffinMuffin.Logger.Monitor.Xaml.Windows;
using Com.Ericmas001.Wpf;
using Com.Ericmas001.Wpf.ViewModels;

namespace BluffinMuffin.Logger.Monitor.ViewModels
{

    public class LoginViewModel : BaseViewModel
    {
        private EnvironmentConfigElement m_SelectedEnvironment;

        public EnvironmentConfigElement SelectedEnvironment
        {
            get { return m_SelectedEnvironment; }
            set
            {
                m_SelectedEnvironment = value;
                RaisePropertyChanged("SelectedEnvironment");
            }
        }
        public IEnumerable<EnvironmentConfigElement> AllEnvironments => App.Environments.Values.ToArray();

        private RelayCommand m_ConnectCommand;
        public ICommand ConnectCommand => m_ConnectCommand ?? (m_ConnectCommand = new RelayCommand(x => Connect(), x => m_SelectedEnvironment != null));

        private void Connect()
        {
            App.InitEnvironment(m_SelectedEnvironment);
            Window currentWindow = Application.Current.MainWindow;
            MainWindow nextWindow = new MainWindow();
            Application.Current.MainWindow = nextWindow;
            currentWindow.Close();
            nextWindow.Show();
        }
    }
}
