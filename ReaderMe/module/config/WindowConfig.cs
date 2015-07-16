using System;
using System.Xml.Serialization;

namespace GPStudio.Tools.ReaderMe.module.config
{
    [Serializable]
    public sealed class WindowConfig
    {
        /// <summary>
        /// 获取或设置窗体模式
        /// </summary>
        [XmlAttribute("mode")]
        public WindowMode Mode { get; set; }
        /// <summary>
        /// 获取或者设置主窗体左上角Y坐标
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// 获取或者设置主窗体左上角X坐标
        /// </summary>
        public int Left { get; set; }

        /// <summary>
        /// 获取或者设置主窗体宽度
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 获取或者设置主窗体高度
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 获取或者设置自动滚动的时间间隔（秒）
        /// </summary>
        public int AutoScrollInterval { get; set; }

        /// <summary>
        /// 获取或者设置自动滚动的距离（行数）
        /// </summary>
        public int AutoScrollRows { get; set; }

    }
}
