using System.Collections.Generic;
using System.Drawing;
using ReaderMe.Common;

namespace ReaderMe.Module.Config
{
    public class ConfigLoader
    {
        public Config LoadFromXml(string file)
        {
            Config config = new Config();
            try
            {
                ObjectXmlSerializer<Config>.Load(ref config, file);
            }
            catch
            {
                SetDefaultValue(ref config);
            }
            return config;
        }

        private void SetDefaultValue(ref Config config)
        {
            config.General = new GeneralConfig();
            config.General.BackColor = Color.White.ToArgb();
            config.General.FontName = "NSimSun";
            config.General.FontSize = 9;
            config.General.Opacity = 0;
            config.General.WordWrap = true;
            config.Windows = new List<WindowConfig>();
            config.Windows.Add(CreateNormalWindowConfig());
            config.Windows.Add(CreateMiniWindowConfig());
            config.Files = new List<FileConfig>();
        }

        private WindowConfig CreateNormalWindowConfig()
        {
            WindowConfig config = new WindowConfig();
            config.Mode = WindowMode.Normal;
            config.AutoScrollInterval = 3;
            config.AutoScrollRows = 3;
            config.Height = 300;
            config.Width = 300;
            config.Left = 0;
            config.Top = 0;
            return config;
        }

        private WindowConfig CreateMiniWindowConfig()
        {
            WindowConfig config = new WindowConfig();
            config.Mode = WindowMode.Mini;
            config.AutoScrollInterval = 2;
            config.AutoScrollRows = 1;
            config.Height = 12;
            config.Width = 300;
            config.Left = 0;
            config.Top = 0;
            return config;
        }
    }
}
