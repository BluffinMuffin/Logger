using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;

namespace BluffinMuffin.Logger.Monitor.DataTypes.Attributes
{
    public class LogCategoryAttribute : Attribute
    {
        public LogCategoryEnum Category { get; private set; }

        public LogCategoryAttribute(LogCategoryEnum cat)
        {
            Category = cat;
        }
    }
}
