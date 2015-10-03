using System;
using BluffinMuffin.Logger.DBAccess;
using Com.Ericmas001.AppMonitor.DataTypes;

namespace BluffinMuffin.Logger.Monitor.DataTypes
{
    public class ExecutedCommandInfo : IDataItemInfo
    {
        public Command Command { get; }
        public DateTime DateAndTime => Command.ExecutionTime;

        public ExecutedCommandInfo(Command c)
        {
            Command = c;
        }
    }
}
