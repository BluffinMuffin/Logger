using BluffinMuffin.Logger.Monitor.DataTypes;
using Com.Ericmas001.AppMonitor.DataTypes.DataElements;
using Newtonsoft.Json;

namespace BluffinMuffin.Logger.Monitor.ViewModels.Entities.DataElements
{
    public class ExecutedCommandDataElement : BaseDataElement
    {
        //public string Source
        //{
        //    get { return String.Format("{0}       {1}       {2}", Command.Info.SourceUrl, Command.Info.SourceController, Command.Info.SourceAction); }
        //}
        //public string Destination
        //{
        //    get { return String.Format("{0}       {1}       {2}", Command.Info.DestUrl, Command.Info.DestController, Command.Info.DestAction); }
        //}

        //public string DestinationCompleteUrl
        //{
        //    get { return String.Format("{0}/{1}/{2}{3}{4}", Command.Info.DestUrl, Command.Info.DestController, Command.Info.DestAction, HasParameters ? "?" : "", Command.Info.Params); }
        //}

        //public bool HasParameters
        //{
        //    get { return Params.Any(); }
        //}

        //public KeyValuePair<string, string>[] Params
        //{
        //    get
        //    {
        //        return Command.Info.Params
        //            .Split(new[] { '?', '&' }, StringSplitOptions.RemoveEmptyEntries)
        //            .Select(x => new KeyValuePair<string, string>(x.Split('=')[0], x.Split('=')[1]))
        //            .ToArray();
        //    }
        //}
        //public string ParamsText
        //{
        //    get { return String.Join(Environment.NewLine, Params.Select(kvp => kvp.Key + ": " + kvp.Value)); }
        //}
        public string Result
        {
            get { return JsonConvert.SerializeObject(JsonConvert.DeserializeObject(Command.Info.Command.Details), Formatting.Indented); }
        }

        public ExecutedCommand Command { get; private set; }

        //private RelayCommand m_TryUrlCommand;
        //public ICommand TryUrlCommand
        //{
        //    get { return m_TryUrlCommand ?? (m_TryUrlCommand = new RelayCommand(x => TryUrl())); }
        //}
        public ExecutedCommandDataElement(ExecutedCommand command)
        {
            Command = command;
        }

        public override string Header => "Command";

        //private void TryUrl()
        //{
        //    Process.Start(DestinationCompleteUrl);
        //}
    }
}

