using System;
using System.IO;

namespace GPSoft.Tools.ReaderMe.module.config
{
    /// <summary>
    /// 设定管理器
    /// </summary>
    public static class ConfigManager
    {
        private static Config singleInstanceConfig = null;
        private static readonly string CONFIG_FILE;

        static ConfigManager()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dir = Path.Combine(dir, "ReaderMe");
            CONFIG_FILE = Path.Combine(dir, "config.xml");
        }

        /// <summary>
        /// 获取设定
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            if (null == singleInstanceConfig)
            {
                ConfigLoader loader = new ConfigLoader();
                singleInstanceConfig = loader.LoadFromXml(CONFIG_FILE);
            }
            return singleInstanceConfig;
        }

        /// <summary>
        /// 保存设定
        /// </summary>
        public static void SaveConfig()
        {
            Config config = GetConfig();
            ConfigWriter writer = new ConfigWriter(config);
            writer.SaveToXml(CONFIG_FILE);
        }
    }
}
