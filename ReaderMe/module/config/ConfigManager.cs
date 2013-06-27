using System.Collections.Generic;
using System.IO;
using GPSoft.Tools.ReaderMe.common;
using GPSoft.Tools.ReaderMe.module.reader;

namespace GPSoft.Tools.ReaderMe.module.config
{
    /// <summary>
    /// 设定管理器
    /// </summary>
    public static class ConfigManager
    {
        private static Dictionary<Reader, Config> configDict;

        static ConfigManager()
        {
            configDict = new Dictionary<Reader, Config>();
        }

        /// <summary>
        /// 获取当前读者的设定
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            Config config;
            Reader reader = ReaderManager.CurrentReader;
            if (configDict.ContainsKey(reader))
            {
                config = configDict[reader];
            }
            else
            {
                ConfigLoader loader = new ConfigLoader();
                string file = GetConfigFile();
                config = loader.LoadFromXml(file);
                configDict.Add(reader, config);
            }
            return config;
        }

        private static string GetConfigFile()
        {
            Reader reader = ReaderManager.CurrentReader;
            string readerFolder = Path.Combine(Const.PATH_ROOT_FOLDER, reader.Name);
            return Path.Combine(readerFolder, "config.xml");
        }

        /// <summary>
        /// 保存当前读者的设定
        /// </summary>
        public static void SaveConfig()
        {
            Config config = GetConfig();
            ConfigWriter writer = new ConfigWriter(config);
            string file = GetConfigFile();
            writer.SaveToXml(file);
        }
    }
}
