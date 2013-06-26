namespace GPSoft.Tools.ReaderMe.Common
{
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    /// <summary>
    /// 提供XML序列化/反序列化的基本操作方法
    /// </summary>
    public static class ObjectXMLSerializer<T> where T : class
    {
        /// <summary>
        /// 反序列化一个对象
        /// </summary>
        /// <param name="serializableObject"></param>
        /// <param name="path"></param>
        public static void Load(ref T serializableObject, string path)
        {
            if (File.Exists(path))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (XmlReader reader = XmlReader.Create(stream))
                    {
                        serializableObject = xs.Deserialize(reader) as T;
                    }
                }
            }
        }

        /// <summary>
        /// 序列化一个对象
        /// </summary>
        /// <param name="serializableObject"></param>
        /// <param name="path"></param>
        public static void Save(object serializableObject, string path)
        {
           XmlSerializer xs = new XmlSerializer(typeof(T));
           using (FileStream stream = new FileStream(path, FileMode.Truncate))
            {
                XmlWriterSettings settings = new XmlWriterSettings()
                {
                    Indent = true
                };
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    xs.Serialize(writer, serializableObject);
                }
            }
        }
    }
}
