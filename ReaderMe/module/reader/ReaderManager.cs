using System.Collections.Generic;
using System.IO;
using GPStudio.Tools.ReaderMe.common;

namespace GPStudio.Tools.ReaderMe.Module.reader
{
    public static class ReaderManager
    {
        private static List<Reader> readers = null;

        /// <summary>
        /// 获取读者列表
        /// </summary>
        public static List<Reader> Readers
        {
            get
            {
                if (null == readers)
                {
                    readers = GetReaders();
                }
                return readers;
            }
        }

        private static List<Reader> GetReaders()
        {
            List<Reader> result = new List<Reader>();
            string[] readerFolders = Directory.GetDirectories(Const.PATH_ROOT_FOLDER);
            foreach (string folder in readerFolders)
            {
                readers.Add(new Reader
                {
                    Name = folder
                });
            }
            return result;
        }

        private static Reader currentReader;

        /// <summary>
        /// 获取或设置当前读者
        /// </summary>
        public static Reader CurrentReader
        {
            get { return currentReader; }
            set { SetCurrentReader(value); }
        }

        private static void SetCurrentReader(Reader value)
        {
            currentReader = value;
            if (!readers.Contains(value))
            {
                readers.Add(value);
                string readerFolder = Path.Combine(Const.PATH_ROOT_FOLDER, value.Name);
                Directory.CreateDirectory(readerFolder);
            }
        }
    }
}
