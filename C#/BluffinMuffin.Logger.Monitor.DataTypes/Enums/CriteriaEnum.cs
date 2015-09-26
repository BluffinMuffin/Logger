using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.Logger.Monitor.DataTypes.Attributes;
using Com.Ericmas001.Portable.Util.Entities.Attributes;
using Com.Ericmas001.Portable.Util.Entities.Fields;
using Com.Ericmas001.Portable.Util.Entities.Filters.Attributes;
using Com.Ericmas001.Portable.Util.Entities.Filters.Enums;

namespace BluffinMuffin.Logger.Monitor.DataTypes.Enums
{
    public enum CriteriaEnum
    {
        [SearchCriteria(FieldTypeEnum.Date)]
        [Description("Give Me Everything")]
        [Tag("[All]")]
        [Priority(999999)]
        None,

        /// <summary>
        /// Date
        /// </summary>
        [SearchCriteria(FieldTypeEnum.Date)]
        [GroupingCriteria]
        [Description("Date")]
        [Tag("[Date]")]
        [Filters(FilterEnum.Date)]
        [Priority(10)]
        Date,

        /// <summary>
        /// Hour
        /// </summary>
        [GroupingCriteria]
        [Description("Hour")]
        [Tag("[Hour]")]
        [Filters(FilterEnum.Time)]
        [Priority(15)]
        Hour,

        /// <summary>
        /// Command Name
        /// </summary>
        [SearchCriteria(FieldTypeEnum.List)]
        [GroupingCriteria]
        [Description("Command Name")]
        [Tag("[Name]")]
        [Filters(FilterEnum.Text)]
        [Priority(100)]
        CommandName,

        ///// <summary>
        ///// Source Controller
        ///// </summary>
        //[SearchCriteria(FieldTypeEnum.List)]
        //[GroupingCriteria]
        //[Description("Source Controller")]
        //[Tag("[SCtl]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(110)]
        //SourceController,

        ///// <summary>
        ///// Source Action
        ///// </summary>
        //[SearchCriteria(FieldTypeEnum.List)]
        //[GroupingCriteria]
        //[Description("Source Action")]
        //[Tag("[SAct]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(120)]
        //SourceAction,

        ///// <summary>
        ///// Dest Url
        ///// </summary>
        //[SearchCriteria(FieldTypeEnum.List)]
        //[GroupingCriteria]
        //[Description("Dest Url")]
        //[Tag("[DUrl]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(200)]
        //DestUrl,

        ///// <summary>
        ///// Dest Controller
        ///// </summary>
        //[SearchCriteria(FieldTypeEnum.List)]
        //[GroupingCriteria]
        //[Description("Dest Controller")]
        //[Tag("[DCtl]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(210)]
        //DestController,

        ///// <summary>
        ///// Dest Action
        ///// </summary>
        //[SearchCriteria(FieldTypeEnum.List)]
        //[GroupingCriteria]
        //[Description("Dest Action")]
        //[Tag("[DAct]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(220)]
        //DestAction,

        ///// <summary>
        ///// Session Id
        ///// </summary>
        //[GroupingCriteria]
        //[Description("Session Id")]
        //[Tag("[Ssid]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(300)]
        //SessionId,

        ///// <summary>
        ///// User Id
        ///// </summary>
        //[GroupingCriteria]
        //[Description("User Id")]
        //[Tag("[Usid]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(400)]
        //UserId,

        ///// <summary>
        ///// Unique Username
        ///// </summary>
        //[GroupingCriteria]
        //[Description("Unique Username")]
        //[Tag("[Usnm]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(410)]
        //UniqueUserName,

        ///// <summary>
        ///// Real Name
        ///// </summary>
        //[GroupingCriteria]
        //[Description("Real Name")]
        //[Tag("[Name]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(420)]
        //RealName,
    }
}