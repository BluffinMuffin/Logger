using System.Configuration;

namespace BluffinMuffin.Logger.Monitor.DataTypes.Configuration
{
    public class BluffinMuffinDataSection : ConfigurationSection
    {
        /// <summary>
        /// The name of this section in the app.config.
        /// </summary>
        public const string SECTION_NAME = "bluffinMuffin";

        private const string ENVIRONMENTS_COLLECTION_NAME = "environments";

        [ConfigurationProperty(ENVIRONMENTS_COLLECTION_NAME)]
        [ConfigurationCollection(typeof (EnvironmentsConfigCollection), AddItemName = "environment")]
        public EnvironmentsConfigCollection Environments => (EnvironmentsConfigCollection) base[ENVIRONMENTS_COLLECTION_NAME];
    }
}
