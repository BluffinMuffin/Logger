using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.Logger.Monitor.DataTypes;
using BluffinMuffin.Logger.Monitor.DataTypes.Attributes;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;
using Com.Ericmas001.AppMonitor.DataTypes.ViewModels;
using Com.Ericmas001.Wpf.ViewModels.Tabs;
using Com.Ericmas001.Portable.Util;

namespace BluffinMuffin.Logger.Monitor.ViewModels
{
    public abstract class BaseCategoryViewModel : BaseSearchResultViewModel<LogCategoryEnum, CriteriaEnum, ExecutedCommand, GroupingCriteriaAttribute>
    {
        private LogCategoryEnum m_Category = LogCategoryEnum.All;

        protected override LogCategoryEnum Category
        {
            get
            {
                if (m_Category == LogCategoryEnum.All)
                    m_Category = GetType().GetAttributeValue((LogCategoryAttribute att) => att.Category);
                return m_Category;
            }
        }

        public BaseCategoryViewModel(CriteriaEnum criteria, string value)
            : base(App.Current.Dispatcher, criteria, value)
        {
        }

        private static Dictionary<LogCategoryEnum, Type> m_CategoryViewModels;

        public static BaseTabViewModel GenerateTab(LogCategoryEnum cat, CriteriaEnum criteria, string value)
        {
            if (m_CategoryViewModels == null)
            {
                m_CategoryViewModels = new Dictionary<LogCategoryEnum, Type>();
                foreach (Type type in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof (BaseCategoryViewModel))))
                {
                    LogCategoryEnum categFromAttribute = type.GetAttributeValue((LogCategoryAttribute att) => att.Category);
                    if (cat == categFromAttribute)
                        m_CategoryViewModels.Add(cat, type);
                }
            }

            if (m_CategoryViewModels.ContainsKey(cat))
            {
                ConstructorInfo ctor = m_CategoryViewModels[cat].GetConstructor(new Type[] {typeof (CriteriaEnum), typeof (string)});
                BaseCategoryViewModel vm = ctor.Invoke(new object[] {criteria, value}) as BaseCategoryViewModel;
                if (vm != null)
                    vm.Init();
                return vm;
            }

            return null;
        }
    }
}
