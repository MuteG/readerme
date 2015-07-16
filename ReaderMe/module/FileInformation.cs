using System;
using System.Text;
using GPStudio.Tools.ReaderMe.common;
using GPStudio.Tools.ReaderMe.Helper;

namespace GPStudio.Tools.ReaderMe.module
{
    public class FileInformation
    {
        #region 属性
        private string _MD5;

        /// <summary>
        /// 获得或设置文件MD5标志
        /// </summary>
        public string MD5
        {
            get { return _MD5; }
            set { _MD5 = value; }
        }

        private string _Path;

        /// <summary>
        /// 获得或设置文本路径
        /// </summary>
        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }

        private int _BookMark;

        /// <summary>
        /// 获得或设置书签
        /// </summary>
        public int BookMark
        {
            get
            {
                return _BookMark < 0 ? 0 : _BookMark;
            }
            set
            {
                if (value < 0)
                {
                    _BookMark = 0;
                }
                else
                {
                    _BookMark = value;
                }
            }
        }

        private string _Encode;

        public string Encode
        {
            get
            {
                if (string.IsNullOrEmpty(_Encode))
                {
                    _Encode = Encoding.Default.WebName;
                }
                return _Encode;
            }
            set
            {
                _Encode = value;
                if (string.IsNullOrEmpty(_Encode))
                {
                    _Encode = Encoding.Default.WebName;
                }
            }
        }

        private string _UpdateTime;

        public string UpdateTime
        {
            get
            {
                if (string.IsNullOrEmpty(_UpdateTime))
                {
                    _UpdateTime = DateTime.Now.ToString(Constants.FORMAT_FILEINFO_UPDATETIME);
                }
                return _UpdateTime;
            }
            set { _UpdateTime = value; }
        }

        #endregion

        public FileInformation()
        {
        }

        public FileInformation(FileInformation fileInfo)
        {
            this.BookMark = fileInfo.BookMark;
            this.Path = fileInfo.Path;
            this.MD5 = fileInfo.MD5;
            this.Encode = fileInfo.Encode;
            this.UpdateTime = fileInfo.UpdateTime;
        }

        public FileInformation(string filePath)
        {
            this.Path = filePath;
            this.BookMark = 0;
            this.MD5 = FileHelper.CalcFileMD5(filePath);
            this.Encode = CommonFunc.GetEncoding(filePath).WebName;
            this.UpdateTime = DateTime.Now.ToString(Constants.FORMAT_FILEINFO_UPDATETIME);
        }

        public override int GetHashCode()
        {
            return this.MD5.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is FileInformation &&
                0 == string.Compare((obj as FileInformation).MD5, this.MD5, true);
        }
    }
        
}
