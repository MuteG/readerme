namespace GPSoft.Tools.ReaderMe.Common
{
    using System.IO;
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
                using (StreamReader stream = new StreamReader(path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializableObject = serializer.Deserialize(stream) as T;
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
            using (StreamWriter textWriter = new StreamWriter(path, false))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(serializableObject.GetType());
                xmlSerializer.Serialize(textWriter, serializableObject);
            }
        }
    }
}
