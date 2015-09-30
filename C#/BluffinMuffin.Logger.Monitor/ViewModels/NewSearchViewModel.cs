using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;
using BluffinMuffin.Logger.Monitor.ViewModels.Sections;
using Com.Ericmas001.Wpf.ViewModels.Sections;
using Com.Ericmas001.Wpf.ViewModels.Tabs;

namespace BluffinMuffin.Logger.Monitor.ViewModels
{
    public class NewSearchViewModel : MultiCategoriesNewTabViewModel<LogCategoryEnum>
    {
        public override string TabTitle => "BluffinMuffin Log Monitor";
        protected override string IconBigImageName => "ImgLogs32";

        protected override IEnumerable<LogCategoryEnum> ExcludeCategories(IEnumerable<LogCategoryEnum> categories)
        {
            return base.ExcludeCategories(categories).Where(x => x != LogCategoryEnum.All);
        }

        protected override TabSection CreateCategorySection(LogCategoryEnum cat)
        {
            return new CategorySection(cat);
        }
    }
}
