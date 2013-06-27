using System;

namespace GPSoft.Tools.ReaderMe.module.config
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
        /// <para>范围：0～100。0为不透明，100为完全透明。</para>
        /// </summary>
        public int Opacity { get; set; }

        /// <summary>
        /// 获取或者设置是否自动换行
        /// </summary>
        public bool WordWrap { get; set; }
    }
}
