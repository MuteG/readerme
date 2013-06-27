namespace GPSoft.Tools.ReaderMe.module
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// 读者
    /// </summary>
    public class Reader
    {
        /// <summary>
        /// 获取或设置读者的用户名
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// 获取所有私人书签
        /// </summary>
        [XmlArray("bookmarks"), XmlArrayItem("mark")]
        public List<Bookmark> Marks { get; set; }

        public Reader()
        {
            this.Name = "ReaderMe";
            this.Marks = new List<Bookmark>();
        }
    }
}
