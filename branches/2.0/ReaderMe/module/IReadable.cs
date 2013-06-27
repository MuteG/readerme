namespace GPSoft.Tools.ReaderMe.module
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public delegate void FileErrorEventHandler(object sender, FileErrorEventArgs args);

    /// <summary>
    /// 文件基本操作接口
    /// </summary>
    public interface IReadable
    {
        /// <summary>
        /// 当对文件的操作发生错误时触发
        /// </summary>
        event FileErrorEventHandler Error;

        /// <summary>
        /// 上一个操作是否发生了错误
        /// </summary>
        bool HasError { get; }

        /// <summary>
        /// 读入当前文件
        /// </summary>
        void Load();

        void Seek(int index);
    }
}
