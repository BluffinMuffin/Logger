using System;
using Com.Ericmas001.AppMonitor.DataTypes;

namespace BluffinMuffin.Logger.Monitor.DataTypes
{
    public class ExecutedCommandInfo : IDataItemInfo
    {
        public DateTime DateAndTime => DateTime.Now;
    }
}
