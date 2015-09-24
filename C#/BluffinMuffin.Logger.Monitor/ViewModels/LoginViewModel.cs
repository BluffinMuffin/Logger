using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using BluffinMuffin.Logger.Monitor.DataTypes;
using BluffinMuffin.Logger.Monitor.Xaml.Windows;
using Com.Ericmas001.Wpf;
using Com.Ericmas001.Wpf.ViewModels;

namespace BluffinMuffin.Logger.Monitor.ViewModels
{

    public class LoginViewModel : BaseViewModel
    {
        private BluffinEnvironment m_SelectedEnvironment;

        public BluffinEnvironment SelectedEnvironment
        {
            get { return m_SelectedEnvironment; }
            set
            {
                m_SelectedEnvironment = value;
                RaisePropertyChanged("SelectedEnvironment");
            }
        }
        public IEnumerable<BluffinEnvironment> AllEnvironments
        {
            get { return BluffinEnvironment.GetAllEnvironments(); }
        }

        private RelayCommand m_ConnectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                if (m_ConnectCommand == null)
                {
                    m_ConnectCommand = new RelayCommand(x => Connect(), x => m_SelectedEnvironment != null);
                }
                return m_ConnectCommand;
            }
        }

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
