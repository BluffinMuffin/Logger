using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.Logger.Monitor.DataTypes;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;
using BluffinMuffin.Logger.Monitor.ViewModels.Entities.DataElements;
using BluffinMuffin.Logger.Monitor.ViewModels.Entities.GlobalElements;
using Com.Ericmas001.AppMonitor.DataTypes.DataElements;
using Com.Ericmas001.AppMonitor.DataTypes.GlobalElements;
using Com.Ericmas001.AppMonitor.DataTypes.TreeElements;
using Com.Ericmas001.Portable.Util.Entities;
using Com.Ericmas001.Wpf.ViewModels.Trees;

namespace BluffinMuffin.Logger.Monitor.ViewModels.Entities.TreeElements
{
    public class ExecutedCommandBranch : BaseCategoryBranchTreeElement<LogCategoryEnum, CriteriaEnum>
    {
        protected override string BranchName
        {
            get
            {
                //if (SearchCriteria == CriteriaEnum.SessionId)
                //{
                //    ExecutedCommandLeaf leaf = FirstLeafInTime();
                //    return String.Format(leaf.DataItem.ObtainDateTime(UsedCriterias.Except(new[] { SearchCriteria })) + leaf.DataItem.ObtainRealName(UsedCriterias.Except(new[] { SearchCriteria })) + leaf.DataItem.ObtainUserAgent(50));
                //}
                return base.BranchName;
            }
        }

        private ExecutedCommandLeaf FirstLeafInTime()
        {
            return TreeLeaves.OfType<ExecutedCommandLeaf>().OrderBy(x => x.DataItem.DateAndTime).First();
        }

        public ExecutedCommandBranch(TreeElementViewModel parent, IEnumerable<CriteriaEnum> usedCriterias, CriteriaEnum searchCriteria, LogCategoryEnum category) 
            : base(parent, usedCriterias, searchCriteria, category)
        {
        }

        protected override IEnumerable<BaseGlobalElement> SetTabs()
        {
            var list = new List<BaseGlobalElement>();
            list.Add(new ExecutedCommandsGridOfLeaves(this));
            list.AddRange(base.SetTabs());
            return list;
        }
    }
}
