using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;
using Com.Ericmas001.AppMonitor.DataTypes.Attributes;
using Com.Ericmas001.Portable.Util.Entities.Fields;

namespace BluffinMuffin.Logger.Monitor.DataTypes.Attributes
{
    public class SearchCriteriaAttribute : BaseLogCategoriesAttribute, ISearchCriteriaAttribute<LogCategoryEnum>
    {
        public FieldTypeEnum FieldType { get; private set; }

        public SearchCriteriaAttribute(FieldTypeEnum fieldType, params LogCategoryEnum[] cats) : base(cats)
        {
            FieldType = fieldType;
        }
    }
}
