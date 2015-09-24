using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //switch (crit)
            //{
            //    case CriteriaEnum.SourceUrl:
            //    case CriteriaEnum.DestUrl:
            //        return App.Db.GetAllUniqueElements("Url");
            //    case CriteriaEnum.SourceController:
            //    case CriteriaEnum.DestController:
            //        return App.Db.GetAllUniqueElements("Controller");
            //    case CriteriaEnum.SourceAction:
            //    case CriteriaEnum.DestAction:
            //        return App.Db.GetAllUniqueElements("Action");
            //}
            return new String[0];
        }

        public override BaseTabViewModel CreateContentTab()
        {
            return BaseCategoryViewModel.GenerateTab(Category, SelectedCriteria, SelectedCriteriaValue);
        }
    }
}
