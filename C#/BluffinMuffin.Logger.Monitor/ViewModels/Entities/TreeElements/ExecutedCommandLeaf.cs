using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.Logger.Monitor.DataTypes;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;
using BluffinMuffin.Logger.Monitor.ViewModels.Entities.DataElements;
using Com.Ericmas001.AppMonitor.DataTypes.DataElements;
using Com.Ericmas001.AppMonitor.DataTypes.TreeElements;
using Com.Ericmas001.Portable.Util.Entities;
using Com.Ericmas001.Wpf.ViewModels.Trees;

namespace BluffinMuffin.Logger.Monitor.ViewModels.Entities.TreeElements
{
    public class ExecutedCommandLeaf : BaseCategoryLeafTreeElement<LogCategoryEnum, CriteriaEnum>
    {
        public new ExecutedCommand DataItem => base.DataItem as ExecutedCommand;

        public ExecutedCommandLeaf(TreeElementViewModel parent, IEnumerable<CriteriaEnum> usedCriterias, CriteriaEnum searchCriteria, LogCategoryEnum category, IDataItem dataItem) :
            base(parent, usedCriterias, searchCriteria, category, dataItem)
        {
        }

        public override string Text => DataItem.ObtainFullName(UsedCriterias);

        protected override IEnumerable<BaseDataElement> SetTabs()
        {
            var list = new List<BaseDataElement>
            {
                new ExecutedCommandDataElement(DataItem)
            };
            list.AddRange(base.SetTabs());
            return list;
        }
    }
}
