using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GPSoft.Tools.ReaderMe.common
{
    public static class Const
    {
        /// <summary>
        /// 程序根目录
        /// </summary>
        public static readonly string PATH_ROOT_FOLDER;

        static Const()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            PATH_ROOT_FOLDER = Path.Combine(dir, "ReaderMe");
        }
    }
}
