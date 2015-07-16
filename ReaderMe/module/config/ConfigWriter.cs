using System.IO;
using GPStudio.Tools.ReaderMe.common;

namespace GPStudio.Tools.ReaderMe.Module.Config
{
    public class ConfigWriter
    {
        private Config Config;

        public ConfigWriter(Config Config)
        {
            this.Config = Config;
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
                ObjectXMLSerializer<Config>.Save(this.Config, file);
            }
            catch
            {
                // 不抛出异常
            }
        }
    }
}
