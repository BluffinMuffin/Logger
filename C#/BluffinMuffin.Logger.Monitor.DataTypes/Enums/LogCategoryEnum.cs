using System.ComponentModel;
using Com.Ericmas001.Portable.Util.Entities.Attributes;
using Com.Ericmas001.Wpf.Entities.Attributes;

namespace BluffinMuffin.Logger.Monitor.DataTypes.Enums
{
    public enum LogCategoryEnum
    {
        All,

        [EnumDescription("Executed Commands")]
        [Color("LightGreen")]
        [ButtonColor("Green")]
        [ImageSource("ImgLogs16", "ImgLogs32")]
        [Priority(100)]
        ExecutedCommand,
    }
}