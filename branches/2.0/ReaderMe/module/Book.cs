namespace GPSoft.Tools.ReaderMe.module
{
    using System;
    using System.Collections.Generic;
    using System.Text;
using System.Drawing;

    public class Book
    {
        private IReadable _File;

        /// <summary>
        /// 获取或设置当前图书的最后阅读时间
        /// </summary>
        public DateTime LastReadTime { get; set; }

        /// <summary>
        /// 获取当前图书的总字数
        /// </summary>
        public int Length
        {
            get { return 0; }
        }

        private int _Position = 0;

        /// <summary>
        /// 获取或设置当前的阅读位置
        /// </summary>
        public int Position
        {
            get { return this._Position; }
            set
            {
                _Position = value;
                if (null != _File)
                {
                    _File.Seek(value);
                }
            }
        }
        
        public Book(IReadable file)
        {
            this._File = file;
        }

        /// <summary>
        /// 使阅读位置前进一行
        /// </summary>
        /// <returns></returns>
        public string NextLine()
        {
            string text = string.Empty;
            //TODO 前进一行
            return text;
        }
    }
}
