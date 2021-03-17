using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using ReaderMe.Module.Entity;

namespace ReaderMe.Module.Config
{
    /// <summary>
    /// 文件配置
    /// </summary>
    [Serializable]
    public sealed class FileConfig
    {
        /// <summary>
        /// 获取或设置书名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置书签
        /// </summary>
        [XmlArray("Bookmarks"), XmlArrayItem("Bookmark")]
        public List<Bookmark> Bookmarks { get; set; }

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
