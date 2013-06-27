using System;

namespace GPSoft.Tools.ReaderMe.module.config
{
    /// <summary>
    /// 文件信息
    /// </summary>
    [Serializable]
    public sealed class FileConfig
    {
        /// <summary>
        /// 获取或设置书签
        /// </summary>
        public int BookMark { get; set; }

        /// <summary>
        /// 获取或设置文件编码信息
        /// </summary>
        public string Encode { get; set; }

        /// <summary>
        /// 获取或设置文件MD5标志
        /// </summary>
        public string MD5 { get; set; }

        /// <summary>
        /// 获取或设置文本路径
        /// </summary>
        public string Path { get; set; }
    }
}
