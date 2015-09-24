using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using BluffinMuffin.Logger.Monitor.DataTypes;
using BluffinMuffin.Logger.Monitor.DataTypes.Attributes;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;
using Com.Ericmas001.AppMonitor.DataTypes.TreeElements;
using Com.Ericmas001.Portable.Util;
using Com.Ericmas001.Portable.Util.Entities.Filters;
using Com.Ericmas001.Portable.Util.Entities.Filters.Commands;
using Com.Ericmas001.Portable.Util.Entities.Filters.Enums;
using Com.Ericmas001.Wpf.Entities.Filters;
using Com.Ericmas001.Wpf.ViewModels.Trees;

namespace BluffinMuffin.Logger.Monitor.ViewModels
{
    [LogCategory(LogCategoryEnum.ExecutedCommand)]
    public class ExecutedCommandCategoryViewModel : BaseCategoryViewModel
    {
        public ExecutedCommandCategoryViewModel(CriteriaEnum criteria, string value)
            : base(criteria, value)
        {
        }
        protected override void ObtainData(object sender, DoWorkEventArgs e)
        {
            DataItems.Data = new ExecutedCommand[0];//App.Db.GetExecutedCommands(ExecutedCommand.GetSearchSqlCommand(App.Db.BaseSqlForExecutedCommands, SearchCriteria, Keyword)));
        }
        protected override BaseBranchTreeElement CreateBranch(TreeElementViewModel parent, CriteriaEnum currentCritere, string value, IEnumerable<CriteriaEnum> usedCriteres, LogCategoryEnum category)
        {
            return null;//new ExecutedCommandsBranch(parent, usedCriteres, currentCritere, category);
        }

        protected override BaseLeafTreeElement CreateLeaf(TreeElementViewModel parent, ExecutedCommand item, IEnumerable<CriteriaEnum> criteres)
        {
            return null;//new ExecutedCommandLeaf(parent, criteres, SearchCriteria, LogCategoryEnum.ExecutedCommand, item);
        }

        protected override string[] GetAllFiltersCriteria()
        {
            return base.GetAllFiltersCriteria().Union(new[] { "User" }).ToArray();
        }

        public override IEnumerable<BaseFilterInCreation> GenerateFilter(string crit)
        {
            //if (crit == "User")
            //    return new BaseFilterInCreation[] { new UserFilterInCreation(DataItems) };
            return base.GenerateFilter(crit);
        }

        private bool m_FirstTime = true;
        protected override void GenerateFilters()
        {
            if (m_FirstTime)
            {
                m_FirstTime = false;
                base.GenerateFilters();
            }
        }

        protected override void InitGroupingAndFiltering()
        {
            base.InitGroupingAndFiltering();
            //ChooseGroupVm.ChooseGroupingCriteria(EnumFactory<CriteriaEnum>.ToString(CriteriaEnum.SessionId));
            //ChooseGroupVm.AddCompiledFilter(new UserCompiledFilter(new FilterInfo("User", new MustSimpleFilterCommand() { Command = FilterCommandEnum.Must }, new ConnectedFilterComparator(), null)));
        }

        protected override string ObtainOrdering(IEnumerable<string> usedCriterias, string criteria, IGrouping<string, ExecutedCommand> @group)
        {
            //if (criteria == EnumFactory<CriteriaEnum>.ToString(CriteriaEnum.SessionId))
            //    return group.Min(x => x.DateAndTime);
            return base.ObtainOrdering(usedCriterias, criteria, @group);
        }
    }
}