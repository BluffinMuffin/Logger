using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.Logger.DBAccess;
using BluffinMuffin.Logger.Monitor.DataTypes.Attributes;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;
using Com.Ericmas001.AppMonitor.DataTypes.ViewModels.Sections;
using Com.Ericmas001.Wpf.ViewModels.Tabs;

namespace BluffinMuffin.Logger.Monitor.ViewModels.Sections
{
    public class CategorySection : SearchCategorySection<CriteriaEnum, LogCategoryEnum, SearchCriteriaAttribute>
    {
        public CategorySection(LogCategoryEnum cat) : base(cat)
        {
        }

        protected override IEnumerable<string> ObtainList(CriteriaEnum crit)
        {
            switch (crit)
            {
                case CriteriaEnum.CommandName:
                    return Command.AllCommandNames();
            }
            return new string[0];
        }

        public override BaseTabViewModel CreateContentTab()
        {
            return BaseCategoryViewModel.GenerateTab(Category, SelectedCriteria, SelectedCriteriaValue);
        }
    }
}
