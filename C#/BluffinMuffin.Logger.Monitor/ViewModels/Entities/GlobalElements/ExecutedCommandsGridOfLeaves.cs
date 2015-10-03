using System;
using System.Collections.Generic;
using BluffinMuffin.Logger.Monitor.DataTypes;
using Com.Ericmas001.AppMonitor.DataTypes.GlobalElements;
using Com.Ericmas001.AppMonitor.DataTypes.TreeElements;

namespace BluffinMuffin.Logger.Monitor.ViewModels.Entities.GlobalElements
{
    public class ExecutedCommandsGridOfLeaves : GridOfLeavesGlobalElement<ExecutedCommand>
    {
        public ExecutedCommandsGridOfLeaves(BaseBranchTreeElement branch) : base(branch)
        {
        }

        public override Dictionary<string, Func<ExecutedCommand, object>> Columns
        {
            get
            {
                return new Dictionary<string, Func<ExecutedCommand, object>>()
                {
                    //{"Id", x => x.Info.Id},
                    {"Date", x => x.DateAndTime},
                    {"Name", x => x.Info.Command.Name},
                    //{"SourceId", x => x.Info.SourceId},
                    //{"SourceUrl", x => x.Info.SourceUrl},
                    //{"SourceController", x => x.Info.SourceController},
                    //{"SourceAction", x => x.Info.SourceAction},
                    //{"DestId", x => x.Info.DestId},
                    //{"DestUrl", x => x.Info.DestUrl},
                    //{"DestController", x => x.Info.DestController},
                    //{"DestAction", x => x.Info.DestAction},
                    //{"ContextId", x => x.Info.ContextId},
                    //{"SessionId", x => x.Info.SessionId},
                    //{"UserId", x => x.Info.UserId},
                    //{"UserAgent", x => x.Info.UserAgent},
                    //{"UserIP", x => x.Info.UserIP},
                    //{"BrowserName", x => x.Info.BrowserName},
                    //{"BrowserPlatform", x => x.Info.BrowserPlatform},
                    //{"BrowserVersion", x => x.Info.BrowserVersion},
                    //{"BrowserEcmaScriptVersion", x => x.Info.BrowserEcmaScriptVersion},
                    //{"IsOnMobile", x => x.Info.IsOnMobile},
                    //{"UniqueUserName", x => x.Info.UniqueUserName},
                    //{"RealName", x => x.Info.RealName},
                };
            }
        }
    }
}
