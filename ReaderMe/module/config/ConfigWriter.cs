using System.IO;
using ReaderMe.Common;

namespace ReaderMe.Module.Config
{
    public class ConfigWriter
    {
        private readonly Config _config;

        public ConfigWriter(Config config)
        {
            _config = config;
        }

        public void SaveToXml(string file)
        {
            string dir = Path.GetDirectoryName(file);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            try
            {
                ObjectXmlSerializer<Config>.Save(_config, file);
            }
            catch
            {
                // 不抛出异常
            }
        }
    }
}
