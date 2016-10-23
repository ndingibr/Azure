using static Configuration.ConfigurationManager;

namespace Azure.Shared
{
    public class ConfigSettings
    {
        public static string StorageConnectionString { get { return AppSettings["StorageConnectionString"]; } }
        public static string CacheConnectionString { get { return AppSettings["CacheConnectionString"]; } }

    }


}