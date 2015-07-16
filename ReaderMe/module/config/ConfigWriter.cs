using System.IO;
using GPStudio.Tools.ReaderMe.common;

namespace GPStudio.Tools.ReaderMe.module.config
{
    public class ConfigWriter
    {
        private Config config;

        public ConfigWriter(Config config)
        {
            this.config = config;
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
                ObjectXMLSerializer<Config>.Save(this.config, file);
            }
            catch
            {
                // 不抛出异常
            }
        }
    }
}
