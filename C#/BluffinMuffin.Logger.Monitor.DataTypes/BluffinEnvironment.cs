using System.Collections.Generic;
using System.Linq;
using BluffinMuffin.Logger.Monitor.DataTypes.Enums;
using Com.Ericmas001.Portable.Util;

namespace BluffinMuffin.Logger.Monitor.DataTypes
{
    public class BluffinEnvironment
    {
        public EnvironmentEnum Environment { get; private set; }
        public string EnvironmentDescription { get; private set; }

        public BluffinEnvironment(EnvironmentEnum env)
        {
            Environment = env;
            EnvironmentDescription = EnumFactory<EnvironmentEnum>.ToString(env);
        }
        public static IEnumerable<BluffinEnvironment> GetAllEnvironments()
        {
            return EnumFactory<EnvironmentEnum>.AllValues.Select(x => new BluffinEnvironment(x)).ToArray();
        }

        public override string ToString()
        {
            return EnvironmentDescription;
        }
    }
}