using BluffinMuffin.Logger.Monitor.DataTypes.Enums;

namespace BluffinMuffin.Logger.Monitor.DataTypes.Attributes
{
    public class GroupingCriteriaAttribute : BaseLogCategoriesAttribute
    {
        public GroupingCriteriaAttribute(params LogCategoryEnum[] cats) : base(cats)
        {

        }
    }
}