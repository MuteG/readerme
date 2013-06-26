using System;
using System.Collections.Generic;
using System.Text;
using GPSoft.Tools.ReaderMe.Model;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace GPSoft.Tools.ReaderMe.Common
{
    public class ConfigLoader
    {
        public Configuration LoadFromXml(string file)
        {
            Configuration config = new Configuration();
            try
            {
                ObjectXMLSerializer<Configuration>.Load(ref config, file);
            }
            catch
            {
                config.BackColor = Color.White.ToArgb();
                config.FileInfoList = new List<FileInformation>();
                config.FontName = "NSimSun";
                config.FontSize = 9;
                config.Height = 400;
                //config.IsDebug = false;
                config.Left = 0;
                //config.LogPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }
            return config;
        }
    }
}
