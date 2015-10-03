using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;
using Com.Ericmas001.AppMonitor.DataTypes.Attributes;
using Com.Ericmas001.Portable.Util;
using Com.Ericmas001.Portable.Util.Entities.Fields;

namespace BluffinMuffin.Logger.Monitor.DataTypes.Attributes
{
    public abstract class BaseLogCategoriesAttribute : Attribute, IManyCategoriesAttribute<LogCategoryEnum>
    {

        public IEnumerable<LogCategoryEnum> Categories { get; private set; }

        public BaseLogCategoriesAttribute(params LogCategoryEnum[] cats)
        {
            if (cats == null || !cats.Any() || cats.Contains(LogCategoryEnum.All))
                Categories = EnumFactory<LogCategoryEnum>.AllValues.Where(x => x != LogCategoryEnum.All).ToArray();
            else
                Categories = cats;
        }
    }
}
