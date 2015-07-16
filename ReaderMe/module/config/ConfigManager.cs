using System.Collections.Generic;
using System.IO;
using GPStudio.Tools.ReaderMe.common;
using GPStudio.Tools.ReaderMe.Module.reader;

namespace GPStudio.Tools.ReaderMe.Module.Config
{
    /// <summary>
    /// 设定管理器
    /// </summary>
    public static class ConfigManager
    {
        private static Dictionary<Reader, Config> ConfigDict;

        static ConfigManager()
        {
            ConfigDict = new Dictionary<Reader, Config>();
        }

        /// <summary>
        /// 获取当前读者的设定
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            Config Config;
            Reader reader = ReaderManager.CurrentReader;
            if (ConfigDict.ContainsKey(reader))
            {
                Config = ConfigDict[reader];
            }
            else
            {
                ConfigLoader loader = new ConfigLoader();
                string file = GetConfigFile();
                Config = loader.LoadFromXml(file);
                ConfigDict.Add(reader, Config);
            }
            return Config;
        }

        private static string GetConfigFile()
        {
            Reader reader = ReaderManager.CurrentReader;
            string readerFolder = Path.Combine(Const.PATH_ROOT_FOLDER, reader.Name);
            return Path.Combine(readerFolder, "Config.xml");
        }

        /// <summary>
        /// 保存当前读者的设定
        /// </summary>
        public static void SaveConfig()
        {
            Config Config = GetConfig();
            ConfigWriter writer = new ConfigWriter(Config);
            string file = GetConfigFile();
            writer.SaveToXml(file);
        }
    }
}
