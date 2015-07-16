namespace GPStudio.Tools.ReaderMe.Module
{
    using System;
    using System.Globalization;

    /// <summary>
    /// 包含错误事件的数据
    /// </summary>
    public sealed class FileErrorEventArgs : EventArgs
    {
        /// <summary>
        /// 获取错误级别
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// 获取错误类别
        /// </summary>
        public int Kind { get; private set; }

        /// <summary>
        /// 获取错误序号
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// 获取错误代码
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 获取或设置错误提示信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 获取或设置是否停止当前处理
        /// </summary>
        public bool IsCancel { get; set; }

        public FileErrorEventArgs(string code)
        {
            this.Level = int.Parse(code.Substring(0, 2), NumberStyles.Integer);
            this.Kind = int.Parse(code.Substring(2, 2), NumberStyles.Integer);
            this.Number = int.Parse(code.Substring(4, 4), NumberStyles.Integer);
            this.Code = code;
            this.Message = string.Empty;
            this.IsCancel = false;
        }
    }
}
