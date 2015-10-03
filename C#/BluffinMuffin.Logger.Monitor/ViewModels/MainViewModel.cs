using Com.Ericmas001.Wpf.ViewModels.Tabs;

namespace BluffinMuffin.Logger.Monitor.ViewModels
{
    public class MainViewModel : TabControlViewModel
    {
        protected override bool KeepNewTab
        {
            get { return false; }
        }

        public string Title
        {
            get { return string.Format("[{0}] BluffinMuffin Log Monitor", App.Environment.ToString()); }
        }

        protected override NewTabViewModel CreateNewTab()
        {
            return new NewSearchViewModel();
        }
    }
}
