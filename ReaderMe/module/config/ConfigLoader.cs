using System.Collections.Generic;
using System.Drawing;
using GPStudio.Tools.ReaderMe.common;

namespace GPStudio.Tools.ReaderMe.Module.Config
{
    public class ConfigLoader
    {
        public Config LoadFromXml(string file)
        {
            Config Config = new Config();
            try
            {
                ObjectXMLSerializer<Config>.Load(ref Config, file);
            }
            catch
            {
                SetDefaultValue(ref Config);
            }
            return Config;
        }

        private void SetDefaultValue(ref Config Config)
        {
            Config.General = new GeneralConfig
            {
                BackColor = Color.White.ToArgb(),
                FontName = "NSimSun",
                FontSize = 9,
                Opacity = 0,
                WordWrap = true
            };
            Config.Windows = new List<WindowConfig>
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
            Config.Files = new List<FileConfig>();
        }
    }
}
