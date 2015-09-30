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
        [EnumDescription("Give Me Everything")]
        [Tag("[All]")]
        [Priority(999999)]
        None,

        /// <summary>
        /// Date
        /// </summary>
        [SearchCriteria(FieldTypeEnum.Date)]
        [GroupingCriteria]
        [EnumDescription("Date")]
        [Tag("[Date]")]
        [Filters(FilterEnum.Date)]
        [Priority(10)]
        Date,

        /// <summary>
        /// Hour
        /// </summary>
        [GroupingCriteria]
        [EnumDescription("Hour")]
        [Tag("[Hour]")]
        [Filters(FilterEnum.Time)]
        [Priority(15)]
        Hour,

        /// <summary>
        /// Command Name
        /// </summary>
        [SearchCriteria(FieldTypeEnum.List)]
        [GroupingCriteria]
        [EnumDescription("Command Name")]
        [Tag("[Cmd]")]
        [Filters(FilterEnum.Text)]
        [Priority(100)]
        CommandName,

        /// <summary>
        /// Direction
        /// </summary>
        [GroupingCriteria]
        [EnumDescription("Direction")]
        [Tag("[Dir]")]
        [Filters(FilterEnum.Text)]
        [Priority(110)]
        Direction,

        /// <summary>
        /// Client
        /// </summary>
        [GroupingCriteria]
        [EnumDescription("Client")]
        [Tag("[Client]")]
        [Filters(FilterEnum.Text)]
        [Priority(200)]
        Client,

        /// <summary>
        /// Client
        /// </summary>
        [GroupingCriteria]
        [EnumDescription("Server")]
        [Tag("[Server]")]
        [Filters(FilterEnum.Text)]
        [Priority(210)]
        Server,

        /// <summary>
        /// Table
        /// </summary>
        [GroupingCriteria]
        [EnumDescription("Table")]
        [Tag("[Table]")]
        [Filters(FilterEnum.Text)]
        [Priority(230)]
        Table,

        /// <summary>
        /// Game
        /// </summary>
        [GroupingCriteria]
        [EnumDescription("Game")]
        [Tag("[Game]")]
        [Filters(FilterEnum.Text)]
        [Priority(240)]
        Game,

        /// <summary>
        /// Game Type
        /// </summary>
        [SearchCriteria(FieldTypeEnum.List)]
        [GroupingCriteria]
        [EnumDescription("Game Type")]
        [Tag("[Type]")]
        [Filters(FilterEnum.Text)]
        [Priority(300)]
        GameType,

        /// <summary>
        /// Game Sub Type
        /// </summary>
        [SearchCriteria(FieldTypeEnum.List)]
        [GroupingCriteria]
        [EnumDescription("Game Sub Type")]
        [Tag("[SType]")]
        [Filters(FilterEnum.Text)]
        [Priority(310)]
        GameSubType,

        ///// <summary>
        ///// Source Controller
        ///// </summary>
        //[SearchCriteria(FieldTypeEnum.List)]
        //[GroupingCriteria]
        //[EnumDescription("Source Controller")]
        //[Tag("[SCtl]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(110)]
        //SourceController,

        ///// <summary>
        ///// Source Action
        ///// </summary>
        //[SearchCriteria(FieldTypeEnum.List)]
        //[GroupingCriteria]
        //[EnumDescription("Source Action")]
        //[Tag("[SAct]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(120)]
        //SourceAction,

        ///// <summary>
        ///// Dest Url
        ///// </summary>
        //[SearchCriteria(FieldTypeEnum.List)]
        //[GroupingCriteria]
        //[EnumDescription("Dest Url")]
        //[Tag("[DUrl]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(200)]
        //DestUrl,

        ///// <summary>
        ///// Dest Controller
        ///// </summary>
        //[SearchCriteria(FieldTypeEnum.List)]
        //[GroupingCriteria]
        //[EnumDescription("Dest Controller")]
        //[Tag("[DCtl]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(210)]
        //DestController,

        ///// <summary>
        ///// Dest Action
        ///// </summary>
        //[SearchCriteria(FieldTypeEnum.List)]
        //[GroupingCriteria]
        //[EnumDescription("Dest Action")]
        //[Tag("[DAct]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(220)]
        //DestAction,

        ///// <summary>
        ///// Session Id
        ///// </summary>
        //[GroupingCriteria]
        //[EnumDescription("Session Id")]
        //[Tag("[Ssid]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(300)]
        //SessionId,

        ///// <summary>
        ///// User Id
        ///// </summary>
        //[GroupingCriteria]
        //[EnumDescription("User Id")]
        //[Tag("[Usid]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(400)]
        //UserId,

        ///// <summary>
        ///// Unique Username
        ///// </summary>
        //[GroupingCriteria]
        //[EnumDescription("Unique Username")]
        //[Tag("[Usnm]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(410)]
        //UniqueUserName,

        ///// <summary>
        ///// Real Name
        ///// </summary>
        //[GroupingCriteria]
        //[EnumDescription("Real Name")]
        //[Tag("[Name]")]
        //[Filters(FilterEnum.Text)]
        //[Priority(420)]
        //RealName,
    }
}