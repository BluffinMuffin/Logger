using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;
using Com.Ericmas001.AppMonitor.DataTypes;
using Com.Ericmas001.Portable.Util;

namespace BluffinMuffin.Logger.Monitor.DataTypes
{
    public class ExecutedCommand : BaseDataItemWithInfo<ExecutedCommandInfo>, IDataItem<CriteriaEnum>
    {
        public ExecutedCommand(ExecutedCommandInfo info)
            : base(info)
        {
        }

        //public override string ToString()
        //{
        //    return Info.LogTimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + "  " + Info.RealName;
        //}

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
                //case CriteriaEnum.Hour:
                //    return DateWithHour;
                //case CriteriaEnum.SourceUrl:
                //    return Info.SourceUrl;
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
                //case CriteriaEnum.Hour:
                //    return Time;
            }
            return ObtainValue(criteria);
        }

        public static SqlCommand GetSearchSqlCommand(string baseSql, CriteriaEnum criteria, string value)
        {
            SqlCommand command = null;
            switch (criteria)
            {
                case CriteriaEnum.None:
                    {
                        command = new SqlCommand(baseSql);
                        break;
                    }
                case CriteriaEnum.Date:
                    {
                        var date1 = DateTime.ParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture).AddHours(-3);
                        var date2 = date1.AddDays(1).AddMilliseconds(-1);
                        command = new SqlCommand(baseSql + Environment.NewLine + "WHERE l.[LogTimeStamp] BETWEEN @DateTimeMin and @DateTimeMax");
                        command.Parameters.Add(new SqlParameter("@DateTimeMin", date1));
                        command.Parameters.Add(new SqlParameter("@DateTimeMax", date2));
                        break;
                    }
                //case CriteriaEnum.SourceUrl:
                //    {
                //        command = new SqlCommand(baseSql + Environment.NewLine + "WHERE se.Url = @SourceUrl");
                //        command.Parameters.Add(new SqlParameter("@SourceUrl", value));
                //        break;
                //    }
                //case CriteriaEnum.DestUrl:
                //    {
                //        command = new SqlCommand(baseSql + Environment.NewLine + "WHERE de.Url = @DestUrl");
                //        command.Parameters.Add(new SqlParameter("@DestUrl", value));
                //        break;
                //    }
                //case CriteriaEnum.SourceController:
                //    {
                //        command = new SqlCommand(baseSql + Environment.NewLine + "WHERE se.Controller = @SourceController");
                //        command.Parameters.Add(new SqlParameter("@SourceController", value));
                //        break;
                //    }
                //case CriteriaEnum.DestController:
                //    {
                //        command = new SqlCommand(baseSql + Environment.NewLine + "WHERE de.Controller = @DestController");
                //        command.Parameters.Add(new SqlParameter("@DestController", value));
                //        break;
                //    }
                //case CriteriaEnum.SourceAction:
                //    {
                //        command = new SqlCommand(baseSql + Environment.NewLine + "WHERE se.Action = @SourceAction");
                //        command.Parameters.Add(new SqlParameter("@SourceAction", value));
                //        break;
                //    }
                //case CriteriaEnum.DestAction:
                //    {
                //        command = new SqlCommand(baseSql + Environment.NewLine + "WHERE de.Action = @DestAction");
                //        command.Parameters.Add(new SqlParameter("@DestAction", value));
                //        break;
                //    }
            }
            return command;
        }

        public string ObtainFullName(IEnumerable<CriteriaEnum> criterias)
        {
            StringBuilder sb = new StringBuilder();
            var criteriaEnums = criterias as CriteriaEnum[] ?? criterias.ToArray();

            sb.Append(ObtainDateTime(criteriaEnums));
            //sb.Append(ObtainRealName(criteriaEnums));
            //sb.Append(ObtainAction(criteriaEnums));

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
            //if (criteriaEnums.Contains(CriteriaEnum.Date) || criteriaEnums.Contains(CriteriaEnum.Hour) || criteriaEnums.Contains(CriteriaEnum.SessionId))
            //{
            //    return Time + " ";
            //}
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
                //case CriteriaEnum.Hour:
                //    return Time;
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
