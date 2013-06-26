using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace GPSoft.Tools.ReaderMe.Model.config
{
    [Serializable]
    public sealed class Config
    {
        /// <summary>
        /// 获取或设置全局设置
        /// </summary>
        public GeneralConfig General { get; set; }

        /// <summary>
        /// 获取或者设置文本文件信息记录列表
        /// </summary>
        [XmlArray("Files"), XmlArrayItem("File")]
        public List<FileInfo> FileInfoList { get; set; }

        /// <summary>
        /// 获取或设置窗体设置列表
        /// <para>每种窗体模式一套设置</para>
        /// </summary>
        [XmlArray("Windows"), XmlArrayItem("Window")]
        public List<WindowConfig> WindowConfigList { get; set; }
    }
}
