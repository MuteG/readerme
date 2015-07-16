using System;
using System.Xml.Serialization;

namespace GPStudio.Tools.ReaderMe.Module.Config
{
    /// <summary>
    /// 书签
    /// </summary>
    [Serializable]
    public class Bookmark
    {
        /// <summary>
        /// 获取或设置书签摘要
        /// </summary>
        [XmlAttribute("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// 获取或设置书签位置
        /// </summary>
        [XmlAttribute("position")]
        public int Position { get; set; }
    }
}
