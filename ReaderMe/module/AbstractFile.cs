namespace GPStudio.Tools.ReaderMe.Module
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using GPStudio.Tools.ReaderMe.common;
    using GPStudio.Tools.ReaderMe.Helper;
    using System.Drawing;

    public class AbstractFile : IReadable
    {
        /// <summary>
        /// 获取当前文件的MD5值
        /// </summary>
        public string MD5 { get; private set; }

        /// <summary>
        /// 获取或设置当前文件的路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 获取或设置当前文件的编码
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// 获取或设置当前文件的字体
        /// </summary>
        public Font Font { get; set; }

        protected string _Text = string.Empty;

        /// <summary>
        /// 获取或设置当前阅读区块内的文字
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// 获取当前图书的总字数
        /// </summary>
        public int Length
        {
            get { return _Text.Length; }
        }

        private int _Position = 0;

        /// <summary>
        /// 获取或设置当前的阅读位置
        /// </summary>
        public int Position
        {
            get { return this._Position; }
            set { Seek(value); }
        }

        /// <summary>
        /// 获取或设置阅读区块的总长度
        /// </summary>
        public int BlockLength { get; set; }

        #region IFile 成员

        public event FileErrorEventHandler Error;

        public bool HasError { get; private set; }

        protected void OnError(string errorCode)
        {
            FileErrorEventArgs args = new FileErrorEventArgs(errorCode);
            args.Message = ErrorManager.GetMessage(errorCode);
            if (null != Error)
            {
                foreach (Delegate item in Error.GetInvocationList())
                {
                    item.DynamicInvoke(this, args);
                    if (args.IsCancel)
                    {
                        break;
                    }
                }
            }
            this.HasError = true;
        }

        public void Load()
        {
            this.HasError = false;
            this.MD5 = FileHelper.CalcFileMD5(Path);
            this._Text = File.ReadAllText(this.Path, this.Encoding);
            this.Position = 0;
        }

        public void Seek(int index)
        {
            this._Position = index;
            this.Text = this._Text.Substring(index, this.BlockLength);
        }

        #endregion

        public override int GetHashCode()
        {
            return this.MD5.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is AbstractFile &&
                0 == string.Compare((obj as AbstractFile).MD5, this.MD5, true);
        }
    }
}
