using System;

namespace GPSoft.Tools.ReaderMe.Model.config
{
    [Serializable]
    public sealed class GeneralConfig
    {
        /// <summary>
        /// 获取或者设置阅读窗口背景色
        /// </summary>
        public int BackColor { get; set; }

        /// <summary>
        /// 获取或者设置文字字体
        /// </summary>
        public string FontName { get; set; }

        /// <summary>
        /// 获取或者设置文字大小
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// 获取或者设置透明度
        /// </summary>
        public int Opacity { get; set; }

        /// <summary>
        /// 获取或者设置是否自动换行
        /// </summary>
        public int WordWrap { get; set; }
    }
}
