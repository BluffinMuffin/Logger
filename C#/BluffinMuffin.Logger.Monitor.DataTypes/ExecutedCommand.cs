using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.Logger.DBAccess;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;
using Com.Ericmas001.AppMonitor.DataTypes;
using Com.Ericmas001.Portable.Util;
using Newtonsoft.Json;

namespace BluffinMuffin.Logger.Monitor.DataTypes
{
    public class ExecutedCommand : BaseDataItemWithInfo<ExecutedCommandInfo>, IDataItem<CriteriaEnum>
    {
        public ExecutedCommand(ExecutedCommandInfo info)
            : base(info)
        {
        }

        protected override Dictionary<string, string> ObtainAllFields()
        {
            var res = new Dictionary<string, string>
            {
                {"Name", Info.Command.Name},
                {"IsFromServer", Info.Command.IsFromServer.ToString()},
                {"Type", Info.Command.Type},
                {"ExecutionTime", Info.Command.ExecutionTime.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                {"Server.ServerIdentification", Info.Command.Server?.ServerIdentification},
                {"Server.ImplementedProtocol", Info.Command.Server?.ImplementedProtocol.ToString(3)},
                {"Server.ServerStartedAt", Info.Command.Server?.ServerStartedAt.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                {"Client.ClientIdentification", Info.Command.Client?.ClientIdentification},
                {"Client.ImplementedProtocol", Info.Command.Client?.ImplementedProtocol?.ToString(3)},
                {"Client.Hostname", Info.Command.Client?.Hostname},
                {"Client.DisplayName", Info.Command.Client?.DisplayName},
                {"Client.ClientStartedAt", Info.Command.Client?.ClientStartedAt.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                {"Game.GameStartedAt", Info.Command.Game?.GameStartedAt.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                {"Game.Table.TableName", Info.Command.Game?.Table?.TableName},
                {"Game.Table.GameType", Info.Command.Game?.Table?.GameType.ToString()},
                {"Game.Table.GameSubType", Info.Command.Game?.Table?.GameSubType.ToString()},
                {"Game.Table.MinPlayersToStart", Info.Command.Game?.Table?.MinPlayersToStart.ToString()},
                {"Game.Table.MaxPlayers", Info.Command.Game?.Table?.MaxPlayers.ToString()},
                {"Game.Table.Arguments", Info.Command.Game?.Table?.Arguments},
                {"Game.Table.BlindType", Info.Command.Game?.Table?.BlindType.ToString()},
                {"Game.Table.LobbyType", Info.Command.Game?.Table?.LobbyType.ToString()},
                {"Game.Table.LimitType", Info.Command.Game?.Table?.LimitType.ToString()},
                {"Game.Table.TableStartedAt", Info.Command.Game?.Table?.TableStartedAt.ToString("yyyy-MM-dd HH:mm:ss.fff")},
                {"Details", Environment.NewLine + JsonConvert.SerializeObject(JsonConvert.DeserializeObject(Info.Command.Details), Formatting.Indented)},
            };
            return res;
        }

        public override string ToString()
        {
            return $"{Info.DateAndTime:yyyy-MM-dd HH:mm:ss.fff} {(Info.Command.IsFromServer? " -->" : "<-- ")} {Info.Command.Name}";
        }

        public override string ObtainValue(string field)
        {
            return ObtainValue(EnumFactory<CriteriaEnum>.Parse(field));
        }

        public string ObtainValue(CriteriaEnum criteria)
        {
            switch (criteria)
            {
                case CriteriaEnum.None:
                    return "All";
                case CriteriaEnum.Date:
                    return Date;
                case CriteriaEnum.Hour:
                    return DateWithHour + "h";
                case CriteriaEnum.CommandName:
                    return Info.Command.Name;
                case CriteriaEnum.Direction:
                    return Info.Command.IsFromServer ? "Server -> Client" : "Client -> Server";
                case CriteriaEnum.Client:
                    return $"{(String.IsNullOrEmpty(Info.Command.Client.DisplayName) ? "?Client?" : Info.Command.Client.DisplayName)} {Info.Command.Client.ClientStartedAt.ToString("yyyy-MM-dd HH:mm:ss.fff")}";
                case CriteriaEnum.Server:
                    return $"Server {Info.Command.Server.ServerStartedAt.ToString("yyyy-MM-dd HH:mm:ss.fff")}";
                case CriteriaEnum.Table:
                    return Info.Command.Game == null ? "-" : $"{Info.Command.Game.Table.TableName} {Info.Command.Game.Table.TableStartedAt.ToString("yyyy-MM-dd HH:mm:ss.fff")}";
                case CriteriaEnum.Game:
                    return Info.Command.Game == null ? "-" : $"{Info.Command.Game.Table.TableName} {Info.Command.Game.GameStartedAt.ToString("yyyy-MM-dd HH:mm:ss.fff")}";
                //case CriteriaEnum.SourceController:
                //    return Info.SourceController;
                //case CriteriaEnum.SourceAction:
                //    return Info.SourceAction;
                //case CriteriaEnum.DestUrl:
                //    return Info.DestUrl;
                //case CriteriaEnum.DestController:
                //    return Info.DestController;
                //case CriteriaEnum.DestAction:
                //    return Info.DestAction;
                //case CriteriaEnum.SessionId:
                //    return Info.SessionId;
                //case CriteriaEnum.UserId:
                //    return Info.UserId;
                //case CriteriaEnum.UniqueUserName:
                //    return Info.UniqueUserName;
                //case CriteriaEnum.RealName:
                //    return Info.RealName;
            }
            return String.Empty;
        }

        public string ObtainValueForFilters(CriteriaEnum criteria)
        {
            switch (criteria)
            {
                case CriteriaEnum.Hour:
                    return Time;
            }
            return ObtainValue(criteria);
        }

        public static IEnumerable<ExecutedCommand> GetCommands(CriteriaEnum criteria, string value)
        {
            switch (criteria)
            {
                case CriteriaEnum.None:
                    return Command.AllCommands().Select(x => new ExecutedCommand(new ExecutedCommandInfo(x)));
                case CriteriaEnum.Date:
                    return Command.AllCommandsOfDate(DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture)).Select(x => new ExecutedCommand(new ExecutedCommandInfo(x)));
                case CriteriaEnum.CommandName:
                    return Command.AllCommandsOfName(value).Select(x => new ExecutedCommand(new ExecutedCommandInfo(x)));
                case CriteriaEnum.GameType:
                    return Command.AllCommandsOfGameType(value).Select(x => new ExecutedCommand(new ExecutedCommandInfo(x)));
                case CriteriaEnum.GameSubType:
                    return Command.AllCommandsOfGameSubType(value).Select(x => new ExecutedCommand(new ExecutedCommandInfo(x)));
            }
            return new ExecutedCommand[0];
        }

        public string ObtainFullName(IEnumerable<CriteriaEnum> criterias)
        {
            StringBuilder sb = new StringBuilder();
            var criteriaEnums = criterias as CriteriaEnum[] ?? criterias.ToArray();

            sb.Append(ObtainDateTime(criteriaEnums));
            sb.Append($"{(Info.Command.IsFromServer ? " -->" : "<-- ")} ");
            sb.Append($"{Info.Command.Name} ");

            return sb.ToString();
        }

        //public string ObtainAction(IEnumerable<CriteriaEnum> criterias)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.Append(Info.DestController);
        //    sb.Append(".");
        //    sb.Append(Info.DestAction);
        //    sb.Append(" ");

        //    JToken o = JToken.Parse(Info.Result);

        //    if (Info.DestController == "Users" && Info.DestAction == "UserFromId")
        //        sb.Append(String.Format("{0} ({1}) ", o["RealName"].Value<string>(), o["Profile"]["Id"].Value<string>()));

        //    if (Info.DestController == "Users" && Info.DestAction == "UserFromName")
        //        sb.Append(String.Format("{0} ({1}) ", o["RealName"].Value<string>(), o["Profile"]["UniqueUserName"].Value<string>()));

        //    if (Info.DestController == "Items" && Info.DestAction == "CreateItem")
        //        sb.Append(String.Format("{0} ", o["Name"].Value<string>()));

        //    return sb.ToString();
        //}

        public string ObtainDateTime(IEnumerable<CriteriaEnum> criterias)
        {
            var criteriaEnums = criterias as CriteriaEnum[] ?? criterias.ToArray();
            if (criteriaEnums.Contains(CriteriaEnum.Date) || criteriaEnums.Contains(CriteriaEnum.Hour)/* || criteriaEnums.Contains(CriteriaEnum.SessionId)*/)
            {
                return Time + " ";
            }
            return DateAndTime + " ";
        }
        //public string ObtainRealName(IEnumerable<CriteriaEnum> criterias)
        //{
        //    var criteriaEnums = criterias as CriteriaEnum[] ?? criterias.ToArray();
        //    if (!criteriaEnums.Contains(CriteriaEnum.RealName) && !criteriaEnums.Contains(CriteriaEnum.SessionId))
        //        return Info.RealName + " ";
        //    return String.Empty;
        //}
        //public string ObtainUserAgent(int maxlength = 0)
        //{
        //    if (Info.UserAgent.Length > maxlength)
        //        return Info.UserAgent.Remove(maxlength - 3) + "... ";
        //    return Info.UserAgent + " ";
        //}

        public string ObtainFilterValue(CriteriaEnum field)
        {
            switch (field)
            {
                case CriteriaEnum.Hour:
                    return Time;
            }
            return ObtainValue(field);
        }

        public override string ObtainFilterValue(string field)
        {
            return ObtainFilterValue(EnumFactory<CriteriaEnum>.Parse(field));
        }

        protected override bool CanDisplayField(PropertyInfo field)
        {
            if (field.Name == "DateAndTime")
                return false;
            return base.CanDisplayField(field);
        }

        protected override string GetFieldDisplayValue(PropertyInfo field)
        {
            if (field.Name == "LogTimeStamp")
                return ((DateTime)field.GetValue(Info)).ToString("yyyy-MM-dd HH:mm:ss.fff");
            return base.GetFieldDisplayValue(field);
        }
    }
}
