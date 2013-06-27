namespace GPSoft.Tools.ReaderMe.module
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// 书签
    /// </summary>
    [Serializable]
    public class Bookmark
    {
        /// <summary>
        /// 获取或设置书籍标识
        /// </summary>
        [XmlAttribute("bookid")]
        public string BookID { get; set; }

        /// <summary>
        /// 获取或设置书签位置
        /// </summary>
        [XmlAttribute("position")]
        public int Position { get; set; }
    }
}
