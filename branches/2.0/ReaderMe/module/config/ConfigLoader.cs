using System.Collections.Generic;
using System.Drawing;
using GPSoft.Tools.ReaderMe.common;

namespace GPSoft.Tools.ReaderMe.module.config
{
    public class ConfigLoader
    {
        public Config LoadFromXml(string file)
        {
            Config config = new Config();
            try
            {
                ObjectXMLSerializer<Config>.Load(ref config, file);
            }
            catch
            {
                SetDefaultValue(ref config);
            }
            return config;
        }

        private void SetDefaultValue(ref Config config)
        {
            config.General = new GeneralConfig
            {
                BackColor = Color.White.ToArgb(),
                FontName = "NSimSun",
                FontSize = 9,
                Opacity = 0,
                WordWrap = true
            };
            config.Windows = new List<WindowConfig>
            {
                new WindowConfig
                {
                    Mode = WindowMode.Normal,
                    AutoScrollInterval = 3,
                    AutoScrollRows = 3,
                    Height = 300,
                    Width = 300,
                    Left = 0,
                    Top = 0
                },
                new WindowConfig
                {
                    Mode = WindowMode.Mini,
                    AutoScrollInterval = 2,
                    AutoScrollRows = 1,
                    Height = 12,
                    Width = 300,
                    Left = 0,
                    Top = 0
                }
            };
            config.Files = new List<FileConfig>();
        }
    }
}
